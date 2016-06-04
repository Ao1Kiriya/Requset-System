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
    public partial class Form2 : Form
    {
        private string ConnecttionString = "Data Source =(local);"
   + "Initial Catalog = quest;Persist Security Info = true;"
   + "Trusted_Connection=SSPI;";
    
        
        
        public Form2()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.name.uname;
            if (Form1.tag.uTag == "1")
            {
                label3.Text = "同学";
            }
            else label3.Text = "企业";

            DataSet dataset = new DataSet();
            SqlConnection conn = new SqlConnection(ConnecttionString);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select qno,pid,ptext,ptime,deadline,qtag,qEmp,uid,type from pquest", conn);
                adapter.Fill(dataset, "quest");
                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "quest";
            }
            catch(Exception ex)
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Form4 f4 = new Form4();
            //f4.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
            Form2 f2 = new Form2();
            f2.Hide();
        }
    }
}
