using System;

namespace WinFormApp.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Revision { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
        public DateTime? QuotationDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string Customer { get; set; }
        public string CustomerPN { get; set; }
        public string InternalPN { get; set; }
        public string GIL_PN_Ref { get; set; }
        public string Spec { get; set; }
        public string Manufacturer { get; set; }
        public decimal LeadTime { get; set; }
        public decimal TargetPrice { get; set; }
        public decimal PercentPricing { get; set; }
        public decimal CostBOM { get; set; }
        public string Vendor { get; set; }
        public decimal POPrice { get; set; }
        public decimal POQty { get; set; }
        public string PIC_Section { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // --- GAP Calculations ---

        // Pricing Gap = POPrice - CostBOM
        public decimal PriceGap => POPrice - CostBOM;

        // % Pricing Gap = ((POPrice - CostBOM) / CostBOM) * 100
        public decimal PercentPriceGap
        {
            get
            {
                if (CostBOM == 0) return 0;
                return (PriceGap / CostBOM) * 100;
            }
        }

        // GAP LT = Difference in weeks relative to target (Standard is 12 weeks)
        public decimal LeadTimeGap => LeadTime - 12;

        // Flag indicating if there is a pricing discrepancy (e.g. PO price is higher than Cost BOM)
        public bool IsPricingGapWarning => POPrice > CostBOM && CostBOM > 0;

        // Flag indicating if lead time is high (e.g., > 12 weeks)
        public bool IsLeadTimeWarning => LeadTime > 12;
    }
}
