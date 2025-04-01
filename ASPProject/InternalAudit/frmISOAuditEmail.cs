using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using ASPData.InternalAuditDTO;
using ASPData.InternalAuditDAO;
using System.Runtime.CompilerServices;
using ASPProject.InternalAudit;

//using ASPProject.class_TungLam;

namespace ASPProject
{
    public partial class frmISOAuditEmail : DevExpress.XtraEditors.XtraForm
    {
        #region declare
        public string userName;
        public int iNgonNgu, curIndex;
        string deptID, factoryID, glSignedID, headSignedID, deptSignedID;
       
        InternalAuditDTO isoDto = new InternalAuditDTO();
        InternalAuditDAO isoDao = new InternalAuditDAO();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        #endregion

        #region constructor
        public frmISOAuditEmail()
        {
            InitializeComponent();

            this.Load += frmISOAuditEmail_Load;
            this.barThoat.ItemClick += BarThoat_ItemClick;
            this.gridISOAuditEmailView.RowClick += GridEmpView_RowClick;
            this.gridISOAuditEmailView.DoubleClick += GridEmpView_DoubleClick;
            this.barXuat.ItemClick += barXuat_ItemClick;
            this.barNapLai.ItemClick += barNapLai_ItemClick;
            this.barSua.ItemClick += BarSua_ItemClick;
            this.barXoa.ItemClick += BarXoa_ItemClick;
            this.barThem.ItemClick += BarThem_ItemClick;
        }
        #endregion

        #region Load
        private void frmISOAuditEmail_Load(object sender, EventArgs e)
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
            gridISOAuditEmail.DataSource = isoDao.GetAllISOAuditEmail();
        }
        #endregion

        #region Event
        private void BarSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmISOAuditEmailEdit editForm = new frmISOAuditEmailEdit();

            editForm.editType = 0;
            editForm.deptID = deptID;
            editForm.factoryID = factoryID;
            editForm.deptSignedID = deptSignedID;
            editForm.glSignedID = glSignedID;
            editForm.headSignedID = headSignedID;
            editForm.userName = userName;
            editForm.editType = 1;

            if (string.IsNullOrEmpty(deptID) || string.IsNullOrEmpty(factoryID))
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
                editForm.ShowDialog();
                LoadData();
            }
        }

        private void BarXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(deptID) && !string.IsNullOrEmpty(factoryID))
            {
                isoDto.DeptID = deptID;
                isoDto.FactoryID = factoryID;

                isoDao.DeleteISOAuditEmail(isoDto);

                XtraMessageBox.Show("Đã xoá thành công.");

                LoadData();
            }
        }
        private void BarThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmISOAuditEmailEdit th = new frmISOAuditEmailEdit();
            th.userName = userName;
            th.editType = 0;
            th.iNgonNgu = iNgonNgu;
            th.ShowDialog();
            LoadData();
        }
        
        private void BarThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deDongTab();
        }

        private void GridEmpView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dtr = gridISOAuditEmailView.GetDataRow(e.RowHandle);
            if (dtr  != null)
            {
                deptID = dtr["DeptID"].ToString();
                factoryID = dtr["FactoryID"].ToString();
                glSignedID = dtr["GLSignedID"].ToString() ;
                headSignedID = dtr["HeadSignedID"].ToString();
                deptSignedID = dtr["DeptSignedID"].ToString();
            }    
        }

        private void GridEmpView_DoubleClick(object sender, EventArgs e)
        {
            BarSua_ItemClick(null, null);
        }

        private void barXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridISOAuditEmail.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void barNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }
        #endregion
    }
}