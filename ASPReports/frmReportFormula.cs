using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using LinkQ.Systems.Data;
using LinkQ.Systems.Commons;
using LinkQ.Systems.Librarys;
using LinkQ.Systems.Controls;
using LinkQ.Systems;

namespace LinkQ.Reports
{
	public partial class frmReportFormula : LinkQ.Systems.Customizes.frmView
	{
		#region Bien

		private DataTable dtFormula;
		private DataRow drCurrent;
		private BindingSource bdsFormula = new BindingSource();
		private dgvControl dgvFormula = new dgvControl();
		private string strTableName;

		#endregion

		#region Contructor
		public frmReportFormula()
		{
			InitializeComponent();
			
			this.KeyDown += new KeyEventHandler(frmReportFormula_KeyDown);
			this.dgvFormula.RowValidated += new DataGridViewCellEventHandler(dgvFormula_RowValidated);
		}

		new public void Load(string strTableName)
		{
			this.strTableName = strTableName;

			this.Build();
			this.FillData();

			this.ShowDialog();
		}

		#endregion

		#region Phuong thuc
		private void Build()
		{
			dgvFormula.ReadOnly = false;			
			dgvFormula.strZone = strTableName;
			dgvFormula.Dock = DockStyle.Fill;

			dgvFormula.BuildGridView();

			this.Controls.Add(dgvFormula);
		}		

		private void FillData()
		{
			dtFormula = DataTool.SQLGetDataTable(strTableName, null, null, "Stt");

			bdsFormula.DataSource = dtFormula;
			dgvFormula.DataSource = bdsFormula;

			this.ExportControl = dgvFormula;
			this.bdsSearch = bdsFormula;
		}

		public void New()
		{
			if (bdsFormula.Count > 0)
				Common.CopyDataRow(((DataRowView)bdsFormula.Current).Row, ref drCurrent);
			else
				drCurrent = dtFormula.NewRow();

			if (DataTool.SQLUpdate(LinkQ.Systems.enuEdit.New, strTableName, ref drCurrent))
			{
				if (bdsFormula.Position > 0)
					dtFormula.ImportRow(drCurrent);
				else
					dtFormula.Rows.Add(drCurrent);

				dtFormula.AcceptChanges();

				bdsFormula.MoveLast();
			}
		}

		public override void Delete()
		{
			if (bdsFormula.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsFormula.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete(strTableName, drCurrent))
			{
				bdsFormula.RemoveAt(bdsFormula.Position);
				dtFormula.AcceptChanges();
			}
		}

		#endregion

		#region Su kien

		void dgvFormula_RowValidated(object sender, DataGridViewCellEventArgs e)
		{
			DataRow drUpdate = ((DataRowView)bdsFormula.Current).Row;

			//if (dtFormula.Rows[e.RowIndex].RowState == DataRowState.Added)
			//    DataTool.SQLUpdate(LinkQ.Systems.enuEdit.New, strTableName, ref drCurrent);
			//else if (dtFormula.Rows[e.RowIndex].RowState == DataRowState.Modified)
			DataTool.SQLUpdate(LinkQ.Systems.enuEdit.Edit, strTableName, ref drUpdate);
		}

		void frmReportFormula_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.N:
					if (e.Control) //Bấm Ctrl+N để thêm mới
						this.New();

					break;
				case Keys.F8:
					Delete();
					break;				
			}
		}

		#endregion
	}
}
