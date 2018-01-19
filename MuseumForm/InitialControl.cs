using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumForm
{
    public partial class InitialControl : UserControl
    { 
        public InitialControl()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Login_Control);
            LoginControl loginControl = (LoginControl)this.ParentForm.Controls[index];
            loginControl.ResetView();

           
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.CreateAccount_Control);
            this.ParentForm.Controls[index].BringToFront();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
