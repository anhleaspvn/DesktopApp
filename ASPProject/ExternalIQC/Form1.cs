using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace ASPProject.ExternalIQC
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            // Cài đặt Form chính
            this.Text = "INVENTORY Dashboard";
            this.Width = 1300;
            this.Height = 900;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tạo Panel chính cho Dashboard
            PanelControl mainPanel = new PanelControl();
            mainPanel.Dock = DockStyle.Fill;
            this.Controls.Add(mainPanel);

            // Header: Tiêu đề và thống kê
            PanelControl headerPanel = new PanelControl();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 150;  // Điều chỉnh chiều cao để vừa đủ hiển thị
            headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 128, 255);  // Màu xanh giống hình gốc
            mainPanel.Controls.Add(headerPanel);

            // Tiêu đề
            LabelControl titleLabel = new LabelControl()
            {
                Text = "INVENTORY Dashboard",
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                Dock = DockStyle.Left,
                Padding = new Padding(10, 0, 0, 0),
                ForeColor = System.Drawing.Color.White // Đặt màu chữ trắng
            };
            headerPanel.Controls.Add(titleLabel);

            // Thông tin thống kê
            PanelControl statsPanel = new PanelControl();
            statsPanel.Dock = DockStyle.Right;
            statsPanel.Width = 450;
            headerPanel.Controls.Add(statsPanel);
            statsPanel.BackColor = System.Drawing.Color.White; // Màu nền của phần thống kê

            // Các chỉ số trong phần thống kê
            CreateStatisticLabel(statsPanel, "Inventory Value", "$20,068,577");
            CreateStatisticLabel(statsPanel, "Stock Available", "3,790,813");
            CreateStatisticLabel(statsPanel, "Turnover Ratio", "9.13");
            CreateStatisticLabel(statsPanel, "Inventory to Sales Ratio", "0.44");
            CreateStatisticLabel(statsPanel, "Avg. Inventory Days of Supply", "39.98");

            // Body: Chia thành 3 hàng (Rows)
            TableLayoutPanel bodyPanel = new TableLayoutPanel();
            bodyPanel.Dock = DockStyle.Fill;
            bodyPanel.RowCount = 3;
            bodyPanel.ColumnCount = 2;
            bodyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
            bodyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
            bodyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
            bodyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            bodyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            mainPanel.Controls.Add(bodyPanel);

            // Row 1: Inventory Value Over Time và Turnover by Month
            ChartControl inventoryValueChart = new ChartControl();
            inventoryValueChart.Dock = DockStyle.Fill;
            bodyPanel.Controls.Add(inventoryValueChart, 0, 0); // Cột 1, Hàng 1
            CreateInventoryValueChart(inventoryValueChart);

            ChartControl turnoverChart = new ChartControl();
            turnoverChart.Dock = DockStyle.Fill;
            bodyPanel.Controls.Add(turnoverChart, 1, 0); // Cột 2, Hàng 1
            CreateTurnoverChart(turnoverChart);

            // Row 2: Inventory Movement và Inventory to Sales Analysis
            ChartControl inventoryMovementChart = new ChartControl();
            inventoryMovementChart.Dock = DockStyle.Fill;
            bodyPanel.Controls.Add(inventoryMovementChart, 0, 1); // Cột 1, Hàng 2
            CreateInventoryMovementChart(inventoryMovementChart);

            ChartControl inventoryToSalesChart = new ChartControl();
            inventoryToSalesChart.Dock = DockStyle.Fill;
            bodyPanel.Controls.Add(inventoryToSalesChart, 1, 1); // Cột 2, Hàng 2
            CreateInventoryToSalesChart(inventoryToSalesChart);

            // Row 3: Top 10 Items Based on Value
            ChartControl topItemsChart = new ChartControl();
            topItemsChart.Dock = DockStyle.Fill;
            bodyPanel.Controls.Add(topItemsChart, 0, 2); // Cột 1, Hàng 3
            CreateTopItemsChart(topItemsChart);
        }

        private void CreateStatisticLabel(PanelControl statsPanel, string label, string value)
        {
            // Tạo mỗi label trong phần thống kê
            LabelControl labelControl = new LabelControl()
            {
                Text = $"{label}: {value}",
                Dock = DockStyle.Top,
                Padding = new Padding(10, 5, 10, 5),
                Font = new System.Drawing.Font("Arial", 10)
            };
            statsPanel.Controls.Add(labelControl);
        }

        private void CreateInventoryValueChart(ChartControl chart)
        {
            // Tạo biểu đồ Inventory Value Over Time (Cột)
            Series series = new Series("Inventory Value", ViewType.Bar);
            series.Points.Add(new SeriesPoint("Jan", 20000000));
            series.Points.Add(new SeriesPoint("Feb", 19000000));
            series.Points.Add(new SeriesPoint("Mar", 19500000));
            series.Points.Add(new SeriesPoint("Apr", 21000000));
            series.Points.Add(new SeriesPoint("May", 22000000));
            series.Points.Add(new SeriesPoint("Jun", 21500000));
            series.Points.Add(new SeriesPoint("Jul", 22500000));
            series.Points.Add(new SeriesPoint("Aug", 23000000));
            series.Points.Add(new SeriesPoint("Sep", 22000000));
            series.Points.Add(new SeriesPoint("Oct", 21000000));
            series.Points.Add(new SeriesPoint("Nov", 20000000));
            series.Points.Add(new SeriesPoint("Dec", 19500000));

            chart.Series.Add(series);
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Sử dụng màu xanh lá cây nhạt dần
            ((BarSeriesView)series.View).ColorEach = true;
            series.View.Color = System.Drawing.Color.LimeGreen;
        }

        private void CreateTurnoverChart(ChartControl chart)
        {
            // Tạo biểu đồ Turnover by Month (Đường)
            Series series = new Series("Turnover", ViewType.Line);
            series.Points.Add(new SeriesPoint("Jan", 40));
            series.Points.Add(new SeriesPoint("Feb", 42));
            series.Points.Add(new SeriesPoint("Mar", 38));
            series.Points.Add(new SeriesPoint("Apr", 41));
            series.Points.Add(new SeriesPoint("May", 45));
            series.Points.Add(new SeriesPoint("Jun", 43));
            series.Points.Add(new SeriesPoint("Jul", 46));
            series.Points.Add(new SeriesPoint("Aug", 47));
            series.Points.Add(new SeriesPoint("Sep", 44));
            series.Points.Add(new SeriesPoint("Oct", 42));
            series.Points.Add(new SeriesPoint("Nov", 40));
            series.Points.Add(new SeriesPoint("Dec", 39));

            chart.Series.Add(series);
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Đường màu xanh dương
            series.View.Color = System.Drawing.Color.RoyalBlue;
        }

        private void CreateInventoryMovementChart(ChartControl chart)
        {
            // Biểu đồ Inventory Movement
            Series series1 = new Series("Purchase", ViewType.Bar);
            Series series2 = new Series("Sale", ViewType.Bar);
            series1.Points.Add(new SeriesPoint("Jan", 5000000));
            series2.Points.Add(new SeriesPoint("Jan", 4000000));

            chart.Series.Add(series1);
            chart.Series.Add(series2);
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
        }

        private void CreateInventoryToSalesChart(ChartControl chart)
        {
            // Biểu đồ Inventory to Sales
            Series series1 = new Series("Inventory Value", ViewType.Bar);
            Series series2 = new Series("Sales Amount", ViewType.Line);

            // Dữ liệu
            series1.Points.Add(new SeriesPoint("Jan", 20000000));
            series2.Points.Add(new SeriesPoint("Jan", 18000000));

            series1.Points.Add(new SeriesPoint("Feb", 19000000));
            series2.Points.Add(new SeriesPoint("Feb", 17000000));

            series1.Points.Add(new SeriesPoint("Mar", 19500000));
            series2.Points.Add(new SeriesPoint("Mar", 17500000));

            chart.Series.Add(series1);
            chart.Series.Add(series2);
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
        }

        private void CreateTopItemsChart(ChartControl chart)
        {
            // Biểu đồ Top 10 Items (cột ngang)
            Series series = new Series("Top 10 Items", ViewType.Bar);
            series.Points.Add(new SeriesPoint("C100006", 0.14));
            series.Points.Add(new SeriesPoint("C100011", 0.13));
            series.Points.Add(new SeriesPoint("C100055", 0.12));
            series.Points.Add(new SeriesPoint("C100009", 0.12));
            series.Points.Add(new SeriesPoint("C100010", 0.12));
            series.Points.Add(new SeriesPoint("C100040", 0.09));
            series.Points.Add(new SeriesPoint("C100004", 0.08));
            series.Points.Add(new SeriesPoint("C100003", 0.08));
            series.Points.Add(new SeriesPoint("C100002", 0.07));
            series.Points.Add(new SeriesPoint("C100001", 0.06));

            chart.Series.Add(series);
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Cấu hình cột ngang
            ((BarSeriesView)series.View).BarWidth = 0.6f;
            //chart.PaletteName = "Soft Pastel"; // Màu sắc

            // Cấu hình trục X và Y
            //chart.Diagram = new XYDiagram();
            ((XYDiagram)chart.Diagram).AxisX.Title.Text = "Value (M)";
            ((XYDiagram)chart.Diagram).AxisY.Title.Text = "Item Code";
        }
    }
}
