namespace MuseumForm
{
    partial class NewEmployeeControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headTitle = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.userMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.userPhone = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nameRequired = new System.Windows.Forms.Label();
            this.emailRequired = new System.Windows.Forms.Label();
            this.passwordRequired = new System.Windows.Forms.Label();
            this.phoneRequired = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SalaryRequired = new System.Windows.Forms.Label();
            this.userSalary = new System.Windows.Forms.TextBox();
            this.SalaryLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MailExists = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // headTitle
            // 
            this.headTitle.AutoSize = true;
            this.headTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.headTitle.Location = new System.Drawing.Point(192, 13);
            this.headTitle.Name = "headTitle";
            this.headTitle.Size = new System.Drawing.Size(275, 29);
            this.headTitle.TabIndex = 15;
            this.headTitle.Text = "Create New Employee";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(197, 70);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(230, 20);
            this.userName.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(120, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 24);
            this.label12.TabIndex = 18;
            this.label12.Text = "Name:";
            // 
            // userMail
            // 
            this.userMail.Location = new System.Drawing.Point(197, 125);
            this.userMail.Name = "userMail";
            this.userMail.Size = new System.Drawing.Size(230, 20);
            this.userMail.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(123, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Email:";
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(197, 180);
            this.userPassword.Name = "userPassword";
            this.userPassword.PasswordChar = '*';
            this.userPassword.Size = new System.Drawing.Size(230, 20);
            this.userPassword.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(85, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(113, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 24);
            this.label6.TabIndex = 23;
            this.label6.Text = "Phone:";
            // 
            // userPhone
            // 
            this.userPhone.Location = new System.Drawing.Point(196, 235);
            this.userPhone.Name = "userPhone";
            this.userPhone.Size = new System.Drawing.Size(230, 20);
            this.userPhone.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(177, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 57);
            this.button1.TabIndex = 25;
            this.button1.Text = "Add Employee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameRequired
            // 
            this.nameRequired.AutoSize = true;
            this.nameRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameRequired.ForeColor = System.Drawing.Color.Firebrick;
            this.nameRequired.Location = new System.Drawing.Point(430, 70);
            this.nameRequired.Name = "nameRequired";
            this.nameRequired.Size = new System.Drawing.Size(148, 20);
            this.nameRequired.TabIndex = 27;
            this.nameRequired.Text = "this field is required!";
            this.nameRequired.Visible = false;
            // 
            // emailRequired
            // 
            this.emailRequired.AutoSize = true;
            this.emailRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailRequired.ForeColor = System.Drawing.Color.Firebrick;
            this.emailRequired.Location = new System.Drawing.Point(430, 125);
            this.emailRequired.Name = "emailRequired";
            this.emailRequired.Size = new System.Drawing.Size(148, 20);
            this.emailRequired.TabIndex = 28;
            this.emailRequired.Text = "this field is required!";
            this.emailRequired.Visible = false;
            // 
            // passwordRequired
            // 
            this.passwordRequired.AutoSize = true;
            this.passwordRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordRequired.ForeColor = System.Drawing.Color.Firebrick;
            this.passwordRequired.Location = new System.Drawing.Point(430, 180);
            this.passwordRequired.Name = "passwordRequired";
            this.passwordRequired.Size = new System.Drawing.Size(148, 20);
            this.passwordRequired.TabIndex = 29;
            this.passwordRequired.Text = "this field is required!";
            this.passwordRequired.Visible = false;
            // 
            // phoneRequired
            // 
            this.phoneRequired.AutoSize = true;
            this.phoneRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneRequired.ForeColor = System.Drawing.Color.Firebrick;
            this.phoneRequired.Location = new System.Drawing.Point(429, 235);
            this.phoneRequired.Name = "phoneRequired";
            this.phoneRequired.Size = new System.Drawing.Size(148, 20);
            this.phoneRequired.TabIndex = 30;
            this.phoneRequired.Text = "this field is required!";
            this.phoneRequired.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.SalaryRequired);
            this.panel1.Controls.Add(this.userSalary);
            this.panel1.Controls.Add(this.SalaryLabel);
            this.panel1.Controls.Add(this.phoneRequired);
            this.panel1.Controls.Add(this.passwordRequired);
            this.panel1.Controls.Add(this.emailRequired);
            this.panel1.Controls.Add(this.nameRequired);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.userPhone);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.userPassword);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.userMail);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.userName);
            this.panel1.Location = new System.Drawing.Point(133, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 460);
            this.panel1.TabIndex = 23;
            // 
            // SalaryRequired
            // 
            this.SalaryRequired.AutoSize = true;
            this.SalaryRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalaryRequired.ForeColor = System.Drawing.Color.Firebrick;
            this.SalaryRequired.Location = new System.Drawing.Point(432, 284);
            this.SalaryRequired.Name = "SalaryRequired";
            this.SalaryRequired.Size = new System.Drawing.Size(148, 20);
            this.SalaryRequired.TabIndex = 33;
            this.SalaryRequired.Text = "this field is required!";
            this.SalaryRequired.Visible = false;
            // 
            // userSalary
            // 
            this.userSalary.Location = new System.Drawing.Point(196, 284);
            this.userSalary.Name = "userSalary";
            this.userSalary.Size = new System.Drawing.Size(230, 20);
            this.userSalary.TabIndex = 32;
            // 
            // SalaryLabel
            // 
            this.SalaryLabel.AutoSize = true;
            this.SalaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalaryLabel.Location = new System.Drawing.Point(113, 280);
            this.SalaryLabel.Name = "SalaryLabel";
            this.SalaryLabel.Size = new System.Drawing.Size(73, 24);
            this.SalaryLabel.TabIndex = 31;
            this.SalaryLabel.Text = "Salary:";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.backButton.Location = new System.Drawing.Point(647, 609);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(98, 32);
            this.backButton.TabIndex = 34;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Coral;
            this.panel2.Controls.Add(this.headTitle);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.panel2.Location = new System.Drawing.Point(133, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 56);
            this.panel2.TabIndex = 35;
            // 
            // MailExists
            // 
            this.MailExists.AutoSize = true;
            this.MailExists.BackColor = System.Drawing.Color.Coral;
            this.MailExists.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.MailExists.Location = new System.Drawing.Point(323, 610);
            this.MailExists.Name = "MailExists";
            this.MailExists.Size = new System.Drawing.Size(244, 31);
            this.MailExists.TabIndex = 36;
            this.MailExists.Text = "Mail already exists!";
            // 
            // NewEmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.MailExists);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.panel1);
            this.Name = "NewEmployeeControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.Load += new System.EventHandler(this.NewEmployeeControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headTitle;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox userMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox userPhone;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label nameRequired;
        private System.Windows.Forms.Label emailRequired;
        private System.Windows.Forms.Label passwordRequired;
        private System.Windows.Forms.Label phoneRequired;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SalaryRequired;
        private System.Windows.Forms.TextBox userSalary;
        private System.Windows.Forms.Label SalaryLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label MailExists;
    }
}
