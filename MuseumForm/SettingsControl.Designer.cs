namespace MuseumForm
{
    partial class SettingsControl
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.RadioMail = new System.Windows.Forms.RadioButton();
            this.RadioPassword = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.PhoneRadio = new System.Windows.Forms.RadioButton();
            this.RadioName = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ValueTextBox);
            this.panel1.Controls.Add(this.RadioMail);
            this.panel1.Controls.Add(this.RadioPassword);
            this.panel1.Controls.Add(this.PhoneRadio);
            this.panel1.Controls.Add(this.RadioName);
            this.panel1.Location = new System.Drawing.Point(166, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 538);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(207, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Change Value";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Settings_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(229, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Insert New Value";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(88, 320);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(427, 20);
            this.ValueTextBox.TabIndex = 5;
            // 
            // RadioMail
            // 
            this.RadioMail.AutoSize = true;
            this.RadioMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioMail.Location = new System.Drawing.Point(328, 198);
            this.RadioMail.Name = "RadioMail";
            this.RadioMail.Size = new System.Drawing.Size(70, 30);
            this.RadioMail.TabIndex = 4;
            this.RadioMail.TabStop = true;
            this.RadioMail.Text = "Mail";
            this.RadioMail.UseVisualStyleBackColor = true;
            this.RadioMail.Click += new System.EventHandler(this.MailClick);
            // 
            // RadioPassword
            // 
            this.RadioPassword.AutoSize = true;
            this.RadioPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioPassword.Location = new System.Drawing.Point(328, 134);
            this.RadioPassword.Name = "RadioPassword";
            this.RadioPassword.Size = new System.Drawing.Size(126, 30);
            this.RadioPassword.TabIndex = 3;
            this.RadioPassword.TabStop = true;
            this.RadioPassword.Text = "Password";
            this.RadioPassword.UseVisualStyleBackColor = true;
            this.RadioPassword.Click += new System.EventHandler(this.PasswordClick);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 49);
            this.label1.TabIndex = 2;
            this.label1.Text = "Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhoneRadio
            // 
            this.PhoneRadio.AutoSize = true;
            this.PhoneRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneRadio.Location = new System.Drawing.Point(169, 198);
            this.PhoneRadio.Name = "PhoneRadio";
            this.PhoneRadio.Size = new System.Drawing.Size(93, 30);
            this.PhoneRadio.TabIndex = 1;
            this.PhoneRadio.TabStop = true;
            this.PhoneRadio.Text = "Phone";
            this.PhoneRadio.UseVisualStyleBackColor = true;
            this.PhoneRadio.Click += new System.EventHandler(this.PhoneClick);
            // 
            // RadioName
            // 
            this.RadioName.AutoSize = true;
            this.RadioName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioName.Location = new System.Drawing.Point(169, 134);
            this.RadioName.Name = "RadioName";
            this.RadioName.Size = new System.Drawing.Size(89, 30);
            this.RadioName.TabIndex = 0;
            this.RadioName.TabStop = true;
            this.RadioName.Text = "Name";
            this.RadioName.UseVisualStyleBackColor = true;
            this.RadioName.Click += new System.EventHandler(this.NameClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Coral;
            this.panel2.Controls.Add(this.label1);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(138, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 49);
            this.panel2.TabIndex = 8;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.RadioButton RadioMail;
        private System.Windows.Forms.RadioButton RadioPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton PhoneRadio;
        private System.Windows.Forms.RadioButton RadioName;
        private System.Windows.Forms.Panel panel2;
    }
}
