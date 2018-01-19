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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nrlabel = new System.Windows.Forms.Label();
            this.nextbutton = new System.Windows.Forms.Button();
            this.messageSentLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(231, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "New Message";
            this.button1.TextAlign = ContentAlignment.MiddleCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.BurlyWood;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.nrlabel);
            this.panel1.Controls.Add(this.nextbutton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(133, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 460);
            this.panel1.TabIndex = 6;
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
            this.nextbutton.Location = new System.Drawing.Point(585, 437);
            this.nextbutton.Name = "nextbutton";
            this.nextbutton.Size = new System.Drawing.Size(40, 20);
            this.nextbutton.TabIndex = 7;
            this.nextbutton.Text = "Next";
            this.nextbutton.UseVisualStyleBackColor = true;
            this.nextbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // messageSentLabel
            // 
            this.messageSentLabel.AutoSize = true;
            this.messageSentLabel.BackColor = System.Drawing.Color.Tomato;
            this.messageSentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.messageSentLabel.Location = new System.Drawing.Point(272, 556);
            this.messageSentLabel.Name = "messageSentLabel";
            this.messageSentLabel.Size = new System.Drawing.Size(334, 26);
            this.messageSentLabel.TabIndex = 7;
            this.messageSentLabel.Text = "Message was sent with success !";
            this.messageSentLabel.Visible = false;
            // 
            // MessagesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.messageSentLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(166, 97);
            this.Name = "MessagesControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.Load += new System.EventHandler(this.MessagesControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Button nextbutton;
        private Label nrlabel;
        private Label messageSentLabel;
    }
}
