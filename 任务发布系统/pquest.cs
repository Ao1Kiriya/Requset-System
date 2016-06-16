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
    public partial class pquest : Form
    {

        private string ConnecttionString = "Data Source = (local);"
+ "Initial Catalog = exchange;Persist Security Info = true;"
+ "Trusted_Connection=SSPI;";
        private Label label4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RichTextBox richTextBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label5;
        private RadioButton radioButton4;
        private Label label7;
        private TextBox textBox2;
        private Panel panel1;
        private Panel panel2;
        private RadioButton radioButton6;
        private DateTimePicker dateTimePicker1;
        private RadioButton radioButton5;
        private SqlConnection conn = null;
        public pquest()
        {
            InitializeComponent();
        }

        public string tag;
        public int type;
        private void Form4_Load(object sender, EventArgs e)
        {
            
        }



        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "类别";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(23, 7);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(41, 16);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1类";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(23, 37);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(41, 16);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "2类";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(23, 72);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(41, 16);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "3类";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(93, 77);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(369, 164);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "发布人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "内容";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(612, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "发布";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(568, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "时限(具体日期）";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(27, 22);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(47, 16);
            this.radioButton4.TabIndex = 12;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "个人";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(568, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "报酬";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(612, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 15;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton6);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Location = new System.Drawing.Point(469, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 146);
            this.panel1.TabIndex = 17;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(23, 108);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(41, 16);
            this.radioButton6.TabIndex = 14;
            this.radioButton6.Text = "4类";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.Click += new System.EventHandler(this.radioButton6_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton5);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Location = new System.Drawing.Point(111, 247);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 55);
            this.panel2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(570, 149);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(152, 21);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(204, 22);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(47, 16);
            this.radioButton5.TabIndex = 13;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "团队";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.Visible = false;
            // 
            // pquest
            // 
            this.ClientSize = new System.Drawing.Size(745, 343);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "pquest";
            this.Text = "发布任务";
            this.Load += new System.EventHandler(this.Form4_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            label3.Text = login.id.uid;
            textBox2.Text = "0";
        }

        private void button1_Click_1(object sender, EventArgs e)
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
            if (radioButton6.Checked == true)
            {
                tag = "4";
            }

            if (radioButton4.Checked == true)
            {
                type = 1;
            }
            else type =2;

            int m = Convert.ToInt32(textBox2.Text);
            if (tag == "2" && m < 30) MessageBox.Show("报酬至少为30");
            else if (tag == "3" && m < 50) MessageBox.Show("报酬至少为50");
            else if (tag == "4" && m < 100) MessageBox.Show("报酬至少为100");
            else
            {
                string ptime = DateTime.Now.ToString();
                conn = new SqlConnection(ConnecttionString);
                string strSql = null;
                string strSql1 = null;
                string money = null;
                int money1 = 0;

                try
                {
                    strSql = "insert into Questview(pid,ptext,qtag,qemp,ptime,ctime,state,reward) values('" + login.id.uid + "','";
                    strSql += richTextBox1.Text + "','" +tag +"',"+ "NULL,'" + ptime + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd")  + "','0','" + textBox2.Text + "')";
                    MessageBox.Show(strSql);
                    strSql1 = string.Format("select pmoney from costomer where id = '{0}'", login.id.uid);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("异常错误" + ex.Message);
                    return;
                }
                SqlCommand command = null;
                SqlCommand command1 = null;
                SqlCommand command2 = null;
                try
                {
                    conn.Open();
                    command = new SqlCommand(strSql, conn);
                    command1 = new SqlCommand(strSql1, conn);
                    int n = command.ExecuteNonQuery();
                   int k= command1.ExecuteNonQuery();
                    //money1 = Convert.ToInt32(command1.ExecuteScalar());
                    //money1 -= Convert.ToInt32(textBox2.Text);
                    //money = Convert.ToString(money1);
                    //string strSql2 = "update costomer set pmoney = '" + money + "' where id = '" + login.id.uid + "'";
                    //command2 = new SqlCommand(strSql2, conn);
                    //int k = command2.ExecuteNonQuery();

                    if (k > 0) MessageBox.Show("发布成功！", "提示：");
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox2.Text = "0";
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox2.Text = "30";
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {

            if (radioButton3.Checked == true)
            {
                textBox2.Text = "50";
            }

        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                textBox2.Text = "100";
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.button1_Click_1(sender, e);//触发button事件  
            }  
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.button1_Click_1(sender, e);//触发button事件  
            }  
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.button1_Click_1(sender, e);//触发button事件  
            }  
        }


    }
}
