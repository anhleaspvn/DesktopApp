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

namespace ASPProject.LineProdStatistic
{
    public partial class frmProdStatisticChart : DevExpress.XtraEditors.XtraForm
    {
        private ProdStatisticDAO prodDao = new ProdStatisticDAO();
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
        private ChartControl barChartProdScrap = new ChartControl();
        string weekName = string.Empty;
        bool chkByW = false; 
        public frmProdStatisticChart()
        {
            InitializeComponent();

            dtpChartDate.EditValue = DateTime.Now;

            lstWeekName.DataSource = prodDao.GetWeeknameOfYear();
            lstWeekName.DisplayMember = "WeekName";
            lstWeekName.ValueMember = "WeekID";

            timerChart.Interval = 900000; //15 minutes
            timerChart.Start();

            this.Load += FrmProdStatisticChart_Load;
            this.timerChart.Tick += TimerChart_Tick;
            this.dtpChartDate.EditValueChanged += DtpChartDate_EditValueChanged;
            this.lstWeekName.SelectedValueChanged += LstWeekName_SelectedValueChanged;
            this.chkByWeek.CheckedChanged += ChkByWeek_CheckedChanged;
            this.btUpdateScrap.Click += BtUpdateScrap_Click;
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

           // dtpChartDate.EditValue = DateTime.Now;
            chartDate = (DateTime)dtpChartDate.EditValue;
           
            Month = chartDate.Month;
            Year = chartDate.Year;
            LineID = (string)_sqlhelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + username + "'");

            lblLineID.Text = LineID;

            //Attendance chart
            DailyAttendanceChartAddSeries();

            //Yield chart
            DailyYieldChartAddSeries();

            //OTE chart
            OTDChartAddSeries();

            //Production chart
            DailyProductionChartAddSeries();

            //Productivity chart
            DailyProductivityChartAddSeries();

            //Planning chart
            PlanningChartAddSeries();

            //Production scrap
            DailyProdScrapChartChartAddSeries();
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
            //barChartDailyAttendance.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartDailyAttendance.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartDailyAttendance.SeriesTemplate.Label).TextPattern = "{V:n0}%";

            // Customize series view settings (for example, bar width):
            StackedBarSeriesView view = (StackedBarSeriesView)barChartDailyAttendance.SeriesTemplate.View;
            view.BarWidth = 0.8;

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
            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine.DataSource = AttendanceChartDataPoint.GetDataPointsLineChart(DailyAttendanceChartData());
            seriesLine.SetDataMembers("AttendanceDate", "Ratio");


            barChartDailyAttendance.Series.Add(seriesLine);
            barChartDailyAttendance.Dock = DockStyle.Fill;

            splitContainerControl5.Panel1.Controls.Add(barChartDailyAttendance);
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

            ds = prodDao.GetDailyYieldChartData(Month, Year, LineID, username);

            return ds;
        }

        private void DailyYieldChartAddSeries()
        {
            if (DailyYieldChartData().Tables.Count == 0)
                return;

            DataTable dtYieldData = DailyYieldChartData().Tables[0];
            
            // Bind the chart to a data source:
            barChartDailyYield.DataSource = YieldChartDataPoint.GetDataPointsDefectStackBar(dtYieldData);
            barChartDailyYield.SeriesTemplate.ChangeView(ViewType.StackedBar3D);
            barChartDailyYield.SeriesTemplate.SeriesDataMember = "Caption";
            barChartDailyYield.SeriesTemplate.SetDataMembers("Caption", "Quantity");

            // Enable series point labels, specify their text pattern and position:
            barChartDailyYield.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartDailyYield.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartDailyYield.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartDailyYield.SeriesTemplate.Label).TextPattern = "{V:n0}%";

            // Add a barChartDailyYield title:
            barChartDailyYield.Titles.Add(new ChartTitle { Text = "YIELD" });

            // Specify legend settings:
            barChartDailyYield.Legend.Direction = LegendDirection.LeftToRight;
            barChartDailyYield.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            barChartDailyYield.Legend.MarkerMode = LegendMarkerMode.Marker;

            ((XYDiagram3D)barChartDailyYield.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram3D)barChartDailyYield.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram3D)barChartDailyYield.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";

            ((XYDiagram3D)barChartDailyYield.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram3D)barChartDailyYield.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram3D)barChartDailyYield.Diagram).AxisY.Label.TextPattern = "{V:n0}%";
            ((XYDiagram3D)barChartDailyYield.Diagram).AxisY.GridLines.Visible = false;
            ((XYDiagram3D)barChartDailyYield.Diagram).AxisX.GridLines.Visible = true;

            barChartDailyYield.Dock = DockStyle.Fill;

            splitContainerControl6.Panel1.Controls.Add(barChartDailyYield);
        }


        #endregion

        #region OTDChartData
        private DataSet OTDChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetOTDChartData(Month, Year, LineID, username);

            return ds;
        }

        private void OTDChartAddSeries()
        {
            if (OTDChartData().Tables.Count == 0)
                return;

            DataTable dtYieldData = OTDChartData().Tables[0];
            //DataTable dtYieldDataLine = new DataTable();

            // Bind the chart to a data source:
            barChartOTD.DataSource = YieldChartDataPoint.GetDataOTDStackBar(dtYieldData);
            barChartOTD.SeriesTemplate.ChangeView(ViewType.StackedBar3D);
            barChartOTD.SeriesTemplate.SeriesDataMember = "Caption";
            barChartOTD.SeriesTemplate.SetDataMembers("Caption", "Quantity");

            // Enable series point labels, specify their text pattern and position:
            barChartOTD.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartOTD.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartOTD.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartOTD.SeriesTemplate.Label).TextPattern = "{V:n0}%";

            // Add a barChartOTD title:
            barChartOTD.Titles.Add(new ChartTitle { Text = "OTD" });

            // Specify legend settings:
            barChartOTD.Legend.Direction = LegendDirection.LeftToRight;
            barChartOTD.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            barChartOTD.Legend.MarkerMode = LegendMarkerMode.Marker;

            ((XYDiagram3D)barChartOTD.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram3D)barChartOTD.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram3D)barChartOTD.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";

            ((XYDiagram3D)barChartOTD.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram3D)barChartOTD.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram3D)barChartOTD.Diagram).AxisY.Label.TextPattern = "{V:n0}%";
            ((XYDiagram3D)barChartOTD.Diagram).AxisY.GridLines.Visible = false;
            ((XYDiagram3D)barChartOTD.Diagram).AxisX.GridLines.Visible = false;

            barChartOTD.Dock = DockStyle.Fill;

            splitContainerControl6.Panel2.Controls.Add(barChartOTD);
        }
        #endregion

        #region ProductionChartData
        private DataSet DailyProductionChartData()
        {
            DataSet ds = new DataSet();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            ds = prodDao.GetDailyProductionChartData(Week, Month, Year, LineID, username, chkByW);

            return ds;
        }

        private void DailyProductionChartAddSeries()
        {
            if (DailyProductionChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = DailyProductionChartData().Tables[0];

            // Bind the chart to a data source:
            barChartDailyProd.DataSource = ProdChartDataPoint.GetDataPointsActualBar(dtProdData);
            barChartDailyProd.SeriesTemplate.ChangeView(ViewType.Bar);
            barChartDailyProd.SeriesTemplate.SeriesDataMember = "Caption";
            barChartDailyProd.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");

            // Enable series point labels, specify their text pattern and position:
            barChartDailyProd.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            //barChartDailyProd.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartDailyProd.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartDailyProd.SeriesTemplate.Label).TextPattern = "{V:n0}pcs";

            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartDailyProd.SeriesTemplate.View;
            view.BarWidth = 0.8;

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
            ((XYDiagram)barChartDailyProd.Diagram).AxisY.Label.TextPattern = "{V:n0}pcs";
            ((XYDiagram)barChartDailyProd.Diagram).AxisY.GridLines.Visible = false;


            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartDailyProd.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartDailyProd.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesLine = new Series("% YTD Thực tế/Actual", ViewType.Line);
            seriesLine.View.Color = Color.DarkGreen;

            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            ((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine.DataSource = ProdChartDataPoint.GetDataPointsActualLine(dtProdData);
            seriesLine.SetDataMembers("StatisticDate", "Quantity");

            barChartDailyProd.Series.Add(seriesLine);

            Series seriesLine2 = new Series("Mục tiêu/Target: " + Convert.ToDouble(dtProdData.Compute("MAX(TotalORTarget)", "")).ToString() + "pcs", ViewType.Line);
            seriesLine2.View.Color = Color.OrangeRed;

            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            ((LineSeriesView)seriesLine2.View).AxisY = ((XYDiagram)barChartDailyProd.Diagram).AxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine2.DataSource = ProdChartDataPoint.GetDataPointsPlanningLine(dtProdData);
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
            ((BarSeriesLabel)barChartProdScrap.SeriesTemplate.Label).TextPattern = "{V:n2}";

            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartProdScrap.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartProdScrap.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;
            //diagram.AxisY.WholeRange.SetMinMaxValues(0, 0.3);
            diagram.AxisY.WholeRange.MaxValue = 1;

            // Add a barChartProdScrap title:
            barChartProdScrap.Titles.Add(new ChartTitle { Text = "SCRAP (%)" });

            // Specify legend settings:
            barChartProdScrap.Legend.Direction = LegendDirection.LeftToRight;
            barChartProdScrap.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartProdScrap.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartProdScrap.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartProdScrap.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram)barChartProdScrap.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram)barChartProdScrap.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            ((XYDiagram)barChartProdScrap.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram)barChartProdScrap.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram)barChartProdScrap.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartProdScrap.Diagram).AxisY.Label.TextPattern = "{V:n2} %";
            ((XYDiagram)barChartProdScrap.Diagram).AxisY.GridLines.Visible = false;

            Series seriesLine = new Series("% YTD Thực tế/Actual", ViewType.Line);
            seriesLine.View.Color = Color.DarkGreen;

            ((LineSeriesView)seriesLine.View).AxisY = ((XYDiagram)barChartProdScrap.Diagram).AxisY;
          
            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine.DataSource = ProdScrapChartDataPoint.GetDataPointsActualLine(dtProdData);
            seriesLine.SetDataMembers("StatisticDate", "Quantity");

            barChartProdScrap.Series.Add(seriesLine);

            Series seriesLine2 = new Series("Mục tiêu/Target: 0.2 %", ViewType.Line);
            seriesLine2.View.Color = Color.OrangeRed;

            ((LineSeriesView)seriesLine2.View).AxisY = ((XYDiagram)barChartProdScrap.Diagram).AxisY;
          
            seriesLine2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine2.DataSource = ProdScrapChartDataPoint.GetDataPointsPlanningLine(dtProdData);
            seriesLine2.SetDataMembers("StatisticDate", "Quantity");

            barChartProdScrap.Series.Add(seriesLine2);

            barChartProdScrap.Dock = DockStyle.Fill;

            splitContainerControl4.Panel2.Controls.Add(barChartProdScrap);
        }
        #endregion

        #region ProductivityChartData
        private DataSet DailyProductivityChartData()
        {
            DataSet ds = new DataSet();

            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            ds = prodDao.GetDailyProductivityChartData(Week, Month, Year, LineID, username, chkByW);

            return ds;
        }

        private void DailyProductivityChartAddSeries()
        {
            if (DailyProductivityChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = DailyProductivityChartData().Tables[0];

            // Bind the chart to a data source:
            barChartProductivity.DataSource = ProductivityChartDataPoint.GetDataPointsActualLine(dtProdData);
            barChartProductivity.SeriesTemplate.ChangeView(ViewType.Line);
            barChartProductivity.SeriesTemplate.SeriesDataMember = "Caption";
            barChartProductivity.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");
            barChartProductivity.SeriesTemplate.ArgumentScaleType = ScaleType.DateTime;

            // Enable series point labels, specify their text pattern and position:
            barChartProductivity.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
          
            // Customize series view settings (for example, bar width):
            LineSeriesView view = (LineSeriesView)barChartProductivity.SeriesTemplate.View;
            view.Color = Color.DarkGreen;
            //view.BarWidth = 0.8;

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
            ((XYDiagram)barChartProductivity.Diagram).AxisY.Label.Visible = true;
            ((XYDiagram)barChartProductivity.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartProductivity.Diagram).AxisY.Label.TextPattern = "{V:n2} %";
            ((XYDiagram)barChartProductivity.Diagram).AxisY.GridLines.Visible = false;

            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            //SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            ////((XYDiagram)barChartProductivity.Diagram).SecondaryAxesX.Add(myAxisX);
            //((XYDiagram)barChartProductivity.Diagram).SecondaryAxesY.Add(myAxisY);

            //Series seriesLine = new Series("% YTD Thực tế/Actual", ViewType.Line);
            //seriesLine.View.Color = Color.DarkGreen;

            //// Assign the series2 to the created axes.
            ////((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            //((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            //myAxisY.Label.TextPattern = "{V:n0}%";
            //myAxisY.GridLines.Visible = false;

            //seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            //seriesLine.DataSource = ProductivityChartDataPoint.GetDataPointsActualLine(dtProdData);
            //seriesLine.SetDataMembers("StatisticDate", "Quantity");

            //barChartProductivity.Series.Add(seriesLine);

            double target = Convert.ToDouble(dtProdData.Compute("MAX(ProductivityTarget)", string.Empty));

            Series seriesLine2 = new Series("Mục tiêu/Target: " + target.ToString() + "%", ViewType.Line);
            seriesLine2.View.Color = Color.OrangeRed;
            ((LineSeriesView)seriesLine2.View).AxisY = ((XYDiagram)barChartProductivity.Diagram).AxisY;
            //myAxisY.Label.TextPattern = "{V:n0}%";
            //myAxisY.GridLines.Visible = false;

            seriesLine2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
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
            ((BarSeriesLabel)barChartPlanning.SeriesTemplate.Label).TextPattern = "{V:n0}%";

            // Customize series view settings (for example, bar width):
            StackedBarSeriesView view = (StackedBarSeriesView)barChartPlanning.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartPlanning.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartPlanning title:
            barChartPlanning.Titles.Add(new ChartTitle { Text = "W.Os COMPLETION RATE (%)" });

            // Specify legend settings:
            barChartPlanning.Legend.Direction = LegendDirection.LeftToRight;
            barChartPlanning.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartPlanning.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartPlanning.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartPlanning.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartPlanning.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
            ((XYDiagram)barChartPlanning.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
            ((XYDiagram)barChartPlanning.Diagram).AxisX.Label.TextPattern = "{A:MMM-yyyy}";
           
            ((XYDiagram)barChartPlanning.Diagram).AxisY.Label.TextPattern = "{V:n0}%";

            ((XYDiagram)barChartPlanning.Diagram).AxisY.GridLines.Visible = false;
          
            barChartPlanning.Dock = DockStyle.Fill;

            splitContainerControl5.Panel2.Controls.Add(barChartPlanning);
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

        //private void DefectChartAddSeries()
        //{
        //    // Bind the chart to a data source:
        //    barChartDefect.DataSource = DefectChartDataPoint.GetDataPoints(DefectChartData());
        //    barChartDefect.SeriesTemplate.ChangeView(ViewType.StackedBar);
        //    barChartDefect.SeriesTemplate.SeriesDataMember = "Caption";

        //    barChartDefect.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");

        //    // Enable series point labels, specify their text pattern and position:
        //    barChartDefect.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
        //    //barChartDefect.SeriesTemplate.Label.TextPattern = "${V}M";
        //    ((BarSeriesLabel)barChartDefect.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
        //    ((BarSeriesLabel)barChartDefect.SeriesTemplate.Label).TextPattern = "{V:n0}";

        //    // Customize series view settings (for example, bar width):
        //    StackedBarSeriesView view = (StackedBarSeriesView)barChartDefect.SeriesTemplate.View;
        //    view.BarWidth = 0.8;

        //    // Disable minor tickmarks on the x-axis:
        //    XYDiagram diagram = (XYDiagram)barChartDefect.Diagram;
        //    diagram.AxisX.Tickmarks.MinorVisible = false;

        //    // Add a barChartDefect title:
        //    barChartDefect.Titles.Add(new ChartTitle { Text = "DEFECT QUANTITY" });

        //    // Specify legend settings:
        //    barChartDefect.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
        //    barChartDefect.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
        //    barChartDefect.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
        //    barChartDefect.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

        //    ((XYDiagram)barChartDefect.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
        //    ((XYDiagram)barChartDefect.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
        //    ((XYDiagram)barChartDefect.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
        //    ((XYDiagram)barChartDefect.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
        //    ((XYDiagram)barChartDefect.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

        //    ((XYDiagram)barChartDefect.Diagram).AxisY.Label.TextPattern = "{V:n0} pcs";

        //    ((XYDiagram)barChartDefect.Diagram).AxisY.GridLines.Visible = false;

        //    barChartDefect.Dock = DockStyle.Fill;

        //    splitContainerControl4.Panel1.Controls.Add(barChartDefect);
        //}
        #endregion

        private void ResetChartControl()
        {
            splitContainerControl5.Panel2.Controls.Remove(barChartPlanning);
            splitContainerControl3.Panel1.Controls.Remove(barChartDailyProd);
            splitContainerControl3.Panel2.Controls.Remove(barChartProductivity);
            splitContainerControl5.Panel1.Controls.Remove(barChartPlanning);
            splitContainerControl6.Panel1.Controls.Remove(barChartDailyYield);
            splitContainerControl6.Panel1.Controls.Remove(barChartOTD);
            splitContainerControl5.Panel2.Controls.Remove(barChartProdScrap);
            splitContainerControl4.Panel2.Controls.Remove(barChartProdScrap);

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

        private void BtUpdateScrap_Click(object sender, EventArgs e)
        {
            int Week = Convert.ToInt32(lstWeekName.SelectedValue.ToString().Substring(1, 2));

            prodDao.InsertDailyProdScrapChartData(Week, Month, Year, LineID, username, chkByW);

            LoadData();
        }
        #endregion
    }
}
