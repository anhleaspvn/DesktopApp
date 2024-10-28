using ASPData;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPMachineMonitor
{
    public partial class MachineChart : Form
    {
        private readonly SQLHelper _sqlhelper;
        public MachineChart()
        {
            InitializeComponent();
            _sqlhelper = new SQLHelper();
            btnOk.Click += BtnOk_Click;

            ChartAddSeries(chartMT);
        }

        #region Data
        private DataTable MachineData()
        {
            DataTable dt = new DataTable();

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetMachineChart");

            //System.Data.DataSet xmlDataSet = new System.Data.DataSet("XML DataSet");
            //// Load the XML document to the DataSet
            //xmlDataSet.ReadXml("data.xml");

            //dt = xmlDataSet.Tables["OpMachineStatusRecord"];

            return dt;
        }
        private void ChartAddSeries(ChartControl chartCtrl)
        {
            chartCtrl.DataSource = MachineData();

            chartCtrl.SeriesDataMember = "StatusName";
            chartCtrl.SeriesTemplate.ChangeView(ViewType.Gantt);
            chartCtrl.SeriesTemplate.ValueScaleType = ScaleType.DateTime;
            chartCtrl.SeriesTemplate.ArgumentDataMember = "MachineName";
            chartCtrl.SeriesTemplate.ValueDataMembers[0] = "StartTime";
            chartCtrl.SeriesTemplate.ValueDataMembers[1] = "EndTime";
            chartCtrl.SeriesTemplate.ColorDataMember = "BackColorName";
        }
        #endregion

        #region Event
        private void BtnOk_Click(object sender, EventArgs e)
        {
            ChartAddSeries(chartMT);
        }
        #endregion
    }
}
