namespace MuseumForm
{
    partial class EditProcessControl
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
            this.processContainer = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateProcess = new System.Windows.Forms.Button();
            this.newValue = new System.Windows.Forms.TextBox();
            this.startBox = new System.Windows.Forms.ComboBox();
            this.endBox = new System.Windows.Forms.ComboBox();
            this.properties = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.processContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // processContainer
            // 
            this.processContainer.BackColor = System.Drawing.Color.BurlyWood;
            this.processContainer.Controls.Add(this.datePicker);
            this.processContainer.Controls.Add(this.label2);
            this.processContainer.Controls.Add(this.UpdateProcess);
            this.processContainer.Controls.Add(this.newValue);
            this.processContainer.Controls.Add(this.startBox);
            this.processContainer.Controls.Add(this.endBox);
            this.processContainer.Controls.Add(this.properties);
            this.processContainer.Location = new System.Drawing.Point(169, 112);
            this.processContainer.Name = "processContainer";
            this.processContainer.Size = new System.Drawing.Size(540, 470);
            this.processContainer.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Choose property";
            // 
            // UpdateProcess
            // 
            this.UpdateProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateProcess.Location = new System.Drawing.Point(149, 290);
            this.UpdateProcess.Name = "UpdateProcess";
            this.UpdateProcess.Size = new System.Drawing.Size(246, 84);
            this.UpdateProcess.TabIndex = 11;
            this.UpdateProcess.Text = "Update Process";
            this.UpdateProcess.UseVisualStyleBackColor = true;
            this.UpdateProcess.Click += new System.EventHandler(this.UpdateProcess_Click);
            // 
            // newValue
            // 
            this.newValue.Location = new System.Drawing.Point(114, 186);
            this.newValue.Name = "newValue";
            this.newValue.Size = new System.Drawing.Size(323, 20);
            this.newValue.TabIndex = 10;
            this.newValue.Visible = false;
            // 
            // startBox
            // 
            this.startBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startBox.FormattingEnabled = true;
            this.startBox.Items.AddRange(new object[] {
            "9:00",
            "9:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00"});
            this.startBox.Location = new System.Drawing.Point(72, 185);
            this.startBox.Name = "startBox";
            this.startBox.Size = new System.Drawing.Size(121, 21);
            this.startBox.TabIndex = 9;
            this.startBox.Visible = false;
            // 
            // endBox
            // 
            this.endBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endBox.FormattingEnabled = true;
            this.endBox.Items.AddRange(new object[] {
            "9:00",
            "9:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00"});
            this.endBox.Location = new System.Drawing.Point(356, 185);
            this.endBox.Name = "endBox";
            this.endBox.Size = new System.Drawing.Size(121, 21);
            this.endBox.TabIndex = 8;
            this.endBox.Visible = false;
            // 
            // properties
            // 
            this.properties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.properties.FormattingEnabled = true;
            this.properties.Items.AddRange(new object[] {
            "From",
            "Until",
            "Schedule",
            "Name",
            "Description",
            "Title"});
            this.properties.Location = new System.Drawing.Point(142, 81);
            this.properties.Name = "properties";
            this.properties.Size = new System.Drawing.Size(253, 21);
            this.properties.TabIndex = 0;
            this.properties.TextChanged += new System.EventHandler(this.OnChange);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(169, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 62);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 56);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Coral;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit Process";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(174, 186);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 13;
            this.datePicker.Visible = false;
            // 
            // EditProcessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.processContainer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditProcessControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.processContainer.ResumeLayout(false);
            this.processContainer.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel processContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox properties;
        private System.Windows.Forms.ComboBox startBox;
        private System.Windows.Forms.ComboBox endBox;
        private System.Windows.Forms.TextBox newValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UpdateProcess;
        private System.Windows.Forms.DateTimePicker datePicker;
    }
}
