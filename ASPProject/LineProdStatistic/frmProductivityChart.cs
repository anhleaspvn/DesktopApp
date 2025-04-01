using ASPControl;
using ASPData;
using ASPData.ASPDAO;
using DevExpress.Charts.Native;
using DevExpress.Data.TreeList;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Office.Drawing;
using DevExpress.Utils.Layout;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Html;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using UnitsNet;

namespace ASPProject.LineProdStatistic
{
    public partial class frmProductivityChart : DevExpress.XtraEditors.XtraForm
    {
        private ProdStatisticDAO prodDao = new ProdStatisticDAO();
        private DateTime chartDate = DateTime.Now.Date;
        private int Month;
        private int Year;
        public string username, LineID = string.Empty, monthList = string.Empty, lineList = string.Empty, dayList = string.Empty, typeProdList = string.Empty;
        private readonly SQLHelper _sqlhelper = new SQLHelper();
        private Loadingggg _loading = new Loadingggg();

        private ChartControl barChartDailyProd = new ChartControl();
        private ChartControl barChartMonthlyProd = new ChartControl();
        private ChartControl barChartYearlyProd = new ChartControl();
        private ChartControl barChartProductivityYear = new ChartControl();
        private ChartControl barChartProductivity = new ChartControl();
        private ChartControl barChartProductivityMonth = new ChartControl();

        string weekName = string.Empty;
        bool chkByW = false;
        public frmProductivityChart()
        {
            InitializeComponent();

            timerChart.Interval = 900000; //15 minutes
            timerChart.Start();

            dtpChartDate.EditValue = DateTime.Now.Date;

            this.Load += FrmProdStatisticChart_Load;
            this.timerChart.Tick += TimerChart_Tick;
            this.lstMonthName.ItemCheck += LstMonthName_ItemCheck;
            this.lstLineID.ItemCheck += LstLineID_ItemCheck;
            this.lstDayName.ItemCheck += LstDayName_ItemCheck;
            this.lstProdType.ItemCheck += LstProdType_ItemCheck;
            this.btSendMail.Click += BtSendMail_Click;
            this.dtpChartDate.EditValueChanged += DtpChartDate_EditValueChanged;
        }

        private void DtpChartDate_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
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

        private void LstProdType_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            LoadDayChart();
            LoadMonthChart();
            LoadYearChart();
        }

        private void BtSendMail_Click(object sender, EventArgs e)
        {
            string strPrdPath = Application.StartupPath + "\\ProductivityChart\\ProdImage.jpeg";

            ScreenCapture sc = new ScreenCapture();
            // capture entire screen, and save it to a file
            System.Drawing.Image img = sc.CaptureScreen();
            // display image in a Picture control named imageDisplay
           
            // capture this window, and save it
            sc.CaptureWindowToFile(this.Handle, strPrdPath, ImageFormat.Jpeg);

            string mailID = "ProductivityChart";

            if (lineList.Contains("PILOT"))
                mailID = "ProductivityChartPilot";

            bool sendMail = SendMail(mailID, strPrdPath);

            if (sendMail)
                XtraMessageBox.Show("Đã gửi mail thành công !", "Thông báo", MessageBoxButtons.OK);
            else
                XtraMessageBox.Show("Không gửi mail thành công, vui lòng kiểm tra lại internet !", "Thông báo", MessageBoxButtons.OK);
        }

        private bool SendMail(string MailID, string attachFile)
        {
            try
            {
                var dicParams = new Dictionary<string, object>()
                {
                    { "@MailID", MailID }
                };

                DataTable dtEmail = _sqlhelper.ExecQueryDataAsDataTable("SELECT * FROM ASPExcuteEmailList WHERE ID = @MailID", dicParams);

                if (dtEmail.Rows.Count == 0)
                    return false;

                DataRow drSendMail = dtEmail.Rows[0];

                string strTitle = "";
                string strbody = "";
                string strAttachedFile = "";
                string fromEmail = drSendMail["Email"].ToString();
                string password = drSendMail["EmailPassword"].ToString();
                string host = drSendMail["HostMail"].ToString() != string.Empty ? drSendMail["HostMail"].ToString() : "smtp.gmail.com";
                int post = drSendMail["Port"].ToString() != string.Empty ? Convert.ToInt32(drSendMail["Port"]) : 587;
                string CcEmail = drSendMail["EmailCC"].ToString();

              
                // Lấy email nhận
                string toEmail = drSendMail["EmailTo"].ToString();
               
                strTitle = drSendMail["EmailTitle"].ToString();
                strbody = drSendMail["EmailContent"].ToString();

                strAttachedFile = drSendMail["AttachedLink"].ToString();

                strTitle = strTitle.Replace("{DocDate}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
                strbody = strbody.Replace("{DocDate}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
                strbody = strbody.Replace("{AttachedLink}", strAttachedFile);

                var smtpClient = new SmtpClient(host, post)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 10000
                };

                var mail = new MailMessage
                {
                    Body = strbody,
                    Subject = strTitle,
                    From = new MailAddress(fromEmail, "Productivity Chart")
                };

                mail.To.Add(toEmail);
                
                if (CcEmail != string.Empty)
                    mail.CC.Add(CcEmail);
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.AlternateViews.Add(GetEmbeddedImage(strbody, attachFile));
                mail.Priority = MailPriority.High;

                Attachment attachment;
                attachment = new Attachment(attachFile);
                mail.Attachments.Add(attachment);
                smtpClient.Timeout = 0;
                smtpClient.Send(mail);
                mail.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private AlternateView GetEmbeddedImage(string strBody, String filePath)
        {
            LinkedResource res = new LinkedResource(filePath);
            res.ContentId = Guid.NewGuid().ToString();
            string htmlBody = strBody + @"</br><img src='cid:" + res.ContentId + @"'/>" + "</br></br><strong>**** THIS EMAIL WAS AUTOMATICALLY GENERATED BY eMES SYSTEM ****</strong></br></br>Thank you";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
        #region Load

        private void LoadYearChart()
        {
            typeProdList = string.Empty;

            for (int m = 0; m <= lstProdType.CheckedItemsCount - 1; m++)
            {
                object oType = lstProdType.CheckedItems[m];

                if (m == lstProdType.CheckedItemsCount - 1)
                    typeProdList += "" + oType.ToString() + "";
                else
                    typeProdList += "" + oType.ToString() + ",";
            }

            ResetChartControlYear();

            YearlyProductionChartAddSeries();

            YearlyProductivityChartAddSeries();
        }
        private void LoadMonthChart()
        {
            monthList = string.Empty;
            lineList = string.Empty;
            typeProdList = string.Empty;

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

            for (int m = 0; m <= lstProdType.CheckedItemsCount - 1; m++)
            {
                object oType = lstProdType.CheckedItems[m];

                if (m == lstProdType.CheckedItemsCount - 1)
                    typeProdList += "" + oType.ToString() + "";
                else
                    typeProdList += "" + oType.ToString() + ",";
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
            typeProdList = string.Empty;
 
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

            for (int m = 0; m <= lstProdType.CheckedItemsCount - 1; m++)
            {
                object oType = lstProdType.CheckedItems[m];

                if (m == lstProdType.CheckedItemsCount - 1)
                    typeProdList += "" + oType.ToString() + "";
                else
                    typeProdList += "" + oType.ToString() + ",";
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

            lstProdType.DataSource = prodDao.GetListProdType();
            lstProdType.DisplayMember = "TypeName";
            lstProdType.ValueMember = "TypeID";

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
            _loading.CreateWaitDialog();
            _loading.SetWaitDialogCaption("Đang tải dữ liệu, xin vui lòng chờ...");   

            //reset chart
            ResetChartControl();

            chkByW = true;

            chartDate = Convert.ToDateTime(dtpChartDate.EditValue).Date;

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

            //yearly production chart
            YearlyProductionChartAddSeries();

            //yearly productivity chart
            YearlyProductivityChartAddSeries();

            _loading.simpleCloseWait();
        }
        #endregion

        #region ProductionChartData
        private DataSet DailyProductionChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetDailyProductivityQuantityChart(dayList,lineList, typeProdList, Month, Year, LineID, username);

            return ds;
        }
        private void DailyProductionChartAddSeries()
        {
            if (DailyProductionChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = DailyProductionChartData().Tables[0];

            // Bind the chart to a data source:
            barChartDailyProd.DataSource = ProdChartDataPoint.GetDataPointsPlanBar(dtProdData);
            barChartDailyProd.SeriesTemplate.ChangeView(ViewType.Bar);
            barChartDailyProd.SeriesTemplate.SeriesDataMember = "Caption";
            barChartDailyProd.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");
            barChartDailyProd.SeriesTemplate.View.Color = Color.Yellow;

            // Enable series point labels, specify their text pattern and position:
            barChartDailyProd.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //barChartDailyProd.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartDailyProd.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartDailyProd.SeriesTemplate.Label).TextPattern = "{V:n1}";
            ((BarSeriesLabel)barChartDailyProd.SeriesTemplate.Label).TextOrientation = TextOrientation.TopToBottom;
            ((BarSeriesView)barChartDailyProd.SeriesTemplate.View).FillStyle.FillMode = FillMode.Solid;
            ((BarSeriesView)barChartDailyProd.SeriesTemplate.View).Shadow.Visible = true;
            ((BarSeriesView)barChartDailyProd.SeriesTemplate.View).Shadow.Color = Color.Gray;
            ((BarSeriesView)barChartDailyProd.SeriesTemplate.View).Shadow.Size = 5;

            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartDailyProd.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartDailyProd.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            //title edit
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "DAILY QUANTITY OUTPUT";
            chartTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
           
            // Add a barChartDailyProd title:
            barChartDailyProd.Titles.Add(chartTitle);

            // Specify legend settings:
            this.barChartDailyProd.Legend.Direction = LegendDirection.LeftToRight;
            this.barChartDailyProd.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            this.barChartDailyProd.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            this.barChartDailyProd.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartDailyProd.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram)barChartDailyProd.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram)barChartDailyProd.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            ((XYDiagram)barChartDailyProd.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram)barChartDailyProd.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;

            ((XYDiagram)barChartDailyProd.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartDailyProd.Diagram).AxisY.Label.TextPattern = "{V:n1} pcs";
            ((XYDiagram)barChartDailyProd.Diagram).AxisY.GridLines.Visible = false;

           
            Series seriesBar = new Series("Actual/Actual", ViewType.Bar);
            seriesBar.View.Color = Color.Green;
            ((BarSeriesView)seriesBar.View).FillStyle.FillMode = FillMode.Gradient;
            ((SideBySideBarSeriesView)seriesBar.View).AxisY = ((XYDiagram)barChartDailyProd.Diagram).AxisY;
            ((SideBySideBarSeriesView)seriesBar.View).AxisY.Label.Visible = true;
            ((SideBySideBarSeriesView)seriesBar.View).AxisY.GridLines.Visible = false;
            ((SideBySideBarSeriesView)seriesBar.View).FillStyle.FillMode = FillMode.Solid;
            ((SideBySideBarSeriesView)seriesBar.View).Shadow.Visible = true;
            ((SideBySideBarSeriesView)seriesBar.View).Shadow.Color = Color.Gray;
            ((SideBySideBarSeriesView)seriesBar.View).Shadow.Size = 5;
            seriesBar.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesBar.Label.TextPattern = "{V:n1}";
            seriesBar.Label.TextOrientation = TextOrientation.TopToBottom;
            seriesBar.DataSource = ProdChartDataPoint.GetDataPointsActualBar(dtProdData);
            seriesBar.SetDataMembers("StatisticDate", "Quantity");

            barChartDailyProd.Series.Add(seriesBar);
            barChartDailyProd.Dock = DockStyle.Fill;

            splitContainerControl3.Panel1.Controls.Add(barChartDailyProd);
        }

        private DataSet MonthlyProductionChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetMonthlyProductionChart(monthList, lineList,  typeProdList, Month, Year, LineID, username);

            return ds;
        }
        private void MonthlyProductionChartAddSeries()
        {
            if (MonthlyProductionChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = MonthlyProductionChartData().Tables[0];
            
            // Bind the chart to a data source:
            barChartMonthlyProd.DataSource = ProdChartDataPoint.GetDataPointsMpsPlanBar(dtProdData);
            barChartMonthlyProd.SeriesTemplate.ChangeView(ViewType.Bar);
            barChartMonthlyProd.SeriesTemplate.SeriesDataMember = "Caption";
            barChartMonthlyProd.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");

            // Enable series point labels, specify their text pattern and position:
            barChartMonthlyProd.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
          
            //barChartMonthlyProd.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartMonthlyProd.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartMonthlyProd.SeriesTemplate.Label).TextPattern = "{V:n1}";
            ((BarSeriesLabel)barChartMonthlyProd.SeriesTemplate.Label).TextOrientation = TextOrientation.TopToBottom;
            barChartMonthlyProd.SeriesTemplate.View.Color = Color.Orange;
            ((BarSeriesView)barChartMonthlyProd.SeriesTemplate.View).FillStyle.FillMode = FillMode.Solid;
            ((BarSeriesView)barChartMonthlyProd.SeriesTemplate.View).Shadow.Visible = true;
            ((BarSeriesView)barChartMonthlyProd.SeriesTemplate.View).Shadow.Color = Color.Gray;
            ((BarSeriesView)barChartMonthlyProd.SeriesTemplate.View).Shadow.Size = 5;

            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartMonthlyProd.SeriesTemplate.View;
            view.BarWidth = 0.8;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartMonthlyProd.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartMonthlyProd title:
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "MONTHLY QUANTITY OUTPUT";
            chartTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            barChartMonthlyProd.Titles.Add(chartTitle);

            // Specify legend settings:
            this.barChartMonthlyProd.Legend.Direction = LegendDirection.LeftToRight;
            this.barChartMonthlyProd.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            this.barChartMonthlyProd.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            this.barChartMonthlyProd.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartMonthlyProd.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
            ((XYDiagram)barChartMonthlyProd.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
            ((XYDiagram)barChartMonthlyProd.Diagram).AxisX.Label.TextPattern = "{A:MMM}";
           
            ((XYDiagram)barChartMonthlyProd.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartMonthlyProd.Diagram).AxisY.Label.TextPattern = "{V:n1} pcs";
            ((XYDiagram)barChartMonthlyProd.Diagram).AxisY.GridLines.Visible = false;


            Series seriesLine4 = new Series("FGs Plan", ViewType.Bar);
            seriesLine4.View.Color = Color.Yellow;
            ((BarSeriesView)seriesLine4.View).FillStyle.FillMode = FillMode.Solid;

            ((BarSeriesView)seriesLine4.View).Shadow.Visible = true;
            ((BarSeriesView)seriesLine4.View).Shadow.Color = Color.Gray;
            ((BarSeriesView)seriesLine4.View).Shadow.Size = 5;
          
            ((SideBySideBarSeriesView)seriesLine4.View).AxisY = ((XYDiagram)barChartMonthlyProd.Diagram).AxisY;
            
            ((SideBySideBarSeriesView)seriesLine4.View).AxisY.Label.Visible = true;
            ((SideBySideBarSeriesView)seriesLine4.View).AxisY.GridLines.Visible = false;

            seriesLine4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine4.Label.TextPattern = "{V:n1}";
            seriesLine4.Label.TextOrientation = TextOrientation.TopToBottom;
            seriesLine4.DataSource = ProdChartDataPoint.GetDataPointsPlanBar(dtProdData);
            seriesLine4.SetDataMembers("StatisticDate", "Quantity");

            barChartMonthlyProd.Series.Add(seriesLine4);

            Series seriesLine5 = new Series("Actual", ViewType.Bar);
            seriesLine5.View.Color = Color.Green;
            ((BarSeriesView)seriesLine5.View).FillStyle.FillMode = FillMode.Solid;

            ((BarSeriesView)seriesLine5.View).Shadow.Visible = true;
            ((BarSeriesView)seriesLine5.View).Shadow.Color = Color.Gray;
            ((BarSeriesView)seriesLine5.View).Shadow.Size = 5;
          
            ((SideBySideBarSeriesView)seriesLine5.View).AxisY = ((XYDiagram)barChartMonthlyProd.Diagram).AxisY;
          
            ((SideBySideBarSeriesView)seriesLine5.View).AxisY.Label.Visible = true;
            ((SideBySideBarSeriesView)seriesLine5.View).AxisY.GridLines.Visible = false;

            seriesLine5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine5.Label.TextPattern = "{V:n1}";
            seriesLine5.Label.TextOrientation = TextOrientation.TopToBottom;
            seriesLine5.DataSource = ProdChartDataPoint.GetDataPointsActualBar(dtProdData);
            seriesLine5.SetDataMembers("StatisticDate", "Quantity");

            barChartMonthlyProd.Series.Add(seriesLine5);
            barChartMonthlyProd.Dock = DockStyle.Fill;

            splitContainerControl4.Panel1.Controls.Add(barChartMonthlyProd);
        }

        private DataSet YearlyProductionChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetYearlyProductionChart(monthList, lineList, typeProdList, Month, Year, LineID, username);

            return ds;
        }

        private void YearlyProductionChartAddSeries()
        {
            if (YearlyProductionChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = YearlyProductionChartData().Tables[0];

            // Bind the chart to a data source:
            barChartYearlyProd.DataSource = ProdChartDataPoint.GetDataPointsYearActualBar(dtProdData);
            barChartYearlyProd.SeriesTemplate.ChangeView(ViewType.Bar);
            barChartYearlyProd.SeriesTemplate.SeriesDataMember = "Caption";
            barChartYearlyProd.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");

            // Enable series point labels, specify their text pattern and position:
            barChartYearlyProd.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            //barChartYearlyProd.SeriesTemplate.Label.TextPattern = "${V}M";
            ((BarSeriesLabel)barChartYearlyProd.SeriesTemplate.Label).Position = BarSeriesLabelPosition.Center;
            ((BarSeriesLabel)barChartYearlyProd.SeriesTemplate.Label).TextPattern = "{V:n1}";
            barChartYearlyProd.SeriesTemplate.View.Color = Color.Orange;
            ((BarSeriesView)barChartYearlyProd.SeriesTemplate.View).FillStyle.FillMode = FillMode.Solid;


            // Customize series view settings (for example, bar width):
            BarSeriesView view = (BarSeriesView)barChartYearlyProd.SeriesTemplate.View;
            //view.BarWidth = 0.8;
            view.Color = Color.Green;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartYearlyProd.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartYearlyProd title:
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "YEARLY QUANTITY OUTPUT";
            chartTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            barChartYearlyProd.Titles.Add(chartTitle);

            // Specify legend settings:
            this.barChartYearlyProd.Legend.Direction = LegendDirection.TopToBottom;
            this.barChartYearlyProd.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            this.barChartYearlyProd.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            this.barChartYearlyProd.Legend.AlignmentVertical = LegendAlignmentVertical.Center;

            ((XYDiagram)barChartYearlyProd.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Year;
            ((XYDiagram)barChartYearlyProd.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Year;
            ((XYDiagram)barChartYearlyProd.Diagram).AxisX.Label.TextPattern = "{A:yyyy}";

            ((XYDiagram)barChartYearlyProd.Diagram).AxisY.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
            ((XYDiagram)barChartYearlyProd.Diagram).AxisY.Label.TextPattern = "{V:n1} pcs";
            ((XYDiagram)barChartYearlyProd.Diagram).AxisY.GridLines.Visible = false;


            barChartYearlyProd.Dock = DockStyle.Fill;

            splitContainerControl8.Panel1.Controls.Add(barChartYearlyProd);
        }
        #endregion

        #region ProductivityChartData
        private DataSet DailyProductivityChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetDailyProductivityPercentChartData(dayList, lineList, typeProdList,  Month, Year, LineID, username);

            return ds;
        }

        private void DailyProductivityChartAddSeries()
        {
            if (DailyProductivityChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = DailyProductivityChartData().Tables[0];

            // Bind the chart to a data source:
            barChartProductivity.DataSource = ProductivityChartDataPoint.GetDataPointsTargetLine(dtProdData);
            barChartProductivity.SeriesTemplate.ChangeView(ViewType.Line);
            barChartProductivity.SeriesTemplate.SeriesDataMember = "Caption";
            barChartProductivity.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");
            barChartProductivity.SeriesTemplate.ArgumentScaleType = ScaleType.DateTime;
            barChartProductivity.SeriesTemplate.View.Color = Color.Red;

            // Enable series point labels, specify their text pattern and position:
            barChartProductivity.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartProductivity.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartProductivity title:
            // Add a barChartYearlyProd title:
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "DAILY OUTPUT RATE";
            chartTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            barChartProductivity.Titles.Add(chartTitle);

            // Specify legend settings:
            this.barChartProductivity.Legend.Direction = LegendDirection.LeftToRight;
            this.barChartProductivity.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            this.barChartProductivity.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            this.barChartProductivity.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
            ((XYDiagram)barChartProductivity.Diagram).AxisX.Label.TextPattern = "{A:dd-MMM}";
            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            ((XYDiagram)barChartProductivity.Diagram).AxisX.DateTimeScaleOptions.WorkdaysOptions.Workdays = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday | Weekday.Thursday | Weekday.Friday | Weekday.Saturday;
           
            ((XYDiagram)barChartProductivity.Diagram).AxisY.Label.Visible = true;
            ((XYDiagram)barChartProductivity.Diagram).AxisY.Label.TextPattern = "{V:n1}%";
            ((XYDiagram)barChartProductivity.Diagram).AxisY.GridLines.Visible = false;

            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartProductivity.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartProductivity.Diagram).SecondaryAxesY.Add(myAxisY);

            barChartProductivity.SeriesTemplate.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;

            Series seriesLine = new Series("%OR Actual", ViewType.Line);
            seriesLine.View.Color = Color.DarkGreen;
       
            ((LineSeriesView)seriesLine.View).AxisY = ((XYDiagram)barChartProductivity.Diagram).AxisY;
            ((LineSeriesView)seriesLine.View).AxisY.Label.TextPattern = "{V:n1}%";
            ((LineSeriesView)seriesLine.View).AxisY.Label.Visible = true;
            ((LineSeriesView)seriesLine.View).AxisY.GridLines.Visible = false;
            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine.Label.TextPattern = "{V:n1}";
            seriesLine.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesLine.DataSource = ProductivityChartDataPoint.GetDataPointsActualLine(dtProdData);
            seriesLine.SetDataMembers("StatisticDate", "Quantity");
            barChartProductivity.Series.Add(seriesLine);

            Series seriesLineACC = new Series("%OR Actual Yield", ViewType.Line);
            seriesLineACC.View.Color = Color.Blue;

            ((LineSeriesView)seriesLineACC.View).AxisY = ((XYDiagram)barChartProductivity.Diagram).AxisY;
            ((LineSeriesView)seriesLineACC.View).AxisY.Label.TextPattern = "{V:n1}%";
            ((LineSeriesView)seriesLineACC.View).AxisY.Label.Visible = true;
            ((LineSeriesView)seriesLineACC.View).AxisY.GridLines.Visible = false;
            seriesLineACC.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLineACC.Label.TextPattern = "{V:n1}";
            seriesLineACC.DataSource = ProductivityChartDataPoint.GetDataPointsACCLine(dtProdData);
            seriesLineACC.SetDataMembers("StatisticDate", "Quantity");
            seriesLineACC.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            barChartProductivity.Series.Add(seriesLineACC);

            Series seriesBar = new Series("OR Target", ViewType.Bar);
            seriesBar.View.Color = Color.Yellow;
            ((BarSeriesView)seriesBar.View).FillStyle.FillMode = FillMode.Solid;
            ((BarSeriesView)seriesBar.View).Shadow.Visible = true;
            ((BarSeriesView)seriesBar.View).Shadow.Color = Color.Gray;
            ((BarSeriesView)seriesBar.View).Shadow.Size = 5;

            ((SideBySideBarSeriesView)seriesBar.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n1}";
            myAxisY.Label.Visible = true;
            myAxisY.GridLines.Visible = false;
            seriesBar.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesBar.Label.TextPattern = "{V:n1}";
            seriesBar.Label.TextOrientation = TextOrientation.TopToBottom;
            seriesBar.DataSource = ProductivityChartDataPoint.GetDataPointsORTargetBar(dtProdData);
            seriesBar.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivity.Series.Add(seriesBar);

            Series seriesBar2 = new Series("OR Actual", ViewType.Bar);
            seriesBar2.View.Color = Color.Green;
            ((BarSeriesView)seriesBar2.View).FillStyle.FillMode = FillMode.Solid;
            ((BarSeriesView)seriesBar2.View).Shadow.Visible = true;
            ((BarSeriesView)seriesBar2.View).Shadow.Color = Color.Gray;
            ((BarSeriesView)seriesBar2.View).Shadow.Size = 5;

            ((SideBySideBarSeriesView)seriesBar2.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n1}";
            myAxisY.Label.Visible = true;
            myAxisY.GridLines.Visible = false;
            seriesBar2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesBar2.Label.TextPattern = "{V:n1}";
            seriesBar2.Label.TextOrientation = TextOrientation.TopToBottom;
            seriesBar2.DataSource = ProductivityChartDataPoint.GetDataPointsORActualBar(dtProdData);
            seriesBar2.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivity.Series.Add(seriesBar2);

            Series seriesBar3 = new Series("OR Plan", ViewType.Bar);
            seriesBar3.View.Color = Color.Blue;
            ((BarSeriesView)seriesBar3.View).FillStyle.FillMode = FillMode.Solid;
            ((BarSeriesView)seriesBar3.View).Shadow.Visible = true;
            ((BarSeriesView)seriesBar3.View).Shadow.Color = Color.Gray;
            ((BarSeriesView)seriesBar3.View).Shadow.Size = 5;

            ((SideBySideBarSeriesView)seriesBar3.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n1}";
            myAxisY.Label.Visible = true;
            myAxisY.GridLines.Visible = false;
            seriesBar3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            seriesBar3.Label.TextPattern = "{V:n1}";
            seriesBar3.Label.TextOrientation = TextOrientation.TopToBottom;
            seriesBar3.DataSource = ProductivityChartDataPoint.GetDataPointsORPlanBar(dtProdData);
            seriesBar3.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivity.Series.Add(seriesBar3);

            barChartProductivity.Dock = DockStyle.Fill;

            splitContainerControl3.Panel2.Controls.Add(barChartProductivity);
        }

        private DataSet MonthlyProductivityChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetMonthlyProductivityChartData(monthList, lineList, typeProdList, Month, Year, LineID, username);

            return ds;
        }

        private void MonthlyProductivityChartAddSeries()
        {
            if (MonthlyProductivityChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = MonthlyProductivityChartData().Tables[0];

            // Bind the chart to a data source:
            barChartProductivityMonth.DataSource = ProductivityChartDataPoint.GetDataPointsTargetLine(dtProdData);
            barChartProductivityMonth.SeriesTemplate.ChangeView(ViewType.Line);
            barChartProductivityMonth.SeriesTemplate.SeriesDataMember = "Caption";
            barChartProductivityMonth.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");
            barChartProductivityMonth.SeriesTemplate.ArgumentScaleType = ScaleType.DateTime;

            // Enable series point labels, specify their text pattern and position:
            barChartProductivityMonth.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            barChartProductivityMonth.SeriesTemplate.View.Color = Color.Red;
           
            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartProductivityMonth.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartProductivityMonth title:
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "MONTHLY OUTPUT RATE";
            chartTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
         
            barChartProductivityMonth.Titles.Add(chartTitle);

            // Specify legend settings:
            this.barChartProductivityMonth.Legend.Direction = LegendDirection.LeftToRight;
            this.barChartProductivityMonth.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            this.barChartProductivityMonth.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            this.barChartProductivityMonth.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

            ((XYDiagram)barChartProductivityMonth.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
            ((XYDiagram)barChartProductivityMonth.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
            ((XYDiagram)barChartProductivityMonth.Diagram).AxisX.Label.TextPattern = "{A:MMM}";
          
            ((XYDiagram)barChartProductivityMonth.Diagram).AxisY.Label.Visible = true;
            ((XYDiagram)barChartProductivityMonth.Diagram).AxisY.Label.TextPattern = "{V:n1}%";
            ((XYDiagram)barChartProductivityMonth.Diagram).AxisY.GridLines.Visible = false;

            barChartProductivityMonth.SeriesTemplate.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;

            Series seriesLine = new Series("%OR Actual Yield", ViewType.Line);
            seriesLine.View.Color = Color.Blue;

            ((LineSeriesView)seriesLine.View).AxisY = ((XYDiagram)barChartProductivity.Diagram).AxisY;
            ((LineSeriesView)seriesLine.View).AxisY.Label.TextPattern = "{V:n1}%";
            ((LineSeriesView)seriesLine.View).AxisY.Label.Visible = true;
            ((LineSeriesView)seriesLine.View).AxisY.GridLines.Visible = false;
            seriesLine.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesLine.Label.TextPattern = "{V:n1}";
            seriesLine.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesLine.DataSource = ProductivityChartDataPoint.GetDataPointsActualLine(dtProdData);
            seriesLine.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivityMonth.Series.Add(seriesLine);

            Series seriesACC = new Series("%OR Actual", ViewType.Line);
            seriesACC.View.Color = Color.DarkGreen;

            ((LineSeriesView)seriesACC.View).AxisY = ((XYDiagram)barChartProductivity.Diagram).AxisY;
            ((LineSeriesView)seriesACC.View).AxisY.Label.TextPattern = "{V:n1}%";
            ((LineSeriesView)seriesACC.View).AxisY.Label.Visible = true;
            ((LineSeriesView)seriesACC.View).AxisY.GridLines.Visible = false;
            seriesACC.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesACC.Label.TextPattern = "{V:n1}";
            seriesACC.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesACC.DataSource = ProductivityChartDataPoint.GetDataPointsACCLine(dtProdData);
            seriesACC.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivityMonth.Series.Add(seriesACC);


            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartProductivityMonth.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartProductivityMonth.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesBar = new Series("OR Target", ViewType.Bar);
            seriesBar.View.Color = Color.Yellow;
            ((BarSeriesView)seriesBar.View).FillStyle.FillMode = FillMode.Solid;
            ((BarSeriesView)seriesBar.View).Shadow.Visible = true;
            ((BarSeriesView)seriesBar.View).Shadow.Color = Color.Gray;
            ((BarSeriesView)seriesBar.View).Shadow.Size = 5;

            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesBar.View).AxisX = myAxisX;
            ((SideBySideBarSeriesView)seriesBar.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n1}";
            myAxisY.GridLines.Visible = false;

            seriesBar.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesBar.Label.TextPattern = "{V:n1}";
            seriesBar.Label.TextOrientation = TextOrientation.TopToBottom;
            seriesBar.DataSource = ProductivityChartDataPoint.GetDataPointsORTargetBar(dtProdData);
            seriesBar.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivityMonth.Series.Add(seriesBar);

            Series seriesBar2 = new Series("OR Actual", ViewType.Bar);
            seriesBar2.View.Color = Color.Green;
            ((BarSeriesView)seriesBar2.View).FillStyle.FillMode = FillMode.Solid;
            ((BarSeriesView)seriesBar2.View).Shadow.Visible = true;
            ((BarSeriesView)seriesBar2.View).Shadow.Color = Color.Gray;
            ((BarSeriesView)seriesBar2.View).Shadow.Size = 5;
            
            ((SideBySideBarSeriesView)seriesBar2.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n1}";
            myAxisY.GridLines.Visible = false;

            seriesBar2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesBar2.Label.TextPattern = "{V:n1}";
            seriesBar2.Label.TextOrientation = TextOrientation.TopToBottom;
            seriesBar2.DataSource = ProductivityChartDataPoint.GetDataPointsORActualBar(dtProdData);
            seriesBar2.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivityMonth.Series.Add(seriesBar2);

            barChartProductivityMonth.Dock = DockStyle.Fill;

            splitContainerControl4.Panel2.Controls.Add(barChartProductivityMonth);
        }

        private DataSet YearlyProductivityChartData()
        {
            DataSet ds = new DataSet();

            ds = prodDao.GetYearlyProductivityChartData(monthList, lineList, typeProdList, Month, Year, LineID, username);

            return ds;
        }

        private void YearlyProductivityChartAddSeries()
        {
            if (YearlyProductivityChartData().Tables.Count == 0)
                return;

            DataTable dtProdData = YearlyProductivityChartData().Tables[0];

            // Bind the chart to a data source:
            barChartProductivityYear.DataSource = ProductivityChartDataPoint.GetDataPointsYearORTargetBar(dtProdData);
            barChartProductivityYear.SeriesTemplate.ChangeView(ViewType.Line);
            barChartProductivityYear.SeriesTemplate.SeriesDataMember = "Caption";
            barChartProductivityYear.SeriesTemplate.SetDataMembers("StatisticDate", "Quantity");
            barChartProductivityYear.SeriesTemplate.ArgumentScaleType = ScaleType.DateTime;

            // Enable series point labels, specify their text pattern and position:
            barChartProductivityYear.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            barChartProductivityYear.SeriesTemplate.View.Color = Color.Red;

            // Disable minor tickmarks on the x-axis:
            XYDiagram diagram = (XYDiagram)barChartProductivityYear.Diagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;

            // Add a barChartProductivityYear title:
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "YEARLY OUTPUT RATE";
            chartTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            barChartProductivityYear.Titles.Add(chartTitle);

            // Specify legend settings:
            this.barChartProductivityYear.Legend.Direction = LegendDirection.TopToBottom;
            this.barChartProductivityYear.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            this.barChartProductivityYear.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            this.barChartProductivityYear.Legend.AlignmentVertical = LegendAlignmentVertical.Center;

            ((XYDiagram)barChartProductivityYear.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Year;
            ((XYDiagram)barChartProductivityYear.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Year;
            ((XYDiagram)barChartProductivityYear.Diagram).AxisX.Label.TextPattern = "{A:yyyy}";

            ((XYDiagram)barChartProductivityYear.Diagram).AxisY.Label.Visible = true;
            ((XYDiagram)barChartProductivityYear.Diagram).AxisY.Label.TextPattern = "{V:n1}%";
            ((XYDiagram)barChartProductivityYear.Diagram).AxisY.GridLines.Visible = false;

            barChartProductivityYear.SeriesTemplate.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;


            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)barChartProductivityYear.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)barChartProductivityYear.Diagram).SecondaryAxesY.Add(myAxisY);

            Series seriesBar = new Series("OR Target", ViewType.Line);
            seriesBar.View.Color = Color.Yellow;
            //((LineSeriesView)seriesBar.View).FillStyle.FillMode = FillMode.Solid;
            ((LineSeriesView)seriesBar.View).Shadow.Visible = true;
            ((LineSeriesView)seriesBar.View).Shadow.Color = Color.Gray;
            ((LineSeriesView)seriesBar.View).Shadow.Size = 5;

            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesBar.View).AxisX = myAxisX;
            ((LineSeriesView)seriesBar.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n1}";
            myAxisY.GridLines.Visible = false;

            Series seriesBar2 = new Series("OR Actual", ViewType.Line);
            seriesBar2.View.Color = Color.DarkGreen;
            //((BarSeriesView)seriesBar2.View).FillStyle.FillMode = FillMode.Solid;
            ((LineSeriesView)seriesBar2.View).Shadow.Visible = true;
            ((LineSeriesView)seriesBar2.View).Shadow.Color = Color.Gray;
            ((LineSeriesView)seriesBar2.View).Shadow.Size = 5;
            //((BarSeriesView)seriesBar2.View).FillStyle.FillMode = FillMode.Hatch;
            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesBar2.View).AxisX = myAxisX;
            ((LineSeriesView)seriesBar2.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n1}";
            myAxisY.GridLines.Visible = false;

            seriesBar2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesBar2.Label.TextPattern = "{V:n1}";
            seriesBar2.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesBar2.DataSource = ProductivityChartDataPoint.GetDataPointsYearORActualBar(dtProdData);
            seriesBar2.SetDataMembers("StatisticDate", "Quantity");

            //barChartProductivityYear.Series.Add(seriesBar2);

            Series seriesBar3 = new Series("%OR Actual Yield", ViewType.Line);
            seriesBar3.View.Color = Color.Blue;
            //((BarSeriesView)seriesBar3.View).FillStyle.FillMode = FillMode.Solid;
            ((LineSeriesView)seriesBar3.View).Shadow.Visible = true;
            ((LineSeriesView)seriesBar3.View).Shadow.Color = Color.Gray;
            ((LineSeriesView)seriesBar3.View).Shadow.Size = 5;
            //((BarSeriesView)seriesBar3.View).FillStyle.FillMode = FillMode.Hatch;
            // Assign the series2 to the created axes.
            //((LineSeriesView)seriesBar2.View).AxisX = myAxisX;
            ((LineSeriesView)seriesBar3.View).AxisY = myAxisY;
            myAxisY.Label.TextPattern = "{V:n1}";
            myAxisY.GridLines.Visible = false;

            seriesBar3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesBar3.Label.TextPattern = "{V:n1}";
            seriesBar3.Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAroundPoint;
            seriesBar3.DataSource = ProductivityChartDataPoint.GetDataPointsYearORACCBar(dtProdData);
            seriesBar3.SetDataMembers("StatisticDate", "Quantity");

            barChartProductivityYear.Series.Add(seriesBar3);

            barChartProductivityYear.Dock = DockStyle.Fill;

            splitContainerControl8.Panel2.Controls.Add(barChartProductivityYear);
        }

        #endregion

        private void ResetChartControl()
        {
            splitContainerControl3.Panel1.Controls.Remove(barChartDailyProd);
            splitContainerControl3.Panel2.Controls.Remove(barChartProductivity);
            splitContainerControl4.Panel1.Controls.Remove(barChartMonthlyProd);
            splitContainerControl4.Panel2.Controls.Remove(barChartProductivityMonth);
            splitContainerControl8.Panel1.Controls.Remove(barChartYearlyProd);
            splitContainerControl8.Panel2.Controls.Remove(barChartProductivityYear);

            barChartDailyProd = new ChartControl();
            barChartMonthlyProd = new ChartControl();
            barChartProductivity = new ChartControl();
            barChartProductivityMonth = new ChartControl();
            barChartYearlyProd = new ChartControl();
            barChartProductivityYear = new ChartControl();
        }

        private void ResetChartControlYear()
        {
            splitContainerControl8.Panel1.Controls.Remove(barChartYearlyProd);
            splitContainerControl8.Panel2.Controls.Remove(barChartProductivityYear);

            barChartYearlyProd = new ChartControl();
            barChartProductivityYear = new ChartControl();
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

        public static List<DateTime> GetDates(int year, int month)
        {
            var dates = new List<DateTime>();

            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            return dates;
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
