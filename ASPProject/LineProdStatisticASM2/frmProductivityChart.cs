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
    public partial class frmProductivityChart : DevExpress.XtraEditors.XtraForm
    {
        private ProdStatisticASM2DAO prodDao = new ProdStatisticASM2DAO();
        private DateTime chartDate = DateTime.Now.Date;
        private int Month;
        private int Year;
        public string username, LineID, monthList = string.Empty, lineList = string.Empty, dayList = string.Empty;
        private readonly SQLHelper _sqlhelper = new SQLHelper();
     
        private ChartControl barChartDailyProd = new ChartControl();
        private ChartControl barChartMonthlyProd = new ChartControl();
        private ChartControl barChartProductivity = new ChartControl();
        private ChartControl barChartProductivityMonth = new ChartControl();

        string weekName = string.Empty;
        bool chkByW = false;
        public frmProductivityChart()
        {
            InitializeComponent();

            timerChart.Interval = 900000; //15 minutes
            timerChart.Start();

            this.Load += FrmProdStatisticChart_Load;
            this.timerChart.Tick += TimerChart_Tick;
            this.lstMonthName.ItemCheck += LstMonthName_ItemCheck;
            this.lstLineID.ItemCheck += LstLineID_ItemCheck;
            this.lstDayName.ItemCheck += LstDayName_ItemCheck;
        }

        private void LstDayName_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            LoadDayChart();
        }

        private void LstLineID_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            LoadDayChart();
            LoadMonthChart();
        }

        private void LstMonthName_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            LoadMonthChart();
        }

       
        #region Load

        private void LoadMonthChart()
        {
            monthList = string.Empty;
            lineList = string.Empty;

            for (int m = 0; m <= lstLineID.CheckedItemsCount - 1; m++)
            {
                object lineId = lstLineID.CheckedItems[m];

                if (m == lstLineID.CheckedItemsCount - 1)
                    lineList += "" + lineId + "";
                else
                    lineList += "" + lineId + ",";
            }

            for (int m = 0; m <= lstMonthName.CheckedItemsCount - 1; m++)
            {
                object oDate = lstMonthName.CheckedItems[m];

                if (m == lstMonthName.CheckedItemsCount - 1)
                    monthList += "" + Convert.ToDateTime(oDate).ToShortDateString() + "";
                else
                    monthList += "" + Convert.ToDateTime(oDate).ToShortDateString() + ",";
            }

            ResetChartControlMonth();

            //monthly production chart
            MonthlyProductionChartAddSeries();

            //monthly productivity chart
            MonthlyProductivityChartAddSeries();
        }

        private void LoadDayChart()
        {
            dayList = string.Empty;
            lineList = string.Empty;

            for (int m = 0; m <= lstLineID.CheckedItemsCount - 1; m++)
            {
                object lineId = lstLineID.CheckedItems[m];

                if (m == lstLineID.CheckedItemsCount - 1)
                    lineList += "" + lineId + "";
                else
                    lineList += "" + lineId + ",";
            }

            for (int m = 0; m <= lstDayName.CheckedItemsCount - 1; m++)
            {
                object oDate = lstDayName.CheckedItems[m];

                if (m == lstDayName.CheckedItemsCount - 1)
                    dayList += "" + Convert.ToDateTime(oDate).ToShortDateString() + "";
                else
                    dayList += "" + Convert.ToDateTime(oDate).ToShortDateString() + ",";
            }

            ResetChartControlDay();

            //monthly production chart
            DailyProductionChartAddSeries();

            //monthly productivity chart
            DailyProductivityChartAddSeries();
        }
        private void FrmProdStatisticChart_Load(object sender, EventArgs e)
        {
            lstDayName.DataSource  = prodDao.GetDateOfMonth(DateTime.Now.Month, DateTime.Now.Year);
            lstDayName.DisplayMember = "NameDate";
            lstDayName.ValueMember = "DateOfMonth";

            lstLineID.DataSource = prodDao.GetLinesByUser(username);
            lstLineID.DisplayMember = "LineName";
            lstLineID.ValueMember = "LineID";

            lstMonthName.DataSource = prodDao.GetMonthOfYear(DateTime.Now.Year);
            lstMonthName.DisplayMember = "TenThang";
            lstMonthName.ValueMember = "Thang";
           
            LoadWeekname();
            LoadData();
        }

        private void LoadWeekname()
        {
         
            DataTable dtWeek = prodDao.GetWeekByDate(chartDate);


            if (dtWeek.Rows.Count > 0)
            {
                weekName = (string)dtWeek.Rows[0]["WeekID"];
                lstDayName.SelectedValue = weekName;
            }
        }

        private void LoadData()
        {
            //reset chart
            ResetChartControl();

            //
            chkByW = true;
 
            Month = chartDate.Month;
            Year = chartDate.Year;
        
            //production chart
            DailyProductionChartAddSeries();

            //monthly production chart
            MonthlyProductionChartAddSeries();

            //productivity chart
            DailyProductivityChartAddSeries();

            //monthly productivity chart
            MonthlyProductivityChartAddSeries();
        }
        #endregion

        #region ProductionChartData
        private DataSet DailyProductionChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetDailyProductivityQuantityChart(dayList,lineList, Month, Year, LineID, username);

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
            ((BarSeriesLabel)barChartDailyProd.SeriesTemplate.Label).TextPattern = "{V:n0}";

            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartDailyProd.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartDailyProd.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartDailyProd title:
            barChartDailyProd.Titles.Add(new ChartTitle { Text = "DAILY QUANTITY OUTPUT" });

            // Specify legend settings:
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

            ////SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            //SecondaryAxisY myAxisY2 = new SecondaryAxisY("my Y-Axis");

            ////((XYDiagram)barChartDailyProd.Diagram).SecondaryAxesX.Add(myAxisX);
            //((XYDiagram)barChartDailyProd.Diagram).SecondaryAxesY.Add(myAxisY2);

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

            barChartDailyProd.Dock = DockStyle.Fill;

            splitContainerControl3.Panel1.Controls.Add(barChartDailyProd);
        }

        private DataSet MonthlyProductionChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetMonthlyProductionChart(monthList, lineList,  Month, Year, LineID, username);

            return ds;
        }
        private void MonthlyProductionChartAddSeries()
        {
            if (MonthlyProductionChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = MonthlyProductionChartData().Tables[0];
            
            // Bind the chart to a data source:
            barChartMonthlyProd.DataSource = ProdChartDataPoint.GetDataPointsActualBar(dtProdData);
            barChartMonthlyProd.SeriesTemplate.ChangeView(ViewType.Bar);
            barChartMonthlyProd.SeriesTemplate.SeriesDataMember = "Caption";
            barChartMonthlyProd.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");

            // Enable series point labels, specify their text pattern and position:
            barChartMonthlyProd.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartMonthlyProd.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartMonthlyProd.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartMonthlyProd.SeriesTemplate.Label).TextPattern = "{V:n0}";

            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartMonthlyProd.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartMonthlyProd.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartMonthlyProd title:
            barChartMonthlyProd.Titles.Add(new ChartTitle { Text = "MONTHLY QUANTITY OUTPUT" });

            // Specify legend settings:
            barChartMonthlyProd.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartMonthlyProd.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartMonthlyProd.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartMonthlyProd.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
            ((XYDiagram)barChartMonthlyProd.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
            ((XYDiagram)barChartMonthlyProd.Diagram).AxisX.Label.TextPattern = "{A:MMM}";
            ((XYDiagram)barChartMonthlyProd.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            //((XYDiagram)barChartMonthlyProd.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram)barChartMonthlyProd.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartMonthlyProd.Diagram).AxisY.Label.TextPattern = "{V:n0} pcs";
            ((XYDiagram)barChartMonthlyProd.Diagram).AxisY.GridLines.Visible = false;


            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartMonthlyProd.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartMonthlyProd.Diagram).SecondaryAxesY.Add(myAxisY);

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

            barChartMonthlyProd.Series.Add(seriesLine);

            Series seriesLine2 = new Series("Mục tiêu/Target", ViewType.Line);
            if (dtProdData.Rows.Count > 0)
                seriesLine2 = new Series("Mục tiêu/Target: " + Convert.ToDouble(dtProdData.Compute("MAX(TotalORTarget)", "")).ToString() + "pcs", ViewType.Line);
         
            seriesLine2.View.Color = Color.OrangeRed;

            ((LineSeriesView)seriesLine2.View).AxisY = ((XYDiagram)barChartMonthlyProd.Diagram).AxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine2.DataSource = ProdChartDataPoint.GetDataPointsPlanningLine(dtProdData);
            seriesLine2.SetDataMembers("StatisticDate", "Quantity");

            barChartMonthlyProd.Series.Add(seriesLine2);

            barChartMonthlyProd.Dock = DockStyle.Fill;

            splitContainerControl4.Panel1.Controls.Add(barChartMonthlyProd);
        }
        #endregion

        #region ProductivityChartData
        private DataSet DailyProductivityChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetDailyProductivityPercentChartData(dayList, lineList, Month, Year, LineID, username);

            return ds;
        }

        private void DailyProductivityChartAddSeries()
        {
            if (DailyProductivityChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = DailyProductivityChartData().Tables[0];

            // Bind the chart to a data source:
            barChartProductivity.DataSource = ProductivityChartDataPoint.GetDataPointsActualBar(dtProdData);
            barChartProductivity.SeriesTemplate.ChangeView(ViewType.Line);
            barChartProductivity.SeriesTemplate.SeriesDataMember = "Caption";
            barChartProductivity.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");
            barChartProductivity.SeriesTemplate.ArgumentScaleType = ScaleType.DateTime;

            // Enable series point labels, specify their text pattern and position:
            barChartProductivity.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
           
            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartProductivity.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartProductivity title:
            barChartProductivity.Titles.Add(new ChartTitle { Text = "DAILY OUTPUT RATE" });

            // Specify legend settings:
            barChartProductivity.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartProductivity.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartProductivity.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram)barChartProductivity.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;
            //((XYDiagram)barChartProductivity.Diagram).AxisX.VisualRange.MaxValue = new DateTime(2023, 08, 30);

            ((XYDiagram)barChartProductivity.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartProductivity.Diagram).AxisY.Label.TextPattern = "{V:n0} pcs";
            ((XYDiagram)barChartProductivity.Diagram).AxisY.GridLines.Visible = false;

            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartProductivity.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartProductivity.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesLine = new Series("% YTD Thực tế/Actual", ViewType.Line);
            seriesLine.View.Color = Color.DarkGreen;

            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            ((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine.DataSource = ProductivityChartDataPoint.GetDataPointsActualLine(dtProdData);
            seriesLine.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivity.Series.Add(seriesLine);

            double target = Convert.ToDouble(dtProdData.Compute("MAX(ProductivityTarget)", string.Empty));

            Series seriesLine2 = new Series("Mục tiêu/Target: " + target.ToString() + "%", ViewType.Line);
            seriesLine2.View.Color = Color.OrangeRed;
            ((LineSeriesView)seriesLine2.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine2.DataSource = ProductivityChartDataPoint.GetDataPointsTargetLine(dtProdData);
            seriesLine2.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivity.Series.Add(seriesLine2);

            barChartProductivity.Dock = DockStyle.Fill;

            splitContainerControl3.Panel2.Controls.Add(barChartProductivity);
        }

        private DataSet MonthlyProductivityChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetMonthlyProductivityChartData(monthList, lineList, Month, Year, LineID, username);

            return ds;
        }

        private void MonthlyProductivityChartAddSeries()
        {
            if (MonthlyProductivityChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = MonthlyProductivityChartData().Tables[0];

            // Bind the chart to a data source:
            barChartProductivityMonth.DataSource = ProductivityChartDataPoint.GetDataPointsActualBar(dtProdData);
            barChartProductivityMonth.SeriesTemplate.ChangeView(ViewType.Line);
            barChartProductivityMonth.SeriesTemplate.SeriesDataMember = "Caption";
            barChartProductivityMonth.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");
            barChartProductivityMonth.SeriesTemplate.ArgumentScaleType = ScaleType.DateTime;

            // Enable series point labels, specify their text pattern and position:
            barChartProductivityMonth.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
          
            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartProductivityMonth.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartProductivityMonth title:
            barChartProductivityMonth.Titles.Add(new ChartTitle { Text = "MONTHLY OUTPUT RATE" });

            // Specify legend settings:
            barChartProductivityMonth.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartProductivityMonth.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartProductivityMonth.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartProductivityMonth.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
            ((XYDiagram)barChartProductivityMonth.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
            ((XYDiagram)barChartProductivityMonth.Diagram).AxisX.Label.TextPattern = "{A:MMM}";
          
            ((XYDiagram)barChartProductivityMonth.Diagram).AxisY.Label.Visible = false;
            ((XYDiagram)barChartProductivityMonth.Diagram).AxisY.GridLines.Visible = false;

            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartProductivityMonth.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartProductivityMonth.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesLine = new Series("% YTD Thực tế/Actual", ViewType.Line);
            seriesLine.View.Color = Color.DarkGreen;

            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesLine.View).AxisX = myAxisX;
            ((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine.DataSource = ProductivityChartDataPoint.GetDataPointsActualLine(dtProdData);
            seriesLine.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivityMonth.Series.Add(seriesLine);

            double target = dtProdData.Rows.Count > 0 ? Convert.ToDouble(dtProdData.Compute("MAX(ProductivityTarget)", string.Empty)) : 0;

            Series seriesLine2 = new Series("Mục tiêu/Target: " + target.ToString() + "%", ViewType.Line);
            seriesLine2.View.Color = Color.OrangeRed;
            ((LineSeriesView)seriesLine2.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n0}%";
            myAxisY.GridLines.Visible = false;

            seriesLine2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine2.DataSource = ProductivityChartDataPoint.GetDataPointsTargetLine(dtProdData);
            seriesLine2.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivityMonth.Series.Add(seriesLine2);

            barChartProductivityMonth.Dock = DockStyle.Fill;

            splitContainerControl4.Panel2.Controls.Add(barChartProductivityMonth);
        }

        #endregion

        private void ResetChartControl()
        {
            splitContainerControl3.Panel1.Controls.Remove(barChartDailyProd);
            splitContainerControl3.Panel2.Controls.Remove(barChartProductivity);
            splitContainerControl4.Panel1.Controls.Remove(barChartMonthlyProd);
            splitContainerControl4.Panel2.Controls.Remove(barChartProductivityMonth);

            barChartDailyProd = new ChartControl();
            barChartMonthlyProd = new ChartControl();
            barChartProductivity = new ChartControl();
        }

        private void ResetChartControlMonth()
        {
            splitContainerControl4.Panel1.Controls.Remove(barChartMonthlyProd);
            splitContainerControl4.Panel2.Controls.Remove(barChartProductivityMonth);

            barChartMonthlyProd = new ChartControl();
            barChartProductivityMonth = new ChartControl();
        }

        private void ResetChartControlDay()
        {
            splitContainerControl3.Panel1.Controls.Remove(barChartDailyProd);
            splitContainerControl3.Panel2.Controls.Remove(barChartProductivity);

            barChartDailyProd = new ChartControl();
            barChartProductivity = new ChartControl();
        }

        #region Event
        private void SplitContainerControl3_SizeChanged(object sender, EventArgs e)
        {
            
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
        #endregion
    }
}
