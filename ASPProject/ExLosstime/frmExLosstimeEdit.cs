using ASPData.ASPDAO;
using ASPData.LosstimeDTO;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Design.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASPProject.ExLosstime
{
    public partial class frmExLosstimeEdit : DevExpress.XtraEditors.XtraForm
    {
        public string userName, lineID, empID, losstimeID;
        public string[] lstEmpID = new string[] { "" };
        public double losstimeNum, losstimeNumTC;
        public DateTime statisticDate;
        public int iNgonNgu, saveMulti;
        public DataTable dtSaveMulti = new DataTable();
        public DataTable dtAll = new DataTable();

        private readonly ASPData.SQLHelper _sqlhelper = new ASPData.SQLHelper();
        LosstimeDAO exLossDAO = new LosstimeDAO();
        LosstimeDTO exLossDTO = new LosstimeDTO();
        public frmExLosstimeEdit()
        {
            InitializeComponent();
            this.Load += FrmExLosstimeEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }

        private void FrmExLosstimeEdit_Load(object sender, EventArgs e)
        {
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            txtLosstimeNum.Text = losstimeNum > 0 ? Convert.ToString(losstimeNum) : string.Empty;
            txtLosstimeNumTC.Text = losstimeNumTC > 0 ? Convert.ToString(losstimeNumTC) : string.Empty;
            txtLosstimeID.Text = Convert.ToString(losstimeID);
            dtpBeginTime.EditValue = statisticDate;
            dtpEndTime.EditValue = statisticDate;
        }

        private bool FormCheckValid()
        {
            //if (string.IsNullOrEmpty(Convert.ToString(txtLosstimeNum.Text)) && string.IsNullOrEmpty(Convert.ToString(txtLosstimeNumTC.Text)))
            //{
            //    XtraMessageBox.Show("Vui lòng nhập giờ Losstime.");
            //    return false;
            //}

            return true;
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
            this.Text = "Update external losstime";
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormCheckValid())
                    return;

                if (saveMulti == 0)
                {
                    if (lstEmpID.Length > 0)
                    {
                        foreach (string strEmpId in lstEmpID)
                        {
                            exLossDTO.StatisticDate = statisticDate.Date;
                            exLossDTO.LineID = lineID;
                            exLossDTO.EmpID = strEmpId.Trim();
                            exLossDTO.LosstimeID = losstimeID;
                            exLossDTO.LosstimeNum = Convert.ToDouble(!string.IsNullOrEmpty(txtLosstimeNum.Text) ? txtLosstimeNum.Text : "0");
                            exLossDTO.LosstimeNumTC = Convert.ToDouble(!string.IsNullOrEmpty(txtLosstimeNumTC.Text) ? txtLosstimeNumTC.Text : "0");
                            exLossDTO.StartTime = !string.IsNullOrEmpty(dtpBeginTime.EditValue.ToString()) ? Convert.ToDateTime(dtpBeginTime.EditValue) : statisticDate;
                            exLossDTO.EndTime = !string.IsNullOrEmpty(dtpEndTime.EditValue.ToString()) ? Convert.ToDateTime(dtpEndTime.EditValue) : statisticDate;
                            exLossDTO.CreatedDate = DateTime.Now;
                            exLossDTO.CreatedBy = userName;
                            exLossDTO.LastModifiedDate = DateTime.Now;
                            exLossDTO.LastModifiedBy = userName;
                            exLossDTO.Description = mmDescription.Text;
                            exLossDAO.UpdateExLosstime(exLossDTO);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(empID))
                        {
                            exLossDTO.StatisticDate = statisticDate.Date;
                            exLossDTO.LineID = lineID;
                            exLossDTO.EmpID = empID;
                            exLossDTO.LosstimeID = losstimeID;
                            exLossDTO.LosstimeNum = Convert.ToDouble(!string.IsNullOrEmpty(txtLosstimeNum.Text) ? txtLosstimeNum.Text : "0");
                            exLossDTO.LosstimeNumTC = Convert.ToDouble(!string.IsNullOrEmpty(txtLosstimeNumTC.Text) ? txtLosstimeNumTC.Text : "0");
                            exLossDTO.StartTime = !string.IsNullOrEmpty(dtpBeginTime.EditValue.ToString()) ? Convert.ToDateTime(dtpBeginTime.EditValue) : statisticDate;
                            exLossDTO.EndTime = !string.IsNullOrEmpty(dtpEndTime.EditValue.ToString()) ? Convert.ToDateTime(dtpEndTime.EditValue) : statisticDate;
                            exLossDTO.CreatedDate = DateTime.Now;
                            exLossDTO.CreatedBy = userName;
                            exLossDTO.LastModifiedDate = DateTime.Now;
                            exLossDTO.LastModifiedBy = userName;
                            exLossDTO.Description = mmDescription.Text;
                            exLossDAO.UpdateExLosstime(exLossDTO);
                        }
                    }
                    this.Close();
                }
                else
                {
                    if (lstEmpID.Length > 0)
                    {
                        foreach (string strEmpId in lstEmpID)
                        {
                            foreach (DataRow drSave in dtSaveMulti.Rows)
                            {
                                exLossDTO.StatisticDate = Convert.ToDateTime(drSave["StatisticDate"]).Date;
                                exLossDTO.LineID = Convert.ToString(drSave["LineID"]);
                                exLossDTO.EmpID = strEmpId;
                                exLossDTO.LosstimeID = Convert.ToString(drSave["LosstimeID"]); ;
                                exLossDTO.LosstimeNum = Convert.ToDouble(!string.IsNullOrEmpty(txtLosstimeNum.Text) ? txtLosstimeNum.Text : "0");
                                exLossDTO.LosstimeNumTC = Convert.ToDouble(!string.IsNullOrEmpty(txtLosstimeNumTC.Text) ? txtLosstimeNumTC.Text : "0");
                                exLossDTO.StartTime = !string.IsNullOrEmpty(dtpBeginTime.EditValue.ToString()) ? Convert.ToDateTime(dtpBeginTime.EditValue) : statisticDate;
                                exLossDTO.EndTime = !string.IsNullOrEmpty(dtpEndTime.EditValue.ToString()) ? Convert.ToDateTime(dtpEndTime.EditValue) : statisticDate;
                                exLossDTO.CreatedDate = DateTime.Now;
                                exLossDTO.CreatedBy = userName;
                                exLossDTO.LastModifiedDate = DateTime.Now;
                                exLossDTO.LastModifiedBy = userName;
                                exLossDTO.Description = mmDescription.Text;
                                exLossDAO.UpdateExLosstime(exLossDTO);
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow drSave in dtSaveMulti.Rows)
                        {
                            exLossDTO.StatisticDate = Convert.ToDateTime(drSave["StatisticDate"]).Date;
                            exLossDTO.LineID = Convert.ToString(drSave["LineID"]);
                            exLossDTO.EmpID = Convert.ToString(drSave["EmpID"]);
                            exLossDTO.LosstimeID = Convert.ToString(drSave["LosstimeID"]); ;
                            exLossDTO.LosstimeNum = Convert.ToDouble(!string.IsNullOrEmpty(txtLosstimeNum.Text) ? txtLosstimeNum.Text : "0");
                            exLossDTO.LosstimeNumTC = Convert.ToDouble(!string.IsNullOrEmpty(txtLosstimeNumTC.Text) ? txtLosstimeNumTC.Text : "0");
                            exLossDTO.StartTime = !string.IsNullOrEmpty(dtpBeginTime.EditValue.ToString()) ? Convert.ToDateTime(dtpBeginTime.EditValue) : statisticDate;
                            exLossDTO.EndTime = !string.IsNullOrEmpty(dtpEndTime.EditValue.ToString()) ? Convert.ToDateTime(dtpEndTime.EditValue) : statisticDate;
                            exLossDTO.CreatedDate = DateTime.Now;
                            exLossDTO.CreatedBy = userName;
                            exLossDTO.LastModifiedDate = DateTime.Now;
                            exLossDTO.LastModifiedBy = userName;
                            exLossDTO.Description = mmDescription.Text;
                            exLossDAO.UpdateExLosstime(exLossDTO);
                        }
                    }

                    this.Close();
                }

                if (chkAll.CheckState == CheckState.Checked)
                {
                    foreach (DataRow drSave in dtAll.Rows)
                    {
                        exLossDTO.StatisticDate = Convert.ToDateTime(drSave["StatisticDate"]).Date;
                        exLossDTO.LineID = Convert.ToString(drSave["LineID"]);
                        exLossDTO.EmpID = Convert.ToString(drSave["EmpID"]);
                        exLossDTO.LosstimeID = Convert.ToString(drSave["LosstimeID"]); ;
                        exLossDTO.LosstimeNum = Convert.ToDouble(!string.IsNullOrEmpty(txtLosstimeNum.Text) ? txtLosstimeNum.Text : "0");
                        exLossDTO.LosstimeNumTC = Convert.ToDouble(!string.IsNullOrEmpty(txtLosstimeNumTC.Text) ? txtLosstimeNumTC.Text : "0");
                        exLossDTO.StartTime = !string.IsNullOrEmpty(dtpBeginTime.EditValue.ToString()) ? Convert.ToDateTime(dtpBeginTime.EditValue) : statisticDate;
                        exLossDTO.EndTime = !string.IsNullOrEmpty(dtpEndTime.EditValue.ToString()) ? Convert.ToDateTime(dtpEndTime.EditValue) : statisticDate;
                        exLossDTO.CreatedDate = DateTime.Now;
                        exLossDTO.CreatedBy = userName;
                        exLossDTO.LastModifiedDate = DateTime.Now;
                        exLossDTO.LastModifiedBy = userName;
                        exLossDTO.Description = mmDescription.Text;
                        exLossDAO.UpdateExLosstime(exLossDTO);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
