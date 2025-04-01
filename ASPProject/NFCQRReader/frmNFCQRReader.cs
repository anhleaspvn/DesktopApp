using ASPData.ASPDAO;
using ASPData.ASPDTO;
using DevExpress.XtraEditors;
using Sydesoft.NfcDevice;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PCSC;
using NdefLibrary.Ndef;
using ASPCameraPicker;
using System.Drawing;

namespace ASPProject.NFCQReader
{
    public partial class frmNFCQRReader : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        BindingSource bdsNfc = new BindingSource();
        DataTable dtNfc = new DataTable();
        NFCReaderDTO nfcDto = new NFCReaderDTO();
        NFCReaderDAO nfcDao = new NFCReaderDAO();
        NFCReader nfcReader = new NFCReader();
        ACR122U acr = new ACR122U();
        ICardReader reader;
        string nfcData = string.Empty;

        delegate void SetTextCallback(string text);
        #endregion

        public frmNFCQRReader()
        {
            InitializeComponent();

            acr.Init(false, 40, 4, 4, 100); //NTAG210

            dtFromDate.EditValue = DateTime.Now;
            dtToDate.EditValue = DateTime.Now;

            this.ActiveControl = mmQRCode;
            mmQRCode.Focus();

            acr.CardInserted += Acr_CardInserted;
            acr.CardRemoved += Acr_CardRemoved;

            this.Load += NFCQRReader_Load;
            this.gridNFCView.RowStyle += GridNFCView_RowStyle;

            this.btFilter.Click += BtFilter_Click;
            this.btSaveInfo.Click += BtSaveInfo_Click;
            this.btCancel.Click += BtCancel_Click;
            this.btCamera.Click += BtCamera_Click;
        }

        private void Acr_CardRemoved()
        {
            try
            {
                if (nfcReader.Connect())
                    nfcReader.Disconnect();
            }
            catch
            {

            }
        }

        private void Acr_CardInserted(ICardReader reader)
        {
            try
            {
                bool active = nfcReader.Connect();
                string condata = string.Empty;

                if (active)
                {
                    byte[] data;

                    data = acr.ReadData(reader);

                    if (data.Length > 0)
                    {
                        NdefMessage ndefmsg = DecodeNfcData(data);

                        if (ndefmsg.Count > 0)
                        {
                            byte[] pload = ndefmsg[0].Payload;
                            condata = Encoding.ASCII.GetString(pload);
                            int strLen = condata.Length;
                            condata = condata.Substring(3);

                            SetText(condata);
                        }
                        nfcReader.Disconnect();
                    }
                    else
                    {
                        nfcReader.Disconnect();
                    }
                }
            }
            catch
            {

            }
           
        }

        private void GridNFCView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            string result = Convert.ToString(gridNFCView.GetRowCellValue(e.RowHandle, "ResultMatch"));
            bool isMaxRow = Convert.ToBoolean(gridNFCView.GetRowCellValue(e.RowHandle, "IsMaxRow"));


            //if exist timekeep without workhours then mark yellow color
            if (result == "NG")
            {
                e.Appearance.ForeColor = Color.Red;
            }
            else if (result == "OK")
            {
                e.Appearance.ForeColor = Color.Blue;
            }

            if (isMaxRow)
                e.Appearance.FontStyleDelta = FontStyle.Bold;

        }

        private void BtCamera_Click(object sender, EventArgs e)
        {
            frmCamera frm = new frmCamera();
            frm.Code = mmSM232.Text;
            frm.ShowDialog();

            mmRGB.Text = frm.RGB;
            mmHSV.Text = frm.HSV;
            mmRGB2.Text = frm.RGB2;
            mmHSV2.Text = frm.HSV2;
        }

        private void SetText(string text)
        {
            if (this.mmSM232.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (text.Length >= 9)
                {
                    this.mmSM232.Text = text;
                    
                    SelectNextControl(mmQRCode, true, true, true, true);
                    mmQRCode.ReadOnly = false;
                }
            }
        }

        private void NFCQRReader_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private NdefMessage DecodeNfcData(byte[] byteData)
        {
            NdefMessage data = new NdefMessage();
            try
            {
                int offset = 0;
                while (offset < byteData.Length)
                {
                    byte tag = byteData[offset++];
                    int len = (byteData[offset++] & 0x0FF);
                    if (len == 255)
                    {
                        len = ((byteData[offset++] & 0x0FF) << 8);
                        len |= (byteData[offset++] & 0x0FF);
                    }
                    if (tag == (byte)0x03)
                    {
                        var msgBytes = new byte[len];
                        Array.Copy(byteData, offset, msgBytes, 0, len);
                        data = NdefMessage.FromByteArray(msgBytes);
                    }
                    else if (tag == (byte)0xFE)
                    {
                        break;
                    }
                    offset += len;
                }
                return data;
            }
            catch
            {

            }
            return data;
        }

        private void FillData()
        {
            nfcDto.FromDate = Convert.ToDateTime(dtFromDate.EditValue);
            nfcDto.ToDate = Convert.ToDateTime(dtToDate.EditValue);

            dtNfc = nfcDao.GetNFCQRCode(nfcDto);
            bdsNfc.DataSource = dtNfc;

            gridNFC.DataSource = bdsNfc;
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void BtSaveInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(mmSM232.Text) && !string.IsNullOrEmpty(mmQRCode.Text) && !(string.IsNullOrEmpty(mmRGB.Text) && string.IsNullOrEmpty(mmHSV.Text)))
                {
                    nfcDto.DocDate = DateTime.Now.Date;
                    nfcDto.SM232Content = mmSM232.Text.Trim();
                    nfcDto.QRCodeContent = mmQRCode.Text.Trim();

                    DataTable dtProdColor = new DataTable();

                    string[] area1RGB = mmRGB.Text.Split('-');
                    string[] area2RGB = mmRGB2.Text.Split('-');

                    dtProdColor = FindColor(Convert.ToInt32(area1RGB[0].Trim()), Convert.ToInt32(area1RGB[1].Trim()),
                                            Convert.ToInt32(area1RGB[2].Trim()), Convert.ToInt32(area2RGB[0].Trim()),
                                            Convert.ToInt32(area2RGB[1].Trim()), Convert.ToInt32(area2RGB[2].Trim()));

                    bool checkNG = CheckResultMatch(mmSM232.Text.Trim(), mmQRCode.Text.Trim(), (string)dtProdColor.Rows[0]["ColorID"],
                                                        (string)dtProdColor.Rows[0]["SerialMaskID"]);

                    nfcDto.ResultMatch = checkNG == true ? "OK" : "NG";

                    if (checkNG == false)
                    {
                        if (XtraMessageBox.Show("Vui lòng xác nhận hàng NG để tiếp tục", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }    
                    }
                   
                    nfcDto.LaserMC = string.Empty;
                    nfcDto.RGB = mmRGB.Text.Trim();
                    nfcDto.HSV = mmHSV.Text.Trim();
                    nfcDto.RGB2 = mmRGB2.Text.Trim();
                    nfcDto.HSV2 = mmHSV2.Text.Trim();
                    nfcDto.ColorID = (string)dtProdColor.Rows[0]["ColorID"];
                    nfcDto.HaveSpring = (string)dtProdColor.Rows[0]["HaveSpring"];
                    nfcDto.CreatedBy = userName;
                    nfcDto.CreatedDate = DateTime.Now;

                    nfcDao.InsertNFCQRCode(nfcDto);

                    FillData();
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng quét đủ mã NFC, QR Code, và Color Code");
                }

                mmSM232.Text = string.Empty;
                mmQRCode.Text = string.Empty;
                mmSM232.ReadOnly = true;
                mmQRCode.ReadOnly = true;
            }
            catch
            {
                mmSM232.Text = string.Empty;
                mmQRCode.Text = string.Empty;
                mmSM232.ReadOnly = true;
                mmQRCode.ReadOnly = true;
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.mmQRCode.Text = string.Empty;
            this.mmSM232.Text = string.Empty;
            this.mmHSV.Text = string.Empty;
            this.mmRGB.Text = string.Empty;
            this.mmHSV2.Text = string.Empty;
            this.mmRGB2.Text = string.Empty;
        }

        private DataTable FindColor(int Area1Red, int Area1Green, int Area1Blue, int Area2Red, int Area2Green, int Area2Blue)
        {
            DataTable dtProdColor = new DataTable();

            dtProdColor = nfcDao.FindProductColorFromRange(Area1Red, Area1Green, Area1Blue, Area2Red, Area2Green, Area2Blue);

            return dtProdColor;
        }

        private bool CheckResultMatch(string nfc, string qrCode, string serialMask, string colorID)
        {
            if (nfc != qrCode)
                return false;

            if (nfc.Substring(0, 3) != serialMask)
                return false;

            if (colorID == "NG")
                return false;

            return true;
        }
    }
}
