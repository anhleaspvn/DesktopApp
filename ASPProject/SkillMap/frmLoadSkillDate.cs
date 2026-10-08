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
    public partial class frmLoadSkillDate : XtraForm
    {
        private readonly ASPData.ASPData _aspData = new ASPData.ASPData();
        private readonly SkillMapDAO _skillMapDao = new SkillMapDAO();

        private string constring => _aspData.ASPDecrypt(configDatabase.CONNECTION_STRINGS);
        private SqlDataAdapter DATA;
        private DataTable DT;
        public string UseNameLogin;


        public frmLoadSkillDate()
        {
            InitializeComponent();

            gridViewSkillDate.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewSkillDate.Appearance.HeaderPanel.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            gridViewSkillDate.OptionsBehavior.Editable = false;
            gridViewSkillDate.OptionsView.ShowAutoFilterRow = true;
            gridViewSkillDate.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridViewSkillDate.OptionsView.ShowGroupPanel = false;

            //-- căn giữa cột tiêu đề
            gridViewSkillDate.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //-- căn giữa dữ liệu trong lưới
            gridViewSkillDate.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }




        private void frmLoadSkillDate_Load(object sender, EventArgs e)
        {
            Setup_DateTime_Control();
            ShowData();
        }



        private void Setup_DateTime_Control()
        {
            DateTime TODAY = DateTime.Now;

            dateEditYear.DateTime = TODAY;
            dateEditYear.EditValue = TODAY;

            dateEditYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditYear.Properties.DisplayFormat.FormatString = "yyyy";

            dateEditYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditYear.Properties.EditFormat.FormatString = "yyyy";

            dateEditYear.Properties.Mask.EditMask = "yyyy";
            dateEditYear.Properties.Mask.UseMaskAsDisplayFormat = true;

            dateEditYear.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
        }




        private void BindingDataToGrid(DataTable DT)
        {
            gridControlSkillDate.DataSource = DT;
            int COUNT_DT = gridViewSkillDate.RowCount;

        }



        private void ShowData()
        {
            int YearSelect = ((DateTime)dateEditYear.EditValue).Year;

            try
            {
                using (SqlConnection CON = new SqlConnection(constring))
                {
                    CON.Open();

                    using (SqlCommand CMD = new SqlCommand("sp_GetSkillMapPivot_V1", CON)) 
                    {
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.Parameters.AddWithValue("@YEAR", YearSelect); 
                        DATA = new SqlDataAdapter(CMD);
                        DT = new DataTable();
                        DATA.Fill(DT);

                        if (DT.Rows.Count > 0)
                        {
                            gridControlSkillDate.DataSource = DT;

                            //BindingDataToGrid(DT);
                            gridViewSkillDate.Columns.Clear();
                            gridViewSkillDate.PopulateColumns();
                            gridViewSkillDate.BestFitColumns();
                        }
                        else
                        {
                            XtraMessageBox.Show("Chưa tìm thấy thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gridControlSkillDate.DataSource = DBNull.Value;
                            gridViewSkillDate.Columns.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error : "+ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void simpleButFilterYear_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
