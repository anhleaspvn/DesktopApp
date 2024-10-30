using ASPData.ASPDAO;
using ASPData.LosstimeDTO;
using ASPData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASPData.ProdStatisticDTO;
using System.Globalization;
using System.Threading;
using DevExpress.XtraEditors;

namespace ASPProject.LineProdStatistic
{
    public partial class frmPSDetailEmpEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType, saveMulti;
        public int iNgonNgu;
        public long HeaderID;
        public string empID, lineID, userName;
        public double empWorktime, empOvertime, empRework, empSorting, empOverRework, empOverSorting;
        public DataTable dtSaveMulti;

        private readonly SQLHelper _sqlHelper = new SQLHelper();

        PSDetailEmp detailEmpDto = new PSDetailEmp();
        ProdStatisticDAO prodStatDto = new ProdStatisticDAO();

        #endregion

        #region Constructor
        public frmPSDetailEmpEdit()
        {
            InitializeComponent();
            this.Load += FrmPSDetailEmpEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Load
        private void FrmPSDetailEmpEdit_Load(object sender, EventArgs e)
        {
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            if (editType == 0)
            {
                txtWorkTime.Text = empWorktime > 0 ? Convert.ToString(empWorktime) : string.Empty;
                txtOverTime.Text = empOvertime > 0 ? Convert.ToString(empOvertime) : string.Empty;
                txtEmpRework.Text = empRework > 0 ? Convert.ToString(empRework) : string.Empty;
                txtEmpSorting.Text = empSorting > 0 ? Convert.ToString(empSorting) : string.Empty;
                txtEmpOverRework.Text = empOverRework > 0 ? Convert.ToString(empOverRework) : string.Empty;
                txtEmpOverSorting.Text = empOverSorting > 0 ? Convert.ToString(empOverSorting) : string.Empty;

                lkeEmpID.EditValue = empID;
                lkeEmpID.Enabled = false;

                lkeEmpID.Properties.DataSource = prodStatDto.GetEmployeeList(empID);
                lkeEmpID.Properties.ValueMember = "EmpID";
                lkeEmpID.Properties.DisplayMember = "EmpID";
                lkeEmpID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                lkeEmpID.Properties.PopupFilterMode = PopupFilterMode.Contains;
            }
            else
            {
                //txtWorkTime.Text = "0";
                //txtOverTime.Text = "0";
                //txtEmpRework.Text = "0";
                //txtEmpSorting.Text = "0";
                //txtEmpOverRework.Text = "0";
                //txtEmpOverSorting.Text = "0";

                lkeEmpID.Properties.DataSource = prodStatDto.GetEmployeeList(string.Empty);
                lkeEmpID.Properties.ValueMember = "EmpID";
                lkeEmpID.Properties.DisplayMember = "EmpID";
                lkeEmpID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                lkeEmpID.Properties.PopupFilterMode = PopupFilterMode.Contains;
            }

        }

        public void LoadTV()
        {
            iNgonNgu = 0;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
        }
        public void LoadEL()
        {
            iNgonNgu = 1;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
            this.Text = "Form Insert && Update Losstime";
        }

        private bool FormCheckValid()
        {
            if (Convert.ToDouble(!string.IsNullOrEmpty(txtWorkTime.Text) ? txtWorkTime.Text : "0") > 8)
            {
                XtraMessageBox.Show("Giờ công hành chính phải <= 8");
                return false;
            }

            if (Convert.ToDouble(!string.IsNullOrEmpty(txtOverTime.Text) ? txtOverTime.Text : "0") > 5)
            {
                XtraMessageBox.Show("Giờ công tăng ca phải <= 5");
                return false;
            }

            if (Convert.ToDouble(!string.IsNullOrEmpty(txtEmpRework.Text) ? txtEmpRework.Text : "0") > 8)
            {
                XtraMessageBox.Show("Giờ công sửa hàng hành chính phải <= 8");
                return false;
            }

            if (Convert.ToDouble(!string.IsNullOrEmpty(txtEmpSorting.Text) ? txtEmpSorting.Text : "0") > 8)
            {
                XtraMessageBox.Show("Giờ công Sorting hành chính phải <= 8");
                return false;
            }

            if (Convert.ToDouble(!string.IsNullOrEmpty(txtEmpOverRework.Text) ? txtEmpOverRework.Text : "0") > 5)
            {
                XtraMessageBox.Show("Giờ công sửa hàng tăng ca phải <= 5");
                return false;
            }

            if (Convert.ToDouble(!string.IsNullOrEmpty(txtEmpOverSorting.Text) ? txtEmpOverSorting.Text : "0") > 5)
            {
                XtraMessageBox.Show("Giờ công Sorting tăng ca phải <= 5");
                return false;
            }

            return true;
        }

        private bool Save(int saveMulti)
        {
            try
            {
                if (!FormCheckValid())
                    return false;

                if (editType == 0)
                {
                    if (saveMulti == 0)
                    {
                        detailEmpDto.HeaderID = HeaderID;
                        detailEmpDto.LineID = lineID;
                        detailEmpDto.EmpID = empID;
                        detailEmpDto.EmpWorktime = Convert.ToDouble(!string.IsNullOrEmpty(txtWorkTime.Text) ? txtWorkTime.Text : "0");
                        detailEmpDto.EmpOvertime = Convert.ToDouble(!string.IsNullOrEmpty(txtOverTime.Text) ? txtOverTime.Text : "0");
                        detailEmpDto.EmpRework = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpRework.Text) ? txtEmpRework.Text : "0");
                        detailEmpDto.EmpSorting = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpSorting.Text) ? txtEmpSorting.Text : "0");
                        detailEmpDto.EmpOverRework = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpOverRework.Text) ? txtEmpOverRework.Text : "0");
                        detailEmpDto.EmpOverSorting = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpOverSorting.Text) ? txtEmpOverSorting.Text : "0");
                        detailEmpDto.LastModifiedDate = DateTime.Now;
                        detailEmpDto.LastModifiedBy = userName;

                        prodStatDto.UpdatePSDetailEmp(detailEmpDto);

                        this.Close();
                    }
                    else
                    {
                        for (int row = 0; row <= dtSaveMulti.Rows.Count - 1; row++)
                        {
                            DataRow drSave = dtSaveMulti.Rows[row];

                            detailEmpDto.HeaderID = (long)Convert.ToDouble(drSave["HeaderID"]);
                            detailEmpDto.LineID = Convert.ToString(drSave["LineID"]);
                            detailEmpDto.EmpID = Convert.ToString(drSave["EmpID"]);
                            detailEmpDto.EmpWorktime = Convert.ToDouble(!string.IsNullOrEmpty(txtWorkTime.Text) ? txtWorkTime.Text : "0");
                            detailEmpDto.EmpOvertime = Convert.ToDouble(!string.IsNullOrEmpty(txtOverTime.Text) ? txtOverTime.Text : "0");
                            detailEmpDto.EmpRework = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpRework.Text) ? txtEmpRework.Text : "0");
                            detailEmpDto.EmpSorting = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpSorting.Text) ? txtEmpSorting.Text : "0");
                            detailEmpDto.EmpOverRework = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpOverRework.Text) ? txtEmpOverRework.Text : "0");
                            detailEmpDto.EmpOverSorting = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpOverSorting.Text) ? txtEmpOverSorting.Text : "0");
                            detailEmpDto.LastModifiedDate = DateTime.Now;
                            detailEmpDto.LastModifiedBy = userName;

                            prodStatDto.UpdatePSDetailEmp(detailEmpDto);

                            this.Close();
                        }
                    }
                }
                else
                {
                    detailEmpDto.HeaderID = HeaderID;
                    detailEmpDto.EmpID = Convert.ToString(lkeEmpID.EditValue);
                    detailEmpDto.LineID = lineID;
                    detailEmpDto.EmpWorktime = Convert.ToDouble(!string.IsNullOrEmpty(txtWorkTime.Text) ? txtWorkTime.Text : "0");
                    detailEmpDto.EmpOvertime = Convert.ToDouble(!string.IsNullOrEmpty(txtOverTime.Text) ? txtOverTime.Text : "0");
                    detailEmpDto.EmpRework = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpRework.Text) ? txtEmpRework.Text : "0");
                    detailEmpDto.EmpSorting = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpSorting.Text) ? txtEmpSorting.Text : "0");
                    detailEmpDto.EmpOverRework = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpOverRework.Text) ? txtEmpOverRework.Text : "0");
                    detailEmpDto.EmpOverSorting = Convert.ToDouble(!string.IsNullOrEmpty(txtEmpOverSorting.Text) ? txtEmpOverSorting.Text : "0");
                    detailEmpDto.CreatedDate = DateTime.Now;
                    detailEmpDto.CreatedBy = userName;

                    prodStatDto.InsertPSDetailEmp(detailEmpDto);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }

            //XtraMessageBox.Show("Đã thêm/cập nhật thành công.");

            return true;
        }
        #endregion

        #region Event
        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            Save(saveMulti);
        }
        #endregion
    }
}
