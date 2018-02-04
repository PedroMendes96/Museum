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
    public partial class ListOfArtPieces : UserControl
    {
        private readonly int _initialHeight;
        private readonly int _normalPie;

        public ListOfArtPieces()
        {
            InitializeComponent();
            _initialHeight = ListContainer.Size.Height;
            _normalPie = _initialHeight / 10;
        }

        private void BackProcess_Click(object sender, EventArgs e)
        {
            var appForms = (AppForms)ParentForm;
            appForms?.ProcessControl.BringToFront();
        }

        public void ListArtPieces(Process process)
        {
            ListContainer.Controls.Clear();
            var totalArtPieceCount = CountArtPieces(process);

            var size = ListContainer.Size;
            if (totalArtPieceCount <= 10)
            {
                var height = _normalPie * totalArtPieceCount;
                size.Height = height;
                ListContainer.Size = size;

                for (int i = 0; i < totalArtPieceCount; i++)
                {
                    var panel = NewArtPiecePanel(i, _normalPie);
                    var decorator = GetDecorator(process, i);
                    var label = NewArtPieceLabel(i, _normalPie, decorator);

                    panel.Controls.Add(label);
                    ListContainer.Controls.Add(panel);
                }
            }
            else
            {
                size.Height = _initialHeight;
                ListContainer.Size = size;
                var pie = _initialHeight / totalArtPieceCount;


                for (int i = 0; i < totalArtPieceCount; i++)
                {
                    var panel = NewArtPiecePanel(i, pie);
                    var decorator = GetDecorator(process, i);
                    var label = NewArtPieceLabel(i, pie, decorator);

                    panel.Controls.Add(label);
                    ListContainer.Controls.Add(panel);
                }
            }
        }

        public int CountArtPieces(Process process)
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

        public IDecorator GetDecorator(Process process, int limit)
        {
            IDecorator decorator = process.Element;
            for (var i = 0; i < limit; i++)
            {
                decorator = decorator.GetElement();
            }

            return decorator;
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

        private Label NewArtPieceLabel(int index, int panelSize, IDecorator decorator)
        {
            var label = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point,
                    0),
                Location = new Point(0, index * panelSize),
                Name = @"Item" + index,
                Size = new Size(ListContainer.Width, panelSize),
                TabIndex = 0,
                Text = decorator.GetInformation(),
                TextAlign = ContentAlignment.MiddleCenter
            };

            return label;
        }
    }
}
