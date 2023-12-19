using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseModelEntityTool
{
    public partial class ConnectForm : Form
    {
        string dbPath;

        private Action<string> connectFormCloseCallBack = null;

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            this.connectFormCloseCallBack = this.Tag as Action<string>;
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            openDBFileDialog.Multiselect = false;
            openDBFileDialog.Title = "请选择数据库文件";
            openDBFileDialog.Filter = "sqlite数据库文件|*.db|sqlite数据库文件|*.db3|sqlite3数据库文件|*.sqlite3"; //设置要选择的文件的类型
            this.dbPath = null;
            openDBFileDialog.FileName = string.Empty;
            if (openDBFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.dbPath = openDBFileDialog.FileName;//返回文件的完整路径
                txtPath.Text = this.dbPath;
            }
        }

        public bool IsFileNameValid(string path)
        {
            if (string.IsNullOrEmpty(dbPath))
            {
                MessageBox.Show("数据库文件名不能为空", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!File.Exists(txtPath.Text))
            {
                MessageBox.Show("文件不存在", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            if (!IsFileNameValid(dbPath))
                return;
            SqliteHelper.SetDBPath(dbPath);
            bool isSuccess = SqliteHelper.TestConnection();
            if (!isSuccess)
            {
                MessageBox.Show("连接数据库失败", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("测试连接成功", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConnectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.connectFormCloseCallBack(null);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!IsFileNameValid(dbPath))
                return;
            SqliteHelper.SetDBPath(dbPath);
            string sql = "select name from sqlite_master where type='table' and name<>'sqlite_sequence'";
            bool isSuccess = SqliteHelper.TestConnection();
            if (!isSuccess)
            {
                MessageBox.Show("连接数据库失败", "连接提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.connectFormCloseCallBack(sql);
            this.Close();
        }
    }
}
