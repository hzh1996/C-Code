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
    public partial class Form1 : Form
    {
        static public string sn, sub,major,sname;//定义两个静态变量
        public Form1()
        {
            InitializeComponent();
        }
        FormMain fr4 = new FormMain();//管理员页面
        FormStudent fr2 = new FormStudent();//学生主页面
        FormTeacher fr3 = new FormTeacher();//教师主页面

        private void btnCanael_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)//登录设计
        {
            if (!ValidateInfo()) return;//用静态方法验证信息

            string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (txtName.Text == "" || txtPassword.Text == "")
                MessageBox.Show("请不要遗漏信息！ ");
            if (rbtnmanager.Checked)
            {
                string cstr = "select * from login where 身份='管理员'and 用户名= '"
                    + txtName.Text.Trim() + "'and 密码 = '" + txtPassword.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(cstr, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    sn = txtName.Text.Trim();
                    fr4.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("输入有误， 请重新输入！ ");
                    txtName.Text = "";
                    txtPassword.Text = "";
                }
            }
            if (rbtnteacher.Checked)
            {
                string cstr = "select * from login where 身份='教师'and 用户名='" +
                    txtName.Text.Trim() + "'and 密码='" + txtPassword.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(cstr, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    sn = txtName.Text.Trim();
                    sub = dr.GetValue(4).ToString();
                    fr3.Show(); this.Visible= false;
                }
                else
                {
                    MessageBox.Show("输入有误， 请重新输入！ ");
                    txtName.Text = "";
                    txtPassword.Text = "";
                }
            }
            if (rbtnstudent.Checked)
            {
                string cstr = "select * from login where 身份='学生'and 用户名='" 
                    +txtName.Text.Trim() + "'and 密码='" + txtPassword.Text.Trim() + "'";
               // SqlDataAdapter da = new SqlDataAdapter("Select * from login where 用户名='"
               //+ txtName.Text.Trim() + "'", conn);
               // DataSet ds = new DataSet();
               // da.Fill(ds, "usertable");
               // string ma = ds.Tables[0].Rows[0][3].ToString();//可以读取指定位置的数据
                SqlCommand comm = new SqlCommand(cstr, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    sn= txtName.Text.Trim();
                    sname = dr.GetValue(1).ToString();
                    major =dr.GetValue(4).ToString(); 
                    fr2.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("输入有误， 请重新输入！ ");
                    txtName.Text = "";
                    txtPassword.Text = "";
                }
            }
            conn.Close();
            conn.Dispose();
        }

        private bool ValidateInfo()//验证输入的信息
        {
            bool b = true;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("学号不能为空！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            //限定学号必须为5位数字
            if (!ValidataInput.IsSNO(txtName.Text)&&rbtnstudent.Checked==true)
            {
                MessageBox.Show("学号为95开头的5位数字！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            if (!ValidataInput.IsPWD(txtPassword.Text))
            {
                MessageBox.Show("密码为5位数字！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            if (rbtnmanager.Checked == false && rbtnstudent.Checked == false && rbtnteacher.Checked == false)
            {
                MessageBox.Show("请选择身份信息","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            return b;
        }
    }
}
