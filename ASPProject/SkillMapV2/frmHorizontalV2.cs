using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ASPData.ASPDAO;

namespace ASPProject.AppTemplateSkillMapV2
{
    /// <summary>
    /// Horizontal multi-type (LineSX / KTV / VPSX / …) — 1 form, Mode load từ ASPSkillMapTypeConfig.
    /// Admin: Mode + Date + Import to Date + Skill Date + Skill Total + Export.
    /// Non-admin: type default (AllowNonAdmin) + Scope Line.
    /// </summary>
    public class frmHorizontalV2 : frmSkillMapBase
    {
        public const int SkillThresholdLine = 75;
        public const int SkillThresholdKtv = 100;
        public const string SkillTypeLineSx = "LineSX";
        public const string SkillTypeKtv = "KTV";

        private readonly SkillMapV2DAO _dao;
        private readonly string _username;
        private readonly bool _isAdmin;

        private string _currentSkillType = SkillTypeLineSx;
        private List<TypeConfigItem> _typeConfigs = new List<TypeConfigItem>();
        private TypeConfigItem _currentTypeConfig;

        /// <summary>Master skill theo mode hiện tại (từ ASPSkillMapList, không hardcode).</summary>
        private List<SkillListItem> _skills = new List<SkillListItem>();
        /// <summary>Cặp cột Actual/Target đã resolve khớp DataTable Horizontal.</summary>
        private List<(string ColActual, string ColTarget, string SkillKey)> _skillColumns =
            new List<(string, string, string)>();

        private sealed class TypeConfigItem
        {
            public string SkillType { get; set; }
            public string DisplayName { get; set; }
            public string LineMatchMode { get; set; }
            public string LineMatchValue { get; set; }
            public int CountThreshold { get; set; } = 75;
            public bool CountExact { get; set; }
            public bool AllowNonAdmin { get; set; }
            public bool IsDefaultNonAdmin { get; set; }
            public override string ToString() => string.IsNullOrEmpty(DisplayName) ? SkillType : DisplayName;

            public bool MatchesLine(string lineId)
            {
                if (string.IsNullOrWhiteSpace(lineId) || string.IsNullOrWhiteSpace(LineMatchValue))
                    return false;

                string mode = (LineMatchMode ?? "EXACT").Trim().ToUpperInvariant();
                string targetVal = LineMatchValue.Trim();
                string inputLine = lineId.Trim();

                switch (mode)
                {
                    case "EXACT":
                        return string.Equals(inputLine, targetVal, StringComparison.OrdinalIgnoreCase);

                    case "PREFIX":
                        return inputLine.StartsWith(targetVal, StringComparison.OrdinalIgnoreCase);

                    case "CONTAINS":
                        return inputLine.IndexOf(targetVal, StringComparison.OrdinalIgnoreCase) >= 0;

                    case "IN":
                        var items = targetVal.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        return items.Any(it => string.Equals(inputLine, it.Trim(), StringComparison.OrdinalIgnoreCase));

                    default:
                        return false;
                }
            }
        }

        private sealed class SkillListItem
        {
            public string SkillId { get; set; }
            public string SkillName { get; set; }
            public string SkillType { get; set; }
            public string ColActual => string.IsNullOrEmpty(SkillName) ? SkillId : (SkillId + "-" + SkillName);
            public string ColTarget => "Target " + (SkillName ?? "");
        }

        private GridControl gridControlHorizontal;
        private GridView gridViewHorizontal;

        private LabelControl lblMode;
        private ComboBoxEdit cboMode;
        private LabelControl lblLineFilter;
        private ComboBoxEdit cboLineFilter;
        private LabelControl labelControl1;
        private DateEdit dateEditDate;
        private SimpleButton btnImportToDate;
        private SimpleButton btnExportMonthYear;
        private SimpleButton btnExportTotalSkillMonth;
        private SimpleButton btnExportExcelHorizontal;

        /// <param name="username">Login hiện tại</param>
        /// <param name="isAdmin">true = full types + toolbar; false = line-scoped default type</param>
        /// <param name="initialSkillType">SkillType ban đầu (vd LineSX, KTV, VPSX). null = default.</param>
        public frmHorizontalV2(string username, bool isAdmin, string initialSkillType = null)
        {
            _dao = new SkillMapV2DAO(constring);
            _username = username ?? "";
            _isAdmin = isAdmin;
            LoadTypeConfigs();
            _currentSkillType = ResolveInitialSkillType(initialSkillType);
            _currentTypeConfig = FindTypeConfig(_currentSkillType);
            BuildUI();
            SetupGridView();
            LoadAll();
        }

        /// <summary>Tương thích cũ: isKTV true → SkillType KTV.</summary>
        public frmHorizontalV2(string username, bool isAdmin, bool isKTV)
            : this(username, isAdmin, isKTV ? SkillTypeKtv : SkillTypeLineSx)
        {
        }

        private int Threshold => _currentTypeConfig?.CountThreshold
            ?? (string.Equals(_currentSkillType, SkillTypeKtv, StringComparison.OrdinalIgnoreCase)
                ? SkillThresholdKtv
                : SkillThresholdLine);

        private bool Exact => _currentTypeConfig?.CountExact
            ?? string.Equals(_currentSkillType, SkillTypeKtv, StringComparison.OrdinalIgnoreCase);

        private string CurrentSkillType => _currentSkillType;

        private void LoadTypeConfigs()
        {
            _typeConfigs = new List<TypeConfigItem>();
            try
            {
                DataTable dt = _dao.GetSkillMapTypeConfigs(activeOnly: true);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        _typeConfigs.Add(new TypeConfigItem
                        {
                            SkillType = ColStr(r, "SkillType"),
                            DisplayName = ColStr(r, "DisplayName"),
                            LineMatchMode = ColStr(r, "LineMatchMode"),
                            LineMatchValue = ColStr(r, "LineMatchValue"),
                            CountThreshold = ColInt(r, "CountThreshold", 75),
                            CountExact = ColBool(r, "CountExact"),
                            AllowNonAdmin = ColBool(r, "AllowNonAdmin"),
                            IsDefaultNonAdmin = ColBool(r, "IsDefaultNonAdmin")
                        });
                    }
                }
            }
            catch { /* fallback below */ }

            if (_typeConfigs.Count == 0)
            {
                // Chưa deploy ASPSkillMapTypeConfig → lấy distinct type từ list + default rule
                try
                {
                    DataTable types = _dao.GetSkillMapTypesFromList();
                    if (types != null)
                    {
                        foreach (DataRow r in types.Rows)
                        {
                            string t = ColStr(r, "SkillType");
                            if (string.IsNullOrEmpty(t)) continue;
                            bool isKtv = string.Equals(t, SkillTypeKtv, StringComparison.OrdinalIgnoreCase);
                            _typeConfigs.Add(new TypeConfigItem
                            {
                                SkillType = t,
                                DisplayName = t == SkillTypeLineSx ? "Line" : t,
                                LineMatchMode = isKtv ? "EXACT" : "DEFAULT",
                                LineMatchValue = isKtv ? "KTV" : "",
                                CountThreshold = isKtv ? 100 : 75,
                                CountExact = isKtv,
                                AllowNonAdmin = string.Equals(t, SkillTypeLineSx, StringComparison.OrdinalIgnoreCase),
                                IsDefaultNonAdmin = string.Equals(t, SkillTypeLineSx, StringComparison.OrdinalIgnoreCase)
                            });
                        }
                    }
                }
                catch { /* ignore */ }
            }

            // Luôn đảm bảo có cấu hình LineSX chuẩn trong bộ nhớ
            if (!_typeConfigs.Any(c => string.Equals(c.SkillType, SkillTypeLineSx, StringComparison.OrdinalIgnoreCase)))
            {
                _typeConfigs.Add(new TypeConfigItem
                {
                    SkillType = SkillTypeLineSx,
                    DisplayName = "Line",
                    LineMatchMode = "DEFAULT",
                    LineMatchValue = "",
                    CountThreshold = 75,
                    AllowNonAdmin = true,
                    IsDefaultNonAdmin = true
                });
            }

            // Luôn đảm bảo có cấu hình KTV chuẩn trong bộ nhớ
            if (!_typeConfigs.Any(c => string.Equals(c.SkillType, SkillTypeKtv, StringComparison.OrdinalIgnoreCase)))
            {
                _typeConfigs.Add(new TypeConfigItem
                {
                    SkillType = SkillTypeKtv,
                    DisplayName = "KTV",
                    LineMatchMode = "CONTAINS",
                    LineMatchValue = "KTV",
                    CountThreshold = 100,
                    CountExact = true,
                    AllowNonAdmin = true,
                    IsDefaultNonAdmin = false
                });
            }
        }

        private string ResolveInitialSkillType(string preferred, string userLineId = null)
        {

            if (!string.IsNullOrWhiteSpace(preferred) &&
                _typeConfigs.Any(c => string.Equals(c.SkillType, preferred, StringComparison.OrdinalIgnoreCase)))
                return preferred.Trim();

            if (!string.IsNullOrWhiteSpace(userLineId))
            {
                // Ưu tiên nhận diện KTV trực tiếp từ LineID (không phụ thuộc thứ tự config DB)
                if (userLineId.IndexOf("KTV", StringComparison.OrdinalIgnoreCase) >= 0)
                    return SkillTypeKtv;

                var matched = _typeConfigs.FirstOrDefault(c => c.MatchesLine(userLineId));
                if (matched != null)
                    return matched.SkillType;
            }

            if (!_isAdmin)
            {
                var def = _typeConfigs.FirstOrDefault(c => c.IsDefaultNonAdmin)
                          ?? _typeConfigs.FirstOrDefault();
                return def?.SkillType ?? SkillTypeLineSx;
            }

            return _typeConfigs.FirstOrDefault()?.SkillType ?? SkillTypeLineSx;
        }

        private TypeConfigItem FindTypeConfig(string skillType)
            => _typeConfigs.FirstOrDefault(c =>
                   string.Equals(c.SkillType, skillType, StringComparison.OrdinalIgnoreCase));

        private static string ColStr(DataRow r, string col)
            => r.Table.Columns.Contains(col) ? (r[col]?.ToString() ?? "").Trim() : "";

        private static int ColInt(DataRow r, string col, int def)
        {
            if (!r.Table.Columns.Contains(col) || r[col] == null || r[col] == DBNull.Value) return def;
            return int.TryParse(r[col].ToString(), out int v) ? v : def;
        }

        private static bool ColBool(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col) || r[col] == null || r[col] == DBNull.Value) return false;
            if (r[col] is bool b) return b;
            if (r[col] is byte by) return by != 0;
            if (int.TryParse(r[col].ToString(), out int i)) return i != 0;
            return string.Equals(r[col].ToString(), "true", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>Đổi SkillType (admin). Non-admin bỏ qua.</summary>
        public void SetMode(string skillType)
        {
            if (!_isAdmin) return;
            if (string.IsNullOrWhiteSpace(skillType)) return;
            if (!_typeConfigs.Any(c => string.Equals(c.SkillType, skillType, StringComparison.OrdinalIgnoreCase)))
                return;

            _currentSkillType = skillType.Trim();
            _currentTypeConfig = FindTypeConfig(_currentSkillType);
            SyncModeCombo();
            ReloadData();
        }

        /// <summary>Tương thích cũ.</summary>
        public void SetMode(bool isKTV) => SetMode(isKTV ? SkillTypeKtv : SkillTypeLineSx);

        private void SyncModeCombo()
        {
            if (cboMode == null || !_isAdmin) return;
            cboMode.SelectedIndexChanged -= CboMode_SelectedIndexChanged;
            for (int i = 0; i < cboMode.Properties.Items.Count; i++)
            {
                if (cboMode.Properties.Items[i] is TypeConfigItem tc &&
                    string.Equals(tc.SkillType, _currentSkillType, StringComparison.OrdinalIgnoreCase))
                {
                    cboMode.SelectedIndex = i;
                    break;
                }
            }
            cboMode.SelectedIndexChanged += CboMode_SelectedIndexChanged;
        }

        private void LoadSkillDefinitions()
        {
            _skills = new List<SkillListItem>();
            try
            {
                DataTable dt = _dao.GetSkillMapList(CurrentSkillType);
                if (dt == null) return;
                foreach (DataRow r in dt.Rows)
                {
                    _skills.Add(new SkillListItem
                    {
                        SkillId = r.Table.Columns.Contains("SkillID") ? (r["SkillID"]?.ToString() ?? "").Trim() : "",
                        SkillName = r.Table.Columns.Contains("SkillName") ? (r["SkillName"]?.ToString() ?? "").Trim() : "",
                        SkillType = r.Table.Columns.Contains("SkillType") ? (r["SkillType"]?.ToString() ?? "").Trim() : ""
                    });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Không load được ASPSkillMapList: " + ex.Message,
                    "Skill Map",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Map master skill → tên cột thật trên grid (giữ convention SkillID-Name / Target Name;
        /// match không phân biệt hoa thường + fallback theo SkillID-).
        /// </summary>
        private void ResolveSkillColumns(DataTable dt)
        {
            _skillColumns = new List<(string, string, string)>();
            if (dt == null || _skills == null) return;

            foreach (var sk in _skills)
            {
                if (string.IsNullOrEmpty(sk.SkillId)) continue;
                string colA = FindColumn(dt, sk.ColActual)
                              ?? FindColumnStartsWith(dt, sk.SkillId + "-")
                              ?? FindColumn(dt, sk.SkillId);
                string colT = FindColumn(dt, sk.ColTarget)
                              ?? FindColumn(dt, "Target" + sk.SkillName)
                              ?? FindColumn(dt, "Target " + sk.SkillId);
                if (colA == null && colT == null) continue;
                _skillColumns.Add((colA, colT, sk.ColActual));
            }
        }

        private static string FindColumn(DataTable dt, string name)
        {
            if (dt == null || string.IsNullOrEmpty(name)) return null;
            if (dt.Columns.Contains(name)) return name;
            foreach (DataColumn c in dt.Columns)
            {
                if (string.Equals(c.ColumnName, name, StringComparison.OrdinalIgnoreCase))
                    return c.ColumnName;
            }
            return null;
        }

        private static string FindColumnStartsWith(DataTable dt, string prefix)
        {
            if (dt == null || string.IsNullOrEmpty(prefix)) return null;
            foreach (DataColumn c in dt.Columns)
            {
                if (c.ColumnName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    return c.ColumnName;
            }
            return null;
        }

        private void BuildUI()
        {
            Text = "Skill Map Horizontal";
            Width = 1200;
            Height = 700;

            var pnl = new Panel { Dock = DockStyle.Top, Height = 48 };

            // Left: Mode (admin) + Date (admin)
            lblMode = new LabelControl
            {
                Text = "Mode:",
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 40,
                Dock = DockStyle.Left,
                Padding = new Padding(8, 14, 0, 0)
            };
            cboMode = new ComboBoxEdit
            {
                Width = 120,
                Dock = DockStyle.Left,
                Properties = { TextEditStyle = TextEditStyles.DisableTextEditor }
            };
            // Mode = toàn bộ SkillType active từ config (LineSX, KTV, VPSX, …)
            foreach (var tc in _typeConfigs)
                cboMode.Properties.Items.Add(tc);
            int idx = _typeConfigs.FindIndex(c =>
                string.Equals(c.SkillType, _currentSkillType, StringComparison.OrdinalIgnoreCase));
            cboMode.SelectedIndex = idx >= 0 ? idx : 0;
            cboMode.SelectedIndexChanged += CboMode_SelectedIndexChanged;

            labelControl1 = new LabelControl
            {
                Text = "Date:",
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 40,
                Dock = DockStyle.Left,
                Padding = new Padding(8, 14, 0, 0)
            };
            dateEditDate = new DateEdit
            {
                Width = 120,
                Dock = DockStyle.Left
            };

            lblLineFilter = new LabelControl
            {
                Text = "Line:",
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 35,
                Dock = DockStyle.Left,
                Padding = new Padding(8, 14, 0, 0),
                Visible = false
            };
            cboLineFilter = new ComboBoxEdit
            {
                Width = 110,
                Dock = DockStyle.Left,
                Visible = false,
                Properties = { TextEditStyle = TextEditStyles.DisableTextEditor }
            };
            cboLineFilter.SelectedIndexChanged += CboLineFilter_SelectedIndexChanged;

            // Right: V1 buttons (Import to Date, Skill Date, Skill Total, Export)
            btnExportExcelHorizontal = new SimpleButton { Text = "Export Excel", Width = 100, Dock = DockStyle.Right };
            btnExportTotalSkillMonth = new SimpleButton { Text = "Skill Total", Width = 90, Dock = DockStyle.Right };
            btnExportMonthYear = new SimpleButton { Text = "Skill Date", Width = 90, Dock = DockStyle.Right };
            btnImportToDate = new SimpleButton { Text = "Import to Date", Width = 110, Dock = DockStyle.Right };

            btnExportExcelHorizontal.Click += (s, e) =>
                ExportToXlsx(gridViewHorizontal, "Export_Horizontal_" + (_currentSkillType ?? "Data"));
            btnImportToDate.Click += BtnImportToDate_Click;
            btnExportMonthYear.Click += (s, e) => new frmSkillDateV2().ShowDialog();
            btnExportTotalSkillMonth.Click += (s, e) => new frmSkillTotalV2().ShowDialog();

            // Dock Right: add Export first so it sits at the far right
            pnl.Controls.Add(btnExportExcelHorizontal);
            pnl.Controls.Add(btnExportTotalSkillMonth);
            pnl.Controls.Add(btnExportMonthYear);
            pnl.Controls.Add(btnImportToDate);

            // Dock Left: last added = leftmost
            // Thứ tự hiển thị mong muốn từ trái qua phải:
            // Admin: lblMode | cboMode | lblLineFilter | cboLineFilter | labelControl1 | dateEditDate
            // Non-admin: lblLineFilter | cboLineFilter
            if (_isAdmin)
            {
                pnl.Controls.Add(dateEditDate);
                pnl.Controls.Add(labelControl1);
            }

            pnl.Controls.Add(cboLineFilter);
            pnl.Controls.Add(lblLineFilter);

            if (_isAdmin)
            {
                pnl.Controls.Add(cboMode);
                pnl.Controls.Add(lblMode);
            }

            if (!_isAdmin)
                HideAdminOnlyButtons();

            gridControlHorizontal = new GridControl { Dock = DockStyle.Fill };
            gridViewHorizontal = new GridView();
            gridControlHorizontal.MainView = gridViewHorizontal;

            Controls.Add(gridControlHorizontal);
            Controls.Add(pnl);
        }

        /// <summary>Non-admin: giống V1 hide snapshot controls; vẫn cho Export line của mình.</summary>
        private void HideAdminOnlyButtons()
        {
            if (labelControl1 != null) labelControl1.Visible = false;
            if (dateEditDate != null) dateEditDate.Visible = false;
            if (btnImportToDate != null) btnImportToDate.Visible = false;
            if (btnExportMonthYear != null) btnExportMonthYear.Visible = false;
            if (btnExportTotalSkillMonth != null) btnExportTotalSkillMonth.Visible = false;
            if (lblMode != null) lblMode.Visible = false;
            if (cboMode != null) cboMode.Visible = false;
        }

        private void CboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isAdmin) return;
            if (!(cboMode.SelectedItem is TypeConfigItem tc)) return;
            if (string.Equals(tc.SkillType, _currentSkillType, StringComparison.OrdinalIgnoreCase)) return;
            _currentSkillType = tc.SkillType;
            _currentTypeConfig = tc;
            ReloadData();
        }

        private void SetupGridView()
        {
            gridViewHorizontal.OptionsView.ColumnAutoWidth = false;
            gridViewHorizontal.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewHorizontal.HorzScrollVisibility = ScrollVisibility.Auto;
            gridViewHorizontal.OptionsView.ShowGroupPanel = false;
            gridViewHorizontal.OptionsView.ShowAutoFilterRow = true;
            gridViewHorizontal.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            gridViewHorizontal.Appearance.HeaderPanel.TextOptions.WordWrap = WordWrap.Wrap;
            gridViewHorizontal.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True;
            gridViewHorizontal.CustomDrawColumnHeader += GridViewHorizontal_CustomDrawColumnHeader;
            gridViewHorizontal.RowCellStyle += gridViewHorizontal_RowCellStyle;
        }

        private void LoadAll()
        {
            if (_isAdmin && dateEditDate != null)
                SetupDateEdit(dateEditDate, "dd-MM-yyyy", VistaCalendarViewStyle.MonthView);
            ReloadData();
        }

        private void ReloadData()
        {
            Show_Data();
        }

        private void Show_Data()
        {
            try
            {
                DataTable dt;
                string line = null;
                if (!_isAdmin)
                {
                    line = _dao.GetLineId(_username);
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        gridControlHorizontal.DataSource = null;
                        gridControlHorizontal.RefreshDataSource();
                        PopulateLineFilter(null);
                        XtraMessageBox.Show(
                            $"Không tìm thấy LineID cho user '{_username}'. Kiểm tra sp_ShowLineId.",
                            "Skill Map Horizontal",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    // Tự động nhận diện SkillType từ LineID qua cấu hình DB hoặc từ khóa KTV
                    _currentSkillType = ResolveInitialSkillType(null, line);
                    _currentTypeConfig = FindTypeConfig(_currentSkillType);

                    bool isKtv = string.Equals(_currentSkillType, SkillTypeKtv, StringComparison.OrdinalIgnoreCase) ||
                                 line.IndexOf("KTV", StringComparison.OrdinalIgnoreCase) >= 0;

                    if (isKtv)
                    {
                        _currentSkillType = SkillTypeKtv;
                        _currentTypeConfig = FindTypeConfig(SkillTypeKtv);
                        // Tài khoản có LineID là KTV: Xem toàn bộ danh sách Kỹ Thuật Viên (Scope = 'All')
                        dt = _dao.GetHorizontalData(SkillTypeKtv, "All", null);
                    }
                    else
                    {
                        // Tài khoản Line sản xuất: Xem theo Line và các Line con trực thuộc (Scope = 'Line')
                        dt = _dao.GetHorizontalData(CurrentSkillType, "Line", line);
                    }
                }
                if (_username == "KTV")
                {
                    dt = _dao.GetHorizontalData("KTV", "All", "KTV");
                }
                else
                {
                    _currentTypeConfig = FindTypeConfig(_currentSkillType) ?? _currentTypeConfig;
                    dt = _dao.GetHorizontalData(CurrentSkillType, "All", null);
                }

                if (dt == null || dt.Rows.Count <= 0)
                {
                    gridControlHorizontal.DataSource = null;
                    gridControlHorizontal.RefreshDataSource();
                    PopulateLineFilter(null);
                    XtraMessageBox.Show(
                        $"Không có dữ liệu Skill Map cho chế độ '{_currentSkillType}'" + (!string.IsNullOrEmpty(line) ? $" (Line: '{line}')" : "") + ".",
                        "Skill Map",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Pipeline: master skill → resolve cột → recalc → bind
                LoadSkillDefinitions();
                ResolveSkillColumns(dt);
                EnsureComputedColumns(dt);
                RecalcRowMetrics(dt);
                if (_isAdmin)
                    CalculateTotalsByLine(dt);

                gridControlHorizontal.DataSource = dt;
                gridViewHorizontal.PopulateColumns();
                ApplyColumnPresentation();
                gridViewHorizontal.BestFitColumns();
                Display_TotalRecord(gridViewHorizontal, "Tên");

                // Cập nhật bộ lọc Line con (tự động hiện khi có >= 2 line con)
                PopulateLineFilter(dt);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Show Data : " + ex.Message, "Error Show Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateLineFilter(DataTable dt)
        {
            if (cboLineFilter == null || lblLineFilter == null) return;

            if (dt == null || !dt.Columns.Contains("Line"))
            {
                lblLineFilter.Visible = false;
                cboLineFilter.Visible = false;
                return;
            }

            var distinctLines = dt.AsEnumerable()
                .Select(r => r["Line"]?.ToString()?.Trim())
                .Where(l => !string.IsNullOrEmpty(l))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(l => l)
                .ToList();

            // Nếu chỉ có <= 1 Line (ví dụ KTV hoặc Line đơn lẻ) => ẩn bộ lọc
            if (distinctLines.Count <= 1 || string.Equals(_currentSkillType, SkillTypeKtv, StringComparison.OrdinalIgnoreCase))
            {
                lblLineFilter.Visible = false;
                cboLineFilter.Visible = false;
                if (gridViewHorizontal != null)
                    gridViewHorizontal.ActiveFilterString = string.Empty;
                return;
            }

            // Có từ 2 Line con trở lên => hiển thị bộ lọc
            cboLineFilter.SelectedIndexChanged -= CboLineFilter_SelectedIndexChanged;
            cboLineFilter.Properties.Items.Clear();
            cboLineFilter.Properties.Items.Add("[Tất cả]");
            foreach (var l in distinctLines)
                cboLineFilter.Properties.Items.Add(l);

            cboLineFilter.SelectedIndex = 0;
            cboLineFilter.SelectedIndexChanged += CboLineFilter_SelectedIndexChanged;

            lblLineFilter.Visible = true;
            cboLineFilter.Visible = true;
            if (gridViewHorizontal != null)
                gridViewHorizontal.ActiveFilterString = string.Empty;
        }

        private void CboLineFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gridViewHorizontal == null || cboLineFilter == null) return;
            string selected = cboLineFilter.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected) || selected == "[Tất cả]")
            {
                gridViewHorizontal.ActiveFilterString = string.Empty;
            }
            else
            {
                gridViewHorizontal.ActiveFilterString = $"[Line] = '{selected.Replace("'", "''")}'";
            }
        }

        /// <summary>
        /// Đảm bảo cột summary tồn tại và ghi được (SP thường trả ReadOnly → SetRowCellValue fail).
        /// </summary>
        private static void EnsureComputedColumns(DataTable dt)
        {
            EnsureWritableIntColumn(dt, "Actual Total");
            EnsureWritableIntColumn(dt, "Target Total");
            EnsureWritableIntColumn(dt, "Số Kỹ Năng Cần Đào Tạo");
            EnsureWritableIntColumn(dt, "Total_Line");
            EnsureWritableIntColumn(dt, "Total_Target");
            EnsureWritableIntColumn(dt, "Total_Gap");
        }

        /// <summary>
        /// SP hay trả summary dạng string + MaxLength hẹp → gán int bị
        /// "value violates the MaxLength limit". Thay bằng cột int ghi được.
        /// </summary>
        private static void EnsureWritableIntColumn(DataTable dt, string name)
        {
            if (!dt.Columns.Contains(name))
            {
                dt.Columns.Add(name, typeof(int));
                return;
            }

            var col = dt.Columns[name];
            // Expression column: không thay được
            if (!string.IsNullOrEmpty(col.Expression))
                return;

            // Đã là số: chỉ mở ghi
            if (col.DataType == typeof(int) || col.DataType == typeof(long) ||
                col.DataType == typeof(short) || col.DataType == typeof(byte) ||
                col.DataType == typeof(decimal) || col.DataType == typeof(double) ||
                col.DataType == typeof(float))
            {
                col.ReadOnly = false;
                return;
            }

            // string / object / khác: xóa và thêm lại kiểu int (giá trị sẽ được Recalc ghi lại)
            int ordinal = col.Ordinal;
            dt.Columns.Remove(col);
            var neu = new DataColumn(name, typeof(int)) { AllowDBNull = true, ReadOnly = false };
            dt.Columns.Add(neu);
            neu.SetOrdinal(ordinal);
        }

        /// <summary>
        /// Đếm Actual/Target theo master list + CountThreshold/CountExact từ TypeConfig.
        /// </summary>
        private void RecalcRowMetrics(DataTable dt)
        {
            int threshold = Threshold;
            bool exact = Exact;

            foreach (DataRow row in dt.Rows)
            {
                int actual = 0;
                int target = 0;
                int trainingGap = 0;

                foreach (var sc in _skillColumns)
                {
                    bool actualQualified = sc.ColActual != null
                        && MeetsThreshold(row[sc.ColActual], threshold, exact);
                    bool targetRequired = sc.ColTarget != null
                        && MeetsThreshold(row[sc.ColTarget], threshold, exact);

                    if (actualQualified)
                        actual++;
                    if (targetRequired)
                        target++;
                    if (targetRequired && !actualQualified)
                        trainingGap++;
                }

                if (CanWrite(dt, "Actual Total"))
                    row["Actual Total"] = actual;
                if (CanWrite(dt, "Target Total"))
                    row["Target Total"] = target;
                if (CanWrite(dt, "Số Kỹ Năng Cần Đào Tạo"))
                    row["Số Kỹ Năng Cần Đào Tạo"] = trainingGap;
            }
        }

        private static bool MeetsThreshold(object cell, int threshold, bool exact)
        {
            if (cell == null || cell == DBNull.Value) return false;
            if (!double.TryParse(cell.ToString(), out double v)) return false;
            return exact ? v == threshold : v >= threshold;
        }

        private static bool CanWrite(DataTable dt, string colName)
        {
            if (!dt.Columns.Contains(colName)) return false;
            var c = dt.Columns[colName];
            return string.IsNullOrEmpty(c.Expression) && !c.ReadOnly;
        }

        /// <summary>Gán Total_Line / Total_Target theo từng Line (Import to Date). Ẩn trên UI.</summary>
        private void CalculateTotalsByLine(DataTable dt)
        {
            if (dt == null || !dt.Columns.Contains("Line")) return;
            if (!dt.Columns.Contains("Total_Line") || !dt.Columns.Contains("Total_Target")
                || !dt.Columns.Contains("Total_Gap")) return;
            if (!CanWrite(dt, "Total_Line") || !CanWrite(dt, "Total_Target")
                || !CanWrite(dt, "Total_Gap")) return;

            var summary = dt.AsEnumerable()
                .GroupBy(r => (r["Line"]?.ToString() ?? "").Trim())
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        SumActual = g.Sum(r =>
                        {
                            int.TryParse(r["Actual Total"]?.ToString(), out int kq);
                            return kq;
                        }),
                        SumTarget = g.Sum(r =>
                        {
                            int.TryParse(r["Target Total"]?.ToString(), out int kq);
                            return kq;
                        }),
                        SumGap = g.Sum(r =>
                        {
                            int.TryParse(r["Số Kỹ Năng Cần Đào Tạo"]?.ToString(), out int kq);
                            return kq;
                        })
                    });

            foreach (DataRow row in dt.Rows)
            {
                string line = (row["Line"]?.ToString() ?? "").Trim();
                if (summary.TryGetValue(line, out var match))
                {
                    row["Total_Line"] = match.SumActual;
                    row["Total_Target"] = match.SumTarget;
                    row["Total_Gap"] = match.SumGap;
                }
            }
        }

        private void ApplyColumnPresentation()
        {
            // Snapshot columns — keep in DataTable for Import to Date, hide on grid
            HideColumn("Total_Line");
            HideColumn("Total_Target");
            HideColumn("Total_Gap");

            AlignColumn("Actual Total", HorzAlignment.Far);
            AlignColumn("Target Total", HorzAlignment.Far);
            if (gridViewHorizontal.Columns["Số Kỹ Năng Cần Đào Tạo"] != null)
            {
                AlignColumn("Số Kỹ Năng Cần Đào Tạo", HorzAlignment.Far);
                CenterAlignColumnData(gridViewHorizontal, "Số Kỹ Năng Cần Đào Tạo");
            }
            AlignColumn("AutoID", HorzAlignment.Center);

            // Header Target vàng (AppearanceHeader + CustomDraw)
            foreach (GridColumn col in gridViewHorizontal.Columns)
            {
                if (col.FieldName != null &&
                    col.FieldName.StartsWith("Target", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(col.FieldName, "Target Total", StringComparison.OrdinalIgnoreCase))
                {
                    col.AppearanceHeader.BackColor = System.Drawing.Color.Yellow;
                    col.AppearanceHeader.Options.UseBackColor = true;
                }
            }

            // Width gợi ý giống V1 KTV
            if (gridViewHorizontal.Columns["Tên"] != null)
                gridViewHorizontal.Columns["Tên"].Width = Math.Max(gridViewHorizontal.Columns["Tên"].Width, 150);
            if (gridViewHorizontal.Columns["Số Kỹ Năng Cần Đào Tạo"] != null)
                gridViewHorizontal.Columns["Số Kỹ Năng Cần Đào Tạo"].Width = Math.Max(
                    gridViewHorizontal.Columns["Số Kỹ Năng Cần Đào Tạo"].Width, 110);
        }

        private void HideColumn(string fieldName)
        {
            var col = gridViewHorizontal.Columns[fieldName];
            if (col != null) col.Visible = false;
        }

        private void AlignColumn(string fieldName, HorzAlignment align)
        {
            var col = gridViewHorizontal.Columns[fieldName];
            if (col != null)
                col.AppearanceCell.TextOptions.HAlignment = align;
        }

        private void GridViewHorizontal_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null &&
                e.Column.FieldName != null &&
                e.Column.FieldName.StartsWith("Target", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(e.Column.FieldName, "Target Total", StringComparison.OrdinalIgnoreCase))
            {
                e.Appearance.BackColor = System.Drawing.Color.Yellow;
                e.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void gridViewHorizontal_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == null || string.IsNullOrEmpty(e.Column.FieldName)) return;
            var match = _skillColumns.Find(x =>
                x.ColActual != null &&
                string.Equals(x.ColActual, e.Column.FieldName, StringComparison.OrdinalIgnoreCase));
            if (match.ColActual == null || match.ColTarget == null) return;

            int.TryParse(Convert.ToString(gridViewHorizontal.GetRowCellValue(e.RowHandle, match.ColActual)), out int vKN);
            int.TryParse(Convert.ToString(gridViewHorizontal.GetRowCellValue(e.RowHandle, match.ColTarget)), out int vTarget);
            if (vKN < vTarget) e.Appearance.BackColor = System.Drawing.Color.LightPink;
        }

        // ---- V1: Import to Date (snapshot) ----
        private void BtnImportToDate_Click(object sender, EventArgs e)
        {
            if (!_isAdmin)
            {
                XtraMessageBox.Show("Bạn không có quyền Import to Date.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dt = gridControlHorizontal.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show("No data to import.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Recompute metrics + line totals from current grid data (Total_* may be hidden)
                if (_skills == null || _skills.Count == 0)
                    LoadSkillDefinitions();
                ResolveSkillColumns(dt);
                EnsureComputedColumns(dt);
                RecalcRowMetrics(dt);
                CalculateTotalsByLine(dt);

                DateTime skillDate = dateEditDate.EditValue is DateTime d ? d : DateTime.Now;
                var lines = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                int tongA = 0, tongT = 0, tongG = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string line = (row["Line"]?.ToString() ?? "").Trim();
                    if (string.IsNullOrEmpty(line) || lines.Contains(line)) continue;

                    int a = 0, t = 0, g = 0;
                    int.TryParse(row["Total_Line"]?.ToString(), out a);
                    int.TryParse(row["Total_Target"]?.ToString(), out t);
                    int.TryParse(row["Total_Gap"]?.ToString(), out g);
                    tongA += a;
                    tongT += t;
                    tongG += g;

                    _dao.InsertSkillMonth(line, t, a, g, skillDate, _username, skillDate);
                    lines.Add(line);
                }

                _dao.InsertSkillMonth("Total", tongT, tongA, tongG, skillDate, _username, skillDate);

                // Snapshot từng skill theo master list (LineSX khi mode Line; KTV khi mode KTV)
                foreach (var sc in _skillColumns)
                    InsertArraySkillMonth(sc.ColActual, sc.ColTarget, sc.SkillKey, skillDate);

                // Chốt thêm fact chi tiết cho dashboard. SP chạy idempotent theo tháng + SkillType.
                _dao.CaptureDashboardSnapshot(skillDate, CurrentSkillType, _username);

                XtraMessageBox.Show("Import Success", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error import : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertArraySkillMonth(string colKN, string colTarget, string skillKey, DateTime createDate)
        {
            int totalA = 0, totalT = 0, trainingGap = 0;
            var dt = gridControlHorizontal.DataSource as DataTable;
            string key = string.IsNullOrEmpty(skillKey) ? (colKN ?? "") : skillKey;
            if (dt == null)
            {
                _dao.InsertSkillMonthTotal(0, 0, 0, key.Trim(), createDate, _username);
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                bool actualQualified = colKN != null && dt.Columns.Contains(colKN)
                    && MeetsThreshold(row[colKN], Threshold, Exact);
                bool targetRequired = colTarget != null && dt.Columns.Contains(colTarget)
                    && MeetsThreshold(row[colTarget], Threshold, Exact);

                if (actualQualified)
                    totalA++;
                if (targetRequired)
                    totalT++;
                if (targetRequired && !actualQualified)
                    trainingGap++;
            }
            _dao.InsertSkillMonthTotal(totalT, totalA, trainingGap, key.Trim(), createDate, _username);
        }
    }
}
