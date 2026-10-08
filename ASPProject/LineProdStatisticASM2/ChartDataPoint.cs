using System;
using System.Collections.Generic;
using System.Data;

namespace ASPProject.LineProdStatisticASM2
{
    #region ProductionChart
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
                data.Add(new AttendanceChartDataPoint(Convert.ToDateTime(dr["AttendanceDate"]), Convert.ToDouble(dr["PRatio"]), "Tỷ lệ hiện diện", defaultBlue));
                data.Add(new AttendanceChartDataPoint(Convert.ToDateTime(dr["AttendanceDate"]), Convert.ToDouble(dr["VRatio"]), "Tỷ lệ vắng", defaultRed));
            }

            return data;
        }

        public static List<AttendanceChartDataPoint> GetDataPointsLineChart(DataTable dt)
        {
            List<AttendanceChartDataPoint> data = new List<AttendanceChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["PRatio"]) > 0)
                    data.Add(new AttendanceChartDataPoint(Convert.ToDateTime(dr["AttendanceDate"]), Convert.ToDouble(dr["PRatio"]), "Tỷ lệ hiện diện", defaultBlue));
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

                data.Add(new AttendanceChartDataPoint(Convert.ToDateTime("1900-01-01"), pRatio, "Tỷ lệ hiện diện", defaultBlue));
                data.Add(new AttendanceChartDataPoint(Convert.ToDateTime("1900-01-01"), vRatio, "Tỷ lệ vắng", defaultRed));
            }


            return data;
        }
    }

    public class YieldChartDataPoint
    {
        //public DateTime StatisticDate { get; set; }
        public double Quantity { get; set; }
        public string Caption { get; set; }
        public DateTime StatisticDate { get; set; }

        public YieldChartDataPoint(DateTime statisticDate, double defectQuantity, string caption)
        {
            this.StatisticDate = statisticDate;
            this.Quantity = defectQuantity;
            this.Caption = caption;
        }

        public static List<YieldChartDataPoint> GetDataPointsDefectStackBar(DataTable dt)
        {
            List<YieldChartDataPoint> data = new List<YieldChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new YieldChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["NumYTD"]), Convert.ToString(dr["ContentID"])));
            }

            return data;
        }

        public static List<YieldChartDataPoint> GetDataPointsTargetStackBar(DataTable dt)
        {
            List<YieldChartDataPoint> data = new List<YieldChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new YieldChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["NumTarget"]), Convert.ToString(dr["ContentID"])));
            }

            return data;
        }

        public static List<YieldChartDataPoint> GetDataOTDStackBar(DataTable dt)
        {
            List<YieldChartDataPoint> data = new List<YieldChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new YieldChartDataPoint(DateTime.Now.Date, Convert.ToDouble(dr["NumPercent"]), Convert.ToString(dr["ContentID"])));
            }

            return data;
        }




    }

    public class OTDChartDataPoint
    {
        //public DateTime StatisticDate { get; set; }
        public double Quantity { get; set; }
        public string Caption { get; set; }
        public int Week { get; set; }

        public OTDChartDataPoint(int week, double defectQuantity, string caption)
        {
            this.Week = week;
            this.Quantity = defectQuantity;
            this.Caption = caption;
        }

        public static List<OTDChartDataPoint> GetOTDPlanStackBar(DataTable dt)
        {
            List<OTDChartDataPoint> data = new List<OTDChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new OTDChartDataPoint(Convert.ToInt32(dr["IntWeek"]), Convert.ToDouble(dr["NumPlan"]), "Plan"));
            }

            return data;
        }

        public static List<OTDChartDataPoint> GetOTDActualStackBar(DataTable dt)
        {
            List<OTDChartDataPoint> data = new List<OTDChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new OTDChartDataPoint(Convert.ToInt32(dr["IntWeek"]), Convert.ToDouble(dr["NumOnTime"]), "On time"));
            }

            return data;
        }

        public static List<OTDChartDataPoint> GetOTDActualRateLine(DataTable dt)
        {
            List<OTDChartDataPoint> data = new List<OTDChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new OTDChartDataPoint(Convert.ToInt32(dr["IntWeek"]), Convert.ToDouble(dr["ActualRate"]) * 100, "Rate"));
            }

            return data;
        }

        public static List<OTDChartDataPoint> GetOTDTargetRateLine(DataTable dt)
        {
            List<OTDChartDataPoint> data = new List<OTDChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new OTDChartDataPoint(Convert.ToInt32(dr["IntWeek"]), Convert.ToDouble(dr["TargetRate"]) * 100, "Rate"));
            }

            return data;
        }
    }

    public class OEEChartDataPoint
    {
        public DateTime StatisticDate { get; set; }
        public string MoldID { get; set; }
        public int MonthPoint { get; set; }
        public double Ratio { get; set; }
        public string Caption { get; set; }
        public string ColorMember { get; set; }

        public static string defaultBlue = "#3d85c6";
        public static string defaultRed = "#BA4D51";
        public OEEChartDataPoint(string moldID, double ratio, string caption, string colorMember)
        {
            this.MoldID = moldID;
            this.Ratio = ratio;
            this.Caption = caption;
            this.ColorMember = colorMember;
        }
        public static List<OEEChartDataPoint> GetDataOEEINJPoints(DataTable dt)
        {
            List<OEEChartDataPoint> data = new List<OEEChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new OEEChartDataPoint(Convert.ToString(dr["MoldID"]), Convert.ToDouble(dr["OEEINJ"]), Convert.ToString(dr["MachineID"]), defaultBlue));
            }

            return data;
        }

        public static List<OEEChartDataPoint> GetDataLossPPoints(DataTable dt)
        {
            List<OEEChartDataPoint> data = new List<OEEChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new OEEChartDataPoint(Convert.ToString(dr["MoldID"]), Convert.ToDouble(dr["PtramLossP"]), Convert.ToString(dr["MachineID"]), defaultRed));
            }

            return data;
        }

        public static List<OEEChartDataPoint> GetDataLossAPoints(DataTable dt)
        {
            List<OEEChartDataPoint> data = new List<OEEChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new OEEChartDataPoint(Convert.ToString(dr["MoldID"]), Convert.ToDouble(dr["PtramLossA"]), Convert.ToString(dr["MachineID"]), defaultRed));
            }

            return data;
        }

        public static List<OEEChartDataPoint> GetDataLossQPoints(DataTable dt)
        {
            List<OEEChartDataPoint> data = new List<OEEChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new OEEChartDataPoint(Convert.ToString(dr["MoldID"]), Convert.ToDouble(dr["PtramLossQ"]), Convert.ToString(dr["MachineID"]), defaultRed));
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
                data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ActualQuantity"]), "Thực tế/Actual"));
            }

            return data;
        }

        public static List<ProdChartDataPoint> GetDataPointsMBOBar(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["MBOTarget"]), "Thực tế/Actual"));
            }

            return data;
        }

        public static List<ProdChartDataPoint> GetDataPointsActualLine(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["YieldRateOfActual"]) > 0)
                    data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["YieldRateOfActual"]), "Thực tế/Actual"));
            }

            return data;
        }

        public static List<ProdChartDataPoint> GetDataPointsPlanningLine(DataTable dt)
        {
            List<ProdChartDataPoint> data = new List<ProdChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["TotalORTarget"]) > 0)
                    data.Add(new ProdChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["TotalORTarget"]), "Target Qty"));
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
                data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ActualQuantity"]), "Thực tế/Actual"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsActualLine(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["YieldRateDGOfVN"]) > 0)
                    data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["YieldRateDGOfVN"]), "Thực tế/Actual"));
            }

            return data;
        }

        public static List<ProductivityChartDataPoint> GetDataPointsTargetLine(DataTable dt)
        {
            List<ProductivityChartDataPoint> data = new List<ProductivityChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["ProductivityTarget"]) > 0)
                    data.Add(new ProductivityChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["ProductivityTarget"]), "Thực tế/Actual"));
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
                data.Add(new ProdScrapChartDataPoint(Convert.ToDateTime(dr["StatisticDate"]), Convert.ToDouble(dr["PercentMoney"]), "Vt xin thêm"));
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
                data.Add(new PlanningChartDataPoint(Convert.ToDateTime(dr["DateMonth"]), Convert.ToDouble(dr["FinishRatio"]), "Tỷ lệ hoàn thành", defaultBlue));
                data.Add(new PlanningChartDataPoint(Convert.ToDateTime(dr["DateMonth"]), Convert.ToDouble(dr["UnfinishRatio"]), "Tỷ lệ chưa hoàn thành", defaultRed));
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
                data.Add(new IQCPPMChartDataPoint(Convert.ToDateTime(dr["DocDate"]), Convert.ToDouble(dr["PPM"]), "Tỷ lệ PPM", defaultRed));
            }

            return data;
        }

        public static List<IQCPPMChartDataPoint> GetDataPointsLineChart(DataTable dt)
        {
            List<IQCPPMChartDataPoint> data = new List<IQCPPMChartDataPoint>();

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToDouble(dr["PPM"]) > 0)
                    data.Add(new IQCPPMChartDataPoint(Convert.ToDateTime(dr["DocDate"]), Convert.ToDouble(dr["PPM"]), "Tỷ lệ PPM", defaultBlue));
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
                data.Add(new IQCProcessPercentDataPoint(Convert.ToString(dr["IQCCheckName"]), Convert.ToDouble(dr["OKPercent"]), "Tỷ lệ đạt", defaultBlue));
                data.Add(new IQCProcessPercentDataPoint(Convert.ToString(dr["IQCCheckName"]), Convert.ToDouble(dr["NGPercent"]), "Tỷ lệ NG", defaultRed));
            }

            return data;
        }
    }
    #endregion
}
