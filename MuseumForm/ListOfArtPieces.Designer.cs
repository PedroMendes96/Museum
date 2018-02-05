namespace MuseumForm
{
    partial class ListOfArtPieces
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
            this.ListContainer = new System.Windows.Forms.Panel();
            this.BackProcess = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.AllArtPieces = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListContainer
            // 
            this.ListContainer.BackColor = System.Drawing.Color.BurlyWood;
            this.ListContainer.Location = new System.Drawing.Point(216, 79);
            this.ListContainer.Name = "ListContainer";
            this.ListContainer.Size = new System.Drawing.Size(540, 500);
            this.ListContainer.TabIndex = 0;
            // 
            // BackProcess
            // 
            this.BackProcess.Location = new System.Drawing.Point(400, 595);
            this.BackProcess.Name = "BackProcess";
            this.BackProcess.Size = new System.Drawing.Size(159, 35);
            this.BackProcess.TabIndex = 1;
            this.BackProcess.Text = "Back to Process";
            this.BackProcess.UseVisualStyleBackColor = true;
            this.BackProcess.Click += new System.EventHandler(this.BackProcess_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Coral;
            this.panel.Controls.Add(this.AllArtPieces);
            this.panel.Location = new System.Drawing.Point(216, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(540, 55);
            this.panel.TabIndex = 2;
            // 
            // AllArtPieces
            // 
            this.AllArtPieces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllArtPieces.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllArtPieces.Location = new System.Drawing.Point(0, 0);
            this.AllArtPieces.Name = "AllArtPieces";
            this.AllArtPieces.Size = new System.Drawing.Size(540, 55);
            this.AllArtPieces.TabIndex = 0;
            this.AllArtPieces.Text = "Art Pieces inserted";
            this.AllArtPieces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(646, 586);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
            this.Back.TabIndex = 3;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(738, 586);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 4;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // ListOfArtPieces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.BackProcess);
            this.Controls.Add(this.ListContainer);
            this.Name = "ListOfArtPieces";
            this.Size = new System.Drawing.Size(915, 650);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ListContainer;
        private System.Windows.Forms.Button BackProcess;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label AllArtPieces;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Next;
    }
}
