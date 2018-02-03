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
            var myTimer = new Timer {Interval = 1000};
            if (!textName.Text.Trim().Equals("") && !textDescription.Text.Trim().Equals("") &&
                !textSize.Text.Trim().Equals("") && !Type.Text.Equals(""))
            {
                var factory = FactoryCreator.Instance.CreateFactory(FactoryCreator.ArtPieceFactory);
                ArtPiece artPiece;
                if (ArtpieceFactory.Sculpture.Equals(Type.Text))
                    artPiece = (Sculpture) factory.Create(ArtpieceFactory.Sculpture);
                else if (ArtpieceFactory.Painting.Equals(Type.Text))
                    artPiece = (Painting) factory.Create(ArtpieceFactory.Painting);
                else if (ArtpieceFactory.Photography.Equals(Type.Text))
                    artPiece = (Photography) factory.Create(ArtpieceFactory.Photography);
                else
                    artPiece = null;
                if (artPiece != null)
                {
                    artPiece.SetParameters(textName.Text, textDescription.Text, textSize.Text, Process.Exhibitor);
                    artPiece.Save();
                    artPiece.AssociateWithProcess(Process.Id);
                    Process.DecorateWithArtPiece(artPiece);
                    Sucess.Visible = true;
                    myTimer.Tick += ShowAndHideSucess;
                    myTimer.Start();
                }

                CleanFields();
            }
            else
            {

                myTimer.Tick += ShowAndHideMissingFields;
                myTimer.Start();
            }
        }

        private void ShowAndHideMissingFields(object sender, EventArgs e)
        {
            MissingFields.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }

        private void ShowAndHideSucess(object sender, EventArgs e)
        {
            Sucess.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }

        private void CleanFields()
        {
            textName.Text = "";
            textDescription.Text = "";
            textSize.Text = "";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            CleanFields();
            if (ParentForm != null)
            {
                var appForms = (AppForms)ParentForm;
                var control = appForms.ProcessControl;
                control.UpdateViewPerUser();
                control.BringToFront();
            }
        }

//        private void MouseDown(object sender, MouseEventArgs e)
//        {
//            var form = (AppForms) ParentForm;
//            form.MouseDown(null,null);
//        }
    }
}