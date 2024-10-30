using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
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
using System.Globalization;
using System.Threading;
using DevExpress.XtraEditors;

namespace ASPProject.LineProdStatistic
{
    public partial class frmProdPSDetailExWork : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType;
        public int iNgonNgu;
        public long HeaderID;
        public string empID, exProdWorkID, userName;
        public double exProdWorkTime, exProdWorkTimeTC;
        private DataTable dtExProdWork = new DataTable();
      
        private readonly SQLHelper _sqlHelper = new SQLHelper();

        PSDetailExProdWork exworkDto = new PSDetailExProdWork();
        ProdStatisticDAO prodStatDao = new ProdStatisticDAO();
        #endregion

        #region Constructor
        public frmProdPSDetailExWork()
        {
            InitializeComponent();

            this.Load += FrmProdPSDetailExWork_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Event
        private void FrmProdPSDetailExWork_Load(object sender, EventArgs e)
        {
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            switch (editType)
            {
                case 1:
                    lkeEmpID.Properties.DataSource = prodStatDao.GetEmployeeList(string.Empty);
                    lkeEmpID.Properties.ValueMember = "EmpID";
                    lkeEmpID.Properties.DisplayMember = "EmpID";
                    lkeEmpID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeEmpID.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    lkeExWorkID.Properties.DataSource = prodStatDao.GetSubJobProdList(string.Empty);
                    lkeExWorkID.Properties.ValueMember = "SubJobID";
                    lkeExWorkID.Properties.DisplayMember = "SubJobID";
                    lkeExWorkID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeExWorkID.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    break;
                case 0:
                    lkeEmpID.EditValue = empID;
                    lkeEmpID.Enabled = false;

                    lkeEmpID.Properties.DataSource = prodStatDao.GetEmployeeList(empID);
                    lkeEmpID.Properties.ValueMember = "EmpID";
                    lkeEmpID.Properties.DisplayMember = "EmpID";
                    lkeEmpID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeEmpID.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    lkeExWorkID.EditValue = exProdWorkID;
                    lkeExWorkID.Enabled = false;

                    lkeExWorkID.Properties.DataSource = prodStatDao.GetSubJobProdList(exProdWorkID);
                    lkeExWorkID.Properties.ValueMember = "SubJobID";
                    lkeExWorkID.Properties.DisplayMember = "SubJobID";
                    lkeExWorkID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeExWorkID.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    txtExProdWorkTime.EditValue = Convert.ToString(exProdWorkTime);
                    txtExProdWorkTimeTC.EditValue = Convert.ToString(exProdWorkTimeTC);

                    break;
                default:
                    break;
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
            this.Text = "Form External Production Work";
        }
        
        private bool FormCheckValid()
        {
            if (string.IsNullOrEmpty((string)lkeEmpID.EditValue))
            {
                XtraMessageBox.Show("Nhân viên không được để trống.");
                return false;
            } 
            
            if (string.IsNullOrEmpty((string)lkeExWorkID.EditValue))
            {
                XtraMessageBox.Show("Công việc không được để trống.");
                return false;
            } 
            
            return true;
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (!FormCheckValid())
                return;

            switch (editType)
            {
                case 1:
                    try
                    {
                        exworkDto.HeaderID = HeaderID;
                        exworkDto.EmpID = Convert.ToString(lkeEmpID.EditValue);
                        exworkDto.EmpName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(EmpName, '') FROM ASPEmployee WHERE EmpID = '" + Convert.ToString(lkeEmpID.EditValue) + "'");
                        exworkDto.ExProdWorkID = Convert.ToString(lkeExWorkID.EditValue);
                        exworkDto.ExProdWorkName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(SubJobName, '') FROM ASPProdExWork WHERE SubJobID = '" + Convert.ToString(lkeExWorkID.EditValue) + "'");
                        exworkDto.ExProdWorkTime = Convert.ToDouble(!string.IsNullOrEmpty(txtExProdWorkTime.Text) ? txtExProdWorkTime.Text : "0");
                        exworkDto.ExProdWorkTimeTC = Convert.ToDouble(!string.IsNullOrEmpty(txtExProdWorkTimeTC.Text) ? txtExProdWorkTimeTC.Text : "0");
                        exworkDto.CreatedBy = userName;
                        exworkDto.CreatedDate = DateTime.Now;

                        prodStatDao.InsertPSDetailExProdWork(exworkDto);

                        this.Close();

                        //XtraMessageBox.Show("Đã thêm thành công sub job.");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }

                    break;
                case 0:
                    exworkDto.HeaderID = HeaderID;
                    exworkDto.EmpID = Convert.ToString(lkeEmpID.EditValue);
                    exworkDto.ExProdWorkID = Convert.ToString(lkeExWorkID.EditValue);
                    exworkDto.ExProdWorkTime = Convert.ToDouble(!string.IsNullOrEmpty(txtExProdWorkTime.Text) ? txtExProdWorkTime.Text : "0");
                    exworkDto.ExProdWorkTimeTC = Convert.ToDouble(!string.IsNullOrEmpty(txtExProdWorkTimeTC.Text) ? txtExProdWorkTimeTC.Text : "0");
                    exworkDto.LastModifiedBy = userName;
                    exworkDto.LastModifiedDate = DateTime.Now;

                    prodStatDao.UpdatePSDetailExProdWork(exworkDto);

                    this.Close();

                    break;
                default:
                    break;
            }    
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
