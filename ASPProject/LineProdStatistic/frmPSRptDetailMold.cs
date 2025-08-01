using ASPData;
using ASPData.ASPDAO;
using ASPData.ASPDTO;
using ASPData.ProdStatisticDTO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.LineProdStatistic
{
    public partial class frmPSRptDetailMold : DevExpress.XtraEditors.XtraForm
    {
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;

        private BindingSource bdsRptMold = new BindingSource();
        DataTable dtRptMold = new DataTable();

        SQLHelper sqlHelper = new SQLHelper();

        ProdStatisticDTO pDto = new ProdStatisticDTO();
        ProdStatisticDAO pDao = new ProdStatisticDAO();

        public frmPSRptDetailMold()
        {
            InitializeComponent();

            this.Load += FrmPSRptDetailMold_Load;
            this.btFilter.Click += BtFilter_Click;
            this.btExport.Click += BtExport_Click;
            this.btRestart.Click += BtRestart_Click;
        }

        private void GridRptMoldView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DataRow drMold = ((DataRowView)bdsRptMold.Current).Row;

            switch (e.Column.Name)
            {
                case "colIsChecked":
                    if (XtraMessageBox.Show("Bạn có muốn hoàn thành kiểm tra khuôn này không ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;

                    if (Convert.ToDouble(drMold["NumOfStamp"]) < Convert.ToDouble(drMold["NumOfDefault"]))
                    {
                        XtraMessageBox.Show("Bạn chưa được hoàn thành kiểm tra khuôn này.", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }    

                    bool isChecked = (bool)drMold["IsChecked"];
                    string strMoldID = (string)drMold["MoldID"];

                    var dicParams = new Dictionary<string, object>()
                    {
                        { "@IsChecked", !isChecked },
                        { "@MoldID", strMoldID },
                        { "@TypeUpdate", 0 }
                    };

                    sqlHelper.ExecProcedureNonData("sp_ASPUpdateMoldSummary", dicParams);

                    drMold["IsChecked"] = !isChecked;

                    break;
                case "colIsRestart":
                    if (XtraMessageBox.Show("Bạn có muốn bắt đầu lại khuôn này không ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;

                    bool isRestart = (bool)drMold["IsRestart"];
                    isChecked = (bool)drMold["IsChecked"];

                    if (isChecked == false)
                    {
                        XtraMessageBox.Show("Bạn chưa được bắt đầu lại khuôn này.", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }    

                    if (isRestart == false)
                    {
                        strMoldID = (string)drMold["MoldID"];
                        dicParams = new Dictionary<string, object>()
                        {
                            { "@IsChecked", false },
                            { "@IsRestart", !isRestart },
                            { "@MoldID", strMoldID },
                            { "@TypeUpdate", 1 }
                        };

                        sqlHelper.ExecProcedureNonData("sp_ASPUpdateMoldSummary", dicParams);

                        drMold["IsRestart"] = !isRestart;
                    }

                    break;
                default:
                    break;
            }
        }

        private void FrmPSRptDetailMold_Load(object sender, EventArgs e)
        {
            dtFromDate.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            dtToDate.EditValue = DateTime.Now.Date;

            FillData();

            this.gridRptMoldView.RowStyle += GridRptMoldView_RowStyle;
            this.gridRptMoldView.RowCellClick += GridRptMoldView_RowCellClick;
           
        }

        private void BtExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridRptMoldView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void BtRestart_Click(object sender, EventArgs e)
        {
            foreach(DataRow drMold in dtRptMold.Rows)
            {
                if ((bool)drMold["IsChecked"] == true)
                {
                    string strMoldID = (string)drMold["MoldID"];
                    var dicParams = new Dictionary<string, object>()
                    {
                        { "@IsChecked", false },
                        { "@IsRestart", 1 },
                        { "@MoldID", strMoldID },
                        { "@TypeUpdate", 1 }
                    };

                    sqlHelper.ExecProcedureNonData("sp_ASPUpdateMoldSummary", dicParams);
                }    
            }

            XtraMessageBox.Show("Đã bắt đầu lại xong.");
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void GridRptMoldView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            double diffNum = Convert.ToDouble(gridRptMoldView.GetRowCellValue(e.RowHandle, "DifferenceNum"));

            if (diffNum < 0)
            {
                e.Appearance.ForeColor = Color.DarkOrange;
            }
        }

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

            dtRptMold = pDao.GetRptDetailMold(pDto);

            bdsRptMold.DataSource = dtRptMold;
            gridRptMold.DataSource = bdsRptMold;
        }
    }
}
