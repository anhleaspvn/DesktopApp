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
            return WriteDataTablesIntoExcelFile(
                new List<DataTable> { dtData },
                fileName,
                new List<string> { sheetName },
                new List<string> { rangeName },
                saveFolder);
        }

        public bool WriteDataTablesIntoExcelFile(
            IList<DataTable> dataTables,
            string fileName,
            IList<string> sheetNames,
            IList<string> rangeNames,
            string saveFolder)
        {
            if (dataTables == null)
                throw new ArgumentNullException(nameof(dataTables));
            if (sheetNames == null)
                throw new ArgumentNullException(nameof(sheetNames));
            if (rangeNames == null)
                throw new ArgumentNullException(nameof(rangeNames));
            if (dataTables.Count == 0)
                return false;
            if (dataTables.Count != sheetNames.Count || dataTables.Count != rangeNames.Count)
                throw new ArgumentException("Số bảng dữ liệu, sheet và vùng dữ liệu không khớp nhau.");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excel = new ExcelPackage(new FileInfo(fileName)))
            {
                for (int i = 0; i < dataTables.Count; i++)
                {
                    if (dataTables[i] == null)
                        throw new ArgumentException("Bảng dữ liệu thứ " + (i + 1) + " không hợp lệ.");
                    if (string.IsNullOrWhiteSpace(sheetNames[i]))
                        throw new ArgumentException("Tên sheet thứ " + (i + 1) + " không hợp lệ.");
                    if (string.IsNullOrWhiteSpace(rangeNames[i]))
                        throw new ArgumentException("Vùng dữ liệu thứ " + (i + 1) + " không hợp lệ.");

                    ExcelWorksheet workSheet = excel.Workbook.Worksheets[sheetNames[i]];
                    if (workSheet == null)
                        throw new InvalidOperationException("Không tìm thấy sheet '" + sheetNames[i] + "' trong file Excel mẫu.");

                    workSheet.Cells[rangeNames[i]].ClearFormulaValues();
                    workSheet.Cells[rangeNames[i]].LoadFromDataTable(dataTables[i]);
                }

                if (string.IsNullOrEmpty(saveFolder))
                    excel.Save();
                else
                    excel.SaveAs(saveFolder);
            }

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
            using (ExcelPackage excel = new ExcelPackage(new FileInfo(fileName)))
            {
                foreach (var sheet in excel.Workbook.Worksheets)
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
