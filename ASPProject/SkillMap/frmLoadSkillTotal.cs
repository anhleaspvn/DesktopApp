using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraCharts.Design;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using ASPData;
using ASPData.ASPDAO;

namespace ASPProject.SkillMap
{
    public partial class frmLoadSkillTotal : XtraForm
    {
        private readonly ASPData.ASPData _aspData = new ASPData.ASPData();
        private readonly SkillMapDAO _skillMapDao = new SkillMapDAO();

        private string constring => _aspData.ASPDecrypt(configDatabase.CONNECTION_STRINGS);
        private SqlDataAdapter DATA;
        private DataTable DT;
        public string UseNameLogin;


        public frmLoadSkillTotal()
        {
            InitializeComponent();

            
            gridViewSkillTotal.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewSkillTotal.Appearance.HeaderPanel.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            gridViewSkillTotal.OptionsBehavior.Editable = false;
            gridViewSkillTotal.OptionsView.ShowAutoFilterRow = true;
            gridViewSkillTotal.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridViewSkillTotal.HorzScrollVisibility = ScrollVisibility.Auto;
            gridViewSkillTotal.OptionsView.ShowGroupPanel = false;

            //-- căn giữa cột tiêu đề
            gridViewSkillTotal.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //-- căn giữa dữ liệu trong lưới
            gridViewSkillTotal.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void frmLoadSkillTotal_Load(object sender, EventArgs e)
        {
            Setup_DateTime_Control();
            ShowData();
        }



        private void Setup_DateTime_Control()
        {
            DateTime TODAY = DateTime.Now;

            dateEditMonth.DateTime = TODAY;
            dateEditMonth.EditValue = TODAY;

            dateEditMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditMonth.Properties.DisplayFormat.FormatString = "MM";

            dateEditMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditMonth.Properties.EditFormat.FormatString = "MM";

            dateEditMonth.Properties.Mask.EditMask = "MM";
            dateEditMonth.Properties.Mask.UseMaskAsDisplayFormat = true;

            dateEditMonth.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView;
        }





        private void ShowData()
        {
            int MonthSelect = ((DateTime)dateEditMonth.EditValue).Month;

            try
            {
                using (SqlConnection CON = new SqlConnection(constring))
                {
                    CON.Open();

                    using (SqlCommand CMD = new SqlCommand("sp_Asp_Show_SkillMonthTotal", CON)) 
                    {
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.Parameters.AddWithValue("@CreateDate", MonthSelect); 
                        DATA = new SqlDataAdapter(CMD);
                        DT = new DataTable();
                        DATA.Fill(DT);

                        if (DT.Rows.Count > 0)
                        {
                           gridControlSkillTotal.DataSource = DT;

                            //BindingDataToGrid(DT);
                            gridViewSkillTotal.Columns.Clear();
                            gridViewSkillTotal.PopulateColumns();
                            // gridViewSkillTotal.BestFitColumns();



                            //--- GridView thực hiện việc gộp ô ---
                            gridViewSkillTotal.OptionsView.AllowCellMerge = true;
                            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridViewSkillTotal.Columns)
                            {
                                col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                            }

                            //  Chỉ bật gộp ô cho 2 cột 
                            gridViewSkillTotal.Columns["Total"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                            gridViewSkillTotal.Columns["Tháng năm"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                            gridViewSkillTotal.Columns["Total"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            gridViewSkillTotal.Columns["Tháng năm"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                        }
                        else
                        {
                            XtraMessageBox.Show("Chưa tìm thấy thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gridControlSkillTotal.DataSource = DBNull.Value;
                            gridViewSkillTotal.Columns.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error : " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButFilterMonth_Click(object sender, EventArgs e)
        {
            ShowData();
        }

    }
}
