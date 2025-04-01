using ASPData.ASPDAO;
using ASPData.DefectiveModeDTO;
using ASPData.LosstimeDTO;
using ASPProject.DefectiveMode;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.Losstime
{
    public partial class frmLosstime : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        string losstimeID, losstimeName, losstimeType;
        
        LosstimeDTO losstimeDto = new LosstimeDTO();
        LosstimeDAO losstimeDao = new LosstimeDAO();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex;
        #endregion

        #region Constructor
        public frmLosstime()
        {
            InitializeComponent();

            this.Load += FrmLosstime_Load;

            this.barThoat.ItemClick += BarThoat_ItemClick;
            this.barThem.ItemClick += BarThem_ItemClick;
            this.barSua.ItemClick += BarSua_ItemClick;
            this.barXoa.ItemClick += BarXoa_ItemClick;
            this.barIn.ItemClick += BarIn_ItemClick;
            this.barNapLai.ItemClick += BarNapLai_ItemClick;
            this.barXuat.ItemClick += BarXuat_ItemClick;

            this.gridLosstimeView.RowClick += GridLosstimeView_RowClick;
            this.gridLosstimeView.DoubleClick += GridLosstimeView_DoubleClick;
        }
        #endregion

        #region Load
        private void FrmLosstime_Load(object sender, EventArgs e)
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
            gridLosstime.DataSource = losstimeDao.GetAllLosstime();
        }
        #endregion

        #region Event
        private void GridLosstimeView_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(losstimeID))
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
                frmLosstimeEdit editForm = new frmLosstimeEdit();
                editForm.editType = 0;
                editForm.losstimeID = losstimeID;
                editForm.losstimeName = losstimeName;
                editForm.losstimeType = losstimeType;
                editForm.userName = userName;
                editForm.ShowDialog();
                LoadData();
            }
        }

        private void GridLosstimeView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dtr = gridLosstimeView.GetDataRow(e.RowHandle);
            losstimeID = dtr[0].ToString();
            textEdit1.Text = losstimeID.Trim().ToString();
            losstimeName = dtr[1].ToString();
            losstimeType = dtr[2].ToString();
            textEdit2.Text = losstimeName;

            curIndex = e.RowHandle;
        }

        private void BarXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                gridLosstime.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void BarNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BarIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridLosstime.ShowPrintPreview();
        }

        private void BarXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(losstimeID))
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
                DialogResult a = XtraMessageBox.Show("Bạn có chắc xóa thông tin losstime " + losstimeName + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.Yes)
                {

                    losstimeDto.LosstimeID = losstimeID;
                    losstimeDao.DeleteLosstime(losstimeDto);
                    LoadData();

                    losstimeID = string.Empty;
                    losstimeName = string.Empty;
                }
            }
            else
            {
                DialogResult a = XtraMessageBox.Show("Are you sure to delete losstime  " + losstimeName + " ???", "Warming", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.Yes)
                {
                    losstimeDto.LosstimeID = losstimeID;
                    losstimeDao.DeleteLosstime(losstimeDto);
                    LoadData();

                    losstimeID = string.Empty;
                    losstimeName = string.Empty;
                }
            }
        }

        private void BarSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLosstimeEdit editForm = new frmLosstimeEdit();
            editForm.editType = 0;

            if (string.IsNullOrEmpty(losstimeID))
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
                editForm.losstimeID = losstimeID;
                editForm.losstimeName = losstimeName;
                editForm.losstimeType = losstimeType;
                editForm.userName = userName;
                editForm.ShowDialog();
                LoadData();
            }
        }

        private void BarThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLosstimeEdit th = new frmLosstimeEdit();
            th.editType = 1;
            th.userName = userName;
            th.ShowDialog();
            LoadData();
        }

        private void BarThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deDongTab();
        }
        #endregion
    }
}
