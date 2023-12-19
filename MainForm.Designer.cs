
namespace DatabaseModelEntityTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.subOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.subSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.subExit = new System.Windows.Forms.ToolStripMenuItem();
            this.genMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.subGenAndReport = new System.Windows.Forms.ToolStripMenuItem();
            this.subGenAllAndReport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenAll = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dbTableListBox = new System.Windows.Forms.ListBox();
            this.txtGenCode = new System.Windows.Forms.TextBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.genMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(788, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "主菜单";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subOpenFile,
            this.subSetting,
            this.toolStripSeparator1,
            this.subExit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileMenu.Size = new System.Drawing.Size(71, 24);
            this.fileMenu.Text = "文件(F)";
            // 
            // subOpenFile
            // 
            this.subOpenFile.Name = "subOpenFile";
            this.subOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.subOpenFile.Size = new System.Drawing.Size(225, 26);
            this.subOpenFile.Text = "打开数据库";
            this.subOpenFile.Click += new System.EventHandler(this.subOpenFile_Click);
            // 
            // subSetting
            // 
            this.subSetting.Name = "subSetting";
            this.subSetting.Size = new System.Drawing.Size(225, 26);
            this.subSetting.Text = "设置";
            this.subSetting.Click += new System.EventHandler(this.subSetting_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // subExit
            // 
            this.subExit.Name = "subExit";
            this.subExit.Size = new System.Drawing.Size(225, 26);
            this.subExit.Text = "退出";
            this.subExit.Click += new System.EventHandler(this.subExit_Click);
            // 
            // genMenu
            // 
            this.genMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subGenAndReport,
            this.subGenAllAndReport});
            this.genMenu.Name = "genMenu";
            this.genMenu.Size = new System.Drawing.Size(53, 24);
            this.genMenu.Text = "生成";
            // 
            // subGenAndReport
            // 
            this.subGenAndReport.Name = "subGenAndReport";
            this.subGenAndReport.Size = new System.Drawing.Size(197, 26);
            this.subGenAndReport.Text = "生成并导出";
            this.subGenAndReport.Click += new System.EventHandler(this.subGenAndReport_Click);
            // 
            // subGenAllAndReport
            // 
            this.subGenAllAndReport.Name = "subGenAllAndReport";
            this.subGenAllAndReport.Size = new System.Drawing.Size(197, 26);
            this.subGenAllAndReport.Text = "全部生成并导出";
            this.subGenAllAndReport.Click += new System.EventHandler(this.subGenAllAndReport_Click);
            // 
            // btnGenAll
            // 
            this.btnGenAll.Location = new System.Drawing.Point(416, 491);
            this.btnGenAll.Name = "btnGenAll";
            this.btnGenAll.Size = new System.Drawing.Size(133, 40);
            this.btnGenAll.TabIndex = 2;
            this.btnGenAll.Text = "全部生成";
            this.btnGenAll.UseVisualStyleBackColor = true;
            this.btnGenAll.Click += new System.EventHandler(this.btnGenAll_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dbTableListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtGenCode);
            this.splitContainer1.Size = new System.Drawing.Size(788, 441);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 3;
            // 
            // dbTableListBox
            // 
            this.dbTableListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbTableListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dbTableListBox.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbTableListBox.FormattingEnabled = true;
            this.dbTableListBox.ItemHeight = 30;
            this.dbTableListBox.Location = new System.Drawing.Point(0, 0);
            this.dbTableListBox.Margin = new System.Windows.Forms.Padding(0);
            this.dbTableListBox.Name = "dbTableListBox";
            this.dbTableListBox.Size = new System.Drawing.Size(204, 390);
            this.dbTableListBox.TabIndex = 0;
            this.dbTableListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dbTableListBox_MouseDown);
            // 
            // txtGenCode
            // 
            this.txtGenCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGenCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGenCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGenCode.Location = new System.Drawing.Point(0, 0);
            this.txtGenCode.Multiline = true;
            this.txtGenCode.Name = "txtGenCode";
            this.txtGenCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGenCode.Size = new System.Drawing.Size(577, 439);
            this.txtGenCode.TabIndex = 0;
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(207, 491);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(133, 40);
            this.btnGen.TabIndex = 4;
            this.btnGen.Text = "生成";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 547);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.btnGenAll);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "数据库实体类生成器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem subOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem subExit;
        private System.Windows.Forms.Button btnGenAll;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtGenCode;
        private System.Windows.Forms.ListBox dbTableListBox;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.ToolStripMenuItem genMenu;
        private System.Windows.Forms.ToolStripMenuItem subGenAndReport;
        private System.Windows.Forms.ToolStripMenuItem subGenAllAndReport;
        private System.Windows.Forms.ToolStripMenuItem subSetting;
    }
}

