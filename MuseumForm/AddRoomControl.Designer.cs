namespace MuseumForm
{
    partial class AddRoomControl
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
            this.BackButton = new System.Windows.Forms.Button();
            this.processContainer = new System.Windows.Forms.Panel();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.Label();
            this.UpdatePrice = new System.Windows.Forms.Button();
            this.SizeBox = new System.Windows.Forms.TextBox();
            this.SizeField = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.MissingFields = new System.Windows.Forms.Label();
            this.Sucess = new System.Windows.Forms.Label();
            this.processContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.BurlyWood;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(721, 567);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(144, 60);
            this.BackButton.TabIndex = 11;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // processContainer
            // 
            this.processContainer.BackColor = System.Drawing.Color.BurlyWood;
            this.processContainer.Controls.Add(this.DescriptionBox);
            this.processContainer.Controls.Add(this.Description);
            this.processContainer.Controls.Add(this.UpdatePrice);
            this.processContainer.Controls.Add(this.SizeBox);
            this.processContainer.Controls.Add(this.SizeField);
            this.processContainer.Location = new System.Drawing.Point(198, 160);
            this.processContainer.Name = "processContainer";
            this.processContainer.Size = new System.Drawing.Size(540, 385);
            this.processContainer.TabIndex = 10;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(82, 148);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionBox.Size = new System.Drawing.Size(375, 117);
            this.DescriptionBox.TabIndex = 4;
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.Location = new System.Drawing.Point(190, 104);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(153, 29);
            this.Description.TabIndex = 3;
            this.Description.Text = "Description:";
            // 
            // UpdatePrice
            // 
            this.UpdatePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePrice.Location = new System.Drawing.Point(138, 288);
            this.UpdatePrice.Name = "UpdatePrice";
            this.UpdatePrice.Size = new System.Drawing.Size(267, 82);
            this.UpdatePrice.TabIndex = 2;
            this.UpdatePrice.Text = "Create Room";
            this.UpdatePrice.UseVisualStyleBackColor = true;
            this.UpdatePrice.Click += new System.EventHandler(this.AddRoom_Click);
            // 
            // SizeBox
            // 
            this.SizeBox.Location = new System.Drawing.Point(122, 70);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(295, 20);
            this.SizeBox.TabIndex = 1;
            // 
            // SizeField
            // 
            this.SizeField.AutoSize = true;
            this.SizeField.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizeField.Location = new System.Drawing.Point(233, 28);
            this.SizeField.Name = "SizeField";
            this.SizeField.Size = new System.Drawing.Size(71, 29);
            this.SizeField.TabIndex = 0;
            this.SizeField.Text = "Size:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(198, 97);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 62);
            this.tableLayoutPanel1.TabIndex = 9;
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
            this.label1.Text = "New Room";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MissingFields
            // 
            this.MissingFields.BackColor = System.Drawing.Color.Firebrick;
            this.MissingFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.MissingFields.Location = new System.Drawing.Point(332, 567);
            this.MissingFields.Name = "MissingFields";
            this.MissingFields.Size = new System.Drawing.Size(270, 25);
            this.MissingFields.TabIndex = 28;
            this.MissingFields.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MissingFields.Visible = false;
            // 
            // Sucess
            // 
            this.Sucess.BackColor = System.Drawing.Color.LightGreen;
            this.Sucess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Sucess.Location = new System.Drawing.Point(332, 590);
            this.Sucess.Name = "Sucess";
            this.Sucess.Size = new System.Drawing.Size(270, 25);
            this.Sucess.TabIndex = 29;
            this.Sucess.Text = "You inserted the room sucessfully!";
            this.Sucess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Sucess.Visible = false;
            // 
            // AddRoomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Sucess);
            this.Controls.Add(this.MissingFields);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.processContainer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddRoomControl";
            this.Size = new System.Drawing.Size(915, 650);
            this.processContainer.ResumeLayout(false);
            this.processContainer.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Panel processContainer;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Button UpdatePrice;
        private System.Windows.Forms.TextBox SizeBox;
        private System.Windows.Forms.Label SizeField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MissingFields;
        private System.Windows.Forms.Label Sucess;
    }
}
