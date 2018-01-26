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
    public partial class AddArtPieceControl : UserControl
    {
        public Process process;
        public AddArtPieceControl()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!textName.Text.Trim().Equals("") && !textDescription.Text.Trim().Equals("") &&
                !textSize.Text.Trim().Equals("") && !Type.Text.Equals(""))
            {
                var artPieceInsert = "INSERT INTO items (name,description,exhibitors_id) VALUES ("+textName.Text+ ","+ textDescription.Text + ","+process.Exhibitor.IdExhibitor+")";
                var id = DBConnection.Instance.Execute(artPieceInsert);

                var specificInsert = "INSERT INTO ";

                Console.WriteLine(Type.Text);
                Console.WriteLine(ArtpieceFactory.sculpture);

                if (ArtpieceFactory.sculpture.Equals(Type.Text))
                {
                    specificInsert += "sculptures" + " (volume,items_id) VALUES (" + textSize.Text + ",";
                }
                else if (ArtpieceFactory.painting.Equals(Type.Text))
                {
                    specificInsert += "paintings" + " (size,items_id) VALUES (" + textSize.Text + ",";
                }
                else if (ArtpieceFactory.photography.Equals(Type.Text))
                {
                    specificInsert += "photographies" + " (size,items_id) VALUES (" + textSize.Text + ",";
                }

                specificInsert += id + ")";

                DBConnection.Instance.Execute(specificInsert);

                var artPieceProcess = "INSERT INTO items_has_processes (items_id,processes_id) VALUES (" + id + "," +
                                      process.Id + ")";
                DBConnection.Instance.Execute(artPieceProcess);
                textName.Text = "";
                textDescription.Text = "";
                textSize.Text = "";
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.ProcessControl);
            var control = (ProcessControl)this.ParentForm.Controls[index];
            control.UpdateViewPerUser();
            control.BringToFront();
        }
    }
}
