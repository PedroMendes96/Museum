using System;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class EditPriceControl : UserControl
    {
        public Process process;

        public EditPriceControl()
        {
            InitializeComponent();
        }

        private void UpdatePrice_Click(object sender, EventArgs e)
        {
            if (!UpdatePrice.Text.Trim().Equals(""))
            {
                process.Price = float.Parse(PriceBox.Text);
                process.Update(Process.PriceProperty, process.Price.ToString());

                if (ParentForm != null)
                {
                    var index = ParentForm.Controls.IndexOfKey(AppForms.ProcessControl);
                    var processControl = (ProcessControl) ParentForm.Controls[index];
                    processControl.UpdateViewPerUser();
                    processControl.BringToFront();
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.ProcessControl);
                var control = (ProcessControl) ParentForm.Controls[index];
                control.UpdateViewPerUser();
                control.BringToFront();
            }
        }
    }
}