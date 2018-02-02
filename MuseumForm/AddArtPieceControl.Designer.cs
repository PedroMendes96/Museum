namespace MuseumForm
{
    partial class AddArtPieceControl
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
            this.MissingFields = new System.Windows.Forms.Label();
            this.Sucess = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textSize = new System.Windows.Forms.TextBox();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.processContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // processContainer
            // 
            this.processContainer.BackColor = System.Drawing.Color.BurlyWood;
            this.processContainer.Controls.Add(this.MissingFields);
            this.processContainer.Controls.Add(this.Sucess);
            this.processContainer.Controls.Add(this.AddButton);
            this.processContainer.Controls.Add(this.label5);
            this.processContainer.Controls.Add(this.Type);
            this.processContainer.Controls.Add(this.label4);
            this.processContainer.Controls.Add(this.label3);
            this.processContainer.Controls.Add(this.label2);
            this.processContainer.Controls.Add(this.textSize);
            this.processContainer.Controls.Add(this.textDescription);
            this.processContainer.Controls.Add(this.textName);
            this.processContainer.Location = new System.Drawing.Point(172, 109);
            this.processContainer.Name = "processContainer";
            this.processContainer.Size = new System.Drawing.Size(540, 470);
            this.processContainer.TabIndex = 7;
            // 
            // MissingFields
            // 
            this.MissingFields.BackColor = System.Drawing.Color.Firebrick;
            this.MissingFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.MissingFields.Location = new System.Drawing.Point(146, 416);
            this.MissingFields.Name = "MissingFields";
            this.MissingFields.Size = new System.Drawing.Size(270, 25);
            this.MissingFields.TabIndex = 29;
            this.MissingFields.Text = "You have to fill all the fields";
            this.MissingFields.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MissingFields.Visible = false;
            // 
            // Sucess
            // 
            this.Sucess.BackColor = System.Drawing.Color.LightGreen;
            this.Sucess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Sucess.Location = new System.Drawing.Point(146, 416);
            this.Sucess.Name = "Sucess";
            this.Sucess.Size = new System.Drawing.Size(270, 25);
            this.Sucess.TabIndex = 28;
            this.Sucess.Text = "You inserted the art piece sucessfully!";
            this.Sucess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Sucess.Visible = false;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(177, 336);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(197, 63);
            this.AddButton.TabIndex = 8;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(240, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Type";
            // 
            // Type
            // 
            this.Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Type.FormattingEnabled = true;
            this.Type.Items.AddRange(new object[] {
            "Sculpture",
            "Painting",
            "Photography"});
            this.Type.Location = new System.Drawing.Point(211, 36);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(121, 21);
            this.Type.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(201, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Size / Volume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(213, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // textSize
            // 
            this.textSize.Location = new System.Drawing.Point(217, 306);
            this.textSize.Name = "textSize";
            this.textSize.Size = new System.Drawing.Size(109, 20);
            this.textSize.TabIndex = 2;
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(104, 166);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(337, 101);
            this.textDescription.TabIndex = 1;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(104, 99);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(337, 20);
            this.textName.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(172, 46);
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
            this.label1.Text = "Add ArtPiece";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.BurlyWood;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(735, 575);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(144, 60);
            this.BackButton.TabIndex = 8;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddArtPieceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.processContainer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddArtPieceControl";
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
        private System.Windows.Forms.TextBox textSize;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label Sucess;
        private System.Windows.Forms.Label MissingFields;
    }
}
