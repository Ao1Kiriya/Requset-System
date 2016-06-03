using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 任务发布系统
{
    public partial class Form4 : Form
    {

        private string ConnecttionString = "Data Source = KALISTAR;"
+ "Initial Catalog = quest;Persist Security Info = true;"
+ "Trusted_Connection=SSPI;";
        private SqlConnection conn = null;
        public Form4()
        {
            InitializeComponent();
        }

        public string tag;
        private void Form4_Load(object sender, EventArgs e)
        {
            label4.Text = Form1.name.uname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tag = "1";
            }
            if (radioButton2.Checked == true)
            {
                tag = "2";
            }
            if (radioButton3.Checked == true)
            {
                tag = "3";
            }

            string ptime = DateTime.Now.ToString();
            conn = new SqlConnection(ConnecttionString);
            string strSql = null;

            try
            {
                strSql = "execute name " + Form1.id.uid + ",";
                strSql += richTextBox1.Text + ",'" + ptime + "'," + tag + "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex.Message);
                return;
            }
            SqlCommand command = null;
            try
            {
                conn.Open();
                command = new SqlCommand(strSql, conn);
                int n = command.ExecuteNonQuery();
                if (n > 0) MessageBox.Show("发布成功！", "提示：");
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常:" + ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
                command.Dispose();
                this.Close();
            }
        }
    }
}
