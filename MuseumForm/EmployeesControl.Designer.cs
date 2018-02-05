namespace MuseumForm
{
    partial class EmployeesControl
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
            this.headPanel = new System.Windows.Forms.Panel();
            this.headTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.pageLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.addEmpButton = new System.Windows.Forms.Button();
            this.NotificationLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.headPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.Coral;
            this.headPanel.Controls.Add(this.headTitle);
            this.headPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.headPanel.Location = new System.Drawing.Point(133, 81);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(625, 56);
            this.headPanel.TabIndex = 0;
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
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.pageLabel);
            this.panel1.Controls.Add(this.nextButton);
            this.panel1.Controls.Add(this.addEmpButton);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.panel1.Location = new System.Drawing.Point(133, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 460);
            this.panel1.TabIndex = 1;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.backButton.Location = new System.Drawing.Point(485, 416);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(51, 24);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pageLabel.Location = new System.Drawing.Point(542, 422);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(14, 13);
            this.pageLabel.TabIndex = 2;
            this.pageLabel.Text = "P";
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nextButton.Location = new System.Drawing.Point(562, 416);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(51, 24);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // addEmpButton
            // 
            this.addEmpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.addEmpButton.Location = new System.Drawing.Point(214, 403);
            this.addEmpButton.Name = "addEmpButton";
            this.addEmpButton.Size = new System.Drawing.Size(219, 44);
            this.addEmpButton.TabIndex = 0;
            this.addEmpButton.Text = "New Employee";
            this.addEmpButton.UseVisualStyleBackColor = true;
            this.addEmpButton.Click += new System.EventHandler(this.addEmpButton_Click);
            // 
            // notificationLabel
            // 
            this.NotificationLabel.BackColor = System.Drawing.Color.Coral;
            this.NotificationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotificationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.NotificationLabel.Location = new System.Drawing.Point(0, 0);
            this.NotificationLabel.Name = "NotificationLabel";
            this.NotificationLabel.Size = new System.Drawing.Size(538, 38);
            this.NotificationLabel.TabIndex = 2;
            this.NotificationLabel.Text = "Notification!";
            this.NotificationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NotificationLabel.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NotificationLabel);
            this.panel2.Location = new System.Drawing.Point(180, 609);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 38);
            this.panel2.TabIndex = 3;
            // 
            // EmployeesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headPanel);
            this.Name = "EmployeesControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.headPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headTitle;
        private System.Windows.Forms.Button addEmpButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label pageLabel;
        private System.Windows.Forms.Panel panel2;
    }
}
