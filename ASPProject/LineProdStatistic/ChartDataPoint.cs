using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace ASPProject.LineProdStatistic
{
    #region ProductionChart
    public static class Win32Native
    {
        public const int DESKTOPVERTRES = 0x75;
        public const int DESKTOPHORZRES = 0x76;

        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hDC, int index);
    }

    public class AttendanceChartDataPoint
    {
        public DateTime AttendanceDate { get; set; }
        public int MonthPoint { get; set; }
        public double Ratio { get; set; }
        public string Caption { get; set; }
        public string ColorMember { get; set; }

        public static string defaultBlue = "#3d85c6";
        public static string defaultRed = "#BA4D51";
        public AttendanceChartDataPoint(DateTime attendanceDate, double ratio, string caption, string colorMember)
        {
            this.AttendanceDate = attendanceDate;
            this.Ratio = ratio;
            this.Caption = caption;
            this.ColorMember = colorMember;
        }
        public static List<AttendanceChartDataPoint> GetDataPoints(DataTable dt)
        {
            List<AttendanceChartDataPoint> data = new List<AttendanceChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new AttendanceChartDataPoint(Convert.ToDateTime(dr["AttendanceDate"]), Convert.ToDouble(dr["PRatio"]), "% Hiện diện", defaultBlue));
                data.Add(new AttendanceChartDataPoint(Convert.ToDateTime(dr["AttendanceDate"]), Convert.ToDouble(dr["VRatio"]), "% Vắng %", defaultRed));
            }

            return data;
        }

        public static List<AttendanceChartDataPoint> GetDataPointsLineChart(DataTable dt)
        {
            List<AttendanceChartDataPoint> data = new List<AttendanceChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["PRatio"]) > 0)
                    data.Add(new AttendanceChartDataPoint(Convert.ToDateTime(dr["AttendanceDate"]), Convert.ToDouble(dr["PRatio"]), "% Hiện diện", defaultBlue));
            }

            return data;
        }

        public static List<AttendanceChartDataPoint> GetDataPointsCircleChart(DataTable dt)
        {
            List<AttendanceChartDataPoint> data = new List<AttendanceChartDataPoint>();

            if (dt.Rows.Count > 0)
            {
                double pRatio = Convert.ToDouble(dt.Compute("AVG(PRatio)", "PRatio > 0")) / 100;
                double vRatio = Convert.ToDouble(dt.Compute("AVG(VRatio)", "VRatio > 0")) / 100;

                data.Add(new AttendanceChartDataPoint(Convert.ToDateTime("1900-01-01"), pRatio, "% Hiện diện", defaultBlue));
                data.Add(new AttendanceChartDataPoint(Convert.ToDateTime("1900-01-01"), vRatio, "% Vắng", defaultRed));
            }


            return data;
        }
    }

    public class YieldChartDataPoint
    {
        //public DateTime StatisticDate { get; set; }
        public double Quantity { get; set; }
        public string Caption { get; set; }

        public YieldChartDataPoint(double defectQuantity, string caption)
        {
            //this.StatisticDate = statisticDate;
            this.Quantity = defectQuantity;
            this.Caption = caption;
        }

        public static List<YieldChartDataPoint> GetDataPointsDefectStackBar(DataTable dt)
        {
            List<YieldChartDataPoint> data = new List<YieldChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new YieldChartDataPoint(Convert.ToDouble(dr["NumPercent"]), Convert.ToString(dr["ContentID"])));
            }

            return data;
        }

        public static List<YieldChartDataPoint> GetDataOTDStackBar(DataTable dt)
        {
            List<YieldChartDataPoint> data = new List<YieldChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new YieldChartDataPoint(Convert.ToDouble(dr["NumPercent"]), Convert.ToString(dr["ContentID"])));
            }

            return data;
        }




    }

    public class ProdChartDataPoint
    {
        public DateTime StatisticDate { get; set; }
        public double Quantity { get; set; }
        public string Caption { get; set; }

        public ProdChartDataPoint(DateTime statisticDate, double quantity, string caption)
        {
            this.StatisticDate = statisticDate;
            this.Quantity = quantity;
            this.Caption = caption;
        }

        public static List<ProdChartDataPoint> GetDataPointsActualBar(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ActualQuantity"]), "Actual"));
            }

            return data;
        }

        public static List<ProdChartDataPoint> GetDataPointsYearActualBar(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["FGsactual"]), "Actual"));
            }

            return data;
        }

        public static List<ProdChartDataPoint> GetDataPointsActualLine(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["YieldRateOfActual"]) > 0)
                    data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["YieldRateOfActual"]), "Actual"));
            }

            return data;
        }

        public static List<ProdChartDataPoint> GetDataPointsMpsPlanBar(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["MbsPlanQuantity"]), "Mps Plan"));
            }

            return data;
        }

        public static List<ProdChartDataPoint> GetDataPointsYearMpsPlanBar(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["MPSPlan"]), "Mps Plan"));
            }

            return data;
        }

        public static List<ProdChartDataPoint> GetDataPointsPlanBar(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["PlanQuantity"]), "FGs Plan"));
            }

            return data;
        }

        public static List<ProdChartDataPoint> GetDataPointsYearPlanBar(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["FGsplan"]), "FGs Plan"));
            }

            return data;
        }

        public static List<ProdChartDataPoint> GetDataPointsPlanningLine(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["TotalORTarget"]) > 0)
                    data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["TotalORTarget"]), "Actual"));
            }

            return data;
        }
    }



    public class ProductivityChartDataPoint
    {
        public DateTime StatisticDate { get; set; }
        public double Quantity { get; set; }
        public string Caption { get; set; }

        public ProductivityChartDataPoint(DateTime statisticDate, double quantity, string caption)
        {
            this.StatisticDate = statisticDate;
            this.Quantity = quantity;
            this.Caption = caption;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsActualBar(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ActualQuantity"]), "Actual"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsORActualBar(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ORActual"]), "Actual"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsYearORActualBar(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ORActual"]), "Actual"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsORTargetBar(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ORTarget"]), "Target"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsYearORTargetBar(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ORTarget"]), "Target"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsORACCBar(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["YieldORActual"]), "ACC"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsYearORACCBar(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ORACC"]), "ACC"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsActualLine(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["YieldRateDGOfVN"]) > 0)
                    data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["YieldRateDGOfVN"]), "Actual"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsYearActualLine(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["YieldRateDGOfVN"]) > 0)
                    data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["Orrateactual"]), "Actual"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsACCLine(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["YieldRateACC"]) > 0)
                    data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["YieldRateACC"]), "OR ACC"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsYearACCLine(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["YieldRateACC"]) > 0)
                    data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ActualACC"]), "OR ACC"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsTargetLine(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["ProductivityTarget"]) > 0)
                    data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ProductivityTarget"]), "Target"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsYearTargetLine(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["Target"]) > 0)
                    data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["Target"]), "Target"));
            }

            return data;
        }
    }

    public class ProdScrapChartDataPoint
    {
        public DateTime StatisticDate { get; set; }
        public double Quantity { get; set; }
        public string Caption { get; set; }

        public ProdScrapChartDataPoint(DateTime statisticDate, double quantity, string caption)
        {
            this.StatisticDate = statisticDate;
            this.Quantity = quantity;
            this.Caption = caption;
        }

        public static List<ProdScrapChartDataPoint> GetDataPointsActualBar(DataTable dt)
        {
            List<ProdScrapChartDataPoint> data = new List<ProdScrapChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProdScrapChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["PercentMoney"]), "% Vt xin thêm"));
            }

            return data;
        }

        public static List<ProdScrapChartDataPoint> GetDataPointsActualLine(DataTable dt)
        {
            List<ProdScrapChartDataPoint> data = new List<ProdScrapChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["YieldPercentMoney"]) > 0)
                    data.Add(new ProdScrapChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["YieldPercentMoney"]), "Luỹ kế"));
            }

            return data;
        }

        public static List<ProdScrapChartDataPoint> GetDataPointsPlanningLine(DataTable dt)
        {
            List<ProdScrapChartDataPoint> data = new List<ProdScrapChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["PercentTarget"]) > 0)
                    data.Add(new ProdScrapChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["PercentTarget"]), "Target"));
            }

            return data;
        }
    }

    public class PlanningChartDataPoint
    {
        public DateTime MonthPoint { get; set; }
        public double Ratio { get; set; }
        public string Caption { get; set; }
        public string ColorMember { get; set; }

        public static string defaultBlue = "#3d85c6";
        public static string defaultRed = "#BA4D51";

        public PlanningChartDataPoint(DateTime monthPoint, double ratio, string caption, string colorMember)
        {
            this.MonthPoint = monthPoint;
            this.Ratio = ratio;
            this.Caption = caption;
            this.ColorMember = colorMember;
        }

        public static List<PlanningChartDataPoint> GetDataPoints(DataTable dt)
        {
            List<PlanningChartDataPoint> data = new List<PlanningChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new PlanningChartDataPoint(Convert.ToDateTime(dr["DateMonth"]), Convert.ToDouble(dr["FinishRatio"]), "% Hoàn thành", defaultBlue));
                data.Add(new PlanningChartDataPoint(Convert.ToDateTime(dr["DateMonth"]), Convert.ToDouble(dr["UnfinishRatio"]), "% Chưa hoàn thành", defaultRed));
            }

            return data;
        }
    }

    public class DefectChartDataPoint
    {
        public DateTime StatisticDate { get; set; }
        public double Quantity { get; set; }
        public string Caption { get; set; }
        public string ColorMember { get; set; }

        public static string defaultBlue = "#3d85c6";
        public static string defaultRed = "#BA4D51";

        public DefectChartDataPoint(DateTime statisticDate, double quantity, string caption, string colorMember)
        {
            this.StatisticDate = statisticDate;
            this.Quantity = quantity;
            this.Caption = caption;
            this.ColorMember = colorMember;
        }

        public static List<DefectChartDataPoint> GetDataPoints(DataTable dt)
        {
            List<DefectChartDataPoint> data = new List<DefectChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new DefectChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["DFQuantity"]), "Số lượng", defaultRed));
            }

            return data;
        }
    }
    #endregion

    #region QualityChart
    public class IQCPPMChartDataPoint
    {
        public DateTime DocDate { get; set; }
        public int MonthPoint { get; set; }
        public double Ratio { get; set; }
        public string Caption { get; set; }
        public string ColorMember { get; set; }

        public static string defaultBlue = "#3d85c6";
        public static string defaultRed = "#BA4D51";

        public IQCPPMChartDataPoint(DateTime docDate, double ratio, string caption, string colorMember)
        {
            this.DocDate = docDate;
            this.Ratio = ratio;
            this.Caption = caption;
            this.ColorMember = colorMember;
        }

        public static List<IQCPPMChartDataPoint> GetDataPoints(DataTable dt)
        {
            List<IQCPPMChartDataPoint> data = new List<IQCPPMChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new IQCPPMChartDataPoint(Convert.ToDateTime(dr["DocDate"]), Convert.ToDouble(dr["PPM"]), "% PPM", defaultRed));
            }

            return data;
        }

        public static List<IQCPPMChartDataPoint> GetDataPointsLineChart(DataTable dt)
        {
            List<IQCPPMChartDataPoint> data = new List<IQCPPMChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["PPM"]) > 0)
                    data.Add(new IQCPPMChartDataPoint(Convert.ToDateTime(dr["DocDate"]), Convert.ToDouble(dr["PPM"]), "% PPM", defaultBlue));
            }

            return data;
        }
    }

    public class IQCProcessPercentDataPoint
    {
        public string IQCCheckName { get; set; }
        public double Ratio { get; set; }
        public string Caption { get; set; }
        public string ColorMember { get; set; }

        public static string defaultBlue = "#3d85c6";
        public static string defaultRed = "#BA4D51";

        public IQCProcessPercentDataPoint(string iqcCheckName, double ratio, string caption, string colorMember)
        {
            this.IQCCheckName = iqcCheckName;
            this.Ratio = ratio;
            this.Caption = caption;
            this.ColorMember = colorMember;
        }

        public static List<IQCProcessPercentDataPoint> GetDataPoints(DataTable dt)
        {
            List<IQCProcessPercentDataPoint> data = new List<IQCProcessPercentDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new IQCProcessPercentDataPoint(Convert.ToString(dr["IQCCheckName"]), Convert.ToDouble(dr["OKPercent"]), "% Đạt", defaultBlue));
                data.Add(new IQCProcessPercentDataPoint(Convert.ToString(dr["IQCCheckName"]), Convert.ToDouble(dr["NGPercent"]), "% NG", defaultRed));
            }

            return data;
        }
    }
    #endregion
}
