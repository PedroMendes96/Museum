namespace MuseumForm
{
    partial class AppForms
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForms));
            this.initialControl1 = new MuseumForm.InitialControl();
            this.SuspendLayout();
            // 
            // initialControl1
            // 
            this.initialControl1.BackColor = System.Drawing.Color.Transparent;
            this.initialControl1.Location = new System.Drawing.Point(0, 0);
            this.initialControl1.Name = "initialControl1";
            this.initialControl1.Size = new System.Drawing.Size(1100, 650);
            this.initialControl1.TabIndex = 0;
            this.initialControl1.Load += new System.EventHandler(this.initialControl1_Load_1);
            this.initialControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            // 
            // AppForms
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.initialControl1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppForms";
            this.Text = "AppForms";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.ResumeLayout(false);

        }

        #endregion

        private InitialControl initialControl1;
    }
}