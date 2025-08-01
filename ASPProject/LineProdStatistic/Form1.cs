using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGauges.Core.Base;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Win;
using DevExpress.XtraGauges.Win.Base;
using DevExpress.XtraGauges.Win.Gauges.Circular;
using System;
using System.Drawing;
using System.Windows.Forms;
using ComboBoxEdit = DevExpress.XtraEditors.ComboBoxEdit;
using Label = System.Windows.Forms.Label;

namespace ASPProject.LineProdStatistic
{
    // Form1.cs - Inventory Dashboard nâng cấp giao diện với một số biểu đồ 3D
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.XtraCharts;
    using DevExpress.XtraEditors;
    using DevExpress.XtraCharts.UI;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Inventory Dashboard";
            this.WindowState = FormWindowState.Maximized;
            //this.BackgroundImage = Image.FromFile("background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            InitLayout();
        }

        private void InitLayout()
        {
            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
                BackColor = Color.Transparent
            };
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var headerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 120,
                BackColor = Color.FromArgb(255, 99, 132) // đỏ nổi bật
            };
            var headerLabel = new Label
            {
                Text = "DAILY PRODUCTION DASHBOARD",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0, 20, 0, 0)
            };
            headerPanel.Controls.Add(headerLabel);
            mainPanel.Controls.Add(headerPanel, 0, 0);

            var contentPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = 2,
                BackColor = Color.Transparent
            };
            contentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            contentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            var sidebarPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(255, 255, 255, 180),
                Padding = new Padding(25)
            };

            var lblDate = new Label { Text = "Date:", AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.FromArgb(64, 64, 64), Location = new Point(0, 20) };
            var datePicker = new DateTimePicker { Width = 180, Format = DateTimePickerFormat.Short, Location = new Point(80, 15) };
            var lblPlant = new Label { Text = "Plant:", AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.FromArgb(64, 64, 64), Location = new Point(0, 60) };
            var cboPlant = new ComboBoxEdit { Location = new Point(80, 55), Width = 180 };
            cboPlant.Properties.Items.AddRange(new[] { "Plant A", "Plant B", "Plant C" });
            cboPlant.SelectedIndex = 0;

            sidebarPanel.Controls.AddRange(new Control[] { lblDate, datePicker, lblPlant, cboPlant });
            contentPanel.Controls.Add(sidebarPanel, 0, 0);

            var chartPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 3,
                BackColor = Color.Transparent,
                Padding = new Padding(30),
                Margin = new Padding(0)
            };
            for (int i = 0; i < 3; i++)
            {
                chartPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
                chartPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
            }

            chartPanel.Controls.Add(CreateChartPanel(CreateCycleCountChart3D(), "Cycle Count Accuracy"), 0, 0);
            chartPanel.Controls.Add(CreateChartPanel(CreateShrinkageRateChart(), "Shrinkage Rate"), 1, 0);
            chartPanel.Controls.Add(CreateChartPanel(CreateOrderFillRateChart3D(), "Order Fill Rate"), 2, 0);
            chartPanel.Controls.Add(CreateChartPanel(CreateStorageSpaceUtilization(), "Storage Space Utilization"), 0, 1);
            chartPanel.Controls.Add(CreateChartPanel(CreateObsolescencePieChart3D(), "Obsolescence Inventory"), 1, 1);
            chartPanel.Controls.Add(CreateChartPanel(CreateDummyChart("Inventory Accuracy"), "Inventory Accuracy"), 2, 1);
            chartPanel.Controls.Add(CreateChartPanel(CreateDummyChart("Average Inventory"), "Average Inventory Levels"), 0, 2);
            chartPanel.Controls.Add(CreateChartPanel(CreateDummyChart("Inventory Turnover"), "Inventory Turnover"), 1, 2);
            chartPanel.Controls.Add(CreateChartPanel(CreateDummyChart("Demand Variability"), "Demand Variability"), 2, 2);

            contentPanel.Controls.Add(chartPanel, 1, 0);
            mainPanel.Controls.Add(contentPanel, 0, 1);
            this.Controls.Add(mainPanel);
        }

        private Panel CreateChartPanel(Control chart, string title)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(255, 255, 255, 200),
                Margin = new Padding(10)
            };

            var label = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Padding = new Padding(5, 0, 0, 8),
                Height = 30
            };

            chart.Dock = DockStyle.Fill;
            panel.Controls.Add(label);
            panel.Controls.Add(chart);
            return panel;
        }

        private ChartControl CreateCycleCountChart3D()
        {
            var chart = new ChartControl();
            var series = new Series("Cycle Count", ViewType.Bar3D);
            series.Points.AddRange(
                new SeriesPoint("APR", 85),
                new SeriesPoint("MAY", 87),
                new SeriesPoint("JUN", 88),
                new SeriesPoint("JUL", 89),
                new SeriesPoint("AUG", 90)
            );
            chart.Series.Add(series);
            //chart.Diagram = new XYDiagram3D();
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chart.BackColor = Color.Transparent;
            return chart;
        }

        private ChartControl CreateOrderFillRateChart3D()
        {
            var chart = new ChartControl();
            var series = new Series("Fill Rate", ViewType.Line3D);
            series.Points.AddRange(
                new SeriesPoint("APR", 92),
                new SeriesPoint("MAY", 94),
                new SeriesPoint("JUN", 93),
                new SeriesPoint("JUL", 95),
                new SeriesPoint("AUG", 96)
            );
            chart.Series.Add(series);
            //chart.Diagram = new XYDiagram3D();
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chart.BackColor = Color.Transparent;
            return chart;
        }

        private ChartControl CreateObsolescencePieChart3D()
        {
            var chart = new ChartControl();
            var series = new Series("Obsolete vs Active", ViewType.Pie3D);
            series.Points.AddRange(
                new SeriesPoint("Active", 85),
                new SeriesPoint("Obsolete", 15)
            );
            chart.Series.Add(series);
            chart.Legend.Font = new Font("Segoe UI", 10);
            chart.Legend.BackColor = Color.Transparent;
            chart.BackColor = Color.Transparent;
            return chart;
        }

        private ChartControl CreateShrinkageRateChart()
        {
            var chart = new ChartControl();
            var series = new Series("Shrinkage", ViewType.Bar);
            series.Points.AddRange(
                new SeriesPoint("APR", 3.1),
                new SeriesPoint("MAY", 2.9),
                new SeriesPoint("JUN", 3.0),
                new SeriesPoint("JUL", 3.2),
                new SeriesPoint("AUG", 3.3)
            );
            chart.Series.Add(series);
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chart.BackColor = Color.Transparent;
            return chart;
        }

        private ChartControl CreateStorageSpaceUtilization()
        {
            var chart = new ChartControl();
            var series = new Series("Utilization", ViewType.Area);
            series.Points.AddRange(
                new SeriesPoint("APR", 45),
                new SeriesPoint("MAY", 50),
                new SeriesPoint("JUN", 48),
                new SeriesPoint("JUL", 51),
                new SeriesPoint("AUG", 53)
            );
            chart.Series.Add(series);
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chart.BackColor = Color.Transparent;
            return chart;
        }

        private ChartControl CreateDummyChart(string name)
        {
            var chart = new ChartControl();
            var series = new Series(name, ViewType.Bar);
            series.Points.AddRange(new[]
            {
            new SeriesPoint("APR", 100),
            new SeriesPoint("MAY", 110),
            new SeriesPoint("JUN", 105),
            new SeriesPoint("JUL", 120),
            new SeriesPoint("AUG", 130)
        });
            chart.Series.Add(series);
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chart.BackColor = Color.Transparent;
            return chart;
        }
    }

}



