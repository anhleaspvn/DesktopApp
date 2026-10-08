using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ASPData.ASPDAO;
using ASPProject.SkillMap;
using System.Diagnostics;

namespace ASPProject.AppTemplateSkillMapV2
{
    public class frmSkillMapV2 : frmSkillMapBase
    {
        private readonly SkillMapV2DAO _dao;
        private GridControl gridControlData;
        private GridView gridView1;
        private RepositoryItemButtonEdit repItemBtnEdit;
        private RepositoryItemButtonEdit repItemBtnDelete;

        private TextEdit txtPath;
        private SimpleButton btnChooseFile, btnImportFile, btnCancelPreview, btnExportExcel, btnAdd, btnExit, btnLoad_Data_Horizontal, btnDashboard;

        public string UseNameLogin { get; set; }
        private DataTable _importTable;
        private bool _isAdmin;
        /// <summary>true = grid đang hiện preview Excel (chưa ghi DB).</summary>
        private bool _isPreviewMode;
        private ASPData.SQLHelper _sqlHelper = new ASPData.SQLHelper();

        public frmSkillMapV2()
        {
            _dao = new SkillMapV2DAO(constring);
            UseNameLogin = SessionMangerSkillMap.Username;
            BuildUI();
            SetupGridView();
        }

        private void BuildUI()
        {
            Text = "SkillMap V2";
            Width = 1200;
            Height = 700;

            var pnl = new Panel { Dock = DockStyle.Top, Height = 44 };
            txtPath = new TextEdit { Dock = DockStyle.Fill, Enabled = false };
            btnChooseFile = new SimpleButton { Text = "Choose File", Width = 90, Dock = DockStyle.Left };
            // Dock Right: add outer-most first → Exit | Horizontal | Add | Export | Cancel | Import
            btnImportFile = new SimpleButton { Text = "Import", Width = 80, Dock = DockStyle.Right, Enabled = false };
            btnCancelPreview = new SimpleButton
            {
                Text = "Cancel Preview",
                Width = 110,
                Dock = DockStyle.Right,
                Visible = false,
                ToolTip = "Bỏ preview Excel, tải lại dữ liệu từ database"
            };
            btnExportExcel = new SimpleButton { Text = "Export Excel", Width = 90, Dock = DockStyle.Right };
            btnAdd = new SimpleButton { Text = "Add", Width = 70, Dock = DockStyle.Right };
            btnLoad_Data_Horizontal = new SimpleButton { Text = "Horizontal", Width = 90, Dock = DockStyle.Right, Visible = false };
            btnExit = new SimpleButton { Text = "Exit", Width = 70, Dock = DockStyle.Right };
            btnDashboard = new SimpleButton { Text = "Dashboard", Width = 90, Dock = DockStyle.Right, Visible = true };

            pnl.Controls.Add(txtPath);
            pnl.Controls.Add(btnChooseFile);
            pnl.Controls.Add(btnExit);
            pnl.Controls.Add(btnLoad_Data_Horizontal);
            pnl.Controls.Add(btnAdd);
            pnl.Controls.Add(btnExportExcel);
            pnl.Controls.Add(btnCancelPreview);
            pnl.Controls.Add(btnImportFile);
            pnl.Controls.Add(btnDashboard);

            gridControlData = new GridControl { Dock = DockStyle.Fill };
            gridView1 = new GridView { Name = "gridView1" };
            gridControlData.MainView = gridView1;

            Controls.Add(gridControlData);
            Controls.Add(pnl);

            btnChooseFile.Click += BtnChooseFile_Click;
            btnImportFile.Click += BtnImportFile_Click;
            btnCancelPreview.Click += BtnCancelPreview_Click;
            btnExportExcel.Click += (s, e) => ExportToXlsx(gridView1, "Export_SkillMap_Detail");
            btnAdd.Click += btnAdd_Click;
            btnExit.Click += (s, e) => Close();
            btnLoad_Data_Horizontal.Click += BtnLoad_Data_Horizontal_Click;
            btnDashboard.Click += (s, e) => OpenDashboard();    

            repItemBtnEdit = new RepositoryItemButtonEdit
            {
                TextEditStyle = TextEditStyles.HideTextEditor
            };
            repItemBtnEdit.Buttons[0].Kind = ButtonPredefines.Glyph;
            repItemBtnEdit.Buttons[0].Caption = "Edit";
            repItemBtnEdit.Buttons[0].Appearance.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            repItemBtnEdit.Buttons[0].Appearance.Options.UseBackColor = true;
            repItemBtnEdit.ButtonClick += RepItemBtnEdit_ButtonClick;
            gridControlData.RepositoryItems.Add(repItemBtnEdit);

            repItemBtnDelete = new RepositoryItemButtonEdit
            {
                TextEditStyle = TextEditStyles.HideTextEditor
            };
            repItemBtnDelete.Buttons[0].Kind = ButtonPredefines.Glyph;
            repItemBtnDelete.Buttons[0].Caption = "Delete";
            repItemBtnDelete.Buttons[0].Appearance.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            repItemBtnDelete.Buttons[0].Appearance.Options.UseBackColor = true;
            repItemBtnDelete.ButtonClick += RepItemBtnDelete_ButtonClick;
            gridControlData.RepositoryItems.Add(repItemBtnDelete);
        }

        private void SetupGridView()
        {
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            // Giống V1: bật edit để sửa cell (Check, EmpName, Line, LV dates…) rồi bấm Edit để lưu DB.
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;

            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            gridView1.CellValueChanged += gridView1_CellValueChanged;
            gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;
            gridView1.ShowingEditor += GridView1_ShowingEditor;
            // V1: click cell → ShowEditor (đảm bảo mở editor ngay)
            gridView1.RowCellClick += GridView1_RowCellClick;
        }

        /// <summary>
        /// Giống V1: hầu hết cột data cho sửa. Chỉ khóa cột hệ thống (AutoID unbound).
        /// Lưu DB khi tick Check + bấm nút Edit (sp_ASP_UPDATE_ID).
        /// </summary>
        private void ApplyColumnEditRules()
        {
            foreach (GridColumn col in gridView1.Columns)
            {
                string f = col.FieldName ?? "";
                // AutoID chỉ hiển thị STT — không sửa
                bool lockCol = f == "AutoID";
                col.OptionsColumn.AllowEdit = !lockCol;
                col.OptionsColumn.ReadOnly = lockCol;
            }
        }

        private void GridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gridView1.IsFilterRow(gridView1.FocusedRowHandle))
                e.Cancel = true;
        }

        private void GridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column == null) return;
            if (gridView1.IsFilterRow(e.RowHandle)) return;
            gridView1.FocusedColumn = e.Column;
            gridView1.ShowEditor();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            KT_Login(UseNameLogin);
        }

        private void KT_Login(string username)
        {
            // sp_SkillMapCheckPermission: 1 = admin; else line-scoped (không hardcode WHA/WHB…)
            _isAdmin = _dao.IsSkillMapAdmin(username);

            if (!_isAdmin)
            {
                Controls.Clear();
                var f = new frmHorizontalV2(username, isAdmin: false, initialSkillType: null);
                f.TopLevel = false;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                Controls.Add(f);
                f.Show();
            }
            else
            {
                Show_Data();
            }
        }

        private void BtnLoad_Data_Horizontal_Click(object sender, EventArgs e)
        {
            var main = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            if (main != null)
                main.OpenSkillMapHorizontalTab(UseNameLogin, initialSkillType: null);
            else
                XtraMessageBox.Show("Không tìm thấy Main form để mở tab Horizontal.", "Skill Map", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            string err;
            string filePath;
            var dt = ImportExcelToDataTable(out err, out filePath);
            if (dt == null)
            {
                if (!string.IsNullOrEmpty(err))
                    XtraMessageBox.Show("Error Import : " + err, "Error Import File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dt.Rows.Count == 0)
            {
                XtraMessageBox.Show(
                    "File không có dòng dữ liệu hợp lệ (sau khi loại trống / trùng EmpID+SkillID).",
                    "Choose File",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _importTable = null;
                SetPreviewMode(false);
                return;
            }

            _importTable = dt;
            if (txtPath != null)
                txtPath.Text = filePath ?? "";

            // Rebind sạch: tránh cột UI cũ (Check/Edit/Delete) + AutoID bound từ file export dính lại
            gridControlData.BeginUpdate();
            try
            {
                gridControlData.DataSource = null;
                gridView1.Columns.Clear();
                gridControlData.DataSource = dt;
                gridView1.PopulateColumns();
                AddAutoIdColumn();
                ApplyColumnEditRules();
                gridView1.BestFitColumns();
                gridView1.RefreshData();
            }
            finally
            {
                gridControlData.EndUpdate();
            }

            SetPreviewMode(true);

            string sanitizeMsg = BuildImportSanitizeMessage();
            if (!string.IsNullOrEmpty(sanitizeMsg))
                XtraMessageBox.Show(sanitizeMsg, "Choose File — đã xử lý trùng/rỗng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Bật/tắt chế độ preview Excel: Import + Cancel Preview.
        /// Cancel = bỏ DataTable preview, gọi lại Show_Data() từ DB (không đụng DB khi chỉ preview).
        /// </summary>
        private void SetPreviewMode(bool preview)
        {
            _isPreviewMode = preview;
            btnImportFile.Enabled = preview && _importTable != null;
            if (btnCancelPreview != null)
                btnCancelPreview.Visible = preview;
            if (!preview && txtPath != null)
                txtPath.Text = "";
            Text = preview ? "SkillMap V2 — Preview Excel (chưa lưu DB)" : "SkillMap V2";
        }

        private void BtnCancelPreview_Click(object sender, EventArgs e)
        {
            if (!_isPreviewMode && _importTable == null) return;

            if (XtraMessageBox.Show(
                    "Bỏ preview file Excel và tải lại dữ liệu hiện tại từ database?\n(Chưa Import thì DB không đổi.)",
                    "Cancel Preview",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _importTable = null;
            SetPreviewMode(false);
            Show_Data();
        }

        private void AddAutoIdColumn()
        {
            // Gỡ AutoID bound (nếu file Excel/export còn sót) trước khi add unbound STT
            var existing = gridView1.Columns.ColumnByFieldName("AutoID");
            while (existing != null)
            {
                gridView1.Columns.Remove(existing);
                existing = gridView1.Columns.ColumnByFieldName("AutoID");
            }

            var c = new GridColumn
            {
                Caption = "AutoID",
                FieldName = "AutoID",
                UnboundType = DevExpress.Data.UnboundColumnType.Integer,
                Visible = true,
                VisibleIndex = 0
            };
            c.OptionsColumn.AllowEdit = false;
            c.OptionsColumn.ReadOnly = true;
            c.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns.Add(c);
            c.VisibleIndex = 0;
        }

        private void GridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "AutoID" && e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }

        private void BtnImportFile_Click(object sender, EventArgs e)
        {
            if (_importTable == null) return;

            if (XtraMessageBox.Show(
                    "Import sẽ XOÁ toàn bộ skill map hiện tại rồi ghi đè bằng file preview.\nTiếp tục?",
                    "Import File",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            var table = _importTable;
            try
            {
                // Loading theo pattern frmMain (ASPControl.Loadingggg / WaitDialogForm)
                RunWithWait("Đang import Skill Map — vui lòng chờ...", () =>
                {
                    _dao.ImportReplace(table);
                });

                _importTable = null;
                SetPreviewMode(false);
                Show_Data();
                XtraMessageBox.Show("Import Data Success!", "Import File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Preview giữ nguyên để user sửa file / Cancel Preview
                XtraMessageBox.Show("Error Import : " + ex.Message, "Error Import File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var f = new frmAddStaffV2(_dao);
            f.DataAdded += Show_Data;
            f.Show();
        }

        private void Show_Data()
        {
            try
            {
                var dt = _dao.GetSkillMapData(SessionMangerSkillMap.Username);
                if (dt.Rows.Count <= 0)
                {
                    gridControlData.DataSource = null;
                    gridControlData.RefreshDataSource();
                    btnLoad_Data_Horizontal.Visible = _isAdmin;
                    return;
                }
                // Cột Check bound vào DataTable (không dùng Unbound — tránh tick không lưu)
                if (!dt.Columns.Contains("IsSelected"))
                    dt.Columns.Add("IsSelected", typeof(bool));
                foreach (DataRow row in dt.Rows)
                {
                    if (row["IsSelected"] == DBNull.Value)
                        row["IsSelected"] = false;
                }

                gridControlData.DataSource = dt;
                gridView1.PopulateColumns();
                gridView1.BestFitColumns();
                if (gridView1.Columns["AutoID"] != null)
                    gridView1.Columns["AutoID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                Display_TotalRecord(gridView1, "EmpName");
                SetupCheckColumn();
                SetupEditDeleteColumns();
                ApplyColumnEditRules();
                btnLoad_Data_Horizontal.Visible = _isAdmin;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    int pct = Calculate_Percent(
                        gridView1.GetRowCellValue(i, "DateReachedLV1"),
                        gridView1.GetRowCellValue(i, "DateReachedLV2"),
                        gridView1.GetRowCellValue(i, "DateReachedLV3"),
                        gridView1.GetRowCellValue(i, "DateReachedLV4"));
                    gridView1.SetRowCellValue(i, "PercentLV", pct);
                }
                gridView1.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Show Data : " + ex.Message, "Error Show Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupEditDeleteColumns()
        {
            if (gridView1.Columns.Count == 0) return;
            if (gridView1.Columns["colEdit"] != null) gridView1.Columns.Remove(gridView1.Columns["colEdit"]);
            if (gridView1.Columns["colDelete"] != null) gridView1.Columns.Remove(gridView1.Columns["colDelete"]);

            var colEdit = new GridColumn
            {
                FieldName = "EditButton",
                Caption = "Edit",
                Name = "colEdit",
                UnboundType = DevExpress.Data.UnboundColumnType.Object,
                Visible = true
            };
            colEdit.OptionsColumn.AllowEdit = true;
            colEdit.OptionsColumn.AllowSize = false;
            colEdit.ColumnEdit = repItemBtnEdit;
            colEdit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colEdit.Width = 95;

            var colDelete = new GridColumn
            {
                FieldName = "DeleteButton",
                Caption = "Delete",
                Name = "colDelete",
                UnboundType = DevExpress.Data.UnboundColumnType.Object,
                Visible = true
            };
            colDelete.OptionsColumn.AllowEdit = true;
            colDelete.OptionsColumn.AllowSize = false;
            colDelete.ColumnEdit = repItemBtnDelete;
            colDelete.Width = 95;

            gridView1.Columns.Add(colEdit);
            gridView1.Columns.Add(colDelete);
            colEdit.VisibleIndex = gridView1.Columns.Count - 2;
            colDelete.VisibleIndex = gridView1.Columns.Count - 1;
            gridView1.BestFitColumns();
        }

        /// <summary>
        /// Cột Check bound bool + CheckEdit. Không set UnboundType (xung đột DataTable → tick không được).
        /// </summary>
        private void SetupCheckColumn()
        {
            var checkColumn = gridView1.Columns.ColumnByFieldName("IsSelected");
            if (checkColumn == null)
            {
                checkColumn = new GridColumn
                {
                    FieldName = "IsSelected",
                    Caption = "Check",
                    Visible = true
                };
                gridView1.Columns.Add(checkColumn);
            }

            checkColumn.Caption = "Check";
            checkColumn.VisibleIndex = 0;
            checkColumn.Width = 60;
            checkColumn.OptionsColumn.AllowEdit = true;
            checkColumn.OptionsColumn.ReadOnly = false;
            checkColumn.OptionsColumn.AllowMove = false;
            checkColumn.OptionsColumn.FixedWidth = true;
            checkColumn.OptionsFilter.AllowFilter = false;
            // Bound column: clear any unbound config from old code paths
            checkColumn.UnboundType = DevExpress.Data.UnboundColumnType.Bound;

            var ric = new RepositoryItemCheckEdit
            {
                ValueChecked = true,
                ValueUnchecked = false,
                AllowGrayed = false
            };
            gridControlData.RepositoryItems.Add(ric);
            checkColumn.ColumnEdit = ric;
        }

        private static bool IsValidDate(object v) => v != null && v != DBNull.Value && Convert.ToDateTime(v) != DateTime.MinValue;

        private static int Calculate_Percent(object lv1, object lv2, object lv3, object lv4)
        {
            int pct = 0;
            if (IsValidDate(lv1))
            {
                pct = 25;
                if (IsValidDate(lv2))
                {
                    pct = 50;
                    if (IsValidDate(lv3))
                    {
                        pct = 75;
                        if (IsValidDate(lv4)) pct = 100;
                    }
                }
            }
            return pct;
        }

        private void RepItemBtnDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int hr = gridView1.FocusedRowHandle;
            if (hr < 0) return;
            object pk = gridView1.GetRowCellValue(hr, "EmpID");
            if (XtraMessageBox.Show($"Are you sure you want to delete the employee with ID : {pk} ?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    _dao.DeleteDataByEmpId(pk.ToString());
                    gridView1.DeleteRow(hr);
                    gridView1.RefreshData();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error Delete : " + ex.Message);
                }
            }
        }

        private void RepItemBtnEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int dem = 0;

            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var v = gridView1.GetRowCellValue(i, "IsSelected");
                    bool isChecked = v != null && v != DBNull.Value && Convert.ToBoolean(v);
                    if (!isChecked) continue;

                    dem++;

                    _dao.UpdateSkillMap(
                        Convert.ToString(gridView1.GetRowCellValue(i, "EmpID")),
                        Convert.ToString(gridView1.GetRowCellValue(i, "EmpName")),
                        Convert.ToString(gridView1.GetRowCellValue(i, "Position")),
                        Convert.ToString(gridView1.GetRowCellValue(i, "Direct_Indirect")),
                        Convert.ToString(gridView1.GetRowCellValue(i, "LineID")),
                        Convert.ToString(gridView1.GetRowCellValue(i, "SkillID")),

                        gridView1.GetRowCellValue(i, "PercentLV"),

                        gridView1.GetRowCellValue(i, "DateReachedLV0"),
                        gridView1.GetRowCellValue(i, "DateReachedLV1"),
                        gridView1.GetRowCellValue(i, "DateReachedLV2"),
                        gridView1.GetRowCellValue(i, "DateReachedLV3"),
                        gridView1.GetRowCellValue(i, "DateReachedLV4"),
                        gridView1.GetRowCellValue(i, "DateOfReTraining"),

                        Convert.ToString(gridView1.GetRowCellValue(i, "EmpStatus")),

                        gridView1.GetRowCellValue(i, "StartDate"),

                        gridView1.GetRowCellValue(i, "Seniority"),
                        Convert.ToString(gridView1.GetRowCellValue(i, "GroupLine"))
                    );
                }

                if (dem > 0)
                {
                    RefreshKeepPosition();
                    XtraMessageBox.Show($"Update Data Success! {dem} Record(s).");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Edit: " + ex.Message);
            }
        }

        private void RefreshKeepPosition()
        {
            int hr = gridView1.FocusedRowHandle;
            object key = hr >= 0 ? gridView1.GetRowCellValue(hr, "EmpID") : null;
            Show_Data();
            if (key == null) return;
            int nh = gridView1.LocateByValue("EmpID", key);
            if (nh != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = nh;
        }

        private void OpenDashboard()
        {
            // Implement the logic to open the dashboard here
            DataTable dtParams = _sqlHelper.ExecQueryDataAsDataTable("SELECT Parameter_Value FROM L00PARAMETERSASP WHERE Parameter_ID = 'DASHBOARDSK'");

            if (dtParams.Rows.Count > 0)
            {
                string dashboardUrl = dtParams.Rows[0]["Parameter_Value"].ToString();
                Process.Start(dashboardUrl); // Open the dashboard URL in the default browser
            }
            else
            {
                XtraMessageBox.Show("Dashboard URL not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.StartsWith("DateReachedLV"))
            {
                int pct = Calculate_Percent(
                    gridView1.GetRowCellValue(e.RowHandle, "DateReachedLV1"),
                    gridView1.GetRowCellValue(e.RowHandle, "DateReachedLV2"),
                    gridView1.GetRowCellValue(e.RowHandle, "DateReachedLV3"),
                    gridView1.GetRowCellValue(e.RowHandle, "DateReachedLV4"));
                gridView1.SetRowCellValue(e.RowHandle, "PercentLV", pct);
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            var dateCols = new[] { "DateReachedLV0", "DateReachedLV1", "DateReachedLV2", "DateReachedLV3", "DateReachedLV4", "StartDate" };
            if (Array.IndexOf(dateCols, e.Column.FieldName) >= 0)
            {
                if (e.Value == null || e.Value == DBNull.Value) e.DisplayText = "";
                else e.DisplayText = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
            }
            else if (e.Column.FieldName == "PercentLV" && e.Value != null && e.Value != DBNull.Value)
            {
                e.DisplayText = Convert.ToInt32(Convert.ToDecimal(e.Value)).ToString();
            }
        }
    }
}
