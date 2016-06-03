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
    public partial class Form3 : Form
    {
        private string ConnecttionString = "Data Source = KALISTAR;"
+ "Initial Catalog = quest;Persist Security Info = true;"
+ "Trusted_Connection=SSPI;";
        private SqlConnection conn = null;
        private string level;

        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConnecttionString);
            string strSql = null;
            string strSql1 = null;

            if (radioButton1.Checked == true)
            {
                level = "1";
            }
            if (radioButton2.Checked == true)
            {
                level = "2";
            }


                        if (textBox1.Text != null)
            {
                if (textBox2.Text == textBox3.Text)
                {

                    try
                    {
                        strSql = "INSERT INTO Login VALUES(";
                        strSql += "'" + textBox1.Text;
                        strSql += "','" + textBox2.Text;
                        strSql += "','" + level + "')";

                        strSql1 = "INSERT INTO [User]  VALUES(";
                        strSql1 += "'" + textBox1.Text;
                        strSql1 += "','" + textBox4.Text;
                        strSql1 += "','0','0','0',' ','0')";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("异常错误" + ex.Message);
                        return;
                    }
                    SqlCommand command = null;
                    SqlCommand command1 = null;
                    try
                    {  
                        conn.Open();
                        command = new SqlCommand(strSql,conn);
                        command1 = new SqlCommand(strSql1, conn);

                        int n = command.ExecuteNonQuery();
                        int k = command1.ExecuteNonQuery();
                        if (k > 0) MessageBox.Show("创建成功！", "提示：");
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
                else
                {
                    MessageBox.Show("两次密码输入不一致！", "提示");
                }           

            }
            else
                {
                    MessageBox.Show("用户名不能为空!","提示");
                }
        }

        
    }
}
