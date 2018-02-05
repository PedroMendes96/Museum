using System;
using System.Drawing;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class ListOfArtPieces : UserControl
    {
        private readonly int _initialHeight;
        private readonly int _normalPie;
        private int _actualPage;
        private Process process;

        public Process Process
        {
            get => process;
            set => process = value;
        }

        public ListOfArtPieces()
        {
            InitializeComponent();
            _initialHeight = ListContainer.Size.Height;
            _normalPie = _initialHeight / 10;
            _actualPage = 1;
        }

        private void BackProcess_Click(object sender, EventArgs e)
        {
            var appForms = (MadeiraMuseum)ParentForm;
            appForms?.ProcessControl.BringToFront();
        }

        public void ListArtPieces()
        {
            ListContainer.Controls.Clear();
            var totalArtPieceCount = CountArtPieces();

            var size = ListContainer.Size;
            if (process.Element != null)
            {
                var information = process.Element.GetInformation();
                var eachPieceInformation = information.Split('¬');

                if (totalArtPieceCount <= 10)
                {
                    Back.Visible = false;
                    Next.Visible = false;
                }
                else
                {
                    Back.Visible = true;
                    Next.Visible = true;
                }

                var limit = 0;
                if (_actualPage * 10 > totalArtPieceCount)
                {
                    limit = totalArtPieceCount;
                }
                else
                {
                    limit = _actualPage * 10;
                }

                var aux = limit - (_actualPage - 1) * 10;
                var height = _normalPie * (aux);
                size.Height = height;
                ListContainer.Size = size;

                for (var i = (_actualPage - 1) * 10; i < limit; i++)
                {
                    var panel = NewArtPiecePanel(i, _normalPie);
                    var label = NewArtPieceLabel(i, _normalPie, eachPieceInformation[i]);
                    panel.Controls.Add(label);
                    ListContainer.Controls.Add(panel);
                }
            }
            else
            {
                Back.Visible = false;
                Next.Visible = false;

                size.Height = 0;
                ListContainer.Size = size;
            }
        }

        public int CountArtPieces()
        {
            var count = 0;
            IDecorator elem = process;
            while (elem.GetElement() != null)
            {
                elem = elem.GetElement();
                count++;
            }

            return count;
        }

        private Panel NewArtPiecePanel(int index, int panelSize)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Top,
                Location = new Point(0, index * panelSize),
                Name = "Item"+index,
                Size = new Size(ListContainer.Width, panelSize),
                AutoSize = false,
                TabIndex = 0,
                BorderStyle = BorderStyle.FixedSingle
            };
            return panel;
        }

        private Label NewArtPieceLabel(int index, int panelSize, string information)
        {
            var label = new Label
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, index * panelSize),
                Name = @"Item" + index,
                Size = new Size(ListContainer.Width, panelSize),
                TabIndex = 0,
                Text = information,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point,
                    0)
            };
            return label;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (_actualPage != 1)
            {
                _actualPage -= 1;
                ListArtPieces();
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            var maxPage = (int)Math.Ceiling((double)CountArtPieces() / 10);
            if (maxPage != _actualPage)
            {
                _actualPage += 1;
                ListArtPieces();
            }
        }
    }
}
