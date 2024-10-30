using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using ASPData.ASPDAO;
using ASPData.DefectiveModeDTO;
using DevExpress.XtraEditors;

namespace ASPProject.DefectiveMode
{
    public partial class frmDefectiveMode : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        string defectID, defectName, defectLevel, defectType, moldAssembly, mainStep;
        DefectiveModeDTO defectDto = new DefectiveModeDTO();
        DefectiveModeDAO defectDao = new DefectiveModeDAO();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex;
        #endregion

        #region Constructor
        public frmDefectiveMode()
        {
            InitializeComponent();

            this.Load += FrmDefectiveMode_Load;

            this.barThoat.ItemClick += BarThoat_ItemClick;
            this.barThem.ItemClick += BarThem_ItemClick;
            this.barSua.ItemClick += BarSua_ItemClick;
            this.barXoa.ItemClick += BarXoa_ItemClick;
            this.barIn.ItemClick += BarIn_ItemClick;
            this.barNapLai.ItemClick += BarNapLai_ItemClick;
            this.barXuat.ItemClick += BarXuat_ItemClick;

            this.gridDefectView.RowClick += GridDefectView_RowClick;
            this.gridDefectView.DoubleClick += GridDefectView_DoubleClick;
        }
        #endregion

        #region Load
        private void FrmDefectiveMode_Load(object sender, EventArgs e)
        {
            frm.LoadVI += new frmMain.Translate(LoadTV);
            frm.LoadEN += new frmMain.Translate(LoadEL);

            LoadData();
            
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }
        }

        public void LoadTV()
        {
            iNgonNgu = 0;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
        }
        public void LoadEL()
        {
            iNgonNgu = 1;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
        }
        private void LoadData()
        {
            gridDefect.DataSource = defectDao.GetAllDefectiveMode();
            //gridDefectView.SelectRow(curIndex);
        }
        #endregion

        #region Event
        private void BarThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDefectiveModeEdit th = new frmDefectiveModeEdit();
            th.editType = 1;
            th.userName = userName;
            th.ShowDialog();
            LoadData();
        }
        private void BarSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDefectiveModeEdit editForm = new frmDefectiveModeEdit();
            editForm.editType = 0;

            if (string.IsNullOrEmpty(defectID))
            {
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn thông tin cần sửa.");
                }
                if (iNgonNgu == 1)
                {
                    XtraMessageBox.Show("Please select information to edit.");
                }
            }
            else
            {
                editForm.defectID = defectID;
                editForm.defectName = defectName;
                editForm.defectLevel = defectLevel;
                editForm.moldAssembly = moldAssembly;
                editForm.mainStep = mainStep;
                editForm.defectType = defectType;
                editForm.userName = userName;
                editForm.ShowDialog();
                LoadData();
            }
        }

        private void BarXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(defectID))
            {
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn thông tin cần xoá.");
                }
                if (iNgonNgu == 1)
                {
                    XtraMessageBox.Show("Please select infomation to delete.");
                }

            }
            else if (iNgonNgu == 0)
            {
                DialogResult a = XtraMessageBox.Show("Bạn có chắc xóa thông tin defect " + defectName + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.Yes)
                {

                    defectDto.DefectID = defectID;
                    defectDao.DeleteDefectiveMode(defectDto);
                    LoadData();

                    defectID = string.Empty;
                    defectName = string.Empty;
                }
            }
            else
            {
                DialogResult a = XtraMessageBox.Show("Are you sure to delete Employee  " + defectName + " ???", "Warming", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.Yes)
                {
                    defectDto.DefectID = defectID;
                    defectDao.DeleteDefectiveMode(defectDto);
                    LoadData();

                    defectID = string.Empty;
                    defectName = string.Empty;
                }
            }
        }

        private void BarThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deDongTab();
        }
        private void GridDefectView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dtr = gridDefectView.GetDataRow(e.RowHandle);
            defectID = dtr[0].ToString();
            textEdit1.Text = defectID.Trim().ToString();
            defectName = dtr[1].ToString();
            textEdit2.Text = defectName;
            defectType = dtr[2].ToString();
            defectLevel = dtr[3].ToString();
            moldAssembly = dtr[4].ToString();
            mainStep = dtr[5].ToString();

            curIndex = e.RowHandle;

        }
        private void GridDefectView_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(defectID))
            {
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn thông tin cần sửa.");
                }
                if (iNgonNgu == 1)
                {
                    XtraMessageBox.Show("Please select information to edit.");
                }
            }
            else
            {
                frmDefectiveModeEdit editForm = new frmDefectiveModeEdit();
                editForm.editType = 0;
                editForm.defectID = defectID;
                editForm.defectName = defectName;
                editForm.defectLevel = defectLevel;
                editForm.moldAssembly = moldAssembly;
                editForm.mainStep = mainStep;
                editForm.defectType = defectType;
                editForm.userName = userName;
                editForm.ShowDialog();
                LoadData();
            }
        }
        private void BarNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BarIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridDefect.ShowPrintPreview();
        }
        private void BarXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridDefect.ExportToXlsx(saveFileDialog1.FileName);
            }
        }
        #endregion
    }
}
