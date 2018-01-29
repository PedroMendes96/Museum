﻿namespace MuseumForm
{
    partial class CreateAccountControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccountControl));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roleRequired = new System.Windows.Forms.Label();
            this.phoneRequired = new System.Windows.Forms.Label();
            this.passwordRequired = new System.Windows.Forms.Label();
            this.emailRequired = new System.Windows.Forms.Label();
            this.nameRequired = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.userPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userMail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioExhibitor = new System.Windows.Forms.RadioButton();
            this.radioEmployee = new System.Windows.Forms.RadioButton();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(508, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.roleRequired);
            this.panel1.Controls.Add(this.phoneRequired);
            this.panel1.Controls.Add(this.passwordRequired);
            this.panel1.Controls.Add(this.emailRequired);
            this.panel1.Controls.Add(this.nameRequired);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.userPhone);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.userPassword);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.userMail);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.userName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioExhibitor);
            this.panel1.Controls.Add(this.radioEmployee);
            this.panel1.Location = new System.Drawing.Point(253, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 455);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // roleRequired
            // 
            this.roleRequired.AutoSize = true;
            this.roleRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleRequired.ForeColor = System.Drawing.Color.Firebrick;
            this.roleRequired.Location = new System.Drawing.Point(426, 128);
            this.roleRequired.Name = "roleRequired";
            this.roleRequired.Size = new System.Drawing.Size(171, 20);
            this.roleRequired.TabIndex = 31;
            this.roleRequired.Text = "Please select your role!";
            this.roleRequired.Visible = false;
            // 
            // phoneRequired
            // 
            this.phoneRequired.AutoSize = true;
            this.phoneRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneRequired.ForeColor = System.Drawing.Color.Firebrick;
            this.phoneRequired.Location = new System.Drawing.Point(449, 280);
            this.phoneRequired.Name = "phoneRequired";
            this.phoneRequired.Size = new System.Drawing.Size(148, 20);
            this.phoneRequired.TabIndex = 30;
            this.phoneRequired.Text = "this field is required!";
            this.phoneRequired.Visible = false;
            this.phoneRequired.Click += new System.EventHandler(this.phoneRequired_Click);
            // 
            // passwordRequired
            // 
            this.passwordRequired.AutoSize = true;
            this.passwordRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordRequired.ForeColor = System.Drawing.Color.Firebrick;
            this.passwordRequired.Location = new System.Drawing.Point(449, 249);
            this.passwordRequired.Name = "passwordRequired";
            this.passwordRequired.Size = new System.Drawing.Size(148, 20);
            this.passwordRequired.TabIndex = 29;
            this.passwordRequired.Text = "this field is required!";
            this.passwordRequired.Visible = false;
            this.passwordRequired.Click += new System.EventHandler(this.passwordRequired_Click);
            // 
            // emailRequired
            // 
            this.emailRequired.AutoSize = true;
            this.emailRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailRequired.ForeColor = System.Drawing.Color.Firebrick;
            this.emailRequired.Location = new System.Drawing.Point(449, 213);
            this.emailRequired.Name = "emailRequired";
            this.emailRequired.Size = new System.Drawing.Size(148, 20);
            this.emailRequired.TabIndex = 28;
            this.emailRequired.Text = "this field is required!";
            this.emailRequired.Visible = false;
            this.emailRequired.Click += new System.EventHandler(this.emailRequired_Click);
            // 
            // nameRequired
            // 
            this.nameRequired.AutoSize = true;
            this.nameRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameRequired.ForeColor = System.Drawing.Color.Firebrick;
            this.nameRequired.Location = new System.Drawing.Point(449, 179);
            this.nameRequired.Name = "nameRequired";
            this.nameRequired.Size = new System.Drawing.Size(148, 20);
            this.nameRequired.TabIndex = 27;
            this.nameRequired.Text = "this field is required!";
            this.nameRequired.Visible = false;
            this.nameRequired.Click += new System.EventHandler(this.label3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(375, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Forgot the password?";
            this.label7.Click += new System.EventHandler(this.ForgotPasswordClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(157, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 67);
            this.button1.TabIndex = 25;
            this.button1.Text = "Create Account";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CreateAccount_Click);
            // 
            // userPhone
            // 
            this.userPhone.Location = new System.Drawing.Point(216, 282);
            this.userPhone.Name = "userPhone";
            this.userPhone.Size = new System.Drawing.Size(230, 20);
            this.userPhone.TabIndex = 24;
            this.userPhone.TextChanged += new System.EventHandler(this.userPhone_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(133, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 24);
            this.label6.TabIndex = 23;
            this.label6.Text = "Phone:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(104, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "Password:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(216, 249);
            this.userPassword.Name = "userPassword";
            this.userPassword.PasswordChar = '*';
            this.userPassword.Size = new System.Drawing.Size(230, 20);
            this.userPassword.TabIndex = 21;
            this.userPassword.TextChanged += new System.EventHandler(this.userPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(142, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Email:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // userMail
            // 
            this.userMail.Location = new System.Drawing.Point(216, 213);
            this.userMail.Name = "userMail";
            this.userMail.Size = new System.Drawing.Size(230, 20);
            this.userMail.TabIndex = 19;
            this.userMail.TextChanged += new System.EventHandler(this.userMail_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(138, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 24);
            this.label12.TabIndex = 18;
            this.label12.Text = "Name:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(216, 179);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(230, 20);
            this.userName.TabIndex = 17;
            this.userName.TextChanged += new System.EventHandler(this.userName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "You are a:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 26);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sign Up";
            // 
            // radioExhibitor
            // 
            this.radioExhibitor.AutoSize = true;
            this.radioExhibitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioExhibitor.Location = new System.Drawing.Point(328, 126);
            this.radioExhibitor.Name = "radioExhibitor";
            this.radioExhibitor.Size = new System.Drawing.Size(97, 24);
            this.radioExhibitor.TabIndex = 14;
            this.radioExhibitor.TabStop = true;
            this.radioExhibitor.Text = "Exhibitor";
            this.radioExhibitor.UseVisualStyleBackColor = true;
            // 
            // radioEmployee
            // 
            this.radioEmployee.AutoSize = true;
            this.radioEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEmployee.Location = new System.Drawing.Point(157, 126);
            this.radioEmployee.Name = "radioEmployee";
            this.radioEmployee.Size = new System.Drawing.Size(105, 24);
            this.radioEmployee.TabIndex = 13;
            this.radioEmployee.TabStop = true;
            this.radioEmployee.Text = "Employee";
            this.radioEmployee.UseVisualStyleBackColor = true;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.BurlyWood;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(953, 587);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(144, 60);
            this.BackButton.TabIndex = 21;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CreateAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CreateAccountControl";
            this.Size = new System.Drawing.Size(1100, 650);
            this.Load += new System.EventHandler(this.CreateAccountControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox userPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userMail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioExhibitor;
        private System.Windows.Forms.RadioButton radioEmployee;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label nameRequired;
        private System.Windows.Forms.Label phoneRequired;
        private System.Windows.Forms.Label passwordRequired;
        private System.Windows.Forms.Label emailRequired;
        private System.Windows.Forms.Label roleRequired;
    }
}
