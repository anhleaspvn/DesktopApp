using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ASPData;
using ASPData.ASPDAO;
using ASPProject.SkillMap;

namespace ASPProject.AppTemplateSkillMapV2
{
    /// <summary>
    /// Form thêm nhân viên từ Excel. Import = append (ImportAppend), không xoá data cũ.
    /// Full replace vẫn dùng Choose File + Import trên màn SkillMap V2 chính.
    /// </summary>
    public class frmAddStaffV2 : frmSkillMapBase
    {
        private readonly SkillMapV2DAO _dao;
        private DataTable _dt;
        private GridControl gridAddStaff;
        private GridView gridView1;
        private TextEdit txtPath;
        private SimpleButton btnChooseFile, btnImportFile, btnExit;

        public event Action DataAdded;

        public frmAddStaffV2(SkillMapV2DAO dao)
        {
            _dao = dao;
            BuildUI();
        }

        private void BuildUI()
        {
            Text = "Add Staff V2 — Import thêm (không xoá data cũ)";
            Width = 900; Height = 600;
            var pnl = new Panel { Dock = DockStyle.Top, Height = 44 };
            txtPath = new TextEdit { Dock = DockStyle.Fill, Enabled = false };
            btnChooseFile = new SimpleButton { Text = "Choose File", Width = 90, Dock = DockStyle.Left };
            btnImportFile = new SimpleButton
            {
                Text = "Import (Add)",
                Width = 100,
                Dock = DockStyle.Right,
                Enabled = false,
                ToolTip = "Chỉ thêm dòng từ file. Không xoá skill map hiện tại. Bỏ qua EmpID+SkillID đã có."
            };
            btnExit = new SimpleButton { Text = "Exit", Width = 70, Dock = DockStyle.Right };
            pnl.Controls.Add(txtPath);
            pnl.Controls.Add(btnExit);
            pnl.Controls.Add(btnImportFile);
            pnl.Controls.Add(btnChooseFile);

            gridAddStaff = new GridControl { Dock = DockStyle.Fill };
            gridView1 = new GridView();
            gridAddStaff.MainView = gridView1;

            Controls.Add(gridAddStaff);
            Controls.Add(pnl);

            btnChooseFile.Click += BtnChooseFile_Click;
            btnImportFile.Click += BtnImportFile_Click;
            btnExit.Click += (s, e) => Close();
            gridView1.CustomUnboundColumnData += (s, e) =>
            {
                if (e.Column.FieldName == "AutoID" && e.IsGetData) e.Value = e.ListSourceRowIndex + 1;
            };
        }

        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            string err;
            string filePath;
            var dt = ImportExcelToDataTable(out err, out filePath);
            if (dt == null)
            {
                if (!string.IsNullOrEmpty(err)) XtraMessageBox.Show("Error Import : " + err, "Error Import File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                XtraMessageBox.Show(
                    "File không có dòng dữ liệu hợp lệ (sau khi loại trống / trùng EmpID+SkillID).",
                    "Choose File",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                btnImportFile.Enabled = false;
                _dt = null;
                return;
            }

            _dt = dt;
            if (txtPath != null)
                txtPath.Text = filePath ?? "";

            gridAddStaff.BeginUpdate();
            try
            {
                gridAddStaff.DataSource = null;
                gridView1.Columns.Clear();
                gridAddStaff.DataSource = dt;
                gridView1.PopulateColumns();

                var existing = gridView1.Columns.ColumnByFieldName("AutoID");
                while (existing != null)
                {
                    gridView1.Columns.Remove(existing);
                    existing = gridView1.Columns.ColumnByFieldName("AutoID");
                }

                var c = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    Caption = "AutoID",
                    FieldName = "AutoID",
                    UnboundType = DevExpress.Data.UnboundColumnType.Integer,
                    Visible = true,
                    VisibleIndex = 0
                };
                c.OptionsColumn.AllowEdit = false;
                c.OptionsColumn.ReadOnly = true;
                gridView1.Columns.Add(c);
                c.VisibleIndex = 0;
                gridView1.BestFitColumns();
                gridView1.RefreshData();
            }
            finally
            {
                gridAddStaff.EndUpdate();
            }

            btnImportFile.Enabled = true;

            string sanitizeMsg = BuildImportSanitizeMessage();
            if (!string.IsNullOrEmpty(sanitizeMsg))
                XtraMessageBox.Show(sanitizeMsg, "Choose File — đã xử lý trùng/rỗng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnImportFile_Click(object sender, EventArgs e)
        {
            if (_dt == null) return;

            if (XtraMessageBox.Show(
                    "Import (Add) sẽ CHỈ THÊM dữ liệu từ file vào skill map hiện tại.\n" +
                    "• Không xoá data cũ\n" +
                    "• Dòng EmpID + SkillID đã có sẽ được bỏ qua\n\n" +
                    "Tiếp tục?",
                    "Import (Add)",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var table = _dt;
            SkillMapImportAppendResult result = null;
            try
            {
                RunWithWait("Đang thêm Skill Map (append) — vui lòng chờ...", () =>
                {
                    result = _dao.ImportAppend(table, SessionMangerSkillMap.Username);
                });

                string msg =
                    "Import (Add) thành công!\n\n" +
                    $"- Đã thêm: {result?.Inserted ?? 0}\n" +
                    $"- Bỏ qua (đã có EmpID+SkillID): {result?.SkippedDuplicate ?? 0}\n" +
                    $"- Bỏ qua (thiếu EmpID): {result?.SkippedEmpty ?? 0}";

                XtraMessageBox.Show(msg, "Import (Add)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataAdded?.Invoke();
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error Import : " + ex.Message, "Error Import File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
