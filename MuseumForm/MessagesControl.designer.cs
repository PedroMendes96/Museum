using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MuseumForm
{
    partial class MessagesControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public List<Label> msgtexts = new List<Label>();


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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.nrlabel = new System.Windows.Forms.Label();
            this.nextbutton = new System.Windows.Forms.Button();
            this.headPanel = new System.Windows.Forms.Panel();
            this.headTitle = new System.Windows.Forms.Label();
            this.NotificationLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.headPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(230, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "New Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.nrlabel);
            this.panel1.Controls.Add(this.nextbutton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(133, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 460);
            this.panel1.TabIndex = 6;
            // 
            // backButton
            // 
            this.backButton.ForeColor = System.Drawing.Color.Black;
            this.backButton.Location = new System.Drawing.Point(517, 437);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(40, 20);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // nrlabel
            // 
            this.nrlabel.AutoSize = true;
            this.nrlabel.Location = new System.Drawing.Point(563, 441);
            this.nrlabel.Name = "nrlabel";
            this.nrlabel.Size = new System.Drawing.Size(16, 13);
            this.nrlabel.TabIndex = 8;
            this.nrlabel.Text = "nr";
            this.nrlabel.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // nextbutton
            // 
            this.nextbutton.ForeColor = System.Drawing.Color.Black;
            this.nextbutton.Location = new System.Drawing.Point(582, 437);
            this.nextbutton.Name = "nextbutton";
            this.nextbutton.Size = new System.Drawing.Size(40, 20);
            this.nextbutton.TabIndex = 7;
            this.nextbutton.Text = "Next";
            this.nextbutton.UseVisualStyleBackColor = true;
            this.nextbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.Coral;
            this.headPanel.Controls.Add(this.headTitle);
            this.headPanel.Location = new System.Drawing.Point(133, 81);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(625, 56);
            this.headPanel.TabIndex = 10;
            // 
            // headTitle
            // 
            this.headTitle.Dock = DockStyle.Fill;
            this.headTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.headTitle.Location = new System.Drawing.Point(0, 0);
            this.headTitle.Name = "headTitle";
            this.headTitle.Size = new System.Drawing.Size(181, 31);
            this.headTitle.TabIndex = 9;
            this.headTitle.Text = "My Messages";
            this.headTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notificationLabel
            // 
            this.NotificationLabel.BackColor = System.Drawing.Color.LightGreen;
            this.NotificationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotificationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.NotificationLabel.Location = new System.Drawing.Point(0, 0);
            this.NotificationLabel.Name = "NotificationLabel";
            this.NotificationLabel.Size = new System.Drawing.Size(538, 38);
            this.NotificationLabel.TabIndex = 11;
            this.NotificationLabel.Text = "Notification";
            this.NotificationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NotificationLabel);
            this.panel2.Location = new System.Drawing.Point(174, 612);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 38);
            this.panel2.TabIndex = 12;
            // 
            // MessagesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.headPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(166, 97);
            this.Name = "MessagesControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.Load += new System.EventHandler(this.MessagesControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private Button nextbutton;
        private Label nrlabel;
        private Panel headPanel;
        private Label headTitle;
        private Button backButton;
        private Panel panel2;
    }
}
