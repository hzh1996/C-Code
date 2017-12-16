using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commons;

namespace StudentMark
{
    public partial class FormTeacher : Form
    {
        //自定义的变量
        
        public FormTeacher()
        {
            InitializeComponent();

            //禁用一下控件
            groupBox1.Visible = false;
            groupBox4.Visible = false;
            txtsName.Enabled = false;
            txtsSNO.Enabled = false;
            txtsubject.Enabled = false;
            学生成绩导出ToolStripMenuItem.Enabled = false;
            this.dataGridView1.MultiSelect = false;//设置只能选中一行数据
        }


        //控件事件：
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void 学生成绩操作ToolStripMenuItem_Click(object sender, EventArgs e)//显示功能页
        {
            groupBox4.Visible = false;
            学生成绩导出ToolStripMenuItem.Enabled = true;
            Display();
        }

        private void button5_Click(object sender, EventArgs e)//提交数据（添加或修改的）
        {

            if(!ValidateInfoS())
                return;//验证输入的分数

            string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand com = new SqlCommand("update stumark set " + Form1.sub + "='" + txtsMark.Text
            + "'where 学号='" + txtsSNO.Text + "'", conn);
            if (com.ExecuteNonQuery() == 1)
                MessageBox.Show("修改成功！ ");
            conn.Close(); conn.Dispose();

            //先记录当前选中的行号等 用于下面的光标定位
            int i = dataGridView1.CurrentCell.RowIndex;  //当前行号
            int FirstRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
            //更新数据显示
            Display();
            //把光标显示到修改后的行上
            dataGridView1.CurrentCell = dataGridView1[0, i];
            dataGridView1.Rows[i].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = FirstRowIndex;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//通过学号模糊查询
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(txtSNO.Text))
                {
                    //找到不匹配行 ，隐藏掉
                    //string index = dataGridView1.CurrentCell.Value.ToString();
                    dataGridView1.CurrentCell = null;//注意取消焦点
                    dataGridView1.Rows[i].Visible = false;
                    dataGridView1.Rows[1].Selected = true;
                }
                else
                {
                    dataGridView1.Rows[i].Visible = true;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)//通过姓名模糊查询
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(txtName.Text))
                {
                    //找到不匹配行 ，隐藏掉
                    dataGridView1.CurrentCell = null;//注意取消焦点
                    dataGridView1.Rows[i].Visible = false;
                }
                else
                    dataGridView1.Rows[i].Visible = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//把DataGridView中选中的数据展示到下方
        {
            string currentSubject = Form1.sub;
            string currentSNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string currentSname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string currentSmark = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtsSNO.Text = currentSNo;
            txtsName.Text = currentSname;
            txtsubject.Text = currentSubject;
            txtsMark.Text = currentSmark;
        }

        private void button1_Click(object sender, EventArgs e)//修改密码的提交（实现）
        {
            if (!ValidateInfo()) return;
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
                    MessageBox.Show("密码修改成功！ "); groupBox3.Visible = false;
                }
            }
            conn.Close(); conn.Dispose();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)//菜单栏的修改密码
        {
            groupBox1.Visible = true;
            groupBox4.Visible = true;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)//退出
        {
            this.Close();
            Form1 l = new Form1();
            l.Visible = true;
        }

        private void 学生成绩导出ToolStripMenuItem_Click(object sender, EventArgs e)//保存为文件
        {
            DataGridViewToExcel(dataGridView1);
        }



        //自定义
        private void Display()//显示数据
        {
            groupBox1.Visible = true;
            string str = "Data Source=.;Initial Catalog=DB_StudentMark;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select 学号,姓名," + Form1.sub
                + " from stumark", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "table");
            dataGridView1.DataSource = ds.Tables["table"].DefaultView;
            conn.Close();
            conn.Dispose();
        }
        private bool ValidateInfo()//验证修改的密码
        {
            bool b = true;

            //限定密码必须为5位数字
            if (!ValidataInput.IsPWD(txtnpd.Text))
            {
                MessageBox.Show("密码必须为5为数字！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return b;
        }
        private bool ValidateInfoS()//验证分数
        {
            bool b = true;
            if (!ValidataInput.IsNumber(txtsMark.Text))
            {
                MessageBox.Show("分数必须为数字！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            string markS = txtsMark.Text;
            int markI = Int32.Parse(markS);
            if (markI > 100 || markI < 0)
            {
                MessageBox.Show("分数必须在0-100之间","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            return b;
        }

        #region DateGridView导出到csv格式的Excel     
        /// <summary>     
        /// 常用方法，列之间加/t，一行一行输出，此文件其实是csv文件，不过默认可以当成Excel打开。     
        /// </summary>     
        /// <remarks>     
        /// using System.IO;     
        /// </remarks>     
        /// <param name="dgv"></param>     
        private void DataGridViewToExcel(DataGridView dgv)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV文件(*.csv)|*.csv|TXT文件(*.txt)|*.txt|Execl files (*.xls)|*.xls";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = true;
            dlg.Title = "保存";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = dlg.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string columnTitle = "";
                try
                {
                    //写入列标题     
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            columnTitle += ",";
                        }
                        columnTitle += dgv.Columns[i].HeaderText;
                    }
                    sw.WriteLine(columnTitle);

                    //写入列内容     
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        string columnValue = "";
                        for (int k = 0; k < dgv.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                columnValue += ",";
                            }
                            if (dgv.Rows[j].Cells[k].Value == null)
                                columnValue += "";
                            else
                                columnValue += dgv.Rows[j].Cells[k].Value.ToString().Trim();
                        }
                        sw.WriteLine(columnValue);
                    }
                    MessageBox.Show("保存完成！");
                    sw.Close();
                    myStream.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }
        #endregion
    }
}
