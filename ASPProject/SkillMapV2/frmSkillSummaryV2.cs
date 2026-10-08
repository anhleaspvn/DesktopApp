using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ASPData;
using ASPData.ASPDAO;

namespace ASPProject.AppTemplateSkillMapV2
{
    /// <summary>
    /// Form gốc cho 2 màn hình summary (Total theo tháng / Date theo năm).
    /// Fix P1: gom chung cấu trúc (v1 frmLoadSkillTotal & frmLoadSkillDate gần y hệt).
    /// </summary>
    public abstract class frmSkillSummaryBase : frmSkillMapBase
    {
        protected GridControl Grid;
        protected GridView View;
        protected DateEdit DateCtl;

        protected abstract string ProcedureName { get; }
        protected abstract SqlParameter[] BuildParams();

        protected void InitSummary(string title, string dateFormat, DevExpress.XtraEditors.VistaCalendarViewStyle style)
        {
            Text = title;
            Width = 1000; Height = 600;
            var pnl = new Panel { Dock = DockStyle.Top, Height = 44 };
            DateCtl = new DateEdit { Width = 120, Dock = DockStyle.Left };
            var btn = new SimpleButton { Text = "Filter", Width = 80, Dock = DockStyle.Right };
            pnl.Controls.Add(DateCtl);
            pnl.Controls.Add(btn);
            Grid = new GridControl { Dock = DockStyle.Fill };
            View = new GridView();
            Grid.MainView = View;
            Controls.Add(Grid);
            Controls.Add(pnl);
            btn.Click += (s, e) => ShowData();
            SetupDateEdit(DateCtl, dateFormat, style);
            SetupView();
        }

        protected void SetupView()
        {
            View.Appearance.HeaderPanel.Options.UseFont = true;
            View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            View.OptionsBehavior.Editable = false;
            View.OptionsView.ShowAutoFilterRow = true;
            View.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            View.HorzScrollVisibility = ScrollVisibility.Auto;
            View.OptionsView.ShowGroupPanel = false;
            View.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center;
        }

        protected void ShowData()
        {
            try
            {
                using (var con = new SqlConnection(constring))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(ProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(BuildParams());
                        var da = new SqlDataAdapter(cmd);
                        var dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Grid.DataSource = dt;
                            View.Columns.Clear();
                            View.PopulateColumns();
                            View.BestFitColumns();
                        }
                        else
                        {
                            XtraMessageBox.Show("Chưa tìm thấy thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Grid.DataSource = null;
                            View.Columns.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error : " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ShowData();
        }
    }

    public class frmSkillTotalV2 : frmSkillSummaryBase
    {
        protected override string ProcedureName => "sp_Asp_Show_SkillMonthTotal";
        protected override SqlParameter[] BuildParams()
        {
            int month = ((DateTime)DateCtl.EditValue).Month;
            return new[] { new SqlParameter("@CreateDate", month) };
        }
        public frmSkillTotalV2()
        {
            InitSummary("Skill Total V2", "MM", DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView);
        }
    }

    public class frmSkillDateV2 : frmSkillSummaryBase
    {
        protected override string ProcedureName => "sp_GetSkillMapPivot_V1";
        protected override SqlParameter[] BuildParams()
        {
            int year = ((DateTime)DateCtl.EditValue).Year;
            return new[] { new SqlParameter("@YEAR", year) };
        }
        public frmSkillDateV2()
        {
            InitSummary("Skill Date V2", "yyyy", DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView);
        }
    }
}
