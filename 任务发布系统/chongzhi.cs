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
    public partial class chongzhi : Form
    {
        public chongzhi()
        {
            InitializeComponent();
        }
       
        private string ConnecttionString = "Data Source =(local);"
+ "Initial Catalog = exchange;Persist Security Info = true;"
+ "Trusted_Connection=SSPI;";
        private SqlConnection conn = null;
        private string money = null;
        private SqlCommand command = null;
        private int money1 = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            conn = new SqlConnection(ConnecttionString);
            conn.Open();
            string strSql = string.Format("select money from [User] where id = '{0}'", id);
            command = new SqlCommand(strSql, conn); 
            DialogResult RESULT = MessageBox.Show("确认?", "信息提示", MessageBoxButtons.YesNo);
            if (RESULT.ToString().Equals("Yes"))
            {
                
                money1 = Convert.ToInt32(command.ExecuteScalar());
                money1 += Convert.ToInt32(textBox2.Text);
                money = Convert.ToString(money1);
                
                string strSql1 = "update [User] set money = '" +money+ "' where id = '" +id+ "'";
                SqlCommand command1 = null;
                try
                {
                    command1 = new SqlCommand(strSql1, conn);
                    int n = command1.ExecuteNonQuery();
                    if (n > 0) MessageBox.Show("成功更新!", "提示：");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发生异常:" + ex.Message);
                }
                finally
                {
                    command1.Dispose();
                    this.Close();
                }

            }
            conn.Close();
            command.Dispose();
            this.Close();
        }
    }
}
