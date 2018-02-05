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
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum) ParentForm;
                var loginControl = appForms.LoginControl;
                loginControl.ResetView();
            }
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum) ParentForm;
                var createAccountControl = appForms.CreateAccountControl;
                createAccountControl.BringToFront();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
        }
    }
}