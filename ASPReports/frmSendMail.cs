using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using LinkQ.Systems;

namespace LinkQ.Systems.Customizes
{
	public partial class frmSendMail : LinkQ.Systems.Customizes.frmEdit
	{
		public string strFileName = string.Empty;
		public string strFileType = string.Empty;		
		string strTen_Bc = string.Empty;

		public frmSendMail()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			cboExportType.Validated += new EventHandler(cboExportType_Validated);
		}

		public void Load(string strTen_Bc)
		{
			this.strTen_Bc = strTen_Bc;
			txtfilename.Text =     strTen_Bc.Trim();
			cboExportType.Text = cboExportType.Items[0].ToString();

			this.ShowDialog();
		}

		void cboExportType_Validated(object sender, EventArgs e)
		{
			switch (cboExportType.Text.Substring(0, 1))
			{
				case "1": //Excel					
					strFileType = "xls";
					break;
				case "2": //enuExportType.Word:					
					strFileType = "doc";
					break;
				case "3": //enuExportType.PDF:					
					strFileType = "pdf";
					break;								
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{

			strFileName = txtfilename.Text.Trim()+"."+strFileType;
			this.isAccept = true;
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
		
	}
}
