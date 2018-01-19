using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumForm
{
    public partial class SingleMessageControl : UserControl
    {
        private Museum.Message message;
       

        public Museum.Message Message
        {
            get => message;
            set => message = value;
        }
        public SingleMessageControl()
        {
           
            InitializeComponent();
            
        }

        public void UpdateText()
        {
            
                headTitle.Text = "Message from: " + message.Sender.Name;
                title.Text = "Title: " + message.Title;
                content.Text = message.Content;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
