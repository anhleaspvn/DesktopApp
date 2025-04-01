using ASPData.ASPDAO;
using ASPData.LosstimeDTO;
using ASPData.TimekeepingDTO;
using ASPProject.Losstime;
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

namespace ASPProject.Timekeeping
{
    public partial class frmTimekeeping : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        string timekeepID, timekeepName;
        double timekeepHours, timekeepHoursMain, timekeepHoursOver, timeOffByDate, timeOffByDateTC;
        TimeSpan dateBeginTime, dateEndTime;

        TimekeepingDTO timekeepDto = new TimekeepingDTO();
        TimekeepingDAO timekeepDao = new TimekeepingDAO();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex;
        #endregion

        #region Constructor
        public frmTimekeeping()
        {
            InitializeComponent();

            this.Load += Timekeeping_Load;
            this.barThoat.ItemClick += BarThoat_ItemClick;
            this.barThem.ItemClick += BarThem_ItemClick;
            this.barSua.ItemClick += BarSua_ItemClick;
            this.barXoa.ItemClick += BarXoa_ItemClick;
            this.barIn.ItemClick += BarIn_ItemClick;
            this.barNapLai.ItemClick += BarNapLai_ItemClick;
            this.barXuat.ItemClick += BarXuat_ItemClick;

            this.gridTimekeepingView.RowClick += GridTimekeepingView_RowClick;
            this.gridTimekeepingView.DoubleClick += GridTimekeepingView_DoubleClick;
        }
        #endregion

        #region Load
        private void Timekeeping_Load(object sender, EventArgs e)
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
            gridTimekeeping.DataSource = timekeepDao.GetAllTimekeeping();
           // gridTimekeepingView.SelectRow(curIndex);
        }
        #endregion

        #region Event
        private void GridTimekeepingView_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(timekeepID))
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
                frmTimekeepingEdit editForm = new frmTimekeepingEdit();
                editForm.editType = 0;
                editForm.timekeepID = timekeepID;
                editForm.timekeepName = timekeepName;
                editForm.timekeepHours = timekeepHours;
                editForm.timekeepHoursMain = timekeepHoursMain;
                editForm.timekeepHoursOver = timekeepHoursOver;
                editForm.dateBeginTime = dateBeginTime;
                editForm.dateEndTime = dateEndTime;
                editForm.timeOffByDate = timeOffByDate;
                editForm.timeOffByDateTC = timeOffByDateTC;
                editForm.userName = userName;
                editForm.ShowDialog();
                LoadData();
            }
        }

        private void GridTimekeepingView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dtr = gridTimekeepingView.GetDataRow(e.RowHandle);
            timekeepID = dtr[0].ToString();
            textEdit1.Text = timekeepID.Trim().ToString();
            timekeepName = dtr[1].ToString();
            textEdit2.Text = timekeepName;
            timekeepHours = Convert.ToDouble(dtr[2]);
            timekeepHoursMain = Convert.ToDouble(dtr[3]);
            timekeepHoursOver = Convert.ToDouble(dtr[4]);
            dateBeginTime = TimeSpan.Parse(dtr[5].ToString());
            dateEndTime = TimeSpan.Parse(dtr[6].ToString());
            timeOffByDate = Convert.ToDouble(dtr[7]);
            timeOffByDateTC = Convert.ToDouble(dtr[8].ToString());
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
                gridTimekeeping.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void BarNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BarIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridTimekeeping.ShowPrintPreview();
        }

        private void BarXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(timekeepID))
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
                DialogResult a = XtraMessageBox.Show("Bạn có chắc xóa thông tin ký hiệu " + timekeepName + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.Yes)
                {

                    timekeepDto.TimekeepID = timekeepID;
                    timekeepDao.DeleteTimekeeping(timekeepDto);
                    LoadData();

                    timekeepID = string.Empty;
                    timekeepName = string.Empty;
                }
            }
            else
            {
                DialogResult a = XtraMessageBox.Show("Are you sure to delete timekeeping  " + timekeepName + " ???", "Warming", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.Yes)
                {
                    timekeepDto.TimekeepID = timekeepID;
                    timekeepDao.DeleteTimekeeping(timekeepDto);
                    LoadData();

                    timekeepID = string.Empty;
                    timekeepName = string.Empty;
                }
            }
        }

        private void BarSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTimekeepingEdit editForm = new frmTimekeepingEdit();
            editForm.editType = 0;

            if (string.IsNullOrEmpty(timekeepID))
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
                editForm.timekeepID = timekeepID;
                editForm.timekeepName = timekeepName;
                editForm.userName = userName;
                editForm.ShowDialog();
                LoadData();
            }
        }

        private void BarThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTimekeepingEdit th = new frmTimekeepingEdit();
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
