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

namespace ASPProject.LineProdStatistic
{
    public partial class InventoryDashboardForm : DevExpress.XtraEditors.XtraForm
    {
        public InventoryDashboardForm()
        {
            InitializeComponent();
            BuildLayout();
        }

        //private void InitializeComponent()
        //{
        //    this.Text = "Inventory Dashboard Clone";
        //    this.WindowState = FormWindowState.Maximized;
        //    this.BackColor = Color.White;
        //}

        private void BuildLayout()
        {
            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.White
            };
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var headerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.DarkRed,
            };
            var headerLabel = new Label
            {
                Text = "INVENTORY MANAGEMENT DASHBOARD",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };
            headerPanel.Controls.Add(headerLabel);
            mainPanel.Controls.Add(headerPanel, 0, 0);

            var contentPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 3,
                Padding = new Padding(20),
                BackColor = Color.White
            };
            for (int i = 0; i < 3; i++)
            {
                contentPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
                contentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            }

            contentPanel.Controls.Add(CreateChart("Inventory Turnover Ratio", ViewType.Line), 0, 0);
            contentPanel.Controls.Add(CreateChart("Days Inventory Outstanding", ViewType.Bar), 1, 0);
            contentPanel.Controls.Add(CreateChart("Average Inventory Levels", ViewType.Bar), 2, 0);

            contentPanel.Controls.Add(CreateChart("Inventory Accuracy", ViewType.Pie), 0, 1);
            contentPanel.Controls.Add(CreateChart("Cycle Count Accuracy", ViewType.Line), 1, 1);
            contentPanel.Controls.Add(CreateChart("Shrinkage Rate", ViewType.Bar), 2, 1);

            contentPanel.Controls.Add(CreateChart("Stock-Out Rate", ViewType.Bar), 0, 2);
            contentPanel.Controls.Add(CreateChart("Backorder Rate", ViewType.Pie), 1, 2);
            contentPanel.Controls.Add(CreateChart("Order Fill Rate", ViewType.Bar), 2, 2);

            mainPanel.Controls.Add(contentPanel, 0, 1);
            this.Controls.Add(mainPanel);
        }

        private ChartControl CreateChart(string title, ViewType type)
        {
            var chart = new ChartControl
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            var series = new Series(title, type);
            series.Points.AddRange(new[]
            {
            new SeriesPoint("JAN", 10),
            new SeriesPoint("FEB", 12),
            new SeriesPoint("MAR", 14),
            new SeriesPoint("APR", 13),
            new SeriesPoint("MAY", 15)
        });
            chart.Series.Add(series);

            chart.Titles.Add(new ChartTitle
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                //ForeColor = Color.FromArgb(33, 37, 41)
            });

            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            return chart;
        }
    }
}
