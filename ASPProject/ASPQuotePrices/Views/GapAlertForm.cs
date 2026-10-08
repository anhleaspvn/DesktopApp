using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormApp.Models;

namespace WinFormApp.Views
{
    public partial class GapAlertForm : Form
    {
        private List<Component> _components;

        public GapAlertForm(List<Component> components)
        {
            InitializeComponent();
            _components = components;
            this.Load += GapAlertForm_Load;
            btnClose.Click += (s, e) => this.Close();
            dgvGaps.CellFormatting += DgvGaps_CellFormatting;
        }

        private void GapAlertForm_Load(object sender, EventArgs e)
        {
            AnalyzeAndBindGaps();
            StyleGrid();
        }

        private void AnalyzeAndBindGaps()
        {
            var gapList = new List<GapReportItem>();

            foreach (var item in _components)
            {
                bool hasLtGap = item.LeadTime > 12;
                // Pricing gap if PO Price exceeds Cost BOM or if Cost BOM is 0 but PO Price exists
                bool hasPriceGap = (item.CostBOM > 0 && item.POPrice != item.CostBOM) || (item.CostBOM == 0 && item.POPrice > 0);
                
                // Source / vendor status
                bool isMultiSource = _components
                    .Where(x => x.InternalPN == item.InternalPN && !string.IsNullOrEmpty(x.Vendor))
                    .Select(x => x.Vendor.ToLower())
                    .Distinct()
                    .Count() > 1;

                if (hasLtGap || hasPriceGap || isMultiSource)
                {
                    List<string> issues = new List<string>();
                    string type = "";

                    if (hasLtGap && hasPriceGap)
                    {
                        type = "LT & Cost Gap";
                        issues.Add($"LT {item.LeadTime:F1} Wks (>12)");
                        decimal diff = item.POPrice - item.CostBOM;
                        decimal pct = item.CostBOM > 0 ? (diff / item.CostBOM) * 100 : 100;
                        issues.Add($"Price Gap: ${diff:F2} ({pct:F1}%)");
                    }
                    else if (hasLtGap)
                    {
                        type = "LT Gap";
                        issues.Add($"LT {item.LeadTime:F1} Wks exceeds standard 12.0 Wks");
                    }
                    else if (hasPriceGap)
                    {
                        type = "Cost Gap";
                        decimal diff = item.POPrice - item.CostBOM;
                        decimal pct = item.CostBOM > 0 ? (diff / item.CostBOM) * 100 : 100;
                        issues.Add($"PO Price ${item.POPrice:F2} vs BOM Cost ${item.CostBOM:F2} (Gap: {pct:F1}%)");
                    }

                    if (isMultiSource)
                    {
                        type = string.IsNullOrEmpty(type) ? "Source Audit" : type + " + Source";
                        var vendors = _components
                            .Where(x => x.InternalPN == item.InternalPN)
                            .Select(x => x.Vendor)
                            .Distinct()
                            .ToList();
                        issues.Add($"Multi-sourced: {string.Join(", ", vendors)}");
                    }

                    gapList.Add(new GapReportItem
                    {
                        Id = item.Id,
                        PartNumber = item.InternalPN,
                        GILRef = item.GIL_PN_Ref ?? "N/A",
                        Revision = item.Revision,
                        Section = item.Section,
                        LeadTime = item.LeadTime,
                        CostBOM = item.CostBOM,
                        POPrice = item.POPrice,
                        PriceDifference = item.POPrice - item.CostBOM,
                        PercentDifference = item.CostBOM > 0 ? ((item.POPrice - item.CostBOM) / item.CostBOM) * 100 : 100m,
                        Vendor = item.Vendor ?? "Unknown",
                        PIC = item.PIC_Section ?? "N/A",
                        GapType = type,
                        AlertDescription = string.Join(" | ", issues)
                    });
                }
            }

            dgvGaps.DataSource = gapList;

            // Stats
            int totalGaps = gapList.Count;
            int ltGaps = gapList.Count(x => x.GapType.Contains("LT"));
            int costGaps = gapList.Count(x => x.GapType.Contains("Cost"));
            
            lblStats.Text = $"Total GAPs: {totalGaps} items  |  Lead Time GAPs: {ltGaps}  |  Pricing GAPs: {costGaps}";
            if (totalGaps > 0)
            {
                panelHeader.BackColor = Color.FromArgb(220, 38, 38); // Red for critical gaps
            }
            else
            {
                panelHeader.BackColor = Color.FromArgb(5, 150, 105); // Green if clear
                lblHeaderTitle.Text = "✓ ALL COMPONENT GAPS CLEARED";
                lblHeaderDesc.Text = "Lead Times are within standard limits, pricing aligns with BOMs, and sources match PO requirements.";
            }
        }

        private void StyleGrid()
        {
            if (dgvGaps.Columns.Count > 0)
            {
                dgvGaps.Columns["Id"].Visible = false;
                dgvGaps.Columns["PartNumber"].Width = 110;
                dgvGaps.Columns["GILRef"].Width = 80;
                dgvGaps.Columns["Revision"].Width = 55;
                dgvGaps.Columns["Section"].Width = 60;
                dgvGaps.Columns["LeadTime"].Width = 80;
                dgvGaps.Columns["CostBOM"].Width = 90;
                dgvGaps.Columns["POPrice"].Width = 90;
                dgvGaps.Columns["PriceDifference"].Width = 90;
                dgvGaps.Columns["PercentDifference"].Width = 90;
                dgvGaps.Columns["Vendor"].Width = 90;
                dgvGaps.Columns["PIC"].Width = 90;
                dgvGaps.Columns["GapType"].Width = 110;
                dgvGaps.Columns["AlertDescription"].Width = 280;

                dgvGaps.Columns["PartNumber"].HeaderText = "Part Number";
                dgvGaps.Columns["GILRef"].HeaderText = "GIL Ref";
                dgvGaps.Columns["LeadTime"].HeaderText = "LT (Wks)";
                dgvGaps.Columns["CostBOM"].HeaderText = "BOM Cost";
                dgvGaps.Columns["POPrice"].HeaderText = "PO Price";
                dgvGaps.Columns["PriceDifference"].HeaderText = "Price Gap";
                dgvGaps.Columns["PercentDifference"].HeaderText = "% Pricing";
                dgvGaps.Columns["GapType"].HeaderText = "GAP Category";
                dgvGaps.Columns["AlertDescription"].HeaderText = "Details of Discrepancy";

                // Format numbers
                dgvGaps.Columns["LeadTime"].DefaultCellStyle.Format = "N1";
                dgvGaps.Columns["CostBOM"].DefaultCellStyle.Format = "C4";
                dgvGaps.Columns["POPrice"].DefaultCellStyle.Format = "C4";
                dgvGaps.Columns["PriceDifference"].DefaultCellStyle.Format = "C4";
                dgvGaps.Columns["PercentDifference"].DefaultCellStyle.Format = "N1";
            }
        }

        private void DgvGaps_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGaps.Columns[e.ColumnIndex].Name == "GapType" && e.Value != null)
            {
                string val = e.Value.ToString();
                if (val.Contains("LT & Cost"))
                {
                    e.CellStyle.BackColor = Color.FromArgb(127, 29, 29); // Dark red
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (val.Contains("Cost"))
                {
                    e.CellStyle.BackColor = Color.FromArgb(153, 27, 27); // Red
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (val.Contains("LT"))
                {
                    e.CellStyle.BackColor = Color.FromArgb(146, 64, 14); // Dark orange
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (val.Contains("Source"))
                {
                    e.CellStyle.BackColor = Color.FromArgb(30, 58, 138); // Dark blue
                    e.CellStyle.ForeColor = Color.White;
                }
            }
            
            // Format Gap differences with color flags
            if (dgvGaps.Columns[e.ColumnIndex].Name == "PriceDifference" && e.Value != null)
            {
                decimal diff = (decimal)e.Value;
                if (diff > 0)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(248, 113, 113); // Soft red
                }
                else if (diff < 0)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(52, 211, 153); // Soft green
                }
            }
        }
    }

    // Helper model for binding gap reports in grid
    public class GapReportItem
    {
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string GILRef { get; set; }
        public string Revision { get; set; }
        public string Section { get; set; }
        public decimal LeadTime { get; set; }
        public decimal CostBOM { get; set; }
        public decimal POPrice { get; set; }
        public decimal PriceDifference { get; set; }
        public decimal PercentDifference { get; set; }
        public string Vendor { get; set; }
        public string PIC { get; set; }
        public string GapType { get; set; }
        public string AlertDescription { get; set; }
    }
}
