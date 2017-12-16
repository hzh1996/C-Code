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
using Commons;

namespace StudentMark
{
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            label2.Text = "欢迎 "+Form1.major+" 专业的 "+ Form1.sname + " 同学使用本成绩管理系统!";
        }

        private void 各科成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)//加载数据库中数据
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from stumark where 学号='" 
                +Form1.sn.Trim() + "'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertable");
            dataGridView1.DataSource = ds.Tables["usertable"].DefaultView;
            //dataGridView1.Columns[0].MinimumWidth = 100;//限定列宽
            dataGridView1.Rows[0].MinimumHeight = 120;//限定行高
            conn.Close(); conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox3.Visible = false;
            groupBox2.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidateInfo()) return;//验证输入的密码
            string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (txtnpd.Text != txtnpassword.Text) { MessageBox.Show("请确认信密码的正确性！ "); }
            if (txtnpd.Text == "" && txtnpassword.Text == "") { MessageBox.Show("密码不允许为空！ "); }
            if (txtnpd.Text == txtnpassword.Text && txtnpd.Text != "")
            {
                SqlCommand com = new SqlCommand("update login set 密码='" +
                txtnpassword.Text.Trim() + "'where 用户名='" + Form1.sn.Trim() + "'", conn);
                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("密码修改成功！ ");
                    //groupBox1.Visible = false;
                }
            }
            conn.Close();
            conn.Dispose();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 l = new Form1();
            l.Visible = true;
        }

        private void 成绩分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from stumark where 学号='" 
                +Form1.sn.Trim() + "'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertable");
            int max = 0, min = 1001;
            double ave = 0.0;
            for (int i = 2; i <= 5; i++)
            {
                if (int.Parse(ds.Tables["usertable"].Rows[0][i].ToString()) > max)
                    max = int.Parse(ds.Tables["usertable"].Rows[0][i].ToString());
                if (int.Parse(ds.Tables["usertable"].Rows[0][i].ToString()) < min)
                    min = int.Parse(ds.Tables["usertable"].Rows[0][i].ToString());
            }
            txthscore.Text = max.ToString();
            txtlscore.Text = min.ToString();
            //txtall.Text = ds.Tables["usertable"].Rows[0]["总分"].ToString();
            //ave = int.Parse(ds.Tables["usertable"].Rows[0]["总分"].ToString()) / (double)4;
            ave = total()/4;
            txtall.Text = total().ToString();
            txtave.Text = ave.ToString();
            conn.Close(); conn.Dispose();
        }
        private int total()//计算总分
        {
            string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from stumark where 学号='"
                + Form1.sn.Trim() + "'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertable");
            int to1 = (int)ds.Tables["usertable"].Rows[0][2];
            int to2 = (int)ds.Tables["usertable"].Rows[0][3];
            int to3 = (int)ds.Tables["usertable"].Rows[0][4];
            int to4 = (int)ds.Tables["usertable"].Rows[0][5];
            int toz = to1 + to2 + to3 + to4;
            conn.Close();
            conn.Dispose();
            return toz;
        }

        private bool ValidateInfo()//验证输入的信息
        {
            bool b = true;
            
            //限定密码必须为5位数字
            if (!ValidataInput.IsPWD(txtnpassword.Text))
            {
                MessageBox.Show("密码必须为5为数字！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return b;
        }
    }
}
