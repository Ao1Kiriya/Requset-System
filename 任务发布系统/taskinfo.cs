using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 任务发布系统
{
    public partial class taskinfo : Form
    {
        private string ConnectionString = "server=(local);database=exchange; Initial Catalog =exchange ;Persist Security Info = True ;Trusted_Connection=SSPI";//连接数据库
        private SqlConnection conn = null;
        private SqlDataAdapter DataAdapter = null;
        private DataSet dataset = null;
        String strSQL = "";
        private SqlCommand cmd = null;
        public taskinfo()
        {
            InitializeComponent();
        }

        private void showdata(string qno)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn == null) conn.Open();
            try
            {
                if (conn == null) conn.Open();
                dataset = new DataSet();
                string sql = "select * from planlist where qNo=" + qno;
                //创建数据库提供者
                SqlDataAdapter adapter = new SqlDataAdapter(sql , conn);
                adapter.Fill(dataset, "planlist");
                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "planlist";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

         public  taskinfo(DataGridViewRow  str)//datagirdview 显示数据
         {
            InitializeComponent();
            taskinfo_Load();
            //显示数据
            string qno = str.Cells[0].Value.ToString();//任务编号
            textBox7.Text = qno;
            textBox1.Text = str.Cells[1].Value.ToString(); 
            textBox5.Text=str.Cells[2].Value.ToString();
            textBox11.Text = str.Cells[3].Value.ToString(); 
            textBox4.Text=str.Cells[4].Value.ToString();//任务条件
             //1：拥有金额为0以上
            //2：拥有金额为30以上
            //3：拥有金额为50以上
            //4：拥有金额为100以上
            if (textBox4.Text == "4")
            {
                textBox4.Text = "拥有金额为100以上";
            }
            if (textBox4.Text == "1")
            {
                textBox4.Text = "拥有金额为0以上";
            }
            if (textBox4.Text == "2")
            {
                textBox4.Text = "拥有金额为30以上";
            }
            if (textBox4.Text == "3")
            {
                textBox4.Text = "拥有金额为50以上";
            }
            textBox10.Text=str.Cells[5].Value.ToString();
            textBox8.Text = str.Cells[6].Value.ToString();
            textBox2.Text = str.Cells[7].Value.ToString();
            textBox9.Text = str.Cells[8].Value.ToString();
            textBox12.Text = str.Cells[9].Value.ToString();
            textBox3.Text = str.Cells[10].Value.ToString();
             //任务状态：
            //0：已发布，未接收
            //1：任务正在进行中
            //2：任务已完成
            //3：任务状态异常
            if (textBox12.Text == "0")
            {
                textBox12.Text = "已发布，未接收";
            }
            if (textBox12.Text == "1")
            {
                textBox12.Text = "任务正在进行中";
            }
            if (textBox12.Text == "2")
            {
                textBox12.Text = "任务已完成";
            }
            if (textBox12.Text == "3")
            {
                textBox12.Text = "任务状态异常";
            }
            showdata(qno);
         }


        private void taskinfo_Load()//预载入
        {
            
            DataSet dataset = new DataSet();
            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            { 
                DataAdapter = new SqlDataAdapter();
               

                string UserID = login.id.uid;
                dataset = new DataSet();
                string sql = "select pname from pmember where uid =" + UserID;
                //创建数据库提供者
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dataset, "planlist");
                comboBox1.Text = null;
                for (int i = 0; i < dataset.Tables["planlist"].Rows.Count; i++)
                {
                    DataRow dr = dataset.Tables["planlist"].Rows[i];
                    string s = "";
                    for (int j = 0; j < dataset.Tables["planlist"].Columns.Count; j++)
                    {
                        s += dr[j].ToString();
                    }
                    comboBox1.Items.Add(s);
                }

                dataset.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                dataset.Dispose();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//数据库单元格点击事件
        {
            int index2 = dataGridView1.CurrentRow.Index;//获取当前记录的索引号

            if (index2 != -1)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConnectionString);
                    DataSet dataset = new DataSet();

                    String info = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    MessageBox.Show(info);//显示当前选中的单元格的内容
                    String s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//选中单元格的首列


                    int index = dataGridView1.CurrentRow.Index;//获取当前记录的索引号
                    //将索引为index的行设置为当前行
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[index].Cells[0];
                    dataGridView1.Rows[index].Selected = true;
                }
                catch
                {
                    MessageBox.Show("选取单元格无效");
                }
            }

        }

       

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//个人竞标
        {
                
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn == null) conn.Open();
            string UserID = login.id.uid;
            string strSQL = "insert into planlist(qNo,issuer,plantext,checked,selected,teamname) values(";
            strSQL += "'" + textBox7.Text;
            strSQL += "','" + UserID;//当前账号ID
            strSQL += "','" + textBox6.Text;//计划
            strSQL += "','";//有么有被查看
            strSQL += "','" ;//是否被选中
           
            strSQL += "',null)";
            //MessageBox.Show(strSQL);
            
            int result;
            string str1, str2;
            str1 = textBox4.Text;

            string Usermoney = string.Format("select pmoney from costomer where id  ='{0}'", UserID);

            SqlCommand command1 = null;
            command1 = new SqlCommand();
            command1.Connection = conn;
            command1.CommandText = Usermoney;
            conn.Open();
            SqlDataReader sdr = command1.ExecuteReader();//cmd 是sqlcommand
            sdr.Read();
            string tm = sdr["pmoney"].ToString();
            conn.Close();

            str2 = tm;
            decimal s2 =0;
            decimal s1 =1;
            if (textBox4.Text == "拥有金额为100以上")
            {
                str1 = "100";
            }
            if (textBox4.Text == "拥有金额为0以上")
            {
                str1 = "0";
            }
            if (textBox4.Text == "拥有金额为30以上")
            {
                str1 = "30";
            }
            if (textBox4.Text == "拥有金额为50以上")
            {
                str1 = "50";
            }
            result=string.Compare(str2,str1);
            try
            {
                s1=decimal.Parse(str1);
                s2 = decimal.Parse(str2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            SqlCommand command = null;
            if(s2>=s1){
                try
                            {
                                command = new SqlCommand();
                                command.Connection = conn;
                                command.CommandText = strSQL;
                                conn.Open();
                                int n = command.ExecuteNonQuery();
                                if (n > 0)
                                {
                                    MessageBox.Show("成功插入数据");
                                    taskinfo_Load();
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                if (conn != null) conn.Close();
                                command.Dispose();
                    taskinfo_Load();
                            } 
            }
            else
                MessageBox.Show("您没有足够的资本来接受这个任务");


          
                
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//团队竞标
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn == null) conn.Open();
            string UserID = login.id.uid;

            string teamName = comboBox1.Text;
            string strSQL = "insert into planlist(qNo,issuer,plantext,checked,selected,teamname) values(";
            strSQL += "'" + textBox7.Text;
            strSQL += "','" + UserID;//当前账号ID
            strSQL += "','" + textBox6.Text;//计划
            strSQL += "','";//有么有被查看
            strSQL += "','";//是否被选中
            strSQL += "','"+teamName;
            strSQL+="')";
            //MessageBox.Show(strSQL);

            int result;
            string str1, str2;
            str1 = textBox4.Text;
          
            string teammoney = string.Format("select pmoney from party where pname ='{0}'", teamName);
            
            SqlCommand command = null;
            command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = teammoney;
            conn.Open();
            SqlDataReader sdr = command.ExecuteReader();//cmd 是sqlcommand
            sdr.Read();
            string tm = sdr["pmoney"].ToString();

            str2 =tm;//
            decimal s2 = 0;
            decimal s1 = 1;
            if (textBox4.Text == "拥有金额为100以上")
            {
                str1 = "100";
            }
            if (textBox4.Text == "拥有金额为0以上")
            {
                str1 = "0";
            }
            if (textBox4.Text == "拥有金额为30以上")
            {
                str1 = "30";
            }
            if (textBox4.Text == "拥有金额为50以上")
            {
                str1 = "50";
            }
            result = string.Compare(str2, str1);
            try
            {
                s1 = decimal.Parse(str1);
                s2 = decimal.Parse(str2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            
            if (s2 >= s1)
            {
                try
                {
                    command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = strSQL;
                    conn.Open();
                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("成功插入数据");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn != null) conn.Close();
                    command.Dispose();
                    taskinfo_Load();
                }
            }
            else
                MessageBox.Show("您的团队没有足够的资本来接受这个任务");
        }





        private void button3_Click(object sender, EventArgs e)//选择最终方案
        {
            conn = new SqlConnection(ConnectionString);
            string strSql = null;
            string strSQL1 = null;
            int flag = 0;
            int index = dataGridView1.CurrentRow.Index;//获取当前记录的索引号
            //将索引为index的行设置为当前行
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[index].Cells[0];
            dataGridView1.Rows[index].Selected = true;
            try
            {
                strSql = "update planlist set selected =1,checked = 1 where qNo= " +  textBox7.Text;
                strSql += "and issuer = " + this.dataGridView1.Rows[index].Cells[1].Value.ToString();
                strSQL1 = "update questview set state = 1 ";
                strSQL1+=", uid= "+ this.dataGridView1.Rows[index].Cells[1].Value.ToString();
                bool isEmpty = (this.dataGridView1.Rows[index].Cells[5].Value.ToString().Length == 0);
                if(isEmpty){
                    ;
                }
                else
                    strSQL1 += ",qemp= '" + this.dataGridView1.Rows[index].Cells[5].Value.ToString()+"'";
                
                strSQL1 += " where qno = " + textBox7.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            SqlCommand command = null;
            


            try
            {
                if (login.id.uid == textBox1.Text)
                {
                    conn.Open();
                    command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = strSql;
                    
                    int n = command.ExecuteNonQuery();
                    if (n > 0) { 
                        MessageBox.Show("选择成功");
                        flag = 1;//如果先择成功falg=1
                    }

                    
                }
                else
                    MessageBox.Show("对不起，您没有选择方案的权限");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常:" + ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            if (flag == 1)//如果选择成功，则修改questview中 接收人和任务状态
            {
                try
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = conn;
                    command1.CommandText = strSQL1;
                    conn.Open();
                    int m = command1.ExecuteNonQuery();
                    if (m > 0) MessageBox.Show("成功修改questview中 接收人和任务状态");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
