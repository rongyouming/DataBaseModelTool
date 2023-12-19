
namespace DatabaseModelEntityTool
{
    partial class SettingForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.ckbUsingSystem = new System.Windows.Forms.CheckBox();
            this.ckbNameSpace = new System.Windows.Forms.CheckBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(320, 22);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(45, 30);
            this.btnSelectPath.TabIndex = 5;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(102, 25);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(212, 25);
            this.txtPath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "生成路径:";
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(162, 170);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(105, 43);
            this.btnSaveSetting.TabIndex = 6;
            this.btnSaveSetting.Text = "保存设置";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // ckbUsingSystem
            // 
            this.ckbUsingSystem.AutoSize = true;
            this.ckbUsingSystem.Location = new System.Drawing.Point(24, 122);
            this.ckbUsingSystem.Name = "ckbUsingSystem";
            this.ckbUsingSystem.Size = new System.Drawing.Size(149, 19);
            this.ckbUsingSystem.TabIndex = 7;
            this.ckbUsingSystem.Text = "引用系统命名空间";
            this.ckbUsingSystem.UseVisualStyleBackColor = true;
            // 
            // ckbNameSpace
            // 
            this.ckbNameSpace.AutoSize = true;
            this.ckbNameSpace.Location = new System.Drawing.Point(24, 76);
            this.ckbNameSpace.Name = "ckbNameSpace";
            this.ckbNameSpace.Size = new System.Drawing.Size(139, 19);
            this.ckbNameSpace.TabIndex = 10;
            this.ckbNameSpace.Text = "包含namespace:";
            this.ckbNameSpace.UseVisualStyleBackColor = true;
            this.ckbNameSpace.CheckedChanged += new System.EventHandler(this.ckbNameSpace_CheckedChanged);
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Enabled = false;
            this.txtNameSpace.Location = new System.Drawing.Point(191, 73);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(212, 25);
            this.txtNameSpace.TabIndex = 11;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 225);
            this.Controls.Add(this.txtNameSpace);
            this.Controls.Add(this.ckbNameSpace);
            this.Controls.Add(this.ckbUsingSystem);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.Text = "设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.CheckBox ckbUsingSystem;
        private System.Windows.Forms.CheckBox ckbNameSpace;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}