using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var processSQL = "UPDATE processes SET price="+ process.Price + " WHERE id="+process.Id;
                Console.WriteLine(processSQL);
                DBConnection.Instance.Execute(processSQL);

                var index = this.ParentForm.Controls.IndexOfKey(AppForms.ProcessControl);
                ProcessControl processControl = (ProcessControl)this.ParentForm.Controls[index];
                processControl.UpdateViewPerUser();
                processControl.BringToFront();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.ProcessControl);
            var control = (ProcessControl) this.ParentForm.Controls[index];
            control.UpdateViewPerUser();
            control.BringToFront();
        }
    }
}
