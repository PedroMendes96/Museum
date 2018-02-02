namespace MuseumForm
{
    partial class ForgotPasswordControl
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
            this.ForgotPassword = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MailBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SendPass = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.Sucess = new System.Windows.Forms.Label();
            this.MissingFields = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ForgotPassword
            // 
            this.ForgotPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ForgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgotPassword.Location = new System.Drawing.Point(0, 0);
            this.ForgotPassword.Name = "ForgotPassword";
            this.ForgotPassword.Size = new System.Drawing.Size(1100, 100);
            this.ForgotPassword.TabIndex = 0;
            this.ForgotPassword.Text = "Reset Password";
            this.ForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ForgotPassword);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 100);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.BurlyWood;
            this.panel2.Controls.Add(this.MailBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.SendPass);
            this.panel2.Location = new System.Drawing.Point(331, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 331);
            this.panel2.TabIndex = 2;
            // 
            // MailBox
            // 
            this.MailBox.Location = new System.Drawing.Point(75, 96);
            this.MailBox.Name = "MailBox";
            this.MailBox.Size = new System.Drawing.Size(290, 20);
            this.MailBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Account Mail:";
            // 
            // SendPass
            // 
            this.SendPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendPass.Location = new System.Drawing.Point(119, 195);
            this.SendPass.Name = "SendPass";
            this.SendPass.Size = new System.Drawing.Size(202, 76);
            this.SendPass.TabIndex = 0;
            this.SendPass.Text = "Send new passoword";
            this.SendPass.UseVisualStyleBackColor = true;
            this.SendPass.Click += new System.EventHandler(this.button1_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.BurlyWood;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(920, 565);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(144, 60);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Back";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Sucess
            // 
            this.Sucess.BackColor = System.Drawing.Color.LightGreen;
            this.Sucess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Sucess.Location = new System.Drawing.Point(416, 534);
            this.Sucess.Name = "Sucess";
            this.Sucess.Size = new System.Drawing.Size(270, 25);
            this.Sucess.TabIndex = 31;
            this.Sucess.Text = "The email was sent sucessfully!";
            this.Sucess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Sucess.Visible = false;
            // 
            // MissingFields
            // 
            this.MissingFields.BackColor = System.Drawing.Color.Firebrick;
            this.MissingFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.MissingFields.Location = new System.Drawing.Point(416, 511);
            this.MissingFields.Name = "MissingFields";
            this.MissingFields.Size = new System.Drawing.Size(270, 25);
            this.MissingFields.TabIndex = 30;
            this.MissingFields.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MissingFields.Visible = false;
            // 
            // ForgotPasswordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Sucess);
            this.Controls.Add(this.MissingFields);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ForgotPasswordControl";
            this.Size = new System.Drawing.Size(1100, 650);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ForgotPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SendPass;
        private System.Windows.Forms.TextBox MailBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label Sucess;
        private System.Windows.Forms.Label MissingFields;
    }
}
