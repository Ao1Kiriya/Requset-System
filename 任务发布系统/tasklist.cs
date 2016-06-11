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
    public partial class tasklist : Form
    {
        private string ConnecttionString = "Data Source =(local);"
   + "Initial Catalog = exchange;Persist Security Info = true;"
   + "Trusted_Connection=SSPI;";
    
        
        
        public tasklist()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = login.name.uname;
            if (login.tag.uTag == "1")
            {
                label3.Text = "同学";
            }
            else label3.Text = "企业";

            DataSet dataset = new DataSet();
            SqlConnection conn = new SqlConnection(ConnecttionString);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select qno,pid,ptext,ptime,ctime,qtag,qemp,uid,reward from Questview", conn);
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
            pquest f4 = new pquest();
            f4.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            userinfo f5 = new userinfo();
            f5.ShowDialog();
            tasklist f2 = new tasklist();
            f2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
