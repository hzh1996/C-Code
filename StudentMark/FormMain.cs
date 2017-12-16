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
    public partial class FormMain : Form
    {
        int Addi = 0;
        int Addj = 0;//定义一个全局变量记录添加按键点击的次数
        public FormMain()
        {
            InitializeComponent();
        }

        //控件事件

        private void FormMain_Load(object sender, EventArgs e)//窗体加载
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            txtName.Enabled = false;
            txtSNO.Enabled = false;
            txtJname.Enabled = false;
            txtJnum.Enabled = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }
        private void 其他操作ToolStripMenuItem_Click(object sender, EventArgs e)//退出
        {
            DialogResult result = MessageBox.Show("确定退出系统？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Form1 l = new Form1();
                l.Visible = true;
            }
        }

        //学生页
        private void btnAdd_Click(object sender, EventArgs e)//迷人的添加学生按钮
        {
            txtName.Enabled = true;
            //txtSNO.Enabled = true;
            Addi++;
            if (Addi % 2 == 0)
            {
                btnAdd.Text = "添加";
                txtName.Enabled = false;
                txtSNO.Enabled = false;

                if (Addi == 0)
                {
                    return;
                }
                else
                {
                    string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    SqlCommand com = new SqlCommand("select * from login where 用户名='"
                        + txtSNO.Text.Trim() + " '", conn);
                    if (com.ExecuteScalar() != null)
                    {
                        MessageBox.Show("用户已存在！ ");//好像不可能存在的。。。
                        cleartxtbox();
                    }
                    else
                    {
                        if (txtName.Text != "" && txtSNO.Text != "" && comboBox1.Text != "")
                        {
                            SqlCommand cm = new SqlCommand("insert into login(用户名,姓名,密码,身份,专业)values('"
                                + txtSNO.Text + "', '" + txtName.Text + "', '" + txtSNO.Text + "', '学生', '" + comboBox1.Text + "')", conn);
                            if (cm.ExecuteNonQuery() == 1)
                            {
                                SqlCommand c = new SqlCommand("insert into stumark(学号,姓名,数据结构,操作系统,C#程序设计,软件工程) values ('"
                                + txtSNO.Text + "', '" + txtName.Text + "','0','0','0','0')", conn);
                                if (c.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("添加成功!");
                                }
                                cleartxtbox();
                            }
                        }
                        else
                            MessageBox.Show("请不要遗漏信息！ ");
                    }
                }
            }
            else//自动添加最大学号+1
            {
                string str1 = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
                SqlConnection conn1 = new SqlConnection(str1);
                conn1.Open();
                SqlCommand com1 = new SqlCommand("select Max(学号) from stumark", conn1);
                int k = Int32.Parse(com1.ExecuteScalar().ToString());
                txtSNO.Text = (k + 1).ToString();
                btnAdd.Text = "提交";//改变按钮显示
            }
        }
        private void btnDel_Click(object sender, EventArgs e)//删除学生信息
        {
            string st = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
            SqlConnection conne = new SqlConnection(st);
            conne.Open();
            SqlDataAdapter co = new SqlDataAdapter("select * from login where 用户名='" + txtDsno.Text.Trim() + "'", conne);
            DataSet ds = new DataSet();
            co.Fill(ds, "usertable");
            string sname = "";
            try
            {
                sname = ds.Tables["usertable"].Rows[0][1].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("没有此学生！");
                conne.Close();
                return;
            }

            DialogResult result = MessageBox.Show("确定删除  " + sname + "  吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                SqlCommand com = new SqlCommand("delete from login where 用户名='"
                    + txtDsno.Text.Trim() + " 'and 身份='学生'", conn);

                if (com.ExecuteNonQuery() == 1)
                {
                    SqlCommand cc1 = new SqlCommand("delete from stumark where 学号='"
                    + txtDsno.Text.Trim() + "'", conn);
                    if (cc1.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("成功删除！ ");
                        txtDsno.Text = "";
                    }
                    else
                        MessageBox.Show("删除成绩表出错了！");
                }
                else
                {
                    MessageBox.Show("没有学生类型的那个用户！ ");
                    txtDsno.Text = "";
                }
                conn.Close();
            }
        }
        private void 学生信息操作ToolStripMenuItem_Click(object sender, EventArgs e)//菜单栏的学生页
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        //教师页
        private void 教师信息操作ToolStripMenuItem_Click(object sender, EventArgs e)//菜单栏教师页
        {
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            display();

        }
        private void button1_Click(object sender, EventArgs e)//添加教师
        {

            txtJname.Enabled = true;
            txtJnum.Enabled = true;
            Addj++;

            if (Addj % 2 == 0)
            {
                if (Addj == 1) return;
                if (!ValidateInfo()) return;//用静态方法验证信息

                txtJname.Enabled = true;
                txtJnum.Enabled = true;
                btnJadd.Text = "提交";
                string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                SqlCommand com = new SqlCommand("select * from login where 用户名='"
                    + txtJnum.Text.Trim()+ " '", conn);
                if (com.ExecuteScalar() != null)
                {
                    MessageBox.Show("用户已存在！ ");
                    conbtn();
                }
                else
                {
                    if (txtJnum.Text != "" && txtJname.Text != "" && comboBox2.Text != "")
                    {
                        SqlCommand cm = new SqlCommand("insert into login(用户名,姓名,密码,身份,专业)values('" + txtJnum.Text + "', '" + txtJname.Text + "', '" + txtJnum.Text + "', '教师', '" + comboBox2.Text + "')", conn);
                        if (cm.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("创建成功！ ");
                            conbtn();
                            display();
                        }
                    }
                    else
                    {
                        MessageBox.Show("请不要遗漏信息！ ");
                        conbtn();
                    }
                }
            }
            else
            {
                btnJadd.Text = "提交";
                txtJname.Text = string.Empty;
                txtJnum.Text = string.Empty;
            }
        }
        private void button2_Click(object sender, EventArgs e)//删除教师
        {

            string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (txtJnum.Text.Equals(""))
            {
                MessageBox.Show("工号不能为空！");
                return;
            }
            else
            {
                SqlCommand com = new SqlCommand("delete from login where 用户名='"
                    + txtJnum.Text.Trim() + " 'and 身份='教师'", conn);
                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("成功删除！ ");
                    conbtn();
                    display();
                }
                else
                {
                    MessageBox.Show("没有老师类型的那个用户！ ");
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//取出DataGridView数据给下边的textbox
        {
            txtJname.Enabled = false;
            txtJnum.Enabled = false;
            string currentSNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string currentSname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string currentSubject = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtJnum.Text = currentSNo;
            txtJname.Text = currentSname;
            comboBox2.Text = currentSubject;
        }


        //自定义事件
        private void cleartxtbox()//控制学生页TeXTBOx显示
        {
            txtName.Text = "";
            txtSNO.Text = "";
        }
        private void conbtn()//控制教师添加的textbox
        {
            btnJadd.Text = "添加";
            txtJname.Text = string.Empty;
            txtJnum.Text = string.Empty;
            txtJname.Enabled = false;
            txtJnum.Enabled = false;
        }
        private void display()//加载数据到DataGridView
        {
            string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select 用户名,姓名,专业" + " from login where 身份='教师'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "table");
            dataGridView1.DataSource = ds.Tables["table"].DefaultView;
            conn.Close();
            conn.Dispose();
        }
        private bool ValidateInfo()//验证输入的信息
        {
            bool b = true;
            if (string.IsNullOrWhiteSpace(txtJnum.Text))
            {
                MessageBox.Show("工号不能为空！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            //限定学号必须为5位数字
            if (!ValidataInput.IsJNum(txtJnum.Text))
            {
                MessageBox.Show("工号为必须为10开头的5位数字！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return b;
        }
    }
}
