namespace MuseumForm
{
    partial class SingleEmployeeControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.salaryBox = new System.Windows.Forms.TextBox();
            this.SalaryLabel = new System.Windows.Forms.Label();
            this.MailLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.headPanel = new System.Windows.Forms.Panel();
            this.headTitle = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.NameText = new System.Windows.Forms.Label();
            this.MailText = new System.Windows.Forms.Label();
            this.PhoneText = new System.Windows.Forms.Label();
            this.LastUpdateLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.headPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.LastUpdateLabel);
            this.panel1.Controls.Add(this.PhoneText);
            this.panel1.Controls.Add(this.MailText);
            this.panel1.Controls.Add(this.NameText);
            this.panel1.Controls.Add(this.salaryBox);
            this.panel1.Controls.Add(this.SalaryLabel);
            this.panel1.Controls.Add(this.MailLabel);
            this.panel1.Controls.Add(this.PhoneLabel);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.panel1.Location = new System.Drawing.Point(145, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 460);
            this.panel1.TabIndex = 3;
            // 
            // salaryBox
            // 
            this.salaryBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.salaryBox.Location = new System.Drawing.Point(167, 230);
            this.salaryBox.Name = "salaryBox";
            this.salaryBox.Size = new System.Drawing.Size(329, 32);
            this.salaryBox.TabIndex = 10;
            // 
            // SalaryLabel
            // 
            this.SalaryLabel.AutoSize = true;
            this.SalaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.SalaryLabel.Location = new System.Drawing.Point(81, 230);
            this.SalaryLabel.Name = "SalaryLabel";
            this.SalaryLabel.Size = new System.Drawing.Size(80, 26);
            this.SalaryLabel.TabIndex = 5;
            this.SalaryLabel.Text = "Salary:";
            // 
            // MailLabel
            // 
            this.MailLabel.AutoSize = true;
            this.MailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.MailLabel.Location = new System.Drawing.Point(104, 110);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(58, 26);
            this.MailLabel.TabIndex = 3;
            this.MailLabel.Text = "Mail:";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.PhoneLabel.Location = new System.Drawing.Point(81, 170);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(81, 26);
            this.PhoneLabel.TabIndex = 2;
            this.PhoneLabel.Text = "Phone:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.NameLabel.Location = new System.Drawing.Point(85, 50);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(77, 26);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name:";
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.editButton.Location = new System.Drawing.Point(201, 341);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(236, 81);
            this.editButton.TabIndex = 0;
            this.editButton.Text = "Edit Employee";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.Coral;
            this.headPanel.Controls.Add(this.headTitle);
            this.headPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.headPanel.Location = new System.Drawing.Point(145, 64);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(625, 56);
            this.headPanel.TabIndex = 2;
            // 
            // headTitle
            // 
            this.headTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headTitle.Location = new System.Drawing.Point(0, 0);
            this.headTitle.Name = "headTitle";
            this.headTitle.Size = new System.Drawing.Size(625, 56);
            this.headTitle.TabIndex = 0;
            this.headTitle.Text = "Employees:";
            this.headTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.headTitle.Click += new System.EventHandler(this.headTitle_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.backButton.Location = new System.Drawing.Point(659, 592);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(98, 32);
            this.backButton.TabIndex = 35;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // NameText
            // 
            this.NameText.AutoSize = true;
            this.NameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.NameText.Location = new System.Drawing.Point(168, 50);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(71, 26);
            this.NameText.TabIndex = 11;
            this.NameText.Text = "Name";
            // 
            // MailText
            // 
            this.MailText.AutoSize = true;
            this.MailText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.MailText.Location = new System.Drawing.Point(168, 110);
            this.MailText.Name = "MailText";
            this.MailText.Size = new System.Drawing.Size(52, 26);
            this.MailText.TabIndex = 12;
            this.MailText.Text = "Mail";
            // 
            // PhoneText
            // 
            this.PhoneText.AutoSize = true;
            this.PhoneText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.PhoneText.Location = new System.Drawing.Point(168, 170);
            this.PhoneText.Name = "PhoneText";
            this.PhoneText.Size = new System.Drawing.Size(75, 26);
            this.PhoneText.TabIndex = 13;
            this.PhoneText.Text = "Phone";
            // 
            // LastUpdateLabel
            // 
            this.LastUpdateLabel.AutoSize = true;
            this.LastUpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.LastUpdateLabel.Location = new System.Drawing.Point(84, 290);
            this.LastUpdateLabel.Name = "LastUpdateLabel";
            this.LastUpdateLabel.Size = new System.Drawing.Size(147, 26);
            this.LastUpdateLabel.TabIndex = 14;
            this.LastUpdateLabel.Text = "Last Updated:";
            // 
            // SingleEmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headPanel);
            this.Name = "SingleEmployeeControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.headPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Label headTitle;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox salaryBox;
        private System.Windows.Forms.Label SalaryLabel;
        private System.Windows.Forms.Label MailLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PhoneText;
        private System.Windows.Forms.Label MailText;
        private System.Windows.Forms.Label NameText;
        private System.Windows.Forms.Label LastUpdateLabel;
    }
}
