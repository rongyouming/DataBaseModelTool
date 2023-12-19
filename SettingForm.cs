using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DatabaseModelEntityTool
{
    public partial class SettingForm : Form
    {
        private Action<CallBackInfo> settingFormCloseCallBack = null;
        //private string exportPath="";
        public SettingForm()
        {
            DateTime dd;
            InitializeComponent();
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CallBackInfo info = new CallBackInfo(txtPath.Text, ckbUsingSystem.Checked,
                ckbNameSpace.Checked, txtNameSpace.Text);
            this.settingFormCloseCallBack(info);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            Tuple<GenCode, Action<CallBackInfo>> pack = this.Tag as Tuple<GenCode, Action<CallBackInfo>>;
            this.settingFormCloseCallBack = pack.Item2;
            txtPath.Text = pack.Item1.exportPath;
            ckbUsingSystem.Checked = pack.Item1.isNeedUsingSystem;
            if (!string.IsNullOrEmpty(pack.Item1.customNameSpace))
            {
                ckbNameSpace.Checked = true;
                txtNameSpace.Text = pack.Item1.customNameSpace;
            }
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                //this.exportPath = folderBrowserDialog.SelectedPath;
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("config.txt"))
            {
                sw.WriteLine("[GenPath]");
                sw.WriteLine(txtPath.Text);
                sw.WriteLine("[NeedUsingSystem]");
                sw.WriteLine(ckbUsingSystem.Checked ? 1 : 0);
                sw.WriteLine("[CustomNameSpace]");
                sw.WriteLine(txtNameSpace.Text);
            }
            MessageBox.Show("设置保存成功");
            this.Close();
        }

        private void ckbNameSpace_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNameSpace.Checked)
            {
                txtNameSpace.Enabled = true;
            }
            else
            {
                txtNameSpace.Enabled = false;
                txtNameSpace.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
    }
}
