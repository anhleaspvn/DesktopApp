using ASPData;
using ASPData.ASPDAO;
using DevExpress.Charts.Native;
using DevExpress.Data.TreeList;
using DevExpress.Utils.Layout;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using UnitsNet;

namespace ASPProject.ExternalIQC
{
    public partial class frmIQCStatisticChart : DevExpress.XtraEditors.XtraForm
    {
        private ProdStatisticDAO prodDao = new ProdStatisticDAO();
        private IQCCheckingDAO iqcDao = new IQCCheckingDAO();
        private DateTime chartDate;
        private int Month;
        private int Year;
        public string username, LineID;
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        private readonly SQLHelper _sqlhelper = new SQLHelper();
        private ChartControl barChartDailyProd = new ChartControl();
        private ChartControl barChartProductivity = new ChartControl();
        private ChartControl barChartQCPPM = new ChartControl();
        private ChartControl barChartQCProcPercent = new ChartControl();
        private ChartControl barChartQCDefectPercent = new ChartControl();

        string weekName = string.Empty;
        public frmIQCStatisticChart()
        {
            InitializeComponent();

            dtpChartDate.EditValue = DateTime.Now;

            lstWeekName.DataSource = prodDao.GetWeeknameOfYear();
            lstWeekName.DisplayMember = "WeekName";
            lstWeekName.ValueMember = "WeekID";

            timerChart.Interval = 300000; //5 minutes
            timerChart.Start();

            this.Load += FrmProdStatisticChart_Load;
            this.timerChart.Tick += TimerChart_Tick;
            this.dtpChartDate.EditValueChanged += DtpChartDate_EditValueChanged;
            lstWeekName.SelectedValueChanged += LstWeekName_SelectedValueChanged;
        }

        #region Load
        private void FrmProdStatisticChart_Load(object sender, EventArgs e)
        {
            LoadWeekname();
            LoadData();
        }

        private void LoadWeekname()
        {
            chartDate = (DateTime)dtpChartDate.EditValue;
            DataTable dtWeek = prodDao.GetWeekByDate(chartDate);


            if (dtWeek.Rows.Count > 0)
            {
                weekName = (string)dtWeek.Rows[0]["WeekID"];
                lstWeekName.SelectedValue = weekName;
            }
        }

        private void LoadData()
        {
            //reset chart
            ResetChartControl();

            chartDate = (DateTime)dtpChartDate.EditValue;
           
            Month = chartDate.Month;
            Year = chartDate.Year;
            LineID = (string)_sqlhelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + username + "'");

            //PPM QC Chart
            DailyIQCDPPMChartAddSeries();

            //ProcessChart
            //DailyIQCProcessPercentChartAddSeries();

            //Defect Quantity
            DailyIQCDefectPercentChartAddSeries();
        }
        #endregion

        #region IQCPPMChart
        private DataTable DailyIQCDPPMChartData()
        {
            DataTable dt = new DataTable();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            dt = iqcDao.GetDailyIQCDPPMChart(Week, Month, Year);

            return dt;
        }
        private void DailyIQCDPPMChartAddSeries()
        {
            // Bind the chart to a data source:
            barChartQCPPM.DataSource = IQCPPMChartDataPoint.GetDataPoints(DailyIQCDPPMChartData());
            barChartQCPPM.SeriesTemplate.ChangeView(ViewType.StackedBar);
            barChartQCPPM.SeriesTemplate.SeriesDataMember = "Caption";

            barChartQCPPM.SeriesTemplate.SetDataMembers("DocDate", "Ratio");

            // Enable series point labels, specify their text pattern and position:
            barChartQCPPM.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartQCPPM.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartQCPPM.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartQCPPM.SeriesTemplate.Label).TextPattern = "{V:n0}";

            // Customize series view settings (for example, bar width):
            StackedBarSeriesView view = (StackedBarSeriesView)barChartQCPPM.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartQCPPM.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;


            // Add a barChartQCPPM title:
            barChartQCPPM.Titles.Add(new ChartTitle { Text = "PPM ( % )" });

            // Specify legend settings:
            barChartQCPPM.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartQCPPM.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartQCPPM.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartQCPPM.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartQCPPM.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            //((XYDiagram)barChartQCPPM.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            //((XYDiagram)barChartQCPPM.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            //((XYDiagram)barChartQCPPM.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            //((XYDiagram)barChartQCPPM.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram)barChartQCPPM.Diagram).AxisY.Label.TextPattern = "{V:n0}";

            ((XYDiagram)barChartQCPPM.Diagram).AxisY.GridLines.Visible = false;

            barChartQCPPM.Dock = DockStyle.Fill;

            splitContainerControl5.Panel1.Controls.Add(barChartQCPPM);
        }
        #endregion

        #region IQCProccessPercentChart
        private DataTable DailyIQCProcessPercentChart()
        {
            DataTable dt = new DataTable();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            dt = iqcDao.GetDailyIQCProcessPercentChart(Week, Month, Year);

            return dt;
        }

        private void DailyIQCProcessPercentChartAddSeries()
        {

            // Bind the chart to a data source:
            barChartQCProcPercent.DataSource = IQCProcessPercentDataPoint.GetDataPoints(DailyIQCProcessPercentChart());
            barChartQCProcPercent.SeriesTemplate.ChangeView(ViewType.StackedBar);
            barChartQCProcPercent.SeriesTemplate.SeriesDataMember = "Caption";

            barChartQCProcPercent.SeriesTemplate.SetDataMembers("IQCCheckName", "Ratio");

            // Enable series point labels, specify their text pattern and position:
            barChartQCProcPercent.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartQCProcPercent.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartQCProcPercent.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartQCProcPercent.SeriesTemplate.Label).TextPattern = "{V:n0}";

            // Customize series view settings (for example, bar width):
            StackedBarSeriesView view = (StackedBarSeriesView)barChartQCProcPercent.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartQCProcPercent.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;


            // Add a barChartQCProcPercent title:
            barChartQCProcPercent.Titles.Add(new ChartTitle { Text = "Process Percent ( % )" });

            // Specify legend settings:
            barChartQCProcPercent.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartQCProcPercent.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartQCProcPercent.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartQCProcPercent.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartQCProcPercent.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram)barChartQCProcPercent.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram)barChartQCProcPercent.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            ((XYDiagram)barChartQCProcPercent.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram)barChartQCProcPercent.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram)barChartQCProcPercent.Diagram).AxisY.Label.TextPattern = "{V:n0}%";

            ((XYDiagram)barChartQCProcPercent.Diagram).AxisY.GridLines.Visible = false;

            ((DevExpress.XtraCharts.XYDiagram)barChartQCProcPercent.Diagram).Rotated = true;

            barChartQCProcPercent.Dock = DockStyle.Fill;

            //splitContainerControl4.Panel1.Controls.Add(barChartQCProcPercent);
        }
        #endregion

        #region IQCDefectPercentChart
        private DataTable DailyIQCDefectPercentChart()
        {
            DataTable dt = new DataTable();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            dt = iqcDao.GetDailyIQCDefectPercentChart(Week, Month, Year);

            return dt;
        }

        private void DailyIQCDefectPercentChartAddSeries()
        {
            // Bind the chart to a data source:
            barChartQCDefectPercent.DataSource = IQCDefectPercentDataPoint.GetDataPoints(DailyIQCDefectPercentChart());
            barChartQCDefectPercent.SeriesTemplate.ChangeView(ViewType.StackedBar);
            barChartQCDefectPercent.SeriesTemplate.SeriesDataMember = "Caption";

            barChartQCDefectPercent.SeriesTemplate.SetDataMembers("Issue", "Ratio");

            // Enable series point labels, specify their text pattern and position:
            barChartQCDefectPercent.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartQCDefectPercent.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartQCDefectPercent.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            //((BarSeriesLabel)barChartQCDefectPercent.SeriesTemplate.Label).TextPattern = "{V:n0}";

            // Customize series view settings (for example, bar width):
            StackedBarSeriesView view = (StackedBarSeriesView)barChartQCDefectPercent.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartQCDefectPercent.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "DEFECT RATE";
            chartTitle.Font = new Font("Arial", 12);

            // Add a barChartQCDefectPercent title:
            barChartQCDefectPercent.Titles.Add(chartTitle);

            // Specify legend settings:
            barChartQCDefectPercent.Legend.Direction = LegendDirection.LeftToRight;
            barChartQCDefectPercent.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartQCDefectPercent.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartQCDefectPercent.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartQCDefectPercent.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartQCDefectPercent.Diagram).AxisY.Label.TextPattern = "{V:n0}";
            ((XYDiagram)barChartQCDefectPercent.Diagram).AxisY.GridLines.Visible = false;

            Series seriesLine = new Series("% NG", ViewType.Line);
            seriesLine.View.Color = Color.DarkGreen;
            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine.DataSource = IQCDefectPercentDataPoint.GetDataPointsPercentLine(DailyIQCDefectPercentChart());
            seriesLine.SetDataMembers("Issue", "Ratio");

            barChartQCDefectPercent.Series.Add(seriesLine);
            barChartQCDefectPercent.Dock = DockStyle.Fill;

            splitContainerControl4.Panel1.Controls.Add(barChartQCDefectPercent);
        }
        #endregion

        #region Event
        private void SplitContainerControl3_SizeChanged(object sender, EventArgs e)
        {
            //splitContainerControl3.SplitterPosition = splitContainerControl3.Height / 2;
        }

        private void frmProdStatisticChart_Load_1(object sender, EventArgs e)
        {

        }

        private void SplitContainerControl2_SizeChanged(object sender, EventArgs e)
        {
            //splitContainerControl2.SplitterPosition = splitContainerControl2.Height / 2;
        }

        private void SplitContainerControl1_SizeChanged(object sender, EventArgs e)
        {
            //splitContainerControl1.SplitterPosition = splitContainerControl1.Width / 2;
        }

        private void TimerChart_Tick(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DtpChartDate_EditValueChanged(object sender, EventArgs e)
        {
            chartDate = (DateTime)dtpChartDate.EditValue;

            LoadData();
        }

        private void LstWeekName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Month == 0)
                Month = DateTime.Now.Month;

            if (Year == 0)
                Year = DateTime.Now.Year;

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));
            DataTable dtDate = prodDao.GetDateByWeek(Week, Month, Year);

            chartDate = (DateTime)dtpChartDate.EditValue;

            if (dtDate.Rows.Count > 0)
            {
                dtpChartDate.EditValue = chartDate;
            }

            LoadData();
            
        }
        #endregion

        #region reset
        private void ResetChartControl()
        {
            splitContainerControl4.Panel1.Controls.Remove(barChartQCDefectPercent);
            //splitContainerControl3.Panel1.Controls.Remove(barChartDailyProd);
            //splitContainerControl4.Panel2.Controls.Remove(barChartQCDefectPercent);
            //splitContainerControl3.Panel1.Controls.Remove(barChartQCDefectPercent);
           
            barChartQCProcPercent = new ChartControl();
            barChartQCPPM = new ChartControl();
            barChartDailyProd = new ChartControl();
            barChartProductivity = new ChartControl();
            barChartQCDefectPercent = new ChartControl();
        }
        #endregion
    }
}
