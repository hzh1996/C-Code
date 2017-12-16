namespace StudentMark
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnName = new System.Windows.Forms.Button();
            this.btnCanael = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.rbtnstudent = new System.Windows.Forms.RadioButton();
            this.rbtnteacher = new System.Windows.Forms.RadioButton();
            this.rbtnmanager = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnName
            // 
            this.btnName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnName.Location = new System.Drawing.Point(89, 255);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(105, 43);
            this.btnName.TabIndex = 5;
            this.btnName.Text = "登录";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCanael
            // 
            this.btnCanael.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCanael.Location = new System.Drawing.Point(273, 255);
            this.btnCanael.Name = "btnCanael";
            this.btnCanael.Size = new System.Drawing.Size(116, 43);
            this.btnCanael.TabIndex = 6;
            this.btnCanael.Text = "取消";
            this.btnCanael.UseVisualStyleBackColor = true;
            this.btnCanael.Click += new System.EventHandler(this.btnCanael_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(99, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(99, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(208, 87);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(181, 28);
            this.txtName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(208, 154);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(181, 28);
            this.txtPassword.TabIndex = 1;
            // 
            // rbtnstudent
            // 
            this.rbtnstudent.AutoSize = true;
            this.rbtnstudent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnstudent.Location = new System.Drawing.Point(115, 205);
            this.rbtnstudent.Name = "rbtnstudent";
            this.rbtnstudent.Size = new System.Drawing.Size(79, 32);
            this.rbtnstudent.TabIndex = 2;
            this.rbtnstudent.TabStop = true;
            this.rbtnstudent.Text = "学生";
            this.rbtnstudent.UseVisualStyleBackColor = true;
            // 
            // rbtnteacher
            // 
            this.rbtnteacher.AutoSize = true;
            this.rbtnteacher.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnteacher.Location = new System.Drawing.Point(200, 205);
            this.rbtnteacher.Name = "rbtnteacher";
            this.rbtnteacher.Size = new System.Drawing.Size(79, 32);
            this.rbtnteacher.TabIndex = 3;
            this.rbtnteacher.TabStop = true;
            this.rbtnteacher.Text = "教师";
            this.rbtnteacher.UseVisualStyleBackColor = true;
            // 
            // rbtnmanager
            // 
            this.rbtnmanager.AutoSize = true;
            this.rbtnmanager.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnmanager.Location = new System.Drawing.Point(289, 205);
            this.rbtnmanager.Name = "rbtnmanager";
            this.rbtnmanager.Size = new System.Drawing.Size(100, 32);
            this.rbtnmanager.TabIndex = 4;
            this.rbtnmanager.TabStop = true;
            this.rbtnmanager.Text = "管理员";
            this.rbtnmanager.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(55, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(411, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "欢迎使用学生成绩管理系统";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(510, 316);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbtnmanager);
            this.Controls.Add(this.rbtnteacher);
            this.Controls.Add(this.rbtnstudent);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCanael);
            this.Controls.Add(this.btnName);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.Text = "登录页";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.Button btnCanael;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.RadioButton rbtnstudent;
        private System.Windows.Forms.RadioButton rbtnteacher;
        private System.Windows.Forms.RadioButton rbtnmanager;
        private System.Windows.Forms.Label label3;
    }
}

