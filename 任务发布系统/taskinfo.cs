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
        private string ConnectionString = "server=(local);database=exchange; Initial Catalog =exchange ;Persist Security Info = TrueTrusted_Connection=SSPI";//连接数据库
        private SqlConnection conn = null;
        private SqlDataAdapter DataAdapter = null;
        private DataSet dataset = null;
        String strSQL = "";
        private SqlCommand cmd = null;
        public taskinfo()
        {
            InitializeComponent();
        }

        private void showdata()
        {
            if (conn == null) conn.Open();
            try
            {
                if (conn == null) conn.Open();
                dataset = new DataSet();
                //创建数据库提供者
                //SqlDataAdapter 
                strSQL = "select * from Planlist";
                DataAdapter = new SqlDataAdapter(strSQL, conn);
                //填充数据集
                DataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset;

                dataGridView1.DataMember = dataset.Tables[0].ToString();

                strSQL = "select * from Questview where qno =1";
                DataAdapter = new SqlDataAdapter(strSQL, conn);
                //填充数据集
                DataAdapter.Fill(dataset);

                //先清除所有绑定，再重新绑定
                textBox1.DataBindings.Clear();
                textBox2.DataBindings.Clear();
                textBox3.DataBindings.Clear();
                textBox4.DataBindings.Clear();
                textBox5.DataBindings.Clear();
               // textBox6.DataBindings.Clear();
                textBox7.DataBindings.Clear();
                textBox8.DataBindings.Clear();
                textBox9.DataBindings.Clear();
                textBox10.DataBindings.Clear();
                textBox11.DataBindings.Clear();
                textBox12.DataBindings.Clear();

                textBox1.DataBindings.Add("Text", dataset, "table.pid");
                textBox2.DataBindings.Add("Text", dataset, "table.ctime");
                textBox3.DataBindings.Add("Text", dataset, "table.reward");
                textBox4.DataBindings.Add("Text", dataset, "table.qtag");
                textBox5.DataBindings.Add("Text", dataset, "table.ptext");
                
                textBox7.DataBindings.Add("Text", dataset, "table.qid");
                textBox8.DataBindings.Add("Text", dataset, "table.ptime");
                textBox9.DataBindings.Add("Text", dataset, "table.true end time");
                textBox10.DataBindings.Add("Text", dataset, "table.qemp");
                textBox11.DataBindings.Add("Text", dataset, "table.uid");
                textBox12.DataBindings.Add("Text", dataset, "table.state");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

         public  taskinfo(DataGridViewRow  str)
         {
            InitializeComponent();
             //Cells[0]为要选的第几列
            //string sname = str.Cells[0].Value.ToString();
            //ssname = sname;
            //textBox1.Text= sname;
            //comboBox1.SelectedItem = str.Cells[1].Value.ToString();;
            //textBox2.Text=str.Cells[2].Value.ToString();;
            //dateTimePicker1.Value = (DateTime)str.Cells[3].Value;
            //textBox3.Text=str.Cells[4].Value.ToString();;
            //textBox4.Text=str.Cells[5].Value.ToString();;
            //richTextBox1.Text = str.Cells[6].Value.ToString(); 
        }


        private void taskinfo_Load(object sender, EventArgs e)
        {
            
            DataSet dataset = new DataSet();
            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                showdata();
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
    }
}
