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
        private bool loadingHeaders;
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
            this.barLock.ItemClick += BarLock_ItemClick;
            this.btApproved.ItemClick += BtApproved_ItemClick;
            this.bdsIQC.PositionChanged += BdsIQC_PositionChanged;
            this.gridIQCHeaderView.FocusedRowChanged += (sender, e) => SyncCurrentHeader();
            this.gridIQCHeaderView.RowStyle += GridIQCHeaderView_RowStyle;
            this.gridIQCHeaderView.SelectionChanged += (sender, e) => UpdateButtonStates();

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
            UpdateButtonStates();
        }

        public void LoadEL()
        {
            iNgonNgu = 1;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
            UpdateButtonStates();
        }

        private void LoadData()
        {
            //header
            dtIQC = iqcDao.GetAllIQCChecking(userName, Convert.ToDateTime(dtpFromDate.EditValue).Date, Convert.ToDateTime(dtpToDate.EditValue).Date, Convert.ToString(cboStatus.EditValue));

            loadingHeaders = true;
            try
            {
                bdsIQC.DataSource = dtIQC;
                gridIQCHeader.DataSource = bdsIQC;
            }
            finally
            {
                loadingHeaders = false;
            }

            SyncCurrentHeader();
            gridIQCHeaderView.Invalidate();
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
            if (IsHeaderLocked(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã bị khóa, không thể sửa." : "Document is locked, cannot edit.");
                return;
            }

            if (IsHeaderApproved(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã được duyệt, không thể sửa." : "Document is approved, cannot edit.");
                return;
            }

            if (drCurrent == null || string.IsNullOrEmpty(Convert.ToString(drCurrent["WODocNo"])))
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
                th.HeaderID = (long)Convert.ToDouble(drCurrent["HeaderID"]);
                th.factoryID = Convert.ToString(drCurrent["FactoryID"]);
                th.docDate = Convert.ToDateTime(drCurrent["DocDate"]);
                th.prodStatus = Convert.ToString(drCurrent["ProdStatus"]);
                th.checkState = Convert.ToString(drCurrent["CheckState"]);
                th.stageOfChecking = Convert.ToString(drCurrent["StateOfChecking"]);
                th.WODocNo = Convert.ToString(drCurrent["WODocNo"]);
                th.lineID = drCurrent.Table.Columns.Contains("LineID") ? Convert.ToString(drCurrent["LineID"]) : string.Empty;
                th.qcID = Convert.ToString(drCurrent["QCID"]);
                th.productID = drCurrent.Table.Columns.Contains("ProductID") ? Convert.ToString(drCurrent["ProductID"]) : string.Empty;
                th.customerID = drCurrent.Table.Columns.Contains("CustomerID") ? Convert.ToString(drCurrent["CustomerID"]) : string.Empty;
                th.prodReqQuantity = drCurrent.Table.Columns.Contains("ProdReqQuantity") && drCurrent["ProdReqQuantity"] != DBNull.Value ? Convert.ToDouble(drCurrent["ProdReqQuantity"]) : 0;
                th.ShowDialog();
                LoadData();
            }
        }

        private void BarXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsHeaderLocked(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã bị khóa, không thể xóa." : "Document is locked, cannot delete.");
                return;
            }

            if (IsHeaderApproved(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã được duyệt, không thể xóa." : "Document is approved, cannot delete.");
                return;
            }

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
            SyncCurrentHeader();
        }

        private void SyncCurrentHeader()
        {
            if (loadingHeaders)
                return;

            DataRow row = gridIQCHeaderView.GetFocusedDataRow();
            bool changed = !ReferenceEquals(drCurrent, row);
            drCurrent = row;
            curIndex = gridIQCHeaderView.FocusedRowHandle;
            if (row == null)
            {
                HeaderID = 0;
                bdsIQCChkCont.DataSource = null;
                bdsIQCActualChk.DataSource = null;
                bdsIQCCheckDefect.DataSource = null;
                UpdateButtonStates();
                return;
            }

            if (!changed)
            {
                UpdateButtonStates();
                return;
            }

            HeaderID = Convert.ToInt64(drCurrent["HeaderID"]);
            factoryID = Convert.ToString(row["FactoryID"]);
            docDate = Convert.ToDateTime(row["DocDate"]);
            prodStatus = Convert.ToString(row["ProdStatus"]);
            WODocNo = Convert.ToString(row["WODocNo"]);
            idQC = Convert.ToString(row["QCID"]);
            checkState = Convert.ToString(row["CheckState"]);
            stageOfChecking = Convert.ToString(row["StateOfChecking"]);
            LoadDataDetail(HeaderID);
            UpdateButtonStates();
        }

        private void GridIQCHeaderView_DoubleClick(object sender, EventArgs e)
        {
            var mouseArgs = e as MouseEventArgs;
            Point pt = mouseArgs != null ? mouseArgs.Location : gridIQCHeader.PointToClient(Control.MousePosition);
            var hitInfo = gridIQCHeaderView.CalcHitInfo(pt);
            if (hitInfo.InRowCell && hitInfo.Column != null && hitInfo.Column.FieldName == "DX$CheckboxSelectorColumn")
                return;

            BarSua_ItemClick(null, null);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GridIQCHeaderView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SyncCurrentHeader();
        }

        private void BtStatDelete_Click(object sender, EventArgs e)
        {
            if (IsHeaderLocked(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã bị khóa, không thể xóa chi tiết." : "Document is locked, cannot delete details.");
                return;
            }

            if (IsHeaderApproved(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã được duyệt, không thể xóa chi tiết." : "Document is approved, cannot delete details.");
                return;
            }

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
            if (IsHeaderLocked(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã bị khóa, không thể sửa chi tiết." : "Document is locked, cannot edit details.");
                return;
            }

            if (IsHeaderApproved(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã được duyệt, không thể sửa chi tiết." : "Document is approved, cannot edit details.");
                return;
            }

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
                    frmPsEmp.checkState = drContCurrent.Table.Columns.Contains("CheckState") && drContCurrent["CheckState"] != DBNull.Value
                        ? Convert.ToString(drContCurrent["CheckState"]) : string.Empty;

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
                    frm.iqcCheckID = Convert.ToString(drActualCurrent["IQCCheckID"]);
                    frm.iqcStandardMin = Convert.ToString(drActualCurrent["IQCStandardMin"]);
                    frm.iqcStandardMax = Convert.ToString(drActualCurrent["IQCStandardMax"]);
                    frm.iqcDFID = Convert.ToString(drActualCurrent["IQCDFID"]);
                    frm.checkState = drActualCurrent.Table.Columns.Contains("CheckState") && drActualCurrent["CheckState"] != DBNull.Value
                        ? Convert.ToString(drActualCurrent["CheckState"]) : string.Empty;
                    frm.iqcCheckingContent = drActualCurrent.Table.Columns.Contains("IQCCheckingContent")
                        ? Convert.ToString(drActualCurrent["IQCCheckingContent"]) : string.Empty;
                    frm.iqcEvalueCheckTime = drActualCurrent.Table.Columns.Contains("IQCEvalueCheckTime")
                        ? Convert.ToString(drActualCurrent["IQCEvalueCheckTime"]) : string.Empty;
                    frm.iqcDeviceID = drActualCurrent.Table.Columns.Contains("IQCDeviceID")
                        ? Convert.ToString(drActualCurrent["IQCDeviceID"]) : string.Empty;
                    frm.iqcMeasuringToolID = drActualCurrent.Table.Columns.Contains("IQCMeasuringToolID")
                        ? Convert.ToString(drActualCurrent["IQCMeasuringToolID"]) : string.Empty;
                    frm.iqcEvalueResult = drActualCurrent.Table.Columns.Contains("IQCEvalueResult")
                        ? Convert.ToString(drActualCurrent["IQCEvalueResult"]) : string.Empty;
                    frm.iqcCutterID = drActualCurrent.Table.Columns.Contains("IQCCutterID")
                        ? Convert.ToString(drActualCurrent["IQCCutterID"]) : string.Empty;
                    frm.iqcEvalueActual = drActualCurrent.Table.Columns.Contains("IQCEvalueActual") && drActualCurrent["IQCEvalueActual"] != DBNull.Value
                        ? Convert.ToDouble(drActualCurrent["IQCEvalueActual"]) : 0;
                    frm.createdDate = drActualCurrent.Table.Columns.Contains("CreatedDate") && drActualCurrent["CreatedDate"] != DBNull.Value
                        ? Convert.ToDateTime(drActualCurrent["CreatedDate"]) : DateTime.Now;
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
            if (IsHeaderLocked(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã bị khóa, không thể sửa lỗi." : "Document is locked, cannot edit defects.");
                return;
            }

            if (IsHeaderApproved(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã được duyệt, không thể sửa lỗi." : "Document is approved, cannot edit defects.");
                return;
            }

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
            frm.defectDescription = drDefect.Table.Columns.Contains("DefectDescription") && drDefect["DefectDescription"] != DBNull.Value
                ? Convert.ToString(drDefect["DefectDescription"])
                : string.Empty;

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
            if (IsHeaderLocked(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã bị khóa, không thể thêm chi tiết." : "Document is locked, cannot add details.");
                return;
            }

            if (IsHeaderApproved(drCurrent))
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Chứng từ đã được duyệt, không thể thêm chi tiết." : "Document is approved, cannot add details.");
                return;
            }

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

        private List<DataRow> GetSelectedHeaderRows()
        {
            List<DataRow> list = new List<DataRow>();
            int[] selectedRowHandles = gridIQCHeaderView.GetSelectedRows();
            if (selectedRowHandles != null && selectedRowHandles.Length > 0)
            {
                foreach (int handle in selectedRowHandles)
                {
                    if (handle >= 0)
                    {
                        DataRow row = gridIQCHeaderView.GetDataRow(handle);
                        if (row != null && !list.Contains(row))
                            list.Add(row);
                    }
                }
            }

            if (list.Count == 0 && drCurrent != null)
            {
                list.Add(drCurrent);
            }

            return list;
        }

        private void BarLock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<DataRow> selectedRows = GetSelectedHeaderRows();
            if (selectedRows.Count == 0)
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Vui lòng chọn thông tin cần khóa/mở khóa." : "Please select information to lock/unlock.");
                return;
            }

            List<DataRow> unlockedRows = selectedRows.Where(r => !IsHeaderLocked(r)).ToList();
            List<DataRow> lockedRows = selectedRows.Where(r => IsHeaderLocked(r)).ToList();

            // Trường hợp 1: Tất cả các dòng chọn đều chưa khóa -> Xác nhận Khóa
            if (lockedRows.Count == 0)
            {
                string confirmMsg = selectedRows.Count == 1
                    ? (iNgonNgu == 0 ? "Bạn có chắc chắn muốn khóa kiểm tra IQC này không ?" : "Are you sure you want to lock this IQC check?")
                    : (iNgonNgu == 0 ? $"Bạn có chắc chắn muốn khóa {unlockedRows.Count} kiểm tra IQC đã chọn không ?" : $"Are you sure you want to lock {unlockedRows.Count} selected IQC check(s)?");

                if (XtraMessageBox.Show(confirmMsg, "Confirm / Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExecuteLockUnlockBatch(unlockedRows, true);
                }
                return;
            }

            // Trường hợp 2: Tất cả các dòng chọn đều đã khóa -> Xác nhận Mở khóa
            if (unlockedRows.Count == 0)
            {
                string confirmMsg = selectedRows.Count == 1
                    ? (iNgonNgu == 0 ? "Bạn có chắc chắn muốn mở khóa kiểm tra IQC này không ?" : "Are you sure you want to unlock this IQC check?")
                    : (iNgonNgu == 0 ? $"Bạn có chắc chắn muốn mở khóa {lockedRows.Count} kiểm tra IQC đã chọn không ?" : $"Are you sure you want to unlock {lockedRows.Count} selected IQC check(s)?");

                if (XtraMessageBox.Show(confirmMsg, "Confirm / Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExecuteLockUnlockBatch(lockedRows, false);
                }
                return;
            }

            // Trường hợp 3: Danh sách hỗn hợp (vừa có dòng khóa, vừa có dòng mở)
            string mixedMsg = iNgonNgu == 0
                ? string.Format("Danh sách chọn có {0} chứng từ chưa khóa và {1} chứng từ đã khóa.\r\n\r\n- Chọn 'Yes' để KHÓA {0} chứng từ chưa khóa.\r\n- Chọn 'No' để MỞ KHÓA {1} chứng từ đã khóa.\r\n- Chọn 'Cancel' để hủy bỏ.", unlockedRows.Count, lockedRows.Count)
                : string.Format("Selected list contains {0} unlocked and {1} locked document(s).\r\n\r\n- Select 'Yes' to LOCK {0} unlocked document(s).\r\n- Select 'No' to UNLOCK {1} locked document(s).\r\n- Select 'Cancel' to abort.", unlockedRows.Count, lockedRows.Count);

            DialogResult dr = XtraMessageBox.Show(mixedMsg, "Confirm / Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ExecuteLockUnlockBatch(unlockedRows, true);
            }
            else if (dr == DialogResult.No)
            {
                ExecuteLockUnlockBatch(lockedRows, false);
            }
        }

        private void BtApproved_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<DataRow> selectedRows = GetSelectedHeaderRows();
            if (selectedRows.Count == 0)
            {
                XtraMessageBox.Show(iNgonNgu == 0 ? "Vui lòng chọn thông tin cần duyệt/mở duyệt." : "Please select information to approve/unapprove.");
                return;
            }

            List<DataRow> unapprovedRows = selectedRows.Where(r => !IsHeaderApproved(r)).ToList();
            List<DataRow> approvedRows = selectedRows.Where(r => IsHeaderApproved(r)).ToList();

            // Trường hợp 1: Tất cả các dòng chọn đều chưa duyệt -> Xác nhận Duyệt
            if (approvedRows.Count == 0)
            {
                string confirmMsg = selectedRows.Count == 1
                    ? (iNgonNgu == 0 ? "Bạn có chắc chắn muốn duyệt kiểm tra IQC này không ?" : "Are you sure you want to approve this IQC check?")
                    : (iNgonNgu == 0 ? $"Bạn có chắc chắn muốn duyệt {unapprovedRows.Count} kiểm tra IQC đã chọn không ?" : $"Are you sure you want to approve {unapprovedRows.Count} selected IQC check(s)?");

                if (XtraMessageBox.Show(confirmMsg, "Confirm / Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExecuteApproveBatch(unapprovedRows, true);
                }
                return;
            }

            // Trường hợp 2: Tất cả các dòng chọn đều đã duyệt -> Xác nhận Mở duyệt
            if (unapprovedRows.Count == 0)
            {
                string confirmMsg = selectedRows.Count == 1
                    ? (iNgonNgu == 0 ? "Bạn có chắc chắn muốn mở duyệt kiểm tra IQC này không ?" : "Are you sure you want to unapprove this IQC check?")
                    : (iNgonNgu == 0 ? $"Bạn có chắc chắn muốn mở duyệt {approvedRows.Count} kiểm tra IQC đã chọn không ?" : $"Are you sure you want to unapprove {approvedRows.Count} selected IQC check(s)?");

                if (XtraMessageBox.Show(confirmMsg, "Confirm / Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExecuteApproveBatch(approvedRows, false);
                }
                return;
            }

            // Trường hợp 3: Danh sách hỗn hợp (vừa có dòng duyệt, vừa có dòng mở duyệt)
            string mixedMsg = iNgonNgu == 0
                ? string.Format("Danh sách chọn có {0} chứng từ chưa duyệt và {1} chứng từ đã duyệt.\r\n\r\n- Chọn 'Yes' để DUYỆT {0} chứng từ chưa duyệt.\r\n- Chọn 'No' để MỞ DUYỆT {1} chứng từ đã duyệt.\r\n- Chọn 'Cancel' để hủy bỏ.", unapprovedRows.Count, approvedRows.Count)
                : string.Format("Selected list contains {0} unapproved and {1} approved document(s).\r\n\r\n- Select 'Yes' to APPROVE {0} unapproved document(s).\r\n- Select 'No' to UNAPPROVE {1} approved document(s).\r\n- Select 'Cancel' to abort.", unapprovedRows.Count, approvedRows.Count);

            DialogResult dr = XtraMessageBox.Show(mixedMsg, "Confirm / Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ExecuteApproveBatch(unapprovedRows, true);
            }
            else if (dr == DialogResult.No)
            {
                ExecuteApproveBatch(approvedRows, false);
            }
        }

        private void ExecuteLockUnlockBatch(List<DataRow> rows, bool isLocked)
        {
            if (rows == null || rows.Count == 0)
                return;

            List<long> headerIDs = new List<long>();
            foreach (DataRow row in rows)
            {
                if (row.Table.Columns.Contains("HeaderID") && row["HeaderID"] != DBNull.Value)
                {
                    headerIDs.Add(Convert.ToInt64(row["HeaderID"]));
                }
            }

            if (headerIDs.Count == 0)
                return;

            try
            {
                iqcDao.LockUnlockIQCCheckingBatch(headerIDs, isLocked);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show((iNgonNgu == 0
                    ? "Không thể cập nhật trạng thái khóa. "
                    : "Unable to update lock status. ") + ex.Message,
                    iNgonNgu == 0 ? "Lỗi" : "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Keep the existing binding, row order, focus and detail data intact.
            foreach (DataRow row in rows)
            {
                if (!row.Table.Columns.Contains("isLocked"))
                    row.Table.Columns.Add("isLocked", typeof(bool));
                row["isLocked"] = isLocked;
            }

            UpdateButtonStates();
            gridIQCHeaderView.Invalidate();

            string actionText = isLocked ? (iNgonNgu == 0 ? "khóa" : "locked") : (iNgonNgu == 0 ? "mở khóa" : "unlocked");
            string successMsg = iNgonNgu == 0
                ? $"Đã {actionText} thành công {headerIDs.Count} chứng từ kiểm tra IQC."
                : $"Successfully {actionText} {headerIDs.Count} IQC check document(s).";
            XtraMessageBox.Show(successMsg, "Thông báo / Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExecuteApproveBatch(List<DataRow> rows, bool isApproved)
        {
            if (rows == null || rows.Count == 0)
                return;

            List<long> headerIDs = new List<long>();
            foreach (DataRow row in rows)
            {
                if (row.Table.Columns.Contains("HeaderID") && row["HeaderID"] != DBNull.Value)
                {
                    headerIDs.Add(Convert.ToInt64(row["HeaderID"]));
                }
            }

            if (headerIDs.Count == 0)
                return;

            DateTime actionDate = DateTime.Now;

            try
            {
                // Gọi DAO cập nhật DB
                iqcDao.ApproveUnapproveIQCCheckingBatch(headerIDs, isApproved, userName, actionDate);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show((iNgonNgu == 0
                    ? "Không thể cập nhật trạng thái duyệt. "
                    : "Unable to update approve status. ") + ex.Message,
                    iNgonNgu == 0 ? "Lỗi" : "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đảm bảo DataTable có đầy đủ các cột hiển thị
            foreach (DataRow row in rows)
            {
                if (!row.Table.Columns.Contains("isApproved"))
                    row.Table.Columns.Add("isApproved", typeof(bool));
                if (!row.Table.Columns.Contains("ApprovedBy"))
                    row.Table.Columns.Add("ApprovedBy", typeof(string));
                if (!row.Table.Columns.Contains("ApprovedDate"))
                    row.Table.Columns.Add("ApprovedDate", typeof(DateTime));
                if (!row.Table.Columns.Contains("DeclinedBy"))
                    row.Table.Columns.Add("DeclinedBy", typeof(string));
                if (!row.Table.Columns.Contains("DeclinedDate"))
                    row.Table.Columns.Add("DeclinedDate", typeof(DateTime));

                row["isApproved"] = isApproved;
                if (isApproved)
                {
                    row["ApprovedBy"] = userName;
                    row["ApprovedDate"] = actionDate;
                }
                else
                {
                    row["ApprovedBy"] = DBNull.Value;
                    row["ApprovedDate"] = DBNull.Value;
                    row["DeclinedBy"] = userName;
                    row["DeclinedDate"] = actionDate;
                }
            }

            UpdateButtonStates();
            gridIQCHeaderView.Invalidate();

            string actionText = isApproved ? (iNgonNgu == 0 ? "duyệt" : "approved") : (iNgonNgu == 0 ? "mở duyệt" : "unapproved");
            string successMsg = iNgonNgu == 0
                ? $"Đã {actionText} thành công {headerIDs.Count} chứng từ kiểm tra IQC."
                : $"Successfully {actionText} {headerIDs.Count} IQC check document(s).";
            XtraMessageBox.Show(successMsg, "Thông báo / Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetCurrentHeaderLocked(bool isLocked)
        {
            if (drCurrent != null)
            {
                ExecuteLockUnlockBatch(new List<DataRow> { drCurrent }, isLocked);
            }
        }

        private static bool IsHeaderLocked(DataRow row)
        {
            return row != null && row.Table.Columns.Contains("isLocked")
                && row["isLocked"] != DBNull.Value && Convert.ToBoolean(row["isLocked"]);
        }

        private static bool IsHeaderApproved(DataRow row)
        {
            return row != null && row.Table.Columns.Contains("isApproved")
                && row["isApproved"] != DBNull.Value && Convert.ToBoolean(row["isApproved"]);
        }

        private void GridIQCHeaderView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0 || !IsHeaderLocked(gridIQCHeaderView.GetDataRow(e.RowHandle)))
                return;

            bool selected = gridIQCHeaderView.IsRowSelected(e.RowHandle)
                || gridIQCHeaderView.FocusedRowHandle == e.RowHandle;
            e.Appearance.BackColor = selected ? Color.FromArgb(255, 230, 153) : Color.FromArgb(255, 242, 204);
            e.Appearance.BackColor2 = e.Appearance.BackColor;
            e.Appearance.ForeColor = Color.Black;
            e.HighPriority = true;
        }

        private void UpdateButtonStates()
        {
            if (drCurrent == null)
            {
                barSua.Enabled = false;
                barXoa.Enabled = false;
                barLock.Enabled = false;
                btApproved.Enabled = false;
                btStatAdd.Enabled = false;
                btStatEdit.Enabled = false;
                btStatDelete.Enabled = false;
                barLock.Caption = iNgonNgu == 0 ? "Khóa" : "Lock";
                btApproved.Caption = iNgonNgu == 0 ? "Duyệt" : "Approve";
                return;
            }

            barLock.Enabled = true;
            btApproved.Enabled = true;

            bool currentLocked = IsHeaderLocked(drCurrent);
            bool currentApproved = IsHeaderApproved(drCurrent);

            // Bị Khóa hoặc đã Duyệt thì không cho phép Sửa/Xóa Header lẫn Detail
            bool canEdit = !currentLocked && !currentApproved;
            barSua.Enabled = canEdit;
            barXoa.Enabled = canEdit;
            btStatAdd.Enabled = canEdit;
            btStatEdit.Enabled = canEdit;
            btStatDelete.Enabled = canEdit;

            List<DataRow> selectedRows = GetSelectedHeaderRows();

            // Cập nhật Caption nút Khóa
            if (selectedRows.Count > 1)
            {
                bool allLocked = selectedRows.All(r => IsHeaderLocked(r));
                barLock.Caption = allLocked ? (iNgonNgu == 0 ? "Mở khóa" : "Unlock") : (iNgonNgu == 0 ? "Khóa" : "Lock");
            }
            else
            {
                barLock.Caption = currentLocked ? (iNgonNgu == 0 ? "Mở khóa" : "Unlock") : (iNgonNgu == 0 ? "Khóa" : "Lock");
            }

            // Cập nhật Caption nút Duyệt
            if (selectedRows.Count > 1)
            {
                bool allApproved = selectedRows.All(r => IsHeaderApproved(r));
                btApproved.Caption = allApproved ? (iNgonNgu == 0 ? "Mở duyệt" : "Unapprove") : (iNgonNgu == 0 ? "Duyệt" : "Approve");
            }
            else
            {
                btApproved.Caption = currentApproved ? (iNgonNgu == 0 ? "Mở duyệt" : "Unapprove") : (iNgonNgu == 0 ? "Duyệt" : "Approve");
            }
        }
        #endregion
    }
}