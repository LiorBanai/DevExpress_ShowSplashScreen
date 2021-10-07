
namespace SplashScreen
{
    partial class FoldersUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tlRecordingFolder = new DevExpress.XtraTreeList.TreeList();
            this.pnlFolders = new DevExpress.XtraEditors.PanelControl();
            this.hylRootFolder = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.KamaItemSelection = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Kama.DataManagement.Forms.DataLoadingWaitForm), true, true, typeof(System.Windows.Forms.UserControl));
            ((System.ComponentModel.ISupportInitialize)(this.tlRecordingFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFolders)).BeginInit();
            this.pnlFolders.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlRecordingFolder
            // 
            this.tlRecordingFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlRecordingFolder.Location = new System.Drawing.Point(2, 35);
            this.tlRecordingFolder.Name = "tlRecordingFolder";
            this.tlRecordingFolder.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.tlRecordingFolder.OptionsBehavior.Editable = false;
            this.tlRecordingFolder.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlRecordingFolder.Size = new System.Drawing.Size(1209, 828);
            this.tlRecordingFolder.TabIndex = 1;
            // 
            // pnlFolders
            // 
            this.pnlFolders.Controls.Add(this.tlRecordingFolder);
            this.pnlFolders.Controls.Add(this.hylRootFolder);
            this.pnlFolders.Controls.Add(this.KamaItemSelection);
            this.pnlFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFolders.Location = new System.Drawing.Point(0, 0);
            this.pnlFolders.Name = "pnlFolders";
            this.pnlFolders.Size = new System.Drawing.Size(1213, 898);
            this.pnlFolders.TabIndex = 2;
            // 
            // hylRootFolder
            // 
            this.hylRootFolder.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hylRootFolder.Appearance.Options.UseFont = true;
            this.hylRootFolder.Appearance.Options.UseTextOptions = true;
            this.hylRootFolder.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.hylRootFolder.AutoEllipsis = true;
            this.hylRootFolder.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.hylRootFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.hylRootFolder.Location = new System.Drawing.Point(2, 2);
            this.hylRootFolder.Name = "hylRootFolder";
            this.hylRootFolder.Size = new System.Drawing.Size(1209, 33);
            this.hylRootFolder.TabIndex = 3;
            this.hylRootFolder.Text = "N/A";
            // 
            // KamaItemSelection
            // 
            this.KamaItemSelection.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KamaItemSelection.Appearance.Options.UseFont = true;
            this.KamaItemSelection.Appearance.Options.UseTextOptions = true;
            this.KamaItemSelection.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.KamaItemSelection.AutoEllipsis = true;
            this.KamaItemSelection.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.KamaItemSelection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KamaItemSelection.Location = new System.Drawing.Point(2, 863);
            this.KamaItemSelection.Name = "KamaItemSelection";
            this.KamaItemSelection.Size = new System.Drawing.Size(1209, 33);
            this.KamaItemSelection.TabIndex = 2;
            this.KamaItemSelection.Text = "N/A";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // FoldersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFolders);
            this.Name = "FoldersUC";
            this.Size = new System.Drawing.Size(1213, 898);
            this.Load += new System.EventHandler(this.KamaDBFoldersUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tlRecordingFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFolders)).EndInit();
            this.pnlFolders.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlRecordingFolder;
        private DevExpress.XtraEditors.PanelControl pnlFolders;
        private DevExpress.XtraEditors.HyperlinkLabelControl KamaItemSelection;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraEditors.HyperlinkLabelControl hylRootFolder;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}
