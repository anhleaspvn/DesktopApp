using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ASPData;

namespace ASPProject.AppTemplateSkillMapV2
{
    /// <summary>
    /// Form gốc chứa helper dùng chung cho mọi form SkillMap V2.
    /// Fix P1/P2: gom Display_TotalRecord, CenterAlignColumnData, Export, Import Excel
    /// (v1 định nghĩa lặp ở nhiều form).
    /// </summary>
    public class frmSkillMapBase : XtraForm
    {
        /// <summary>Cột UI-only (export từ grid) — không đưa vào DB.</summary>
        private static readonly HashSet<string> ImportUiOnlyColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "AutoID", "IsSelected", "Check", "EditButton", "DeleteButton", "Edit", "Delete"
        };

        protected readonly ASPData.ASPData _aspData;
        protected readonly string constring;

        /// <summary>Thống kê sau SanitizeImportTable (để UI báo user).</summary>
        protected int LastImportRawRows { get; private set; }
        protected int LastImportEmptyRemoved { get; private set; }
        protected int LastImportDupRemoved { get; private set; }

        public frmSkillMapBase()
        {
            _aspData = new ASPData.ASPData();
            constring = SQLHelper.ConnectionString;
        }

        protected void Display_TotalRecord(GridView gv, string countColumn)
        {
            var col = gv.Columns[countColumn];
            if (col == null) return;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "Total Record: {0}";
            gv.OptionsView.ShowFooter = true;
            gv.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        protected void CenterAlignColumnData(GridView gv, string columnName)
        {
            var col = gv.Columns[columnName];
            if (col == null) return;
            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            col.AppearanceCell.Options.UseTextOptions = true;
            col.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
        }

        protected void ExportToXlsx(GridView gv, string prefix)
        {
            if (gv.RowCount <= 0)
            {
                XtraMessageBox.Show("No data Export Excel", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads",
                $"{prefix}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            gv.ExportToXlsx(path);
            XtraMessageBox.Show("Export Excel Success", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Đọc Excel Sheet1$ → chuẩn hoá cột → loại row rỗng / trùng EmpID+SkillID / cột UI-only.
        /// </summary>
        protected DataTable ImportExcelToDataTable(out string error)
        {
            return ImportExcelToDataTable(out error, out _);
        }

        protected DataTable ImportExcelToDataTable(out string error, out string filePath)
        {
            error = null;
            filePath = null;
            LastImportRawRows = 0;
            LastImportEmptyRemoved = 0;
            LastImportDupRemoved = 0;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xls;*.xlsx";
                if (ofd.ShowDialog() != DialogResult.OK) return null;

                filePath = ofd.FileName;
                string ext = Path.GetExtension(ofd.FileName).ToLower();
                string conn;
                if (ext == ".xlsx")
                    conn = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ofd.FileName};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                else if (ext == ".xls")
                    conn = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ofd.FileName};Extended Properties='Excel 8.0 Xml;HDR=YES;IMEX=1;'";
                else
                {
                    error = "Choose File Excel, Please !";
                    return null;
                }

                try
                {
                    using (var c = new System.Data.OleDb.OleDbConnection(conn))
                    {
                        c.Open();
                        var da = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [Sheet1$]", c);
                        var dt = new DataTable();
                        da.Fill(dt);
                        NormalizeImportColumnNames(dt);
                        SanitizeImportTable(dt);
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return null;
                }
            }
        }

        /// <summary>
        /// Chuẩn hoá header: bỏ space, tránh trùng tên cột sau khi strip space.
        /// </summary>
        protected static void NormalizeImportColumnNames(DataTable dt)
        {
            if (dt == null) return;
            var used = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataColumn col in dt.Columns)
            {
                string name = (col.ColumnName ?? "").Replace(" ", "").Trim();
                if (string.IsNullOrEmpty(name)) name = "Col";
                string unique = name;
                int n = 1;
                while (!used.Add(unique))
                    unique = name + "_" + (n++);
                col.ColumnName = unique;
            }
        }

        /// <summary>
        /// Làm sạch data import:
        /// 1) Bỏ cột UI-only (AutoID/Check/Edit/Delete…) từ file export grid
        /// 2) Bỏ dòng hoàn toàn trống + dòng thiếu EmpID
        /// 3) Bỏ trùng key EmpID+SkillID (giữ dòng sau cùng)
        /// </summary>
        protected void SanitizeImportTable(DataTable dt)
        {
            if (dt == null) return;
            LastImportRawRows = dt.Rows.Count;
            LastImportEmptyRemoved = 0;
            LastImportDupRemoved = 0;

            // 1) Cột UI-only
            var dropCols = new List<DataColumn>();
            foreach (DataColumn col in dt.Columns)
            {
                if (ImportUiOnlyColumns.Contains(col.ColumnName))
                    dropCols.Add(col);
            }
            foreach (var col in dropCols)
                dt.Columns.Remove(col);

            bool hasEmpId = dt.Columns.Contains("EmpID");
            bool hasSkillId = dt.Columns.Contains("SkillID");

            // 2) Row rỗng / thiếu EmpID
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dt.Rows[i];
                if (row.RowState == DataRowState.Deleted) continue;

                if (IsImportRowEmpty(row) || (hasEmpId && string.IsNullOrWhiteSpace(RowCell(row, "EmpID"))))
                {
                    row.Delete();
                    LastImportEmptyRemoved++;
                }
            }
            dt.AcceptChanges();

            // 3) Trùng EmpID + SkillID (1 người + 1 skill chỉ 1 dòng)
            if (hasEmpId && hasSkillId && dt.Rows.Count > 1)
            {
                var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = dt.Rows[i];
                    string key = RowCell(row, "EmpID") + "\u001f" + RowCell(row, "SkillID");
                    if (!seen.Add(key))
                    {
                        row.Delete();
                        LastImportDupRemoved++;
                    }
                }
                dt.AcceptChanges();
            }
        }

        private static bool IsImportRowEmpty(DataRow row)
        {
            foreach (DataColumn col in row.Table.Columns)
            {
                object v = row[col];
                if (v != null && v != DBNull.Value && !string.IsNullOrWhiteSpace(Convert.ToString(v)))
                    return false;
            }
            return true;
        }

        private static string RowCell(DataRow row, string col)
            => row.Table.Columns.Contains(col) ? (row[col]?.ToString() ?? "").Trim() : "";

        /// <summary>Thông báo sau Choose File nếu đã loại empty/dup.</summary>
        protected string BuildImportSanitizeMessage()
        {
            if (LastImportEmptyRemoved <= 0 && LastImportDupRemoved <= 0)
                return null;
            return $"Đã làm sạch file import:\n" +
                   $"- Dòng thô (OleDB): {LastImportRawRows}\n" +
                   $"- Bỏ trống / thiếu EmpID: {LastImportEmptyRemoved}\n" +
                   $"- Bỏ trùng EmpID+SkillID: {LastImportDupRemoved}\n" +
                   $"- Còn lại: {LastImportRawRows - LastImportEmptyRemoved - LastImportDupRemoved}";
        }

        protected void SetupDateEdit(DevExpress.XtraEditors.DateEdit de, string format, DevExpress.XtraEditors.VistaCalendarViewStyle style)
        {
            DateTime today = DateTime.Now;
            de.DateTime = today;
            de.EditValue = today;
            de.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            de.Properties.DisplayFormat.FormatString = format;
            de.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            de.Properties.EditFormat.FormatString = format;
            de.Properties.Mask.EditMask = format;
            de.Properties.Mask.UseMaskAsDisplayFormat = true;
            de.Properties.VistaCalendarViewStyle = style;
        }

        /// <summary>
        /// Wait dialog theo pattern toàn project (<see cref="ASPControl.Loadingggg"/> / frmMain).
        /// Chạy work trên UI thread (giống các chỗ hiện có) — dialog hiện trước khi block.
        /// </summary>
        protected void RunWithWait(string caption, Action work)
        {
            if (work == null) return;
            var ld = new ASPControl.Loadingggg();
            bool prevEnabled = Enabled;
            try
            {
                Enabled = false;
                ld.CreateWaitDialog();
                if (!string.IsNullOrEmpty(caption))
                    ld.SetWaitDialogCaption(caption);
                // Cho dialog kịp paint trước khi thao tác sync dài (import/ bulk)
                Application.DoEvents();
                work();
            }
            finally
            {
                try { ld.simpleCloseWait(); }
                catch { /* dialog đã đóng / null */ }
                Enabled = prevEnabled;
            }
        }
    }
}
