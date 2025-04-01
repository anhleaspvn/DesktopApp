using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPControl
{
    public partial class Header : UserControl
    {
        #region Objects/Variabels

        bool showBorder = false;

        #endregion

        # region Constructors

        public Header()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            //this.BackgroundImage = ASPToolsProject.Properties.Resources.Header_Background1;//PhoneBook.Properties.Resources.Header_Background1;
            //this.panMain.BackgroundImage = ASPToolsProject.Properties.Resources.Header_Main1;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the title text (the upper text) of the control.
        /// </summary>
        [Browsable(true)]
        [DefaultValue("Title")]
        [Description("Indicates the title text (the upper text) of the header.")]
        public string Title
        {
            set { this.lblTitle.Text = value; }
            get { return this.lblTitle.Text; }
        }

        /// <summary>
        /// Gets or sets the description text (the lower text) of the control.
        /// </summary>
        [Browsable(true)]
        [DefaultValue("Description")]
        [Description("Indicates the description text (the lower text) of the header.")]
        public string Description
        {
            set { this.lblDescription.Text = value; }
            get { return this.lblDescription.Text; }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Determines whether the border line is displayed or not.")]
        public bool ShowBorder
        {
            set { this.showBorder = value; }
            get { return this.showBorder; }
        }

        //[Browsable(false)]
        //public Image MainImage
        //{
        //    get { return ASPToolsProject.Properties.Resources.Header_Main1; }
        //}

        /*Overrides Header control properties*/

        [Browsable(true)]
        [DefaultValue(DockStyle.Top)]
        public override DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; }
        }

        [Browsable(true)]
        public override Color ForeColor
        {
            get { return this.lblTitle.ForeColor; }
            set { this.lblTitle.ForeColor = value; }
        }

        //[Browsable(false)]
        //public override System.Drawing.Image BackgroundImage
        //{
        //    get { return global::ASPToolsProject.Properties.Resources.Header_Background1; }
        //}

        [Browsable(false)]
        public override System.Drawing.Color BackColor
        {
            get { return Color.White; }
        }

        [Browsable(false)]
        public override System.Windows.Forms.ImageLayout BackgroundImageLayout
        {
            get { return ImageLayout.Stretch; }
        }

        #endregion

        #region User's Defined Methods

        /// <summary>
        /// Sets the title and description text of the control.
        /// </summary>
        /// <param name="title">The title text (upper text)of the control</param>
        /// <param name="description">The description text (lower text) of the control</param>
        public void setText(string title, string description)
        {
            this.lblTitle.Text = title;
            this.lblDescription.Text = description;
        }

        #endregion

        #region Events

        private void Header_Resize(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(this.Width, 54);
        }

        private void panMain_Paint(object sender, PaintEventArgs e)
        {
            if (showBorder)
            {
                e.Graphics.DrawLine(new System.Drawing.Pen(Color.DodgerBlue), 0, 0, this.Width - 1, 0);
                e.Graphics.DrawLine(new System.Drawing.Pen(Color.DodgerBlue), 0, 0, 0, this.Height);
            }
        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {
            if (showBorder)
            {
                e.Graphics.DrawLine(new System.Drawing.Pen(Color.DodgerBlue), 0, 0, this.Width - 1, 0);
                e.Graphics.DrawLine(new System.Drawing.Pen(Color.DodgerBlue), this.Width - 1, 0, this.Width - 1, this.Height);
            }
        }

        #endregion
    }
}
