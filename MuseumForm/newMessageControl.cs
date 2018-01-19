using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class newMessageControl : UserControl
    {
        private Person person;

        public Person Person
        {
            get => person;
            set => person = value;
        }

        public newMessageControl()
        {
            InitializeComponent();
        }

        public void EmptyTextFields()
        {
            content.Text = null;
            Title.Text = null;

        }

        public void getUsers()
        {
            sender.Text = Person.Name;
            SqlOperations so = Museum.SqlOperations.Instance;
            DBConnection db = DBConnection.Instance;
            string[] selvals = { "*" };
            string[] tables = { "persons"};

            string select = so.Select(selvals, tables);
            Debug.WriteLine(select);
            IList<Dictionary<string, string>> l = db.Query(select);
            bool valueExists;
            foreach (Dictionary<string, string> d in l)
            {
                valueExists = false;
                DictonaryAdapter da = new DictonaryAdapter(d);
                
                int counter = 0;
                var cmbEnumerator = receivercomboBox1.Items.GetEnumerator();
                while (counter < receivercomboBox1.Items.Count && receivercomboBox1.Items.Count >0)
                    {
                        cmbEnumerator.MoveNext();
                        ComboboxItem cmbItem = (ComboboxItem)cmbEnumerator.Current;
                        if (cmbItem.Value == int.Parse(da.GetValue("id")))
                        {
                            valueExists = true;
                        }
                        Debug.WriteLine("Items count:" + receivercomboBox1.Items.Count + " counter: " + counter);

                        counter++;

                    }
                if (!valueExists)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = da.GetValue("name");
                    item.Value = int.Parse(da.GetValue("id"));
                    receivercomboBox1.Items.Add(item);
                    receivercomboBox1.SelectedIndex = 0;
                }

                //MessageBox.Show((receivercomboBox1.SelectedItem as ComboboxItem).Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            int sel = receivercomboBox1.SelectedIndex;
            string receiver_id = (receivercomboBox1.SelectedItem as ComboboxItem).Value.ToString();
            Debug.WriteLine(receiver_id);
           
            Person Sender = Person;
            Museum.Message message = new Museum.Message();//cria msg
            message.Sender = Sender;
            message.LastUpdate = DateTime.Now.ToString();
            message.Title = Title.Text;
            message.Content = content.Text;
            Dictionary<string,string> recDictionary = message.Save(receiver_id); //guarda na db
            if (recDictionary != null)
            {
                Person receiver = Person.checkRole(receiver_id); //instancia o receiver
                receiver.Notifications.Add(message); //Adiciona a msg ao receiver
            }
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Messages_Control);
            MessagesControl messagesControl = (MessagesControl)this.ParentForm.Controls[index];
            messagesControl.ResetView();
            messagesControl.MessageSentLabel.Visible = true;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void newMessageControl_Load(object sender, EventArgs e)
        {

        }
    }
}
