using System.Drawing;
using System.Windows.Forms;

namespace MuseumForm
{
    partial class SingleMessageControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.TextBox();
            this.headPanel = new System.Windows.Forms.Panel();
            this.headTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.headPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.BurlyWood;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.title);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.content);
            this.panel1.Location = new System.Drawing.Point(133, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 460);
            this.panel1.TabIndex = 2;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.title.Location = new System.Drawing.Point(67, 32);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(46, 26);
            this.title.TabIndex = 4;
            this.title.Text = "title";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.title.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.Color.BurlyWood;
            this.content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.content.Location = new System.Drawing.Point(62, 70);
            this.content.Multiline = true;
            this.content.Name = "content";
            this.content.ReadOnly = true;
            this.content.Size = new System.Drawing.Size(500, 319);
            this.content.TabIndex = 3;
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.Coral;
            this.headPanel.Controls.Add(this.headTitle);
            this.headPanel.Location = new System.Drawing.Point(133, 81);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(625, 56);
            this.headPanel.TabIndex = 3;
            // 
            // headTitle
            // 
            this.headTitle.AutoSize = true;
            this.headTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.headTitle.Location = new System.Drawing.Point(213, 12);
            this.headTitle.Name = "headTitle";
            this.headTitle.Size = new System.Drawing.Size(181, 31);
            this.headTitle.TabIndex = 0;
            this.headTitle.Text = "My Messages";
            this.headTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SingleMessageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.headPanel);
            this.Controls.Add(this.panel1);
            this.Name = "SingleMessageControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox content;
        private Label title;
        private Panel headPanel;
        private Label headTitle;
    }
}
