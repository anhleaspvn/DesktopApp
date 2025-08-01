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
        private ChartControl barChartQCProcProduct = new ChartControl();
        private ChartControl barChartQCProcDefect = new ChartControl();

        string weekName = string.Empty;
        public frmIQCStatisticChart()
        {
            InitializeComponent();

          
            this.dtFromDate.EditValue = new DateTime(2024, 1, 1);
            this.dtToDate.EditValue = DateTime.Now;

            timerChart.Interval = 300000; //5 minutes
            timerChart.Start();

            this.Load += FrmProdStatisticChart_Load;
            this.timerChart.Tick += TimerChart_Tick;
            

            this.dtFromDate.EditValueChanged += DtFromDate_EditValueChanged;
            this.dtToDate.EditValueChanged += DtToDate_EditValueChanged;
            
        }

        #region Load
        private void FrmProdStatisticChart_Load(object sender, EventArgs e)
        {
            LoadWeekname();
            LoadData();
        }

        private void LoadWeekname()
        {
            //chartDate = (DateTime)dtpChartDate.EditValue;
            //DataTable dtWeek = prodDao.GetWeekByDate(chartDate);


            //if (dtWeek.Rows.Count > 0)
            //{
            //    weekName = (string)dtWeek.Rows[0]["WeekID"];
            //}
        }

        private void LoadData()
        {
            //reset chart
            ResetChartControl();

            //chartDate = (DateTime)dtpChartDate.EditValue;
           
            Month = chartDate.Month;
            Year = chartDate.Year;
            LineID = (string)_sqlhelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + username + "'");

            //PPM QC Chart
            DailyIQCDPPMChartAddSeries();

            //Defect Quantity
            DailyIQCDefectPercentChartAddSeries();

            //ProcessChart
            DailyIQCPPMByProcessChartAddSeries();

            //ProductChart
            DailyIQCPPMByProductChartAddSeries();

            //PPMByDefectChart
            DailyIQCPPMByDefectChartAddSeries();
        }
        #endregion

        #region IQCPPMChart
        private DataTable DailyIQCDPPMChartData()
        {
            DataTable dt = new DataTable();

            int Week = 0;

            dt = iqcDao.GetDailyIQCDPPMChartV2(Convert.ToDateTime(this.dtFromDate.EditValue), Convert.ToDateTime(this.dtToDate.EditValue));

            return dt;
        }
        private void DailyIQCDPPMChartAddSeries()
        {
            // Bind the chart to a data source
            barChartQCPPM.DataSource = IQCPPMChartDataPoint.GetDataPoints(DailyIQCDPPMChartData());
            barChartQCPPM.SeriesTemplate.ChangeView(ViewType.Line);
            barChartQCPPM.SeriesTemplate.SeriesDataMember = "Caption";
            barChartQCPPM.SeriesTemplate.SetDataMembers("DocDate", "Ratio");

            // Enable and customize series point labels
            barChartQCPPM.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            barChartQCPPM.SeriesTemplate.Label.Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular);
            barChartQCPPM.SeriesTemplate.Label.TextPattern = "{V:n0}";
           // barChartQCPPM.SeriesTemplate.Label.Position = PointLabelPosition.Top;

            // Customize series view settings
            LineSeriesView view = (LineSeriesView)barChartQCPPM.SeriesTemplate.View;
            view.LineStyle.Thickness = 2;
            view.LineStyle.DashStyle = DashStyle.Solid;
            view.LineMarkerOptions.Visible = true;
            view.LineMarkerOptions.Size = 6;
            view.LineMarkerOptions.Color = Color.DodgerBlue; // Vibrant blue
            view.Color = Color.DodgerBlue; // Vibrant blue

            // Customize diagram and axes
            XYDiagram diagram = (XYDiagram)barChartQCPPM.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;
            diagram.AxisX.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            diagram.AxisX.Label.Angle = 0; // Horizontal labels for readability
            diagram.AxisY.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            diagram.AxisY.Label.TextPattern = "{V:n0}";
            diagram.AxisY.GridLines.Visible = true;
            diagram.AxisY.GridLines.Color = System.Drawing.Color.FromArgb(220, 220, 220); // Light gray grid lines
            diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            diagram.AxisX.Label.TextPattern = "{A:dd-MMM}";
            diagram.AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            diagram.AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            // Add and customize chart title
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "PPM BY DAY";
            chartTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); // Modern font
            chartTitle.Alignment = StringAlignment.Center;
            barChartQCPPM.Titles.Clear();
            barChartQCPPM.Titles.Add(chartTitle);

            // Customize legend
            barChartQCPPM.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartQCPPM.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartQCPPM.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartQCPPM.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            barChartQCPPM.Legend.Font = new System.Drawing.Font("Segoe UI", 8);

            barChartQCPPM.Dock = DockStyle.Fill;

            splitContainerControl3.Panel1.Controls.Add(barChartQCPPM);
        }
        #endregion

        #region IQCProccessPercentChart
        private DataTable DailyIQCPPMByProcessChart()
        {
            DataTable dt = new DataTable();

            int Week = 0;

            dt = iqcDao.GetDailyIQCPPMByProcessChartV2(Convert.ToDateTime(this.dtFromDate.EditValue), Convert.ToDateTime(this.dtToDate.EditValue));

            return dt;
        }

        private void DailyIQCPPMByProcessChartAddSeries()
        {
            // Bind the chart to a data source
            barChartQCProcPercent.DataSource = IQCPPMByProcessDataPoint.GetDataPoints(DailyIQCPPMByProcessChart());
            barChartQCProcPercent.SeriesTemplate.ChangeView(ViewType.StackedBar);
            barChartQCProcPercent.SeriesTemplate.SeriesDataMember = "Caption";
            barChartQCProcPercent.SeriesTemplate.SetDataMembers("IQCCheckName", "Ratio");

            // Enable and customize series point labels
            barChartQCProcPercent.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((BarSeriesLabel)barChartQCProcPercent.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartQCProcPercent.SeriesTemplate.Label).TextPattern = "{V:n0}";
            ((BarSeriesLabel)barChartQCProcPercent.SeriesTemplate.Label).Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular);

            // Customize series view settings
            StackedBarSeriesView view = (StackedBarSeriesView)barChartQCProcPercent.SeriesTemplate.View;
            view.BarWidth = 0.8;
            view.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid; // Ensure FillMode is set
            view.Color = Color.LightCoral; // Vibrant coral (alternative to FillOptions)
            view.Border.Color = System.Drawing.Color.FromArgb(50, 50, 50); // Subtle border
            view.Border.Thickness = 1;

            // Customize diagram and axes
            XYDiagram diagram = (XYDiagram)barChartQCProcPercent.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;
            diagram.AxisX.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            diagram.AxisX.Label.Angle = 0; // Horizontal labels for readability
            diagram.AxisY.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            diagram.AxisY.Label.TextPattern = "{V:n0}";
            diagram.AxisY.GridLines.Visible = true;
            diagram.AxisY.GridLines.Color = System.Drawing.Color.FromArgb(220, 220, 220); // Light gray grid lines

            // Add and customize chart title
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "PPM BY PROCESS";
            chartTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); // Modern font
            chartTitle.Alignment = StringAlignment.Center;
            barChartQCProcPercent.Titles.Clear();
            barChartQCProcPercent.Titles.Add(chartTitle);

            // Customize legend
            barChartQCProcPercent.Legend.Direction = LegendDirection.LeftToRight;
            barChartQCProcPercent.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartQCProcPercent.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartQCProcPercent.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartQCProcPercent.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            barChartQCProcPercent.Legend.Font = new System.Drawing.Font("Segoe UI", 8);

            // Add secondary axis for line series
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");
            myAxisY.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            myAxisY.Label.TextPattern = "{V:n0}";
            ((XYDiagram)barChartQCProcPercent.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesLine = new Series("% PPM", ViewType.Line);
            ((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            seriesLine.View.Color = Color.LimeGreen; // Vibrant green
            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine.DataSource = IQCPPMByProcessDataPoint.GetDataPointsLine(DailyIQCPPMByProcessChart());
            seriesLine.SetDataMembers("IQCCheckName", "Ratio");

            barChartQCProcPercent.Series.Add(seriesLine);
            barChartQCProcPercent.Dock = DockStyle.Fill;

            splitContainerControl4.Panel1.Controls.Add(barChartQCProcPercent);
        }
        #endregion

        #region IQCDefectPercentChart
        private DataTable DailyIQCDefectPercentChart()
        {
            DataTable dt = new DataTable();

            int Week = 0;

            dt = iqcDao.GetDailyIQCDefectPercentChartV2(Convert.ToDateTime(dtFromDate.EditValue), Convert.ToDateTime(dtToDate.EditValue));

            return dt;
        }

        private void DailyIQCDefectPercentChartAddSeries()
        {
            // Bind the chart to a data source
            barChartQCDefectPercent.DataSource = IQCDefectPercentDataPoint.GetDataPoints(DailyIQCDefectPercentChart());
            barChartQCDefectPercent.SeriesTemplate.ChangeView(ViewType.StackedBar);
            barChartQCDefectPercent.SeriesTemplate.SeriesDataMember = "Caption";
            barChartQCDefectPercent.SeriesTemplate.SetDataMembers("Issue", "Ratio");

            // Enable and customize series point labels
            barChartQCDefectPercent.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((BarSeriesLabel)barChartQCDefectPercent.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartQCDefectPercent.SeriesTemplate.Label).TextPattern = "{V:n0}";
            ((BarSeriesLabel)barChartQCDefectPercent.SeriesTemplate.Label).Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular);

            // Customize series view settings
            StackedBarSeriesView view = (StackedBarSeriesView)barChartQCDefectPercent.SeriesTemplate.View;
            view.BarWidth = 0.8;
            view.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid; // Ensure FillMode is set
            view.Color = Color.Turquoise; // Vibrant turquoise (alternative to FillOptions)
            view.Border.Color = System.Drawing.Color.FromArgb(50, 50, 50); // Subtle border
            view.Border.Thickness = 1;

            // Customize diagram and axes
            XYDiagram diagram = (XYDiagram)barChartQCDefectPercent.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;
            diagram.AxisX.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            diagram.AxisX.Label.Angle = 0; // Horizontal labels for readability
            diagram.AxisY.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            diagram.AxisY.Label.TextPattern = "{V:n0}";
            diagram.AxisY.GridLines.Visible = true;
            diagram.AxisY.GridLines.Color = System.Drawing.Color.FromArgb(220, 220, 220); // Light gray grid lines

            // Add and customize chart title
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "NG QUANTITY BY DEFECT";
            chartTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); // Modern font
            chartTitle.Alignment = StringAlignment.Center;
            barChartQCDefectPercent.Titles.Clear();
            barChartQCDefectPercent.Titles.Add(chartTitle);

            // Specify legend settings
            barChartQCDefectPercent.Legend.Direction = LegendDirection.LeftToRight;
            barChartQCDefectPercent.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartQCDefectPercent.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartQCDefectPercent.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartQCDefectPercent.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            barChartQCDefectPercent.Legend.Font = new System.Drawing.Font("Segoe UI", 8);

            // Add secondary axis for line series
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");
            myAxisY.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            myAxisY.Label.TextPattern = "{V:n0}";
            ((XYDiagram)barChartQCDefectPercent.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesLine = new Series("% NG", ViewType.Line);
            ((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            seriesLine.View.Color = Color.Gold; // Vibrant gold
            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine.DataSource = IQCDefectPercentDataPoint.GetDataPointsPercentLine(DailyIQCDefectPercentChart());
            seriesLine.SetDataMembers("Issue", "Ratio");

            barChartQCDefectPercent.Series.Add(seriesLine);
            barChartQCDefectPercent.Dock = DockStyle.Fill;

            splitContainerControl3.Panel2.Controls.Add(barChartQCDefectPercent);
        }
        #endregion

        #region IQCProductPPMChart
        private DataTable DailyIQCPPMByProductChart()
        {
            DataTable dt = new DataTable();

            int Week = 0;

            dt = iqcDao.GetDailyIQCPPMByProductChartV2(Convert.ToDateTime(this.dtFromDate.EditValue), Convert.ToDateTime(this.dtToDate.EditValue));

            return dt;
        }

        private void DailyIQCPPMByProductChartAddSeries()
        {
            // Bind the chart to a data source
            barChartQCProcProduct.DataSource = IQCPPMByProcessDataPoint.GetDataPoints(DailyIQCPPMByProductChart());
            barChartQCProcProduct.SeriesTemplate.ChangeView(ViewType.StackedBar);
            barChartQCProcProduct.SeriesTemplate.SeriesDataMember = "Caption";
            barChartQCProcProduct.SeriesTemplate.SetDataMembers("IQCCheckName", "Ratio");

            // Enable and customize series point labels
            barChartQCProcProduct.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((BarSeriesLabel)barChartQCProcProduct.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartQCProcProduct.SeriesTemplate.Label).TextPattern = "{V:n0}";
            ((BarSeriesLabel)barChartQCProcProduct.SeriesTemplate.Label).Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular);

            // Customize series view settings
            StackedBarSeriesView view = (StackedBarSeriesView)barChartQCProcProduct.SeriesTemplate.View;
            view.BarWidth = 0.8;
            view.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid; // Ensure FillMode is set
            view.Color = Color.Violet; // Vibrant violet
            view.Border.Color = System.Drawing.Color.FromArgb(40, 40, 40); // Slightly darker subtle border
            view.Border.Thickness = 1;

            // Customize diagram and axes
            XYDiagram diagram = (XYDiagram)barChartQCProcProduct.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;
            diagram.AxisX.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            diagram.AxisX.Label.Angle = 0; // Horizontal labels for readability
            diagram.AxisY.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            diagram.AxisY.Label.TextPattern = "{V:n0}";
            diagram.AxisY.GridLines.Visible = true;
            diagram.AxisY.GridLines.Color = System.Drawing.Color.FromArgb(220, 220, 220); // Light gray grid lines
            diagram.AxisY.GridLines.MinorVisible = false; // Avoid clutter with minor grid lines

            // Add and customize chart title
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "PPM BY PRODUCT";
            chartTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            chartTitle.Alignment = StringAlignment.Center;
            barChartQCProcProduct.Titles.Clear();
            barChartQCProcProduct.Titles.Add(chartTitle);

            // Specify legend settings
            barChartQCProcProduct.Legend.Direction = LegendDirection.LeftToRight;
            barChartQCProcProduct.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartQCProcProduct.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartQCProcProduct.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartQCProcProduct.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            barChartQCProcProduct.Legend.Font = new System.Drawing.Font("Segoe UI", 8);

            // Add secondary axis for line series
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");
            myAxisY.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            myAxisY.Label.TextPattern = "{V:n0}";
            ((XYDiagram)barChartQCProcProduct.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesLine = new Series("% PPM", ViewType.Line);
            ((LineSeriesView)seriesLine.View).AxisY = myAxisY;
            seriesLine.View.Color = Color.Orange; // Vibrant orange
            ((LineSeriesView)seriesLine.View).LineStyle.Thickness = 2;
            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesLine.DataSource = IQCPPMByProcessDataPoint.GetDataPointsLine(DailyIQCPPMByProductChart());
            seriesLine.SetDataMembers("IQCCheckName", "Ratio");

            barChartQCProcProduct.Series.Add(seriesLine);
            barChartQCProcProduct.Dock = DockStyle.Fill;

            splitContainerControl4.Panel2.Controls.Add(barChartQCProcProduct);
        }
        #endregion
        #region IQCDefectPPMChart
        private DataTable DailyIQCPPMByDefectChart()
        {
            DataTable dt = new DataTable();

            int Week = 0;

            dt = iqcDao.GetDailyIQCPPMByDefectChart(Convert.ToDateTime(this.dtFromDate.EditValue), Convert.ToDateTime(this.dtToDate.EditValue));

            return dt;
        }

        private void DailyIQCPPMByDefectChartAddSeries()
        {
            // Bind the chart to a data source
            barChartQCProcDefect.DataSource = IQCPPMByProcessDataPoint.GetDataPoints(DailyIQCPPMByDefectChart());
            barChartQCProcDefect.SeriesTemplate.ChangeView(ViewType.StackedBar);
            barChartQCProcDefect.SeriesTemplate.SeriesDataMember = "Caption";
            barChartQCProcDefect.SeriesTemplate.SetDataMembers("IQCCheckName", "Ratio");

            // Enable and customize series point labels
            barChartQCProcDefect.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((BarSeriesLabel)barChartQCProcDefect.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartQCProcDefect.SeriesTemplate.Label).TextPattern = "{V:n0}";
            ((BarSeriesLabel)barChartQCProcDefect.SeriesTemplate.Label).Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular);

            // Customize series view settings
            StackedBarSeriesView view = (StackedBarSeriesView)barChartQCProcDefect.SeriesTemplate.View;
            view.BarWidth = 0.8;
            view.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid; // Ensure FillMode is set
            view.Color = Color.LightGreen; // Vibrant light green
            view.Border.Color = System.Drawing.Color.FromArgb(50, 50, 50); // Subtle border
            view.Border.Thickness = 1;

            // Customize diagram and axes
            XYDiagram diagram = (XYDiagram)barChartQCProcDefect.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;
            diagram.AxisX.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            diagram.AxisX.Label.Angle = 0; // Horizontal labels for readability
            diagram.AxisY.Label.Font = new System.Drawing.Font("Segoe UI", 8);
            diagram.AxisY.Label.TextPattern = "{V:n0}";
            diagram.AxisY.GridLines.Visible = true;
            diagram.AxisY.GridLines.Color = System.Drawing.Color.FromArgb(220, 220, 220); // Light gray grid lines

            // Add and customize chart title
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "PPM BY DEFECT";
            chartTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); // Modern font
            chartTitle.Alignment = StringAlignment.Center;
            barChartQCProcDefect.Titles.Clear();
            barChartQCProcDefect.Titles.Add(chartTitle);

            // Specify legend settings
            barChartQCProcDefect.Legend.Direction = LegendDirection.LeftToRight;
            barChartQCProcDefect.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChartQCProcDefect.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            barChartQCProcDefect.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            barChartQCProcDefect.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            barChartQCProcDefect.Legend.Font = new System.Drawing.Font("Segoe UI", 8);

            barChartQCProcDefect.Dock = DockStyle.Fill;

            splitContainerControl5.Panel1.Controls.Add(barChartQCProcDefect);
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
            //chartDate = (DateTime)dtpChartDate.EditValue;

            LoadData();
        }

        private void DtToDate_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LstWeekName_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (Month == 0)
            //    Month = DateTime.Now.Month;

            //if (Year == 0)
            //    Year = DateTime.Now.Year;

            //int Week = 0;
            //DataTable dtDate = prodDao.GetDateByWeek(Week, Month, Year);

            //chartDate = (DateTime)dtpChartDate.EditValue;

            //if (dtDate.Rows.Count > 0)
            //{
            //    dtpChartDate.EditValue = chartDate;
            //}

            //LoadData();
            
        }
        #endregion

        #region reset
        private void ResetChartControl()
        {
            splitContainerControl4.Panel1.Controls.Remove(barChartQCProcPercent);
            splitContainerControl3.Panel1.Controls.Remove(barChartQCPPM);
            splitContainerControl4.Panel2.Controls.Remove(barChartQCProcProduct);
            splitContainerControl3.Panel2.Controls.Remove(barChartQCDefectPercent);
            splitContainerControl5.Panel1.Controls.Remove(barChartQCProcDefect);

            barChartQCProcPercent = new ChartControl();
            barChartQCPPM = new ChartControl();
            barChartDailyProd = new ChartControl();
            barChartProductivity = new ChartControl();
            barChartQCDefectPercent = new ChartControl();
            barChartQCProcProduct = new ChartControl();
            barChartQCProcDefect = new ChartControl();
        }
        #endregion
    }
}
