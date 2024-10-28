using ASPData;
using ASPData.ASPDAO;
using ASPData.ASPDTO;
using ASPData.ProdStatisticDTO;
using ASPProject.LineProdStatistic;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASPProject.ExternalIQC
{
    public partial class frmExternalIQC : DevExpress.XtraEditors.XtraForm
    {
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;
        private DataTable dtIQC = new DataTable();
        private DataSet dsDetailIQC = new DataSet();
        private DataTable dtDefect = new DataTable();
        private BindingSource bdsIQC = new BindingSource();
        private BindingSource bdsIQCChkCont = new BindingSource();
        private BindingSource bdsIQCActualChk = new BindingSource();
        private BindingSource bdsIQCCheckDefect = new BindingSource();
        private DataRow drCurrent, drContCurrent, drActualCurrent, drDefect;
        public int curIndex, contIndex, actualIndex, dfIndex;
      
        IQCCheckingDTO iqcDto = new IQCCheckingDTO();
        IQCCheckingDAO iqcDao = new IQCCheckingDAO();

        IQCCheckListDTO iqcListDto = new IQCCheckListDTO();

        public long HeaderID, AutoID;
        public string WODocNo, productID, prodStatus, factoryID, idQC, checkState, stageOfChecking;
        public DateTime docDate;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        public frmExternalIQC()
        {
            InitializeComponent();

            new GridviewCheckbox(gridCheckContentView, this, gridCheckContentView.GetSelectedRows().ToList());
            new GridviewCheckbox(gridActualCheckView, this, gridActualCheckView.GetSelectedRows().ToList());

            gridIQCHeaderView.BestFitColumns();

            btStatEmpMulti.Visible = false;

            //default value
            dtpFromDate.EditValue = DateTime.Now;
            dtpToDate.EditValue = DateTime.Now;
            cboStatus.EditValue = "All";

            RepositoryItemComboBox resCbo = new RepositoryItemComboBox();
            resCbo.Items.Add("All");
            resCbo.Items.Add("Pilot");
            resCbo.Items.Add("Sample");
            resCbo.Items.Add("MP");

            cboStatus.Edit = resCbo;

            this.Load += FrmExternalIQC_Load;

            //event
            this.barThem.ItemClick += BarThem_ItemClick;
            this.barSua.ItemClick += BarSua_ItemClick;
            this.barThoat.ItemClick += BarThoat_ItemClick;
            this.barXoa.ItemClick += BarXoa_ItemClick;
            this.gridIQCHeaderView.RowClick += GridIQCHeaderView_RowClick;
            this.gridIQCHeaderView.DoubleClick += GridIQCHeaderView_DoubleClick;
            this.barLocNgay.ItemClick += BarLocNgay_ItemClick;
            this.bdsIQC.PositionChanged += BdsIQC_PositionChanged;

            //detail
            this.btStatAdd.Click += BtStatAdd_Click;
            this.btStatEdit.Click += BtStatEdit_Click;
            this.btStatEmpMulti.Click += BtStatEmpMulti_Click;
            this.btStatDelete.Click += BtStatDelete_Click;
            this.gridCheckContentView.DoubleClick += GridCheckContentView_DoubleClick;
            this.gridCheckContentView.RowClick += GridCheckContentView_RowClick;
            this.gridActualCheckView.DoubleClick += GridActualCheckView_DoubleClick;
            this.gridActualCheckView.RowClick += GridActualCheckView_RowClick;
            this.gridDefectView.DoubleClick += GridDefectView_DoubleClick;
            this.gridDefectView.RowClick += GridDefectView_RowClick;
            this.bdsIQCChkCont.PositionChanged += BdsIQCChkCont_PositionChanged;
            this.btExportReport.Click += BtExportReport_Click;
        }

        #region Load
        private void FrmExternalIQC_Load(object sender, EventArgs e)
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
            //header
            dtIQC = iqcDao.GetAllIQCChecking(userName, Convert.ToDateTime(dtpFromDate.EditValue).Date, Convert.ToDateTime(dtpToDate.EditValue).Date, Convert.ToString(cboStatus.EditValue));

            bdsIQC.DataSource = dtIQC;
            gridIQCHeader.DataSource = bdsIQC;

            //if (drCurrent == null)
            //    drCurrent = ((DataRowView)bdsIQC.Current).Row;

            if (drCurrent != null && dtIQC.Rows.Count > 0)
            {
                long HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);

                LoadDataDetail(HeaderID);
            }
            gridIQCHeaderView.SelectRow(curIndex);
        }
        private void LoadDataDetail(long HeaderID)
        {
            //detail
            dsDetailIQC = iqcDao.GetAllDetailIQCChecking(HeaderID);

            if (dsDetailIQC.Tables.Count >= 1)
            {
                bdsIQCChkCont.DataSource = dsDetailIQC.Tables[0];
                gridCheckContent.DataSource = bdsIQCChkCont;
                gridCheckContentView.ClearSelection();

                if (bdsIQCChkCont.Position >= 0)
                    idQC = (string)((DataRowView)bdsIQCChkCont.Current).Row["IQCCheckID"];

                if (HeaderID > 0)
                    LoadDataDetailDetail(HeaderID, idQC);
            }

            if (dsDetailIQC.Tables.Count >= 2)
            {
                bdsIQCActualChk.DataSource = dsDetailIQC.Tables[1];
                gridActualCheck.DataSource = bdsIQCActualChk;
                gridActualCheckView.ClearSelection();
            }
        }

        private void LoadDataDetailDetail(long HeaderID, string IQCCheckID)
        {
           
            if (bdsIQCChkCont.Position >= 0)
            {
                iqcListDto.HeaderID = HeaderID;

                iqcListDto.IQCCheckID = (string)((DataRowView)bdsIQCChkCont.Current).Row["IQCCheckID"];
                iqcListDto.CreatedBy = userName;
                iqcListDto.CreatedDate = DateTime.Now;
                dtDefect = iqcDao.GetAllIQCCheckDefect(iqcListDto);
                bdsIQCCheckDefect.DataSource = dtDefect;

                gridDefect.DataSource = bdsIQCCheckDefect;
                gridDefectView.ClearSelection();
            }  
        }
        #endregion

        #region Event
        private void BarThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExternalIQCEdit th = new frmExternalIQCEdit();
            th.editType = 1;
            th.userName = userName;
            th.ShowDialog();
            LoadData();
        }

        private void BarSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(WODocNo))
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
                frmExternalIQCEdit th = new frmExternalIQCEdit();
                th.editType = 0;
                th.userName = userName;
                th.HeaderID = HeaderID;
                th.factoryID = factoryID;
                th.docDate = docDate;
                th.prodStatus = prodStatus;
                th.checkState = checkState;
                th.stageOfChecking = stageOfChecking;
                th.WODocNo = WODocNo;
                th.qcID = idQC;
                th.ShowDialog();
                LoadData();
            }
        }

        private void BarXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắn chắn xoá kiểm tra IQC này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                iqcDto.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
                iqcDao.DeleteIQCCheckingHeader(iqcDto);
            }
            else return;

            LoadData();
        }

        private void BarThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deDongTab();
        }

        private void BarLocNgay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BdsIQC_PositionChanged(object sender, EventArgs e)
        {
            if (bdsIQC.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsIQC.Current).Row;

            LoadDataDetail(Convert.ToInt32(drCurrent["HeaderID"]));
        }

        private void GridIQCHeaderView_DoubleClick(object sender, EventArgs e)
        {
            BarSua_ItemClick(null, null);
        }

        private void GridIQCHeaderView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (bdsIQC.Position < 0)
                return;

            drCurrent = gridIQCHeaderView.GetDataRow(e.RowHandle);
            curIndex = e.RowHandle;

            HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
            factoryID = Convert.ToString(drCurrent["FactoryID"]);
            docDate = Convert.ToDateTime(drCurrent["DocDate"]);
            prodStatus = Convert.ToString(drCurrent["ProdStatus"]);
            WODocNo = Convert.ToString(drCurrent["WODocNo"]);
            idQC = Convert.ToString(drCurrent["QCID"]);
            checkState = Convert.ToString(drCurrent["CheckState"]);
            stageOfChecking = Convert.ToString(drCurrent["StateOfChecking"]);
        }

        private void BtStatDelete_Click(object sender, EventArgs e)
        {
            switch (tabPageProdStatDetail.SelectedTabPage.Name)
            {
                case "tabCheckContent":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn dòng ở lưới trên.");
                        return;
                    }
                    if (drContCurrent == null || string.IsNullOrEmpty(drContCurrent["IQCCheckID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn nội dung cần xoá.");
                        return;
                    }

                    if (XtraMessageBox.Show("Bạn có chắc chắc muốn xoá nội dung " + Convert.ToString(drContCurrent["IQCCheckID"]) + " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

                    iqcListDto.HeaderID = HeaderID;
                    iqcListDto.IQCCheckID = Convert.ToString(drContCurrent["IQCCheckID"]);
                    iqcDao.DeleteDetailIQCCheckContent(iqcListDto);

                    LoadData();

                    XtraMessageBox.Show("Đã xoá thành công.");

                    drContCurrent = null;
                    break;
                case "tabActualChecking":

                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn dòng ở lưới trên.");
                        return;
                    }

                    if (drActualCurrent == null || string.IsNullOrEmpty(drActualCurrent["AutoID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn nội dung cần xoá.");
                        return;
                    }

                    if (XtraMessageBox.Show("Bạn có chắc chắc muốn xoá nội dung này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

                    iqcListDto.AutoID = (long)Convert.ToDouble(drActualCurrent["AutoID"]);
                    iqcDao.DeleteDetailIQCActualCheck(iqcListDto);

                    LoadData();

                    XtraMessageBox.Show("Đã xoá thành công.");

                    drActualCurrent = null;
                    break;
                
                default:
                    break;
            }
        }

        private void BtStatEmpMulti_Click(object sender, EventArgs e)
        {
           
        }

        private void BtStatEdit_Click(object sender, EventArgs e)
        {
            switch (tabPageProdStatDetail.SelectedTabPage.Name)
            {
                case "tabCheckContent":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn dòng ở lưới trên.");
                        return;
                    }

                    if (drContCurrent == null || string.IsNullOrEmpty(drContCurrent["IQCCheckID"].ToString()))
                    {
                        XtraMessageBox.Show("Vui lòng click chọn nội dung cần sửa.");
                        return;
                    }

                    frmExternalIQCDetailContentEdit frmPsEmp = new frmExternalIQCDetailContentEdit();
                    frmPsEmp.editType = 0;
                    frmPsEmp.saveMulti = 0;
                    frmPsEmp.userName = userName;
                    frmPsEmp.HeaderID = HeaderID;
                    frmPsEmp.AutoID = (long)Convert.ToDouble(drContCurrent["AutoID"]);
                    frmPsEmp.iqcCheckID = (string)drContCurrent["IQCCheckID"];
                    frmPsEmp.iqcEvalueResult = (string)drContCurrent["IQCEvalueResult"];
                    frmPsEmp.iqcTemplateQuantity = Convert.ToDouble(drContCurrent["IQCTemplateQuantity"]);
                    frmPsEmp.iqcEvalueResult = (string)drContCurrent["IQCEvalueResult"];

                    frmPsEmp.ShowDialog();

                    LoadData();

                    gridCheckContentView.TopRowIndex = contIndex;
                    gridCheckContentView.FocusedRowHandle = contIndex;

                    break;
                case "tabActualChecking":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn dòng ở lưới trên.");
                        return;
                    }

                    frmExternalIQCDetailActualCheckEdit frm = new frmExternalIQCDetailActualCheckEdit();
                    frm.editType = 0;
                    frm.saveMulti = 0;
                    frm.userName = userName;
                    frm.HeaderID = HeaderID;
                    frm.AutoID = (long)Convert.ToDouble(drActualCurrent["AutoID"]);
                    frm.iqcCheckID = (string)drActualCurrent["IQCCheckID"];
                    frm.iqcStandardMin = (string)drActualCurrent["IQCStandardMin"];
                    frm.iqcStandardMax = (string)drActualCurrent["IQCStandardMax"];
                    frm.iqcDFID = (string)drActualCurrent["IQCDFID"];
                    frm.iqcEvalueActual = Convert.ToDouble(drActualCurrent["IQCEvalueActual"]);
                    frm.ShowDialog();

                    LoadData();
                    break;
                default:
                    break;
            }
        }

        private void GridCheckContentView_DoubleClick(object sender, EventArgs e)
        {
            BtStatEdit_Click(sender, e);
        }

        private void GridCheckContentView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            drContCurrent = gridCheckContentView.GetDataRow(e.RowHandle);
            contIndex = e.RowHandle;
        }

        private void GridActualCheckView_RowClick(object sender, RowClickEventArgs e)
        {
            drActualCurrent = gridActualCheckView.GetDataRow(e.RowHandle);
            actualIndex = e.RowHandle;
        }

        private void BdsIQCChkCont_PositionChanged(object sender, EventArgs e)
        {
            if (bdsIQCChkCont.Position >= 0 && drCurrent != null)
            {
                drContCurrent = ((DataRowView)bdsIQCChkCont.Current).Row;
                LoadDataDetailDetail((long)Convert.ToDouble(drCurrent["HeaderID"]), Convert.ToString(drContCurrent["IQCCheckID"]));
            }
        }
        private void BtExportReport_Click(object sender, EventArgs e)
        {
            
        }

        private void GridDefectView_RowClick(object sender, RowClickEventArgs e)
        {
           drDefect = gridDefectView.GetDataRow(e.RowHandle);
           dfIndex = e.RowHandle;
        }

        private void GridDefectView_DoubleClick(object sender, EventArgs e)
        {
            if (HeaderID == 0)
            {
                XtraMessageBox.Show("Vui lòng click chọn dòng ở lưới trên.");
                return;
            }

            if (drContCurrent == null || string.IsNullOrEmpty(drContCurrent["IQCCheckID"].ToString()))
            {
                XtraMessageBox.Show("Vui lòng click chọn công đoạn cần sửa.");
                return;
            }

            if (drDefect == null || string.IsNullOrEmpty(drDefect["DefectID"].ToString()))
            {
                XtraMessageBox.Show("Vui lòng click chọn nội dung cần sửa.");
                return;
            }

            frmIQCDetailDefectEdit frm = new frmIQCDetailDefectEdit();
            frm.editType = 0;
            frm.userName = userName;
            frm.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
            frm.AutoID = (long)Convert.ToDouble(drDefect["AutoID"]);
            frm.iqcCheckID = Convert.ToString(drContCurrent["IQCCheckID"]);
            frm.defectID = Convert.ToString(drDefect["DefectID"]);
            frm.defectQuantity = Convert.ToDouble(drDefect["DefectQuantity"]);

            frm.ShowDialog();

            LoadData();
            LoadDataDetailDetail((long)Convert.ToDouble(drCurrent["HeaderID"]), Convert.ToString(drContCurrent["IQCCheckID"]));

            gridDefectView.TopRowIndex = dfIndex;
            gridDefectView.FocusedRowHandle = dfIndex;
        }

        private void GridActualCheckView_DoubleClick(object sender, EventArgs e)
        {
            BtStatEdit_Click(sender, e);
        }

        private void BtStatAdd_Click(object sender, EventArgs e)
        {
            switch (tabPageProdStatDetail.SelectedTabPage.Name)
            {
                case "tabCheckContent":
                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn dòng ở lưới trên.");
                        return;
                    }

                    frmExternalIQCDetailContentEdit frmEmp = new frmExternalIQCDetailContentEdit();
                    frmEmp.userName = userName;
                    frmEmp.editType = 1;
                    frmEmp.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
                    frmEmp.ShowDialog();

                    LoadData();

                    break;
                case "tabActualChecking":

                    if (HeaderID == 0)
                    {
                        XtraMessageBox.Show("Vui lòng click chọn dòng ở lưới trên.");
                        return;
                    }

                    frmExternalIQCDetailActualCheckEdit frm = new frmExternalIQCDetailActualCheckEdit();
                    frm.userName = userName;
                    frm.editType = 1;
                    frm.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
                    frm.ShowDialog();

                    LoadData();
                    break;
                
                default:
                    break;
            }
        }
        #endregion
    }
}
