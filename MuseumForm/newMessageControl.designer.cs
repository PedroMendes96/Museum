using System.Drawing;
using System.Windows.Forms;

namespace MuseumForm
{
    partial class newMessageControl
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
            this.SendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sender = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.receivercomboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.headTitle = new System.Windows.Forms.Label();
            this.headPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.titleRequired = new System.Windows.Forms.Label();
            this.contentRequired = new System.Windows.Forms.Label();
            this.titleContentRequired = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.headPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.SendButton.ForeColor = System.Drawing.Color.Black;
            this.SendButton.Location = new System.Drawing.Point(251, 403);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(150, 35);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Send Message";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.BurlyWood;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(84, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "To:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.BurlyWood;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(298, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "From:";
            // 
            // sender
            // 
            this.sender.AutoSize = true;
            this.sender.BackColor = System.Drawing.Color.BurlyWood;
            this.sender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.sender.Location = new System.Drawing.Point(343, 25);
            this.sender.Name = "sender";
            this.sender.Size = new System.Drawing.Size(58, 20);
            this.sender.TabIndex = 3;
            this.sender.Text = "sender";
            this.sender.Click += new System.EventHandler(this.label3_Click);
            // 
            // content
            // 
            this.content.Location = new System.Drawing.Point(76, 110);
            this.content.Multiline = true;
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(472, 287);
            this.content.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.BurlyWood;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(82, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Content:";
            // 
            // receivercomboBox1
            // 
            this.receivercomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.receivercomboBox1.FormattingEnabled = true;
            this.receivercomboBox1.Location = new System.Drawing.Point(121, 27);
            this.receivercomboBox1.Name = "receivercomboBox1";
            this.receivercomboBox1.Size = new System.Drawing.Size(171, 21);
            this.receivercomboBox1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.sender);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.TitleLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.receivercomboBox1);
            this.panel1.Controls.Add(this.SendButton);
            this.panel1.Controls.Add(this.content);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(133, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 460);
            this.panel1.TabIndex = 8;
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(121, 64);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(427, 20);
            this.Title.TabIndex = 8;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.BurlyWood;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TitleLabel.Location = new System.Drawing.Point(82, 62);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(42, 20);
            this.TitleLabel.TabIndex = 7;
            this.TitleLabel.Text = "Title:";
            // 
            // headTitle
            // 
            this.headTitle.AutoSize = true;
            this.headTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.headTitle.Location = new System.Drawing.Point(215, 13);
            this.headTitle.Name = "headTitle";
            this.headTitle.Size = new System.Drawing.Size(186, 31);
            this.headTitle.TabIndex = 9;
            this.headTitle.Text = "New Message";
            this.headTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.backButton.Location = new System.Drawing.Point(647, 609);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(98, 32);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titleRequired
            // 
            this.titleRequired.AutoSize = true;
            this.titleRequired.BackColor = System.Drawing.Color.Tomato;
            this.titleRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.titleRequired.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.titleRequired.Location = new System.Drawing.Point(361, 615);
            this.titleRequired.Name = "titleRequired";
            this.titleRequired.Size = new System.Drawing.Size(202, 26);
            this.titleRequired.TabIndex = 9;
            this.titleRequired.Text = "Please insert a title!";
            this.titleRequired.Visible = false;
            // 
            // contentRequired
            // 
            this.contentRequired.AutoSize = true;
            this.contentRequired.BackColor = System.Drawing.Color.Tomato;
            this.contentRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.contentRequired.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.contentRequired.Location = new System.Drawing.Point(349, 615);
            this.contentRequired.Name = "contentRequired";
            this.contentRequired.Size = new System.Drawing.Size(221, 26);
            this.contentRequired.TabIndex = 11;
            this.contentRequired.Text = "Please insert content!";
            this.contentRequired.Visible = false;
            this.contentRequired.Click += new System.EventHandler(this.label4_Click);
            // 
            // titleContentRequired
            // 
            this.titleContentRequired.AutoSize = true;
            this.titleContentRequired.BackColor = System.Drawing.Color.Tomato;
            this.titleContentRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.titleContentRequired.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.titleContentRequired.Location = new System.Drawing.Point(304, 615);
            this.titleContentRequired.Name = "titleContentRequired";
            this.titleContentRequired.Size = new System.Drawing.Size(303, 26);
            this.titleContentRequired.TabIndex = 12;
            this.titleContentRequired.Text = "Please insert content and title!";
            this.titleContentRequired.Visible = false;
            // 
            // newMessageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.titleContentRequired);
            this.Controls.Add(this.contentRequired);
            this.Controls.Add(this.titleRequired);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.headPanel);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(166, 97);
            this.Name = "newMessageControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.Load += new System.EventHandler(this.newMessageControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sender;
        private System.Windows.Forms.TextBox content;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox receivercomboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Label headTitle;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button backButton;
        private Label titleRequired;
        private Label contentRequired;
        private Label titleContentRequired;
    }
}
