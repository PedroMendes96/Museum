namespace MuseumForm
{
    partial class AddPermanentControl
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
            this.panel10 = new System.Windows.Forms.Panel();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            this.comboBoxRooms = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.addButtonRoom = new System.Windows.Forms.Button();
            this.processContainer = new System.Windows.Forms.Panel();
            this.Information = new System.Windows.Forms.Label();
            this.headPanel = new System.Windows.Forms.Panel();
            this.headTitle = new System.Windows.Forms.Label();
            this.InvalidValue = new System.Windows.Forms.Label();
            this.processContainer.SuspendLayout();
            this.headPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel10
            // 
            this.panel10.AutoSize = true;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(0, 335);
            this.panel10.TabIndex = 9;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(58, 139);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(185, 20);
            this.textBoxName.TabIndex = 10;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(303, 139);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(185, 20);
            this.textBoxDescription.TabIndex = 11;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(184, 191);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(185, 20);
            this.textBoxTitle.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(132, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(361, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(263, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Title";
            // 
            // Submit
            // 
            this.Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit.Location = new System.Drawing.Point(193, 242);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(162, 45);
            this.Submit.TabIndex = 18;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // comboBoxRooms
            // 
            this.comboBoxRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRooms.FormattingEnabled = true;
            this.comboBoxRooms.Location = new System.Drawing.Point(163, 45);
            this.comboBoxRooms.Name = "comboBoxRooms";
            this.comboBoxRooms.Size = new System.Drawing.Size(225, 21);
            this.comboBoxRooms.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(243, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Add Room";
            // 
            // addButtonRoom
            // 
            this.addButtonRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButtonRoom.Location = new System.Drawing.Point(229, 72);
            this.addButtonRoom.Name = "addButtonRoom";
            this.addButtonRoom.Size = new System.Drawing.Size(96, 23);
            this.addButtonRoom.TabIndex = 20;
            this.addButtonRoom.Text = "Add Room";
            this.addButtonRoom.UseVisualStyleBackColor = true;
            this.addButtonRoom.Click += new System.EventHandler(this.addButtonRoom_Click);
            // 
            // processContainer
            // 
            this.processContainer.BackColor = System.Drawing.Color.BurlyWood;
            this.processContainer.Controls.Add(this.addButtonRoom);
            this.processContainer.Controls.Add(this.label11);
            this.processContainer.Controls.Add(this.comboBoxRooms);
            this.processContainer.Controls.Add(this.Submit);
            this.processContainer.Controls.Add(this.label9);
            this.processContainer.Controls.Add(this.label8);
            this.processContainer.Controls.Add(this.label7);
            this.processContainer.Controls.Add(this.textBoxTitle);
            this.processContainer.Controls.Add(this.textBoxDescription);
            this.processContainer.Controls.Add(this.textBoxName);
            this.processContainer.Controls.Add(this.panel10);
            this.processContainer.Location = new System.Drawing.Point(189, 110);
            this.processContainer.Name = "processContainer";
            this.processContainer.Size = new System.Drawing.Size(540, 335);
            this.processContainer.TabIndex = 33;
            // 
            // Information
            // 
            this.Information.BackColor = System.Drawing.Color.LightGreen;
            this.Information.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Information.Location = new System.Drawing.Point(338, 481);
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(270, 25);
            this.Information.TabIndex = 34;
            this.Information.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Information.Visible = false;
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.Coral;
            this.headPanel.Controls.Add(this.headTitle);
            this.headPanel.Location = new System.Drawing.Point(189, 51);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(540, 56);
            this.headPanel.TabIndex = 35;
            // 
            // headTitle
            // 
            this.headTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.headTitle.Location = new System.Drawing.Point(0, 0);
            this.headTitle.Name = "headTitle";
            this.headTitle.Size = new System.Drawing.Size(540, 56);
            this.headTitle.TabIndex = 9;
            this.headTitle.Text = "Add permanent event";
            this.headTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InvalidValue
            // 
            this.InvalidValue.BackColor = System.Drawing.Color.Firebrick;
            this.InvalidValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.InvalidValue.Location = new System.Drawing.Point(338, 481);
            this.InvalidValue.Name = "InvalidValue";
            this.InvalidValue.Size = new System.Drawing.Size(270, 25);
            this.InvalidValue.TabIndex = 33;
            this.InvalidValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InvalidValue.Visible = false;
            // 
            // AddPermanentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.InvalidValue);
            this.Controls.Add(this.headPanel);
            this.Controls.Add(this.Information);
            this.Controls.Add(this.processContainer);
            this.Name = "AddPermanentControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.processContainer.ResumeLayout(false);
            this.processContainer.PerformLayout();
            this.headPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.ComboBox comboBoxRooms;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button addButtonRoom;
        private System.Windows.Forms.Panel processContainer;
        private System.Windows.Forms.Label Information;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Label headTitle;
        private System.Windows.Forms.Label InvalidValue;
    }
}
