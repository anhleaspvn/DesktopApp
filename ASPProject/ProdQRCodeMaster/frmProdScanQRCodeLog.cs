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
using DevExpress.Printing.Core.PdfExport.Metafile;
using DevExpress.XtraEditors;
using System.Device;
using System.Management;
using DevExpress.DataAccess.Native.EntityFramework;

namespace ASPProject.ProdQRCodeMaster
{
    public partial class frmProdScanQRCodeLog : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private DataTable dtProdScanQRCode = new DataTable();
        private BindingSource bdsProdScanQRCode = new BindingSource();
       
        private DataRow drHeaderCur = null;
        private DataRow drDetailCur = null;

        QRCodeLog qrDto = new QRCodeLog();
        ProdStatisticDAO qrDao = new ProdStatisticDAO();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex;
        bool isOK, isNG;
        #endregion

        public frmProdScanQRCodeLog()
        {
            InitializeComponent();

            this.KeyPreview = true;

            this.Load += FrmProdScanQRCodeLog_Load;
            
            this.txtQRCodeData.TextChanged += TxtQRCodeData_TextChanged;
        }

        private void TxtQRCodeData_TextChanged(object sender, EventArgs e)
        {
            if (txtQRCodeData.Text == string.Empty)
            {
                this.ActiveControl = txtQRCodeData;
                return;
            }

            if (txtQRCodeData.Text.Length < 18)
                return;
  
            DataTable dtUsbDevice = new DataTable();
            dtUsbDevice = _sqlHelper.ExecQueryDataAsDataTable("SELECT EmpID, AreaScan FROM ASPEmployee WHERE EmpID = '" + userName + "'");

            if (dtUsbDevice.Rows.Count > 0)
            {
                qrDto.LogID = ASPGenLogQRCode();
                qrDto.StageID = Convert.ToString(lkeProduct.EditValue);
                qrDto.LogTime = DateTime.Now;
                qrDto.LogResult = (string)dtUsbDevice.Rows[0]["AreaScan"];
                qrDto.LineID = (string)_sqlHelper.ExecQuerySacalar("SELECT ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + userName + "'");
                qrDto.QRCodeData = txtQRCodeData.Text.Trim();
                qrDto.CreatedDate = DateTime.Now;
                qrDto.CreatedBy = userName;
                qrDto.LastModifiedBy = userName;
                qrDto.LastModifiedDate = DateTime.Now;

                if (qrDto.LogResult == "OK")
                {
                    lbOK.Visible = true;
                    lbNG.Visible = false;

                    isOK = true;
                    isNG = false;
                }
                else
                {
                    lbOK.Visible = false;
                    lbNG.Visible = true;

                    isOK = false;
                    isNG = true;
                }

                if (!ValidateQRCode())
                {
                    txtQRCodeData.Text = string.Empty;
                    this.ActiveControl = txtQRCodeData;
                    return;
                }

                qrDao.InsertProdQRCodeLog(qrDto);

               
            }

            txtQRCodeData.Text = string.Empty;
            FillData();
        }
        private bool ValidateQRCode()
        {
            bool chk = true;

            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 5000;
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            args.DefaultButtonIndex = 0;
            args.Caption = "Thông báo lỗi";
            args.Text = "This message closes automatically after 5 seconds.";

            if (!txtQRCodeData.Text.StartsWith("ASM"))
            {
                args.Text = "QR Code không hợp lệ!";
                XtraMessageBox.Show(args);
                chk = false;
            }

            var dicParams = new Dictionary<string, object>()
            {
                { "@QRCodeData", txtQRCodeData.Text },
                { "@StageID", (string)lkeProduct.EditValue },
            };

            DataTable dtCheckExist = new DataTable();
            
            if (isOK == true && isNG == false)
                dtCheckExist = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPProdScanQRCodeLog WHERE QRCodeData=@QRCodeData AND LogResult='OK' AND StageID = @StageID", dicParams);
            else if (isNG == true && isOK == false)
                dtCheckExist = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPProdScanQRCodeLog WHERE QRCodeData=@QRCodeData AND StageID = @StageID", dicParams);

            if (dtCheckExist.Rows.Count > 0)
            {
                args.Text = "QR Code đã được scan, không được phép scan lại!";
                XtraMessageBox.Show(args);
                chk = false;
            }

            return chk;
        }

        private void FrmProdScanQRCodeLog_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtQRCodeData;

            dtProdScanQRCode = qrDao.GetStageOfScanQRCode();

            lkeProduct.Properties.DataSource = dtProdScanQRCode;
            lkeProduct.Properties.DisplayMember = "StageName";
            lkeProduct.Properties.ValueMember = "StageID";
            lkeProduct.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeProduct.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lkeProduct.EditValue = qrDao.GetStageAreaQRCode(userName);

           
            FillData();
        }

        private static List<UsbDevice> GetMyUSBDevices(int vid, int pid, string areaId, string status)
        {
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = searcher.Get();

            var usbDevice =
                (from ManagementBaseObject device in collection
                 select new UsbDevice(
         (string)device.GetPropertyValue("DeviceID"),
         (string)device.GetPropertyValue("Description"), areaId, status)).ToList();

            var devices = new List<UsbDevice>();

            foreach (var device in collection)
            {
                
                devices.Add(new UsbDevice(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("Description"),
                areaId, status
                ));
            }

            collection.Dispose();

            return devices.Where(device => device.DeviceId.Contains("VID") && device.VID == vid && device.DeviceId.Contains("VID") && device.PID == pid && device.Status == status).ToList();
        }

        private string ASPGenLogQRCode()
        {
            string qrCode = string.Empty;

            var dicParams = new Dictionary<string, object> {
                { "@Prefix", "LOG" },
                { "@NumLen", 20 },
                { "@ColumnID", "LogID" },
                { "@TableName", "ASPProdScanQRCodeLog" }
            };

            qrCode = (string)_sqlHelper.ExecProcedureSacalar("sp_ASPGenerateCode", dicParams);

            return qrCode;
        }

        private void FillData()
        {
            qrDto.Username = userName;

            dtProdScanQRCode = qrDao.GetQRCodeLog(qrDto);
            bdsProdScanQRCode.DataSource = dtProdScanQRCode;

            gridQRCodeLog.DataSource = dtProdScanQRCode;
        }
    }
}
public class UsbDevice
{
    public UsbDevice(string deviceId, string description, string areaID, string status)
    {
        DeviceId = deviceId;
        Description = description;
        AreaID = areaID;
        Status = status;
    }

    public string DeviceId { get; private set; }
    public string Description { get; private set; }
    public string AreaID { get; private set; }
    public string Status { get; private set; }

    public int VID
    {
        get { return int.Parse(GetIdentifierPart("VID_"), System.Globalization.NumberStyles.HexNumber); }
    }

    public int PID
    {
        get { return int.Parse(GetIdentifierPart("PID_"), System.Globalization.NumberStyles.HexNumber); }
    }

    private string GetIdentifierPart(string identifier)
    {
        var vidIndex = DeviceId.IndexOf(identifier, StringComparison.Ordinal);
        var startingAtVid = DeviceId.Substring(vidIndex + 4);
        return startingAtVid.Substring(0, 4);
    }
}