using System;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class EditPriceControl : UserControl
    {
        public Process Process;

        public EditPriceControl()
        {
            InitializeComponent();
        }

        private void UpdatePrice_Click(object sender, EventArgs e)
        {
            if (!UpdatePrice.Text.Trim().Equals(""))
            {
                try
                {
                    Process.Price = float.Parse(PriceBox.Text);
                    Process.Update(Process.PriceProperty, Process.Price.ToString());
                }
                catch (Exception)
                {
                    InvalidValue.Text = @"You have to insert a value";
                    InvalidValue.Visible = true;
                    var myTimer = new Timer {Interval = 1000};
                    myTimer.Tick += ShowAndHideMessage;
                    myTimer.Start();
                }


                if (ParentForm != null)
                {
                    var appForms = (MadeiraMuseum) ParentForm;
                    var processControl = appForms.ProcessControl;
                    processControl.UpdateViewPerUser();
                    processControl.BringToFront();
                }
            }
            else
            {
                InvalidValue.Text = @"You have to insert a value";
                InvalidValue.Visible = true;
                var myTimer = new Timer {Interval = 1000};
                myTimer.Tick += ShowAndHideMessage;
                myTimer.Start();
            }
        }

        private void ShowAndHideMessage(object sender, EventArgs e)
        {
            InvalidValue.Visible = false;
            var timer = (Timer) sender;
            timer.Enabled = false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum) ParentForm;
                var control = appForms.ProcessControl;
                control.UpdateViewPerUser();
                control.BringToFront();
            }
        }
    }
}