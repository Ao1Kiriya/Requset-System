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
using System.Collections;

namespace 任务发布系统
{
    public partial class userinfo : Form
    {
        private string ConnectionString = "Data Source =(local);"
        + "Initial Catalog = exchange;Persist Security Info = true;"
        + "Trusted_Connection=SSPI;";
        private SqlConnection conn = null;     
        SqlCommand cmd = null;
        String strSQL = "";
        String strSQL1 = "";
        String strSQL2 = "";
        String strSQL3 = "";
        String strSQL4 = "";
        String strSQL5 = "";
        private tasklist parent;
       // private DataGridViewRow s;
        string s;
        private DataSet dataset = null;
        private SqlDataAdapter DataAdapter = null;
        public userinfo(string s,tasklist f)
        {
            
            this.s = s;
            parent = f;
            InitializeComponent();

            //textBox1.Text = s.Cells[4].Value.ToString();
            textBox1.Text = s;
            textBox2.ReadOnly = true;
           // strSQL = "select name from costomer where costomer.id = " + textBox1.Text;
            conn = new SqlConnection("Data Source =(local);"
        + "Initial Catalog = exchange;Persist Security Info = true;" + "Trusted_Connection=SSPI;");
            conn.Open();
            if (conn == null) conn.Open();
            try
            {
                if (conn == null) conn.Open();
                strSQL = "select name from costomer where costomer.id = " + textBox1.Text;
                strSQL1 = "select grade from costomer where costomer.id = " + textBox1.Text;
                strSQL2 = "select appraise from costomer where costomer.id = " + textBox1.Text;
                strSQL3 = "select pmoney from costomer where costomer.id = " + textBox1.Text;              
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    this.textBox2.Text = obj.ToString();                   
                }

                cmd = new SqlCommand(strSQL1, conn);
                obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    this.textBox3.Text = obj.ToString();
                }

                cmd = new SqlCommand(strSQL2, conn);
                obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    this.textBox4.Text = obj.ToString();
                }

                cmd = new SqlCommand(strSQL3, conn);
                obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    this.textBox5.Text = obj.ToString();
                }

                DataSet dataset = new DataSet();               
                try
                {
                    strSQL = "select distinct pname from Pmember where uid = " + textBox1.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter(strSQL, conn);
                    adapter.Fill(dataset, "Pmember");
                    dataGridView1.DataSource = dataset;
                    dataGridView1.DataMember = "Pmember";
                    dataGridView1.Columns[0].HeaderText = "团队名";
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

                strSQL4 = "select Ptext,Uid,Qtag,Ptime,Reward from Questview where state = '0' and Pid = " + textBox1.Text;
                dataset = new DataSet();
                conn = new SqlConnection(ConnectionString);
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(strSQL4, conn);
                    adapter.Fill(dataset, "Questview");
                    dataGridView2.DataSource = dataset;
                    dataGridView2.DataMember = "Questview";
                    dataGridView2.Columns[0].HeaderText = "任务内容";
                    dataGridView2.Columns[1].HeaderText = "接收人id";
                    dataGridView2.Columns[2].HeaderText = "等级";
                    dataGridView2.Columns[3].HeaderText = "发布时间";
                    dataGridView2.Columns[4].HeaderText = "报酬";
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

                strSQL5 = "select qno,Ptext,Uid,Qtag,Ptime,Reward ,pid from Questview where state = '1' and Pid = " + textBox1.Text;
                dataset = new DataSet();
                conn = new SqlConnection(ConnectionString);
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(strSQL5, conn);
                    adapter.Fill(dataset, "Questview");
                    dataGridView3.DataSource = dataset;
                    dataGridView3.DataMember = "Questview";
                    dataGridView3.Columns[0].HeaderText = "任务序号";
                    dataGridView3.Columns[1].HeaderText = "任务内容";
                    dataGridView3.Columns[2].HeaderText = "接收人id";
                    dataGridView3.Columns[3].HeaderText = "等级";
                    dataGridView3.Columns[4].HeaderText = "发布时间";
                    dataGridView3.Columns[5].HeaderText = "报酬";
                    dataGridView3.Columns[6].HeaderText = "用户id";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chongzhi f6 = new chongzhi();
            f6.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source =(local);"
        + "Initial Catalog = exchange;Persist Security Info = true;" + "Trusted_Connection=SSPI;");
            conn.Open();
            string strSQL = null;           
            try
            {
                MessageBox.Show(strSQL);
                strSQL += "'grade='" + textBox3.Text;              
                strSQL += "',appraise='" + textBox4.Text;
                strSQL += "',name='" + textBox2.Text;
                strSQL += "',pmoney='" + textBox5.Text;                              
                MessageBox.Show(strSQL);

                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = strSQL;
                conn.Open();

                int n = cmd.ExecuteNonQuery();
                if (n > 0) MessageBox.Show("更新成功!");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               if (conn != null) conn.Close();
                cmd.Dispose();
                this.parent.Show();
                this.Close();
                

            }
            parent.ShowDialog();
            parent.dataGridView1.CurrentCell = parent.dataGridView1.Rows[parent.index].Cells[0];
            parent.dataGridView1.Rows[parent.index].Selected = true;         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //if(parent.flag5!=0)
                //{
                //    MessageBox.Show("权限不够");
                //    return;
                //}
                string strSQL = "delete from costomer where id= '" +textBox1.Text + "'";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = strSQL;
                conn.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) MessageBox.Show("删除成功!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
                cmd.Dispose();
                parent.Show();
                parent.ShowDialog();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {       
            this.Close();
            tasklist f2 = new tasklist();
            f2.Show();
            f2.ShowDialog();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tasklist f2 = new tasklist();
            f2.Show();
            this.Close();           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source =(local);"
        + "Initial Catalog = exchange;Persist Security Info = true;" + "Trusted_Connection=SSPI;");
            conn.Open();

            int a = dataGridView3.CurrentRow.Index;         
            string p = dataGridView3.Rows[a].Cells["qno"].Value.ToString();
            double money = double.Parse(dataGridView3.Rows[a].Cells["reward"].Value.ToString());
            string id = dataGridView3.Rows[a].Cells["Uid"].Value.ToString();
            string pid = dataGridView3.Rows[a].Cells["pid"].Value.ToString();
            Double addmoney = 0;
            double demoney = 0;
            double i = 0;

            strSQL = "select pmoney from costomer where  id = " + id;                     
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != null)
            {                           
                i = double.Parse(obj.ToString());
                addmoney =  money + i;                 
            }
            strSQL = "select pmoney from costomer where  id = " + pid ;
            cmd = new SqlCommand(strSQL, conn);
            object obj1 = cmd.ExecuteScalar();
            if (obj1 != null)
            {
                double s = double.Parse(obj.ToString());
                demoney = s - i ;
            }

            strSQL = "UPDATE costomer SET pmoney = " + addmoney + "WHERE id = " + id + "UPDATE Questview SET state = 0 WHERE  qno = '" + p + "'" + "UPDATE costomer SET pmoney = " + demoney + "WHERE id  = " + pid;
            //strSQL = "UPDATE Questview SET state = 0 WHERE  qno = '" + p + "'";
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = strSQL;         ;
            int n = cmd.ExecuteNonQuery();
            if (n > 0) MessageBox.Show("任务完成!");
            
        }
    }
}
