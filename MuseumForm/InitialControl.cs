using System;
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
            var index = ParentForm.Controls.IndexOfKey(AppForms.Login_Control);
            var loginControl = (LoginControl) ParentForm.Controls[index];
            loginControl.ResetView();
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.CreateAccount_Control);
            var createAccountControl = (CreateAccountControl)ParentForm.Controls[index];
            createAccountControl.BringToFront();
            createAccountControl.MailExists.Visible = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }
    }
}