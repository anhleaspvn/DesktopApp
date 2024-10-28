using OfficeOpenXml;
using OfficeOpenXml.Export.ToDataTable;
using OfficeOpenXml.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace ASPExcelDataProcess
{
    public partial class ASPExcelDataProcess
    {
        public DataTable ReadDataFromExcelFile(string fileName, string sheetName, string rangeName)
        {
            DataTable dt = new DataTable();
            try
            {
                // Creating an instance
                // of ExcelPackage
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                ExcelPackage excel = new ExcelPackage(fileName);

                var ws = excel.Workbook.Worksheets[sheetName];

                var opt = ToDataTableOptions.Create();
                opt.DataTableName = "dt2";
                opt.FirstRowIsColumnNames = true;
                opt.EmptyRowStrategy = EmptyRowsStrategy.Ignore;
                

                dt = ws.Cells[rangeName].ToDataTable(opt);

                //string strWrg = wrg.Value.ToString()
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public string ReadDataFromExcelFileStr(string fileName, string sheetName, string rangeName)
        {
            string strWrg = string.Empty;
            try
            {
                // Creating an instance
                // of ExcelPackage
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                ExcelPackage excel = new ExcelPackage(fileName);

                var ws = excel.Workbook.Worksheets[sheetName];

                if (ws is null)
                {
                    string a = sheetName;
                    return string.Empty;
                }    
                   

                strWrg = string.IsNullOrEmpty(Convert.ToString(ws.Cells[rangeName].Value)) ? string.Empty : Convert.ToString(ws.Cells[rangeName].Value);
                  
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strWrg;
        }

        public bool WriteDataIntoExcelFile(DataTable dtData, string fileName, string sheetName, string rangeName, string saveFolder)
        {
            try
            {
                // Creating an instance
                // of ExcelPackage
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                ExcelPackage excel = new ExcelPackage(fileName);

                // name of the sheet
                var workSheet = excel.Workbook.Worksheets[sheetName];

                if (workSheet == null)
                    return false;

                // setting the properties
                // of the work sheet 
              
                // Setting the properties
                // of the first row
                workSheet.Cells[rangeName].Clear();
                workSheet.Cells[rangeName].LoadFromDataTable(dtData);

                foreach (var cell in workSheet.Cells[rangeName])
                {
                    if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        cell.Clear();
                    }
                }

                //if (string.IsNullOrEmpty(saveFolder))
                if (string.IsNullOrEmpty(saveFolder))
                    excel.Save();
                else excel.SaveAs(saveFolder);
            }
            catch (Exception ex) { throw ex; }
            
            return true;
        }

        public bool WriteDataIntoExcelFileStr(string value, string fileName, string sheetName, string rangeName, string saveFolder)
        {
            try
            {
                // Creating an instance
                // of ExcelPackage
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                ExcelPackage excel = new ExcelPackage(fileName);

                // name of the sheet
                var workSheet = excel.Workbook.Worksheets[sheetName];

                // setting the properties
                // of the work sheet 
                workSheet.TabColor = System.Drawing.Color.Black;
                workSheet.DefaultRowHeight = 12;

                // Setting the properties
                // of the first row
                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;

                workSheet.Cells[rangeName].Value = value;

                //if (string.IsNullOrEmpty(saveFolder))
                if (string.IsNullOrEmpty(saveFolder))
                    excel.Save();
                else excel.SaveAs(saveFolder);
            }
            catch (Exception ex) { throw ex; }

            return true;
        }

        public List<string> ExcelGetAllNameOfSheets(string fileName)
        {
            List<string> sheetNames = new List<string>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var excel = new ExcelPackage(fileName);
            var worksheets = excel.Workbook.Worksheets;

            foreach (var sheet in worksheets)
            {
                sheetNames.Add(sheet.Name);
            }

            return sheetNames;
        }

        public bool CheckSheetExits(string fileName, string sheetName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(fileName)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == sheetName) ?? null;

                if (workSheet == null)
                {
                    return false;
                }
            }

            return true;
        }

        public void DeleteRangeOfSheet(string fileName, string sheetName, string rangeName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(fileName)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == sheetName) ?? null;

                if (workSheet != null)
                {
                    workSheet.Cells[rangeName].Clear();
                }

                package.Save();
            }
        }
    }
}
