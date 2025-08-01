using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using ASPData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ASPProject.LineProdStatistic
{
    public partial class frmPSRptDetailJig : DevExpress.XtraEditors.XtraForm
    {
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;

        private BindingSource bdsRptJig = new BindingSource();
        DataTable dtRptJig = new DataTable();

        SQLHelper sqlHelper = new SQLHelper();

        ProdStatisticDTO pDto = new ProdStatisticDTO();
        ProdStatisticDAO pDao = new ProdStatisticDAO();

        public frmPSRptDetailJig()
        {
            InitializeComponent();

            this.Load += FrmPSRptDetailJig_Load;
            this.btFilter.Click += BtFilter_Click;
            this.btExport.Click += BtExport_Click;
            this.btRestart.Click += BtRestart_Click;


        }


        private void BtRestart_Click(object sender, EventArgs e)
        {
            foreach (DataRow drJig in dtRptJig.Rows)
            {
                if ((bool)drJig["IsChecked"] == true)
                {
                    string strJigID = (string)drJig["JigID"];
                    var dicParams = new Dictionary<string, object>()
                    {
                        { "@IsChecked", false },
                        { "@IsRestart", 1 },
                        { "@JigID", strJigID },
                        { "@TypeUpdate", 1 }
                    };

                    sqlHelper.ExecProcedureNonData("sp_ASPUpdateJigSummary", dicParams);
                }
            }

            XtraMessageBox.Show("Đã bắt đầu lại xong.");
        }

        private void BtExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridMachine.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void FrmPSRptDetailJig_Load(object sender, EventArgs e)
        {
            dtFromDate.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            dtToDate.EditValue = DateTime.Now.Date;

            FillData();

            gridMachineView.RowCellClick += GridMachineView_RowCellClick;
            gridMachineView.RowCellStyle += GridMachineView_RowCellStyle;
        }

        private void GridMachineView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            double diffNum = Convert.ToDouble(gridMachineView.GetRowCellValue(e.RowHandle, "DifferenceNum"));

            if (diffNum < 0)
            {
                e.Appearance.ForeColor = Color.DarkOrange;
            }
        }

        private void GridMachineView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DataRow drJig = ((DataRowView)bdsRptJig.Current).Row;

            switch (e.Column.Name)
            {
                case "IsChecked":
                    if (XtraMessageBox.Show("Bạn có muốn hoàn thành kiểm tra QC Jig này không ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;

                    if (Convert.ToDouble(drJig["Quantity"]) < Convert.ToDouble(drJig["QuotaQuantity"]))
                    {
                        XtraMessageBox.Show("Bạn chưa được hoàn thành kiểm tra QC Jig này.", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    bool isChecked = (bool)drJig["IsChecked"];
                    bool isRestart = (bool)drJig["IsRestart"];
                    string strJigID = (string)drJig["JigID"];

                    var dicParams = new Dictionary<string, object>()
                        {
                            { "@IsChecked", !isChecked },
                            { "@IsCheckedKTV", (bool)drJig["IsCheckedKTV"] },
                            { "@IsRestart", isRestart },
                            { "@JigID", strJigID },
                            { "@TypeUpdate", 0 }
                        };

                    sqlHelper.ExecProcedureNonData("sp_ASPUpdateJigSummary", dicParams);

                    drJig["IsChecked"] = !isChecked;

                    break;
                case "IsCheckedKTV":
                    if (XtraMessageBox.Show("Bạn có muốn hoàn thành kiểm tra KTV Jig này không ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;

                    if (Convert.ToDouble(drJig["Quantity"]) < Convert.ToDouble(drJig["QuotaQuantity"]))
                    {
                        XtraMessageBox.Show("Bạn chưa được hoàn thành kiểm tra KTV Jig này.", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    bool isCheckedKTV = (bool)drJig["IsCheckedKTV"];
                    isRestart = (bool)drJig["IsRestart"];
                    strJigID = (string)drJig["JigID"];

                    dicParams = new Dictionary<string, object>()
                        {
                            { "@IsChecked", (bool)drJig["IsChecked"] },
                            { "@IsCheckedKTV", !isCheckedKTV },
                            { "@IsRestart", isRestart },
                            { "@JigID", strJigID },
                            { "@TypeUpdate", 0 }
                        };

                    sqlHelper.ExecProcedureNonData("sp_ASPUpdateJigSummary", dicParams);

                    drJig["IsCheckedKTV"] = !isCheckedKTV;

                    break;
                case "IsRestart":
                    if (XtraMessageBox.Show("Bạn có muốn bắt đầu lại Jig này không ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;

                    isRestart = (bool)drJig["IsRestart"];
                    isChecked = (bool)drJig["IsChecked"];
                    isCheckedKTV = (bool)drJig["IsCheckedKTV"];

                    if (isChecked == false || isCheckedKTV == false)
                    {
                        XtraMessageBox.Show("Bạn chưa được bắt đầu lại Jig này.", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    if (isRestart == false)
                    {
                        strJigID = (string)drJig["JigID"];
                        dicParams = new Dictionary<string, object>()
                            {
                                { "@IsChecked", false },
                                { "@IsCheckedKTV", false },
                                { "@IsRestart", !isRestart },
                                { "@JigID", strJigID },
                                { "@TypeUpdate", 1 }
                            };

                        sqlHelper.ExecProcedureNonData("sp_ASPUpdateJigSummary", dicParams);

                        drJig["IsRestart"] = !isRestart;
                    }

                    break;
                default:
                    break;
            }
        }

        //private void GridRptJigView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        //{
        //    DataRow drJig = ((DataRowView)bdsRptJig.Current).Row;

        //    switch (e.Column.Name)
        //    {
        //        case "colIsChecked":
        //            if (XtraMessageBox.Show("Bạn có muốn hoàn thành kiểm tra Jig này không ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        //                return;

        //            if (Convert.ToDouble(drJig["Quantity"]) < Convert.ToDouble(drJig["QuotaQuantity"]))
        //            {
        //                XtraMessageBox.Show("Bạn chưa được hoàn thành kiểm tra Jig này.", "Thông báo", MessageBoxButtons.OK);
        //                return;
        //            }

        //            bool isChecked = (bool)drJig["IsChecked"];
        //            string strJigID = (string)drJig["JigID"];

        //            var dicParams = new Dictionary<string, object>()
        //            {
        //                { "@IsChecked", !isChecked },
        //                { "@JigID", strJigID },
        //                { "@TypeUpdate", 0 }
        //            };

        //            sqlHelper.ExecProcedureNonData("sp_ASPUpdateJigSummary", dicParams);

        //            drJig["IsChecked"] = !isChecked;

        //            break;
        //        case "colIsRestart":
        //            if (XtraMessageBox.Show("Bạn có muốn bắt đầu lại Jig này không ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        //                return;

        //            bool isRestart = (bool)drJig["IsRestart"];
        //            isChecked = (bool)drJig["IsChecked"];

        //            if (isChecked == false)
        //            {
        //                XtraMessageBox.Show("Bạn chưa được bắt đầu lại Jig này.", "Thông báo", MessageBoxButtons.OK);
        //                return;
        //            }

        //            if (isRestart == false)
        //            {
        //                strJigID = (string)drJig["JigID"];
        //                dicParams = new Dictionary<string, object>()
        //                {
        //                    { "@IsChecked", false },
        //                    { "@IsRestart", !isRestart },
        //                    { "@JigID", strJigID },
        //                    { "@TypeUpdate", 1 }
        //                };

        //                sqlHelper.ExecProcedureNonData("sp_ASPUpdateJigSummary", dicParams);

        //                drJig["IsRestart"] = !isRestart;
        //            }

        //            break;
        //        default:
        //            break;
        //    }
        //}

        //private void GridRptJigView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        //{
        //    double diffNum = Convert.ToDouble(gridRptJigView.GetRowCellValue(e.RowHandle, "DifferenceNum"));

        //    if (diffNum < 0)
        //    {
        //        e.Appearance.ForeColor = Color.DarkOrange;
        //    }
        //}

        private bool FormCheckValid()
        {
            if (Convert.ToDateTime(dtFromDate.EditValue).Year < 2000 || Convert.ToDateTime(dtToDate.EditValue).Year < 2000)
            {
                XtraMessageBox.Show("Vui lòng nhập đủ ngày để lọc dữ liệu");
                return false;
            }

            return true;
        }

        private void FillData()
        {
            if (!FormCheckValid())
                return;

            pDto.FromDate = Convert.ToDateTime(dtFromDate.EditValue);
            pDto.ToDate = Convert.ToDateTime(dtToDate.EditValue);
            pDto.Username = userName;

            dtRptJig = pDao.GetDetailTableJig(pDto);

            bdsRptJig.DataSource = dtRptJig;
            gridMachine.DataSource = bdsRptJig;
        }

        //private void gridRptJigView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
