namespace Randolf.WordToolkit
{
    partial class MainRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MainRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_randolfToolkit = this.Factory.CreateRibbonTab();
            this.group_captionManage = this.Factory.CreateRibbonGroup();
            this.btn_ShowCaption = this.Factory.CreateRibbonButton();
            this.tab_picManage = this.Factory.CreateRibbonGroup();
            this.edt_picWidth = this.Factory.CreateRibbonEditBox();
            this.edt_picHeight = this.Factory.CreateRibbonEditBox();
            this.btn_updatePic = this.Factory.CreateRibbonButton();
            this.tab_randolfToolkit.SuspendLayout();
            this.group_captionManage.SuspendLayout();
            this.tab_picManage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_randolfToolkit
            // 
            this.tab_randolfToolkit.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab_randolfToolkit.Groups.Add(this.group_captionManage);
            this.tab_randolfToolkit.Groups.Add(this.tab_picManage);
            this.tab_randolfToolkit.Label = "RandolfToolkit";
            this.tab_randolfToolkit.Name = "tab_randolfToolkit";
            // 
            // group_captionManage
            // 
            this.group_captionManage.Items.Add(this.btn_ShowCaption);
            this.group_captionManage.Label = "Caption Manage";
            this.group_captionManage.Name = "group_captionManage";
            // 
            // btn_ShowCaption
            // 
            this.btn_ShowCaption.Label = "Show Captions";
            this.btn_ShowCaption.Name = "btn_ShowCaption";
            this.btn_ShowCaption.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_ShowCaption_Click);
            // 
            // tab_picManage
            // 
            this.tab_picManage.Items.Add(this.edt_picWidth);
            this.tab_picManage.Items.Add(this.edt_picHeight);
            this.tab_picManage.Items.Add(this.btn_updatePic);
            this.tab_picManage.Label = "Pic Manage";
            this.tab_picManage.Name = "tab_picManage";
            // 
            // edt_picWidth
            // 
            this.edt_picWidth.Label = "Width";
            this.edt_picWidth.Name = "edt_picWidth";
            this.edt_picWidth.Text = null;
            this.edt_picWidth.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.edt_picWidth_TextChanged);
            // 
            // edt_picHeight
            // 
            this.edt_picHeight.Label = "Height";
            this.edt_picHeight.Name = "edt_picHeight";
            this.edt_picHeight.Text = null;
            this.edt_picHeight.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.edt_picHeight_TextChanged);
            // 
            // btn_updatePic
            // 
            this.btn_updatePic.Label = "Update Pic";
            this.btn_updatePic.Name = "btn_updatePic";
            this.btn_updatePic.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_updatePic_Click);
            // 
            // MainRibbon
            // 
            this.Name = "MainRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab_randolfToolkit);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MainRibbon_Load);
            this.tab_randolfToolkit.ResumeLayout(false);
            this.tab_randolfToolkit.PerformLayout();
            this.group_captionManage.ResumeLayout(false);
            this.group_captionManage.PerformLayout();
            this.tab_picManage.ResumeLayout(false);
            this.tab_picManage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab_randolfToolkit;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_captionManage;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_ShowCaption;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup tab_picManage;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox edt_picWidth;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_updatePic;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox edt_picHeight;
    }

    partial class ThisRibbonCollection
    {
        internal MainRibbon MainRibbon
        {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}
