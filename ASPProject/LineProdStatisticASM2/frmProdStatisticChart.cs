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
using System.Windows.Controls;
using System.Windows.Forms;
using UnitsNet;

namespace ASPProject.LineProdStatisticASM2
{
    public partial class frmProdStatisticChart : DevExpress.XtraEditors.XtraForm
    {
        private ProdStatisticASM2DAO prodDao = new ProdStatisticASM2DAO();
        private DateTime chartDate;
        private int Month;
        private int Year;
        public string username, LineID;
        private double TotalORTarget, AvgActual, RatioActual, TotalProduct, TotalActual;
        private readonly SQLHelper _sqlhelper = new SQLHelper();
        private ChartControl barChartDailyAttendance = new ChartControl();
        private ChartControl circleChartDailyAttendance = new ChartControl();
        private ChartControl barChartDailyYield = new ChartControl();
        private ChartControl pipeChartYield = new ChartControl();
        private ChartControl barChartDailyProd = new ChartControl();
        private ChartControl barChartProductivity = new ChartControl();
        private ChartControl barChartPlanning = new ChartControl();
        private ChartControl barChartDefect = new ChartControl();
        private ChartControl barChartOTD = new ChartControl();
        private ChartControl barChartOEE = new ChartControl();
        private ChartControl barChartProdScrap = new ChartControl();
        public static string defaultBlue = "#3d85c6";
        public static string defaultRed = "#BA4D51";
        string weekName = string.Empty;
        public List<string> lstProdType = new List<string>();
        bool chkByW = false; 
        public frmProdStatisticChart()
        {
            InitializeComponent();

            dtpChartDate.EditValue = DateTime.Now;

            lstWeekName.DataSource = prodDao.GetWeeknameOfYear();
            lstWeekName.DisplayMember = "WeekName";
            lstWeekName.ValueMember = "WeekID";

            //Prod type
            lstProdType.Add("ASSEMBLY");
            lstProdType.Add("INJECTION");

            lkeProductType.Properties.DataSource = lstProdType;
            lkeProductType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeProductType.Properties.PopupFilterMode = PopupFilterMode.Contains;

            timerChart.Interval = 900000; //15 minutes
            timerChart.Start();

            this.Load += FrmProdStatisticChart_Load;
            this.timerChart.Tick += TimerChart_Tick;
            this.dtpChartDate.EditValueChanged += DtpChartDate_EditValueChanged;
            this.lstWeekName.SelectedValueChanged += LstWeekName_SelectedValueChanged;
            this.chkByWeek.CheckedChanged += ChkByWeek_CheckedChanged;
            this.lkeProductType.EditValueChanged += LkeProductType_EditValueChanged;

            this.chkByWeek.Checked = true;
            this.lkeProductType.EditValue = "INJECTION";
        }

        private void LkeProductType_EditValueChanged(object sender, EventArgs e)
        {
            LoadWeekname();
            LoadData();
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

           //dtpChartDate.EditValue = DateTime.Now;
            chartDate = (DateTime)dtpChartDate.EditValue;
           
            Month = chartDate.Month;
            Year = chartDate.Year;
            LineID = (string)_sqlhelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + username + "'");

            lblLineID.Text = LineID;

            //Attendance chart
            DailyAttendanceChartAddSeries();
            //DailyAttendanceCircleChartAddSeries();

            //yield chart
            DailyYieldChartAddSeries();
            //DailyPipeYieldChartAddSeries();

            OTDChartAddSeries();

            //production chart
            DailyProductionChartAddSeries();

            //productivity chart
            DailyProductivityChartAddSeries();

            //oee
            DailyOEEChartAddSeries();
        }
        #endregion

        #region AttendanceChartData
        //Daily Attendance Chart
        private DataTable DailyAttendanceChartData()
        {
            DataTable dt = new DataTable();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            dt = prodDao.GetDailyAttendanceChartData(Week, Month, Year, LineID, username);

            return dt;
        }

        private void DailyAttendanceChartAddSeries()
        {
            // Bind the chart to a data source:
            barChartDailyAttendance.DataSource = AttendanceChartDataPoint.GetDataPoints(DailyAttendanceChartData());
            barChartDailyAttendance.SeriesTemplate.ChangeView(ViewType.StackedBar);
            barChartDailyAttendance.SeriesTemplate.SeriesDataMember = "Caption";
            barChartDailyAttendance.SeriesTemplate.SetDataMembers("AttendanceDate", "Ratio");

            // Enable series point labels, specify their text pattern and position:
            barChartDailyAttendance.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((BarSeriesLabel)barChartDailyAttendance.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartDailyAttendance.SeriesTemplate.Label).TextPattern = "{V:n0}";
            ((BarSeriesView)barChartDailyAttendance.SeriesTemplate.View).FillStyle.FillMode = FillMode.Solid;

            // Customize series view settings (for example, bar width):
            StackedBarSeriesView view = (StackedBarSeriesView)barChartDailyAttendance.SeriesTemplate.View;
            view.BarWidth = 0.8;
            //view.Color = ColorTranslator.FromHtml(defaultBlue);

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartDailyAttendance.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartDailyAttendance title:
            barChartDailyAttendance.Titles.Add(new ChartTitle { Text = "ATTENDANCE RATE" });

            // Specify legend settings:
            barChartDailyAttendance.Legend.Direction = LegendDirection.LeftToRight;
            barChartDailyAttendance.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartDailyAttendance.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartDailyAttendance.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartDailyAttendance.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartDailyAttendance.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram)barChartDailyAttendance.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram)barChartDailyAttendance.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            ((XYDiagram)barChartDailyAttendance.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram)barChartDailyAttendance.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram)barChartDailyAttendance.Diagram).AxisY.Label.TextPattern = "{V:n0}%";

            ((XYDiagram)barChartDailyAttendance.Diagram).AxisY.GridLines.Visible = false;

            Series seriesLine = new Series("% YTD", ViewType.Line);
            seriesLine.View.Color = Color.DarkGreen;
            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine.DataSource = AttendanceChartDataPoint.GetDataPointsLineChart(DailyAttendanceChartData());
            seriesLine.SetDataMembers("AttendanceDate", "Ratio");
            
            barChartDailyAttendance.Series.Add(seriesLine);
            barChartDailyAttendance.Dock = DockStyle.Fill;

            splitContainerControl5.Panel2.Controls.Add(barChartDailyAttendance);
        }

        private void DailyAttendanceCircleChartAddSeries()
        {
            // Create an empty chart.
            circleChartDailyAttendance.Titles.Add(new ChartTitle() { Text = "" });

            // Create a pie series.
            Series series1 = new Series("Attendance Date", ViewType.Doughnut);
            Legend legend = new Legend();
            legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            // Bind the series to data.
            series1.DataSource = AttendanceChartDataPoint.GetDataPointsCircleChart(DailyAttendanceChartData());
            series1.ArgumentDataMember = "Caption";
            series1.ValueDataMembers.AddRange(new string[] { "Ratio" });

            ((PiePointOptions)series1.PointOptions).PointView = PointView.Values;
            ((PiePointOptions)series1.PointOptions).PercentOptions.ValueAsPercent = false;
            ((PiePointOptions)series1.PointOptions).ValueNumericOptions.Format = NumericFormat.Percent;
            ((PiePointOptions)series1.PointOptions).ValueNumericOptions.Precision = 1;

            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.ShowInLegend = true;

            // Add the series to the chart.
            circleChartDailyAttendance.Series.Add(series1);

            // Access the view-type-specific options of the series.
            DoughnutSeriesView myView = (DoughnutSeriesView)series1.View;

            // Customize the legend.
            circleChartDailyAttendance.Size = new Size(600, 600);

            // Add the chart to the form.
            circleChartDailyAttendance.Dock = DockStyle.Fill;


        }

        #endregion

        #region YieldChartData
        private DataSet DailyYieldChartData()
        {
            DataSet ds = new DataSet();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            ds = prodDao.GetDailyYieldChartData(Week, Month, Year, LineID, username, chkByW, Convert.ToString(lkeProductType.EditValue));

            return ds;
        }

        private void DailyYieldChartAddSeries()
        {
            if (DailyYieldChartData().Tables.Count == 0)
                return;

            DataTable dtYieldData = DailyYieldChartData().Tables[0];
     
            // Bind the chart to a data source:
            barChartDailyYield.DataSource = YieldChartDataPoint.GetDataPointsTargetStackBar(dtYieldData);
            barChartDailyYield.SeriesTemplate.ChangeView(ViewType.Line);
            barChartDailyYield.SeriesTemplate.SeriesDataMember = "Caption";
            barChartDailyYield.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");

            LineSeriesView view = (LineSeriesView)barChartDailyYield.SeriesTemplate.View;
            //view.BarWidth = 0.8;
            view.Color = ColorTranslator.FromHtml(defaultRed);

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartDailyYield.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartDailyYield title:
            barChartDailyYield.Titles.Add(new ChartTitle { Text = "YIELD (%)" });

            // Specify legend settings:
            barChartDailyYield.Legend.Direction = LegendDirection.LeftToRight;
            barChartDailyYield.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartDailyYield.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartDailyYield.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            barChartDailyYield.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            barChartDailyYield.SeriesTemplate.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;

            ((XYDiagram)barChartDailyYield.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram)barChartDailyYield.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram)barChartDailyYield.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            ((XYDiagram)barChartDailyYield.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram)barChartDailyYield.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram)barChartDailyYield.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartDailyYield.Diagram).AxisY.Label.TextPattern = "{V:n2}%";
            ((XYDiagram)barChartDailyYield.Diagram).AxisY.GridLines.Visible = false;

            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");
            myAxisY.Label.TextPattern = "{V:n2}%";
            myAxisY.GridLines.Visible = false;

            //((XYDiagram)barChartDailyProd.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartDailyYield.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesBar = new Series("YTD", ViewType.Bar);
            seriesBar.View.Color = ColorTranslator.FromHtml(defaultBlue);
            ((BarSeriesView)seriesBar.View).FillStyle.FillMode = FillMode.Solid;

           
            ((BarSeriesView)seriesBar.View).AxisY = myAxisY;
            //myAxisY.Label.TextPattern = "{V:n2} pcs";
            ((BarSeriesView)seriesBar.View).AxisY.Label.Visible = true;
            ((BarSeriesView)seriesBar.View).AxisY.GridLines.Visible = false;

            seriesBar.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesBar.Label.TextPattern = "{V:n2}";
            seriesBar.DataSource = YieldChartDataPoint.GetDataPointsDefectStackBar(dtYieldData);
            seriesBar.SetDataMembers("StatisticDate", "Quantity");

            barChartDailyYield.Series.Add(seriesBar);

            barChartDailyYield.Dock = DockStyle.Fill;

            splitContainerControl4.Panel1.Controls.Add(barChartDailyYield);
        }

        #endregion

        #region OTDChartData
        private DataSet OTDChartData()
        {
            DataSet ds = new DataSet();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            if (Week > 1)
                Week = Week - 1;

            ds = prodDao.GetOTDChartData(Week, Month, Year, LineID, username);

            return ds;
        }

        private void OTDChartAddSeries()
        {
            if (OTDChartData().Tables.Count == 0)
                return;

            DataTable dtYieldData = OTDChartData().Tables[0];

            // Bind the chart to a data source:
            barChartOTD.DataSource = OTDChartDataPoint.GetOTDPlanStackBar(dtYieldData);
            barChartOTD.SeriesTemplate.ChangeView(ViewType.Bar);
            barChartOTD.SeriesTemplate.SeriesDataMember = "Caption";
            barChartOTD.SeriesTemplate.SetDataMembers("Week", "Quantity");

            // Enable series point labels, specify their text pattern and position:
            barChartOTD.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartOTD.SeriesTemplate.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAllAroundPoint;

            //barChartOTD.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartOTD.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartOTD.SeriesTemplate.Label).TextPattern = "{V:n0}";
            barChartOTD.SeriesTemplate.View.Color = ColorTranslator.FromHtml(defaultRed);

            ((BarSeriesView)barChartOTD.SeriesTemplate.View).FillStyle.FillMode = FillMode.Solid;
            //((BarSeriesView)barChartOTD.SeriesTemplate.View).Shadow.Visible = true;
            //((BarSeriesView)barChartOTD.SeriesTemplate.View).Shadow.Color = Color.LightGray;
            //((BarSeriesView)barChartOTD.SeriesTemplate.View).Shadow.Size = 5;

            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartOTD.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartOTD.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartOTD title:
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "OTD";
            chartTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            barChartOTD.Titles.Add(chartTitle);

            // Specify legend settings:
            barChartOTD.Legend.Direction = LegendDirection.LeftToRight;
            barChartOTD.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartOTD.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartOTD.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartOTD.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartOTD.Diagram).AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)barChartOTD.Diagram).AxisX.Label.TextPattern = "Week {V:n0}";
            

            ((XYDiagram)barChartOTD.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartOTD.Diagram).AxisY.Label.TextPattern = "{V:n0} pcs";
            ((XYDiagram)barChartOTD.Diagram).AxisY.GridLines.Visible = false;

            Series seriesBar2 = new Series("Actual OTD", ViewType.Bar);
            seriesBar2.View.Color = ColorTranslator.FromHtml(defaultBlue);
            ((BarSeriesView)seriesBar2.View).FillStyle.FillMode = FillMode.Solid;

            ((BarSeriesView)seriesBar2.View).Shadow.Visible = true;
            ((BarSeriesView)seriesBar2.View).Shadow.Color = Color.LightGray;
            ((BarSeriesView)seriesBar2.View).Shadow.Size = 5;
            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            ((SideBySideBarSeriesView)seriesBar2.View).AxisY = ((XYDiagram)barChartOTD.Diagram).AxisY;
            //myAxisY.Label.TextPattern = "{V:n0} pcs";
            ((SideBySideBarSeriesView)seriesBar2.View).AxisY.Label.Visible = true;
            ((SideBySideBarSeriesView)seriesBar2.View).AxisY.GridLines.Visible = false;

            seriesBar2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesBar2.Label.TextPattern = "{V:n0}";
            seriesBar2.DataSource = OTDChartDataPoint.GetOTDActualStackBar(dtYieldData);
            seriesBar2.SetDataMembers("Week", "Quantity");

            barChartOTD.Series.Add(seriesBar2);

            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartDailyProd.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartOTD.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesLine = new Series("Rate", ViewType.Line);
            seriesLine.View.Color = Color.Blue;

            ((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            ((LineSeriesView)seriesLine.View).AxisY.Label.TextPattern = "{V:n0}%";
            ((LineSeriesView)seriesLine.View).AxisY.Label.Visible = true;
            ((LineSeriesView)seriesLine.View).AxisY.GridLines.Visible = false;
            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine.Label.TextPattern = "{V:n0}";
            seriesLine.DataSource = OTDChartDataPoint.GetOTDActualRateLine(dtYieldData);
            seriesLine.SetDataMembers("Week", "Quantity");
            seriesLine.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;

            barChartOTD.Series.Add(seriesLine);

            Series seriesLine2 = new Series("Target Rate", ViewType.Line);
            seriesLine2.View.Color = Color.Red;

            ((LineSeriesView)seriesLine2.View).AxisY = myAxisY;
            ((LineSeriesView)seriesLine2.View).AxisY.Label.TextPattern = "{V:n0}%";
            ((LineSeriesView)seriesLine2.View).AxisY.Label.Visible = true;
            ((LineSeriesView)seriesLine2.View).AxisY.GridLines.Visible = false;
            seriesLine2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine2.Label.TextPattern = "{V:n0}";
            seriesLine2.DataSource = OTDChartDataPoint.GetOTDTargetRateLine(dtYieldData);
            seriesLine2.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesLine2.SetDataMembers("Week", "Quantity");

            barChartOTD.Series.Add(seriesLine2);

            barChartOTD.Dock = DockStyle.Fill;

            splitContainerControl4.Panel2.Controls.Add(barChartOTD);
        }
        #endregion

        #region ProductionChartData
        private DataSet DailyProductionChartData()
        {
            DataSet ds = new DataSet();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            ds = prodDao.GetDailyProductionChartData(Week, Month, Year, LineID, username, chkByW, Convert.ToString(lkeProductType.EditValue));

            return ds;
        }

        private void DailyProductionChartAddSeries()
        {
            if (DailyProductionChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = DailyProductionChartData().Tables[0];

            // Bind the chart to a data source:
            barChartDailyProd.DataSource = ProdChartDataPoint.GetDataPointsPlanningLine(dtProdData);
            barChartDailyProd.SeriesTemplate.ChangeView(ViewType.Bar);
            barChartDailyProd.SeriesTemplate.SeriesDataMember = "Caption";
            barChartDailyProd.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");

            // Enable series point labels, specify their text pattern and position:
            barChartDailyProd.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartDailyProd.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartDailyProd.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartDailyProd.SeriesTemplate.Label).TextPattern = "{V:n0}";

            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartDailyProd.SeriesTemplate.View;
            view.BarWidth = 0.8;
            view.Color = ColorTranslator.FromHtml(defaultRed);
            view.FillStyle.FillMode = FillMode.Solid;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartDailyProd.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartDailyProd title:
            barChartDailyProd.Titles.Add(new ChartTitle { Text = "QUANTITY (%)" });

            // Specify legend settings:
            barChartDailyProd.Legend.Direction = LegendDirection.LeftToRight;
            barChartDailyProd.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartDailyProd.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartDailyProd.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartDailyProd.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram)barChartDailyProd.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram)barChartDailyProd.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            ((XYDiagram)barChartDailyProd.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram)barChartDailyProd.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram)barChartDailyProd.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartDailyProd.Diagram).AxisY.Label.TextPattern = "{V:n0} pcs";
            ((XYDiagram)barChartDailyProd.Diagram).AxisY.GridLines.Visible = false;

            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartDailyProd.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartDailyProd.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesLine = new Series("% YTD Thực tế/Actual", ViewType.Line);
            seriesLine.View.Color = Color.DarkBlue;

            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            ((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesLine.DataSource = ProdChartDataPoint.GetDataPointsActualLine(dtProdData);
            seriesLine.SetDataMembers("StatisticDate", "Quantity");

            barChartDailyProd.Series.Add(seriesLine);

            Series seriesMBO = new Series("% MBO Target", ViewType.Line);
            seriesMBO.View.Color = Color.Red;

            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesMBO.View).AxisX = myAxisX;
            ((LineSeriesView)seriesMBO.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesMBO.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesMBO.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesMBO.DataSource = ProdChartDataPoint.GetDataPointsMBOBar(dtProdData);
            seriesMBO.SetDataMembers("StatisticDate", "Quantity");

            barChartDailyProd.Series.Add(seriesMBO);

            Series seriesLine2 = new Series("Actual Qty", ViewType.Bar);
            seriesLine2.View.Color = ColorTranslator.FromHtml(defaultBlue);
            
            ((SideBySideBarSeriesLabel)seriesLine2.Label).Position = BarSeriesLabelPosition.Center;
            ((SideBySideBarSeriesLabel)seriesLine2.Label).TextPattern = "{V:n0}";
            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            ((SideBySideBarSeriesView)seriesLine2.View).AxisY = ((XYDiagram)barChartDailyProd.Diagram).AxisY;
            ((SideBySideBarSeriesView)seriesLine2.View).FillStyle.FillMode = FillMode.Solid;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine2.DataSource = ProdChartDataPoint.GetDataPointsActualBar(dtProdData);
            seriesLine2.SetDataMembers("StatisticDate", "Quantity");

            barChartDailyProd.Series.Add(seriesLine2);

            if (dtProdData.Rows.Count > 0)
            {
                TotalORTarget = Convert.ToDouble(dtProdData.Compute("MAX(TotalProdQuantityIntMonth)", ""));

                AvgActual = Convert.ToDouble(dtProdData.Compute("MAX(AvgActual)", ""));

                RatioActual = Convert.ToDouble(dtProdData.Compute("MAX(RatioActual)", ""));

                TotalActual = Convert.ToDouble(dtProdData.Compute("MAX(TotalActualQuantity)", ""));
            }

            barChartDailyProd.Dock = DockStyle.Fill;

            lblORTarget.Text = Math.Round(TotalORTarget, 1, MidpointRounding.AwayFromZero).ToString("N0") + " pcs";
            lblActualQty.Text = Math.Round(TotalActual, 1, MidpointRounding.AwayFromZero).ToString("N0") + " pcs";
            lblAcPercent.Text = Math.Round(RatioActual, 1, MidpointRounding.AwayFromZero).ToString("N0") + "%";
            splitContainerControl3.Panel1.Controls.Add(barChartDailyProd);
        }
        #endregion

        #region DailyProdScrapChart
        private DataSet DailyProdScrapChartData()
        {
            DataSet ds = new DataSet();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            ds = prodDao.GetDailyProdScrapChartData(Week, Month, Year, LineID, username, chkByW);

            return ds;
        }

        private void DailyProdScrapChartChartAddSeries()
        {
            if (DailyProdScrapChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = DailyProdScrapChartData().Tables[0];

            // Bind the chart to a data source:
            barChartProdScrap.DataSource = ProdScrapChartDataPoint.GetDataPointsActualBar(dtProdData);
            barChartProdScrap.SeriesTemplate.ChangeView(ViewType.Bar);
            barChartProdScrap.SeriesTemplate.SeriesDataMember = "Caption";
            barChartProdScrap.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");

            // Enable series point labels, specify their text pattern and position:
            barChartProdScrap.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartProdScrap.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartProdScrap.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartProdScrap.SeriesTemplate.Label).TextPattern = "{V:n4}";

            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartProdScrap.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartProdScrap.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartProdScrap title:
            barChartProdScrap.Titles.Add(new ChartTitle { Text = "SCRAP (%)" });

            // Specify legend settings:
            barChartProdScrap.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartProdScrap.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartProdScrap.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartProdScrap.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram)barChartProdScrap.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram)barChartProdScrap.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            ((XYDiagram)barChartProdScrap.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram)barChartProdScrap.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram)barChartProdScrap.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartProdScrap.Diagram).AxisY.Label.TextPattern = "{V:n4} %";
            ((XYDiagram)barChartProdScrap.Diagram).AxisY.GridLines.Visible = false;


            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartProdScrap.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartProdScrap.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesLine = new Series("% YTD Thực tế/Actual", ViewType.Line);
            seriesLine.View.Color = Color.DarkGreen;

            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            ((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n4}%";
            myAxisY.GridLines.Visible = false;

            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine.DataSource = ProdScrapChartDataPoint.GetDataPointsActualLine(dtProdData);
            seriesLine.SetDataMembers("StatisticDate", "Quantity");

            barChartProdScrap.Series.Add(seriesLine);

            ////SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            //SecondaryAxisY myAxisY2 = new SecondaryAxisY("my Y-Axis");

            ////((XYDiagram)barChartProdScrap.Diagram).SecondaryAxesX.Add(myAxisX);1
            //((XYDiagram)barChartProdScrap.Diagram).SecondaryAxesY.Add(myAxisY2);

            Series seriesLine2 = new Series("Mục tiêu/Target: " + Convert.ToString(dtProdData.Rows[0]["PercentTarget"]), ViewType.Line);
            seriesLine2.View.Color = Color.OrangeRed;

            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            ((LineSeriesView)seriesLine2.View).AxisY = ((XYDiagram)barChartProdScrap.Diagram).AxisY;
            myAxisY.Label.TextPattern = "{V:n4}%";
            myAxisY.GridLines.Visible = false;

            seriesLine2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine2.DataSource = ProdScrapChartDataPoint.GetDataPointsPlanningLine(dtProdData);
            seriesLine2.SetDataMembers("StatisticDate", "Quantity");

            barChartProdScrap.Series.Add(seriesLine2);

            //if (dtProdData.Rows.Count > 0)
            //{
            //    TotalORTarget = Convert.ToDouble(dtProdData.Compute("MAX(TotalProdQuantityIntMonth)", ""));

            //    AvgActual = Convert.ToDouble(dtProdData.Compute("MAX(AvgActual)", ""));

            //    RatioActual = Convert.ToDouble(dtProdData.Compute("MAX(RatioActual)", ""));

            //    TotalActual = Convert.ToDouble(dtProdData.Compute("MAX(TotalActualQuantity)", ""));
            //}

            barChartProdScrap.Dock = DockStyle.Fill;

            //lblORTarget.Text = Math.Round(TotalORTarget, 1, MidpointRounding.AwayFromZero).ToString("N0") + " pcs";
            //lblActualQty.Text = Math.Round(TotalActual, 1, MidpointRounding.AwayFromZero).ToString("N0") + " pcs";
            //lblAcPercent.Text = Math.Round(RatioActual, 1, MidpointRounding.AwayFromZero).ToString("N0") + "%";
            //splitContainerControl4.Panel2.Controls.Add(barChartProdScrap);
        }
        #endregion

        #region ProductivityChartData
        private DataSet DailyProductivityChartData()
        {
            DataSet ds = new DataSet();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            ds = prodDao.GetDailyProductivityChartData(Week, Month, Year, LineID, username, chkByW, Convert.ToString(lkeProductType.EditValue));

            return ds;
        }

        private void DailyProductivityChartAddSeries()
        {
            if (DailyProductivityChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = DailyProductivityChartData().Tables[0];

            // Bind the chart to a data source:
            barChartProductivity.DataSource = ProductivityChartDataPoint.GetDataPointsActualBar(dtProdData);
            barChartProductivity.SeriesTemplate.ChangeView(ViewType.Bar);
            barChartProductivity.SeriesTemplate.SeriesDataMember = "Caption";
            barChartProductivity.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");
            barChartProductivity.SeriesTemplate.ArgumentScaleType = ScaleType.DateTime;

            // Enable series point labels, specify their text pattern and position:
            barChartProductivity.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            barChartProductivity.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartProductivity.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartProductivity.SeriesTemplate.Label).TextPattern = "{V:n0}";

            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartProductivity.SeriesTemplate.View;
            view.Color = ColorTranslator.FromHtml(defaultBlue);
            view.FillStyle.FillMode = FillMode.Solid;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartProductivity.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartProductivity title:
            barChartProductivity.Titles.Add(new ChartTitle { Text = "PRODUCTIVITY (%)" });

            // Specify legend settings:
            barChartProductivity.Legend.Direction = LegendDirection.LeftToRight;
            barChartProductivity.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartProductivity.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartProductivity.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram)barChartProductivity.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;
            //((XYDiagram)barChartProductivity.Diagram).AxisX.VisualRange.MaxValue = new DateTime(2023, 08, 30);

            //((XYDiagram)barChartProductivity.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            //((XYDiagram)barChartProductivity.Diagram).AxisY.Label.TextPattern = "{V:n0} pcs";
            ((XYDiagram)barChartProductivity.Diagram).AxisY.Label.Visible = false;
            ((XYDiagram)barChartProductivity.Diagram).AxisY.GridLines.Visible = false;

            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartProductivity.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartProductivity.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesLine = new Series("% YTD Thực tế/Actual", ViewType.Line);
            seriesLine.View.Color = Color.DarkBlue;
            seriesLine.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            ((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine.DataSource = ProductivityChartDataPoint.GetDataPointsActualLine(dtProdData);
            seriesLine.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivity.Series.Add(seriesLine);

            double target = Convert.ToDouble(dtProdData.Compute("MAX(ProductivityTarget)", string.Empty));

            Series seriesLine2 = new Series("Mục tiêu/Target: " + target.ToString() + "%", ViewType.Line);
            seriesLine2.View.Color = Color.OrangeRed;
            ((LineSeriesView)seriesLine2.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine2.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesLine2.DataSource = ProductivityChartDataPoint.GetDataPointsTargetLine(dtProdData);
            seriesLine2.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivity.Series.Add(seriesLine2);

            if (dtProdData.Rows.Count > 0)
            {
                TotalProduct = Convert.ToDouble(dtProdData.Compute("MAX(TotalProduct)", ""));

                RatioActual = Convert.ToDouble(dtProdData.Compute("MAX(RatioActual)", ""));
            }

            barChartProductivity.Dock = DockStyle.Fill;

            splitContainerControl3.Panel2.Controls.Add(barChartProductivity);
        }

        #endregion

        #region OEEChartData
        private DataSet DailyOEEChartData()
        {
            DataSet ds = new DataSet();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            ds = prodDao.GetDailyOEEChartData(Convert.ToDateTime(dtpChartDate.EditValue).Date,Week, Month, Year, LineID, username, chkByW);

            return ds;
        }

        private void DailyOEEChartAddSeries()
        {
            if (DailyOEEChartData().Tables.Count == 0)
                return;

            DataTable dtYieldData = DailyOEEChartData().Tables[0];

            // Bind the chart to a data source:
            barChartOEE.DataSource = OEEChartDataPoint.GetDataOEEINJPoints(dtYieldData);
            barChartOEE.SeriesTemplate.ChangeView(ViewType.ManhattanBar);
            barChartOEE.SeriesTemplate.SeriesDataMember = "Caption";
            barChartOEE.SeriesTemplate.SetDataMembers("MoldID", "Ratio");

            // Enable series point labels, specify their text pattern and position:
            barChartOEE.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            ((BarSeriesLabel)barChartOEE.SeriesTemplate.Label).TextPattern = "{V:n4}%";
            //((BarSeriesLabel)barChartOEE.SeriesTemplate.Label).TextOrientation = TextOrientation.Horizontal;
            //((BarSeriesLabel)barChartOEE.SeriesTemplate.Label).ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
           barChartOEE.SeriesTemplate.View.Color = ColorTranslator.FromHtml(defaultBlue);

            // Customize series view settings (for example, bar width):
            ManhattanBarSeriesView view = (ManhattanBarSeriesView)barChartOEE.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram3D diagram = (XYDiagram3D)barChartOEE.Diagram;
            //diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartOEE title:
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "OEE RATE %";
            //chartTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            barChartOEE.Titles.Add(chartTitle);

            // Specify legend settings:
            this.barChartOEE.Legend.Direction = LegendDirection.LeftToRight;
            this.barChartOEE.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            this.barChartOEE.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            this.barChartOEE.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram3D)barChartOEE.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram3D)barChartOEE.Diagram).AxisY.Label.TextPattern = "{V:n4}%";
            ((XYDiagram3D)barChartOEE.Diagram).AxisY.GridLines.Visible = false;
            //((XYDiagram3D)barChartOEE.Diagram).PerspectiveAngle = 45;
            ((XYDiagram3D)barChartOEE.Diagram).ZoomPercent = 150;


            Series seriesLine4 = new Series("% Loss P", ViewType.ManhattanBar);
            seriesLine4.View.Color = Color.Yellow;
           
            seriesLine4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine4.Label.TextPattern = "{V:n4}%";
            //seriesLine4.Label.TextOrientation = TextOrientation.Horizontal;
            //seriesLine4.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesLine4.DataSource = OEEChartDataPoint.GetDataLossPPoints(dtYieldData);
            seriesLine4.SetDataMembers("MoldID", "Ratio");
            barChartOEE.Series.Add(seriesLine4);

            Series seriesLine5 = new Series("% Loss A", ViewType.ManhattanBar);
            seriesLine5.View.Color = Color.DarkOrange;

            seriesLine5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine5.Label.TextPattern = "{V:n4}%";
            //seriesLine5.Label.TextOrientation = TextOrientation.Horizontal;
            //seriesLine5.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesLine5.DataSource = OEEChartDataPoint.GetDataLossAPoints(dtYieldData);
            seriesLine5.SetDataMembers("MoldID", "Ratio");
            barChartOEE.Series.Add(seriesLine5);

            Series seriesLine6 = new Series("% Loss Q", ViewType.ManhattanBar);
            
            seriesLine6.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine6.Label.TextPattern = "{V:n4}%";
            //seriesLine6.Label.TextOrientation = TextOrientation.Horizontal;
            //seriesLine6.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesLine6.DataSource = OEEChartDataPoint.GetDataLossQPoints(dtYieldData);
            seriesLine6.SetDataMembers("MoldID", "Ratio");

            barChartOEE.Series.Add(seriesLine6);

            barChartOEE.Dock = DockStyle.Fill;
            //splitContainerControl4.Panel2.Controls.Add(barChartOEE);
        }
        #endregion

        #region PlanningChartData
        private DataTable PlanningChartData()
        {
            DataTable dt = new DataTable();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            dt = prodDao.GetPlanningChartData(Year, LineID, username);

            return dt;
        }

        private void PlanningChartAddSeries()
        {
            // Bind the chart to a data source:
            barChartPlanning.DataSource = PlanningChartDataPoint.GetDataPoints(PlanningChartData());
            barChartPlanning.SeriesTemplate.ChangeView(ViewType.StackedBar);
            barChartPlanning.SeriesTemplate.SeriesDataMember = "Caption";

            barChartPlanning.SeriesTemplate.SetDataMembers("MonthPoint", "Ratio");

            // Enable series point labels, specify their text pattern and position:
            barChartPlanning.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartPlanning.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartPlanning.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartPlanning.SeriesTemplate.Label).TextPattern = "{V:n0}";

            // Customize series view settings (for example, bar width):
            StackedBarSeriesView view = (StackedBarSeriesView)barChartPlanning.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartPlanning.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartPlanning title:
            barChartPlanning.Titles.Add(new ChartTitle { Text = "W.Os COMPLETION RATE (%)" });

            // Specify legend settings:
            barChartPlanning.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartPlanning.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartPlanning.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartPlanning.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartPlanning.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
            ((XYDiagram)barChartPlanning.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
            ((XYDiagram)barChartPlanning.Diagram).AxisX.Label.TextPattern = "{A:MMM-yyyy}";
            //((XYDiagram)barChartPlanning.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            //((XYDiagram)barChartPlanning.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram)barChartPlanning.Diagram).AxisY.Label.TextPattern = "{V:n0}%";

            ((XYDiagram)barChartPlanning.Diagram).AxisY.GridLines.Visible = false;

            barChartPlanning.Dock = DockStyle.Fill;

            //splitContainerControl5.Panel2.Controls.Add(barChartPlanning);
        }
        #endregion

        #region DefectChartData
        private DataTable DefectChartData()
        {
            DataTable dt = new DataTable();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            dt = prodDao.GetDefectChartData(Week, Month, Year, LineID, username);

            return dt;
        }

        #endregion

        private void ResetChartControl()
        {
            splitContainerControl4.Panel1.Controls.Remove(barChartDailyYield);
            splitContainerControl3.Panel1.Controls.Remove(barChartDailyProd);
            splitContainerControl3.Panel2.Controls.Remove(barChartProductivity);
            splitContainerControl5.Panel2.Controls.Remove(barChartDailyAttendance);
            splitContainerControl4.Panel2.Controls.Remove(barChartOTD);
            //splitContainerControl6.Panel1.Controls.Remove(barChartOTD);
          

            barChartDailyAttendance = new ChartControl();
            circleChartDailyAttendance = new ChartControl();
            barChartDailyYield = new ChartControl();
            pipeChartYield = new ChartControl();
            barChartDailyProd = new ChartControl();
            barChartProductivity = new ChartControl();
            barChartPlanning = new ChartControl();
            barChartDefect = new ChartControl();
            barChartOTD = new ChartControl();
            barChartProdScrap = new ChartControl();
            barChartOTD = new ChartControl();
            barChartOEE = new ChartControl();
        }

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

        private void lblLineID_Click(object sender, EventArgs e)
        {

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

        private void ChkByWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (chkByWeek.Checked == true)
                chkByW = true;
            else
                chkByW = false;

            LoadData();
        }
        #endregion
    }
}
