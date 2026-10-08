using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPGoogleSheet
{
    public static class ProcessTable
    {
        static CultureInfo cf = new CultureInfo("vi-VI");
        public static bool ToExcelFile(this DataTable dt, string filename)
        {
            bool Success = false;
            
            try
            {
                XLWorkbook wb = new XLWorkbook();

                wb.Worksheets.Add(dt, "Sheet 1");

                if (filename.Contains("."))
                {
                    int IndexOfLastFullStop = filename.LastIndexOf('.');

                    filename = filename.Substring(0, IndexOfLastFullStop) + ".xlsx";

                }

                filename = filename + ".xlsx";

                wb.SaveAs(filename);

                Success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Success;
        }

        public static DataTable ToDataTable(ListView listview, DataTable dt)
        {
            dt.Columns.Add("Date_Only", typeof(DateTime));

            dt.Columns.Add("Date_Of", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Line", typeof(string));
            dt.Columns.Add("From_To", typeof(string));
            dt.Columns.Add("Tan_Suat", typeof(string));
            dt.Columns.Add("Ma_Sp", typeof(string));
            dt.Columns.Add("So_Ct_LSX", typeof(string));
            dt.Columns.Add("Tong_SL_DonHang", typeof(string));
            dt.Columns.Add("Ma_CongDoan", typeof(string));
            dt.Columns.Add("SL_KiemTra", typeof(string));
            dt.Columns.Add("OKorNG", typeof(string));
            dt.Columns.Add("SL_NG", typeof(string));
            dt.Columns.Add("Ma_Loi", typeof(string));
            dt.Columns.Add("So_Luong_Loi", typeof(string));
            dt.Columns.Add("Open_Car", typeof(string));
            dt.Columns.Add("Other_Check", typeof(string));
            dt.Columns.Add("Nguoi_Duyet", typeof(string));


            foreach (ListViewItem it in listview.Items)
            {
                DataRow dr = dt.NewRow();

                for (int i = 0; i <= it.SubItems.Count - 1; i++)
                {
                    dr[i + 1] = it.SubItems[i].Text.ToUpper().Trim();
                    string[] arrDate = dr[1].ToString().Split(' ');
                    if (arrDate.Length > 1)
                    {
                        dr[0] = DateTime.ParseExact(arrDate[0], "dd/MM/yyyy", cf, DateTimeStyles.None);
                    }

                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static DataTable ToDataTableDimFunction(ListView listview, DataTable dt)
        {
            dt.Columns.Add("Date_Only", typeof(DateTime));

            dt.Columns.Add("Date_Of", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Line", typeof(string));
            dt.Columns.Add("From_To", typeof(string));
            dt.Columns.Add("Tan_Suat", typeof(string));
            dt.Columns.Add("Ma_Sp", typeof(string));
            dt.Columns.Add("So_Ct_LSX", typeof(string));
            dt.Columns.Add("Tong_SL_DonHang", typeof(double));
            dt.Columns.Add("Process", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Standard", typeof(string));
            dt.Columns.Add("Actual#1", typeof(object));
            dt.Columns.Add("Actual#2", typeof(object));
            dt.Columns.Add("Actual#3", typeof(object));
            dt.Columns.Add("Actual#4", typeof(object));
            dt.Columns.Add("Actual#5", typeof(object));
            dt.Columns.Add("Results", typeof(string));
            dt.Columns.Add("Nguoi_Duyet", typeof(string));
            //dt.Columns.Add("Date_Only_Date", typeof(DateTime));

            foreach (ListViewItem it in listview.Items)
            {
                DataRow dr = dt.NewRow();

                for (int i = 0; i <= it.SubItems.Count - 1; i++)
                {
                    double res = 0;
                    bool doubleTryParse = double.TryParse(it.SubItems[i].Text.ToUpper().Trim(), out res);

                    if (doubleTryParse == true)
                        dr[i + 1] = res;
                    else
                        dr[i + 1] = it.SubItems[i].Text.ToUpper().Trim();

                    string[] arrDate = dr[1].ToString().Split(' ');

                    if (arrDate.Length > 1)
                    {
                        dr[0] = DateTime.ParseExact(arrDate[0], "dd/MM/yyyy", cf, DateTimeStyles.None);
                    }

                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static void CreateDataTableMain(DataTable dtMain)
        {
            dtMain.Columns.Add("Date_Only", typeof(DateTime)); //0
            dtMain.Columns.Add("Date_Of", typeof(string)); //1
            dtMain.Columns.Add("ID", typeof(string)); //2
            dtMain.Columns.Add("Line", typeof(string)); //3
            dtMain.Columns.Add("From_To", typeof(string)); //4
            dtMain.Columns.Add("Tan_Suat", typeof(string)); //5
            dtMain.Columns.Add("Ma_Sp", typeof(string)); //6
            dtMain.Columns.Add("So_Ct_LSX", typeof(string)); //7
            dtMain.Columns.Add("Tong_SL_DonHang", typeof(int)); //8
            dtMain.Columns.Add("Ma_CongDoan", typeof(string)); //9
            dtMain.Columns.Add("SL_KiemTra", typeof(int)); //10
            dtMain.Columns.Add("OKorNG", typeof(string)); //11
            dtMain.Columns.Add("SL_NG", typeof(int)); //12
            dtMain.Columns.Add("Ma_Loi", typeof(string)); //13
            dtMain.Columns.Add("So_Luong_Loi", typeof(int)); //14
            dtMain.Columns.Add("Open_Car", typeof(string)); //15
            dtMain.Columns.Add("Other_Check", typeof(string)); //16
            dtMain.Columns.Add("Nguoi_Duyet", typeof(string)); //17
            //dtMain.Columns.Add("Date_Only_Date", typeof(DateTime)); //18
        }

        public static void ProcessData(DataTable dt, DataTable dtMain)
        {
            DataRow[] arrDr1 = dt.Select("Ma_Loi NOT LIKE '%,%'");
            DataRow[] arrDr2 = dt.Select("Ma_Loi LIKE '%,%'");
            DataRow[] arrDr3 = dt.Select("OKorNG LIKE 'OK'");

            foreach (DataRow drow in arrDr1)
            {
                DataRow drMain = dtMain.NewRow();

                for (int j = 0; j <= drow.Table.Columns.Count - 1; j++)
                {
                    if (drow.Table.Columns[j].ColumnName != "So_Luong_Loi")
                    {
                        int tempInt = 0;
                        if (Int32.TryParse(drow[j].ToString() == string.Empty ? "0" : drow[j].ToString(), out tempInt))
                        {
                            drMain[j] = tempInt;
                        }
                        else
                            drMain[j] = drow[j];
                    }
                }

                string[] SL_Loi = drow["So_Luong_Loi"].ToString().Split(':');
                string SL_Loi_Sgle = "";

                if (SL_Loi.Length > 1)
                    SL_Loi_Sgle = SL_Loi[1];

                drMain["So_Luong_Loi"] = string.IsNullOrEmpty(SL_Loi_Sgle) ? 0 : Convert.ToInt32(SL_Loi_Sgle);

                //drMain["Date_Only_Date"] = DateTime.ParseExact(drMain["Date_Only"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                dtMain.Rows.Add(drMain);
            }

            dtMain.AcceptChanges();

            foreach (DataRow drow in arrDr2)
            {
                string[] Ma_Loi = drow["Ma_Loi"].ToString().Split(',');
                string[] So_Luong_Loi = drow["So_Luong_Loi"].ToString().Split(',');

                for (int i = 0; i <= Ma_Loi.Length - 1; i++)
                {
                    string[] SL_Loi = So_Luong_Loi[i].Split(':');
                    string SL_Loi_Sgle = "";

                    if (SL_Loi.Length > 1)
                        SL_Loi_Sgle = SL_Loi[1];

                    DataRow drMain = dtMain.NewRow();

                    for (int j = 0; j <= drow.Table.Columns.Count - 1; j++)
                    {
                        if (drow.Table.Columns[j].ColumnName != "So_Luong_Loi")
                        {
                            int tempInt = 0;
                            if (Int32.TryParse(drow[j].ToString() == string.Empty ? "0" : drow[j].ToString(), out tempInt))
                            {
                                drMain[j] = tempInt;
                            }
                            else
                                drMain[j] = drow[j];
                        }
                    }

                    drMain["Ma_Loi"] = Ma_Loi[i];
                    drMain["So_Luong_Loi"] = string.IsNullOrEmpty(SL_Loi_Sgle) ? 0 : Convert.ToInt32(SL_Loi_Sgle);

                    //drMain["Date_Only_Date"] = DateTime.ParseExact(drMain["Date_Only"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    dtMain.Rows.Add(drMain);
                }
            }

            foreach (DataRow drow in arrDr3)
            {
                DataRow drMain = dtMain.NewRow();

                for (int j = 0; j <= drow.Table.Columns.Count - 1; j++)
                {
                    int tempInt = 0;
                    if (Int32.TryParse(drow[j].ToString() == string.Empty ? "0" : drow[j].ToString(), out tempInt))
                    {
                        drMain[j] = tempInt;
                    }
                    else
                        drMain[j] = drow[j];
                }

                //drMain["Date_Only_Date"] = DateTime.ParseExact(drMain["Date_Only"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                dtMain.Rows.Add(drMain);
            }

            dtMain.AcceptChanges();

            //dtMain.Columns["Date_Only_Date"].SetOrdinal(0);
            dtMain.Columns["Date_Only"].SetOrdinal(0);
        }
    }
}
