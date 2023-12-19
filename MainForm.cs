using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace DatabaseModelEntityTool
{
    public partial class MainForm : Form
    {
        [DllImport("user32")]
        private static extern int mouse_event(int mouseevent, int dx, int dy, int cButtons, int dwExtraInfo);

        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public MainForm()
        {
            InitializeComponent();
        }
        private GenCode gen = new GenCode();
        private Action<string> connectFormCloseCallBack = null;
        private Action<CallBackInfo> settingFormCloseCallBack = null;

        private void OnSettingFormCallBack(CallBackInfo info)
        {
            gen.exportPath = info.exportPath;
            gen.isNeedUsingSystem = info.isNeedUsingSystem;
            gen.isNeedCustomNameSpace = info.isNeedNameSpace;
            gen.customNameSpace = info.customNameSpace;
            this.Enabled = true;
        }
        private void OnConnectFormCloseCallBack(string sql)
        {
            this.Enabled = true;
            if (string.IsNullOrEmpty(sql))
            {
                return;
            }
            this.gen.tableNameDt= SqliteHelper.GetDataTable(sql);
            this.gen.tableStructureDic.Clear();
            string pragma_sql = "PRAGMA  table_info (@table_name)";
            foreach (DataRow dr in this.gen.tableNameDt.Rows)
            {
                string table_name = dr["name"].ToString();
                string full_sql = pragma_sql.Replace("@table_name", table_name);
                DataTable dt = SqliteHelper.GetDataTable(full_sql);
                int count = dt.Rows.Count;
                this.gen.tableStructureDic[table_name] = dt;
            }
            
            dbTableListBox.DataSource = this.gen.tableNameDt;
            dbTableListBox.ValueMember = "name";
            dbTableListBox.SelectedIndex = 0;
            dbTableListBox.Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.connectFormCloseCallBack = OnConnectFormCloseCallBack;
            this.settingFormCloseCallBack = OnSettingFormCallBack;
            LoadConfig();
        }

        private void LoadConfig()
        {
            if (!File.Exists("Config.txt"))
            {
                return;
            }
            using (StreamReader sr=new StreamReader("Config.txt"))
            {
                while (!sr.EndOfStream)
                {
                    switch (sr.ReadLine())
                    {
                        case "[GenPath]":
                            gen.exportPath = sr.ReadLine();
                            break;
                        case "[NeedUsingSystem]":
                            gen.isNeedUsingSystem = sr.ReadLine() == "0" ? false : true;
                            break;
                        case "[CustomNameSpace]":
                            gen.customNameSpace = sr.ReadLine();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void subOpenFile_Click(object sender, EventArgs e)
        {
            ConnectForm connectForm = new ConnectForm();
            this.Enabled = false;
            
            connectForm.Tag = this.connectFormCloseCallBack;
            connectForm.ShowInTaskbar=false;
            connectForm.Show();
        }

        private void dbTableListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //SetCursorPos(Control.MousePosition.X, Control.MousePosition.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);

            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (this.gen.tableNameDt == null)
            {
                MessageBox.Show("请先连接数据库", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string table_name = (dbTableListBox.SelectedItem as DataRowView).Row["name"].ToString();
            txtGenCode.Text = this.gen.MakeCode(table_name);
        }

        private void btnGenAll_Click(object sender, EventArgs e)
        {
            if (this.gen.tableNameDt == null)
            {
                MessageBox.Show("请先连接数据库", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            txtGenCode.Text = this.gen.MakeAllCode();
        }

        

        private void subExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void subSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            //this.Enabled = false;
            Tuple<GenCode, Action<CallBackInfo>> pack = new Tuple<GenCode, Action<CallBackInfo>>(gen, settingFormCloseCallBack);
            settingForm.Tag = pack;
            settingForm.ShowInTaskbar = false;
            settingForm.ShowDialog();
            //settingForm.Show();
        }

        private void subGenAndReport_Click(object sender, EventArgs e)
        {
            if (this.gen.tableNameDt == null)
            {
                MessageBox.Show("请先连接数据库", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(this.gen.exportPath))
            {
                MessageBox.Show("导出路径不能为空", "导出提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string table_name = (dbTableListBox.SelectedItem as DataRowView).Row["name"].ToString();
            bool state= this.gen.MakeAndExport(table_name);
            if (state)
            {
                MessageBox.Show("导出成功");
            }
        }

        private void subGenAllAndReport_Click(object sender, EventArgs e)
        {
            if (this.gen.tableNameDt == null)
            {
                MessageBox.Show("请先连接数据库", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(this.gen.exportPath))
            {
                MessageBox.Show("导出路径不能为空", "导出提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool state = this.gen.MakeAndExportAll();
            if (state)
            {
                MessageBox.Show("全部导出成功");
            }
        }
    }
}
