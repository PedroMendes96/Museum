using System;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class AddArtPieceControl : UserControl
    {
        public AddArtPieceControl()
        {
            InitializeComponent();
        }

        public Process Process { get; set; }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!textName.Text.Trim().Equals("") && !textDescription.Text.Trim().Equals("") &&
                !textSize.Text.Trim().Equals("") && !Type.Text.Equals(""))
            {
                var factory = FactoryCreator.Instance.CreateFactory(FactoryCreator.ArtPieceFactory);
                ArtPiece artPiece;
                if (ArtpieceFactory.sculpture.Equals(Type.Text))
                    artPiece = (Sculpture) factory.Create(ArtpieceFactory.sculpture);
                else if (ArtpieceFactory.painting.Equals(Type.Text))
                    artPiece = (Painting) factory.Create(ArtpieceFactory.painting);
                else if (ArtpieceFactory.photography.Equals(Type.Text))
                    artPiece = (Photography) factory.Create(ArtpieceFactory.photography);
                else
                    artPiece = null;
                artPiece.SetParameters(textName.Text, textDescription.Text, textSize.Text, Process.Exhibitor);
                artPiece.Save();
                artPiece.AssociateWithProcess(Process.Id);
                textName.Text = "";
                textDescription.Text = "";
                textSize.Text = "";

                //                var artPieceInsert = "INSERT INTO items (name,description,exhibitors_id) VALUES ("+textName.Text+ ","+ textDescription.Text + ","+process.Exhibitor.IdExhibitor+")";
                //                var id = DBConnection.Instance.Execute(artPieceInsert);
                //
                //                var specificInsert = "INSERT INTO ";
                //
                //                if (ArtpieceFactory.sculpture.Equals(Type.Text))
                //                {
                //                    specificInsert += "sculptures" + " (volume,items_id) VALUES (" + textSize.Text + ",";
                //                }
                //                else if (ArtpieceFactory.painting.Equals(Type.Text))
                //                {
                //                    specificInsert += "paintings" + " (size,items_id) VALUES (" + textSize.Text + ",";
                //                }
                //                else if (ArtpieceFactory.photography.Equals(Type.Text))
                //                {
                //                    specificInsert += "photographies" + " (size,items_id) VALUES (" + textSize.Text + ",";
                //                }
                //
                //                specificInsert += id + ")";
                //
                //                DBConnection.Instance.Execute(specificInsert);
                //                var artPieceProcess = "INSERT INTO items_has_processes (items_id,processes_id) VALUES (" + id + "," +
                //                                      process.Id + ")";
                //                DBConnection.Instance.Execute(artPieceProcess);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.ProcessControl);
            var control = (ProcessControl) ParentForm.Controls[index];
            control.UpdateViewPerUser();
            control.BringToFront();
        }
    }
}