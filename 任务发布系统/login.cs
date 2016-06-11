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
    public partial class login : Form
    {
        private string ConnecttionString = "Data Source =(local);"
    + "Initial Catalog = exchange;Persist Security Info = true;"
    + "Trusted_Connection=SSPI;";
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public class tag
        {
            public static string uTag;

        }

        public class name
        {
            public static string uname;
        }

        public class id
        {
            public static string uid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("用户名不能为空");
                }
                else
                {
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("密码不能为空!");
                    }
                    else
                    {
                        string admin_id = textBox1.Text;//获取账号
                        string admin_psw = textBox2.Text;//获取密码
                        SqlConnection connection = new SqlConnection(ConnecttionString);//创建连接
                        connection.Open();//打开连接
                        string sql = string.Format("select count(*) from login where id ='{0}' and password='{1}'", admin_id, admin_psw);
                        //查询是否有该条记录，根据账户密码
                        string usertag = string.Format("select tage from login where id ='{0}'", admin_id);
                        string username = string.Format("select name from costomer where id ='{0}'", admin_id);
                        SqlCommand command = new SqlCommand(sql, connection);
                        SqlCommand command1 = new SqlCommand(usertag, connection);
                        SqlCommand command2 = new SqlCommand(username, connection);
                        //sqlcommand表示要向向数据库执行sql语句或存储过程
                        int i = Convert.ToInt32(command.ExecuteScalar());
                        string k = Convert.ToString(command1.ExecuteScalar());
                        string j = Convert.ToString(command2.ExecuteScalar());
                        //执行后返回记录行数
                        if (i > 0)//如果大于1，说明记录存在，登录成功
                        {
                            MessageBox.Show("登录成功！");
                            tag.uTag = k;
                            name.uname = j;
                            id.uid = admin_id;
                            login f1 = new login();
                            f1.Close();
                            tasklist f2 = new tasklist();
                            f2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("用户名或者密码错误！");
                        }
                        connection.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.Close();
            zhuce f3 = new zhuce();
            f3.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.button1_Click(sender, e);//触发button事件  
            }  
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.button1_Click(sender, e);//触发button事件  
            }  
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
