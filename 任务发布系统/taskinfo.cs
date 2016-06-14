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
             //Cells[0]为要选的第几列
            string qno = str.Cells[0].Value.ToString();//任务编号
            textBox7.Text = qno;
            textBox1.Text = str.Cells[1].Value.ToString(); 
            textBox5.Text=str.Cells[2].Value.ToString();
            textBox11.Text = str.Cells[3].Value.ToString(); 
            textBox4.Text=str.Cells[4].Value.ToString();
            textBox10.Text=str.Cells[5].Value.ToString();
            textBox8.Text = str.Cells[6].Value.ToString();
            textBox2.Text = str.Cells[7].Value.ToString();
            textBox9.Text = str.Cells[8].Value.ToString();
            textBox12.Text = str.Cells[9].Value.ToString();
            textBox3.Text = str.Cells[10].Value.ToString(); 
            showdata(qno);
         }


        private void taskinfo_Load(object sender, EventArgs e)
        {
            
            DataSet dataset = new DataSet();
            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            { 
                SqlDataAdapter adapter = new SqlDataAdapter("select qNo,issuer,plantext,checked,selected from planlist", conn);
                adapter.Fill(dataset, "planlist");
                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "planlist";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                SqlConnection conn = new SqlConnection(ConnectionString);
                if (conn == null) conn.Open();
                string UserID = login.id.uid;
                DataAdapter = new SqlDataAdapter();
                dataset = new DataSet();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select pname from pmember where uid ="+"UserID";
                DataAdapter.SelectCommand = cmd;
                DataAdapter.Fill(dataset, "t1");
                comboBox1.Items.Clear();
                for (int i = 0; i < dataset.Tables["t1"].Columns.Count; i++)
                {
                    comboBox1.Items.Add(dataset.Tables["t1"].Columns[i].ToString());
                    
                }    
                dataset.Clear();
            string teamName = comboBox1.Text;
            string strSQL = "insert into planlist values(";
            strSQL += "'" + textBox7.Text;
            strSQL += "','" + UserID;//当前账号ID
            strSQL += "','" + textBox6.Text;//计划
            strSQL += "','";//有么有被查看
            strSQL += "','" ;//是否被选中
            strSQL += "','"+teamName;//队名
            strSQL += "')";
            MessageBox.Show(strSQL);
            
            SqlCommand command = null;
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
                    Close();
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
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
