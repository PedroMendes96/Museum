using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class newMessageControl : UserControl
    {
        private Person person;
        private string role;

        public Person Person
        {
            get => person;
            set => person = value;
        }

        public string Role
        {
            get => role;
            set => role = value;
        }

        public newMessageControl()
        {
            InitializeComponent();

        }

        public void EmptyTextFields()
        {
            content.Text = null;
            Title.Text = null;
            contentRequired.Visible = false;
            titleRequired.Visible = false;
            titleContentRequired.Visible = false;
            receivercomboBox1.SelectedIndex = 0;

        }

        public void ResetCBoxItems()
        {
            receivercomboBox1.Items.Clear();
        }

        public void getUsers()
        {
            sender.Text = Person.Name;
            SqlOperations so = Museum.SqlOperations.Instance;
            DBConnection db = DBConnection.Instance;
            Regex r = new Regex("(Employee -)");
            Regex rName = new Regex("(" + Person.Name + ")");

            string selQuery = "SELECT DISTINCT * FROM persons";
            IList<Dictionary<string, string>> l = db.Query(selQuery);
            bool valueExists;
            foreach (Dictionary<string, string> d in l)
            {
                valueExists = false;
                DictonaryAdapter da = new DictonaryAdapter(d);

                int counter = 0;
                var cmbEnumerator = receivercomboBox1.Items.GetEnumerator();
                while (counter < receivercomboBox1.Items.Count && receivercomboBox1.Items.Count > 0)
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
                  
                    string sel =
                        "SELECT persons.id FROM persons,exhibitors WHERE persons.id = exhibitors.persons_id AND persons.id = " +
                        da.GetValue("id");
                    ComboboxItem item = new ComboboxItem();
                    item.Value = int.Parse(da.GetValue("id"));
                    var queryex = db.Query(sel);
                    if (queryex.Count > 0)
                    {                       
                        item.Text = "Exhibitor - " + da.GetValue("name");
                        
                    }
                    else
                    {
                        item.Text = "Employee - " + da.GetValue("name");
                    }
                    Match m = r.Match(item.Text);
                    Match mName = rName.Match(item.Text);
                    Debug.WriteLine(mName.Success);                 
                    if (Role == "Exhibitor" && m.Success)
                    {
                        if (mName.Success)
                        {
                            // caso seja o seu nome, não mostra o seu nome nos destinatarios
                        }
                        else
                        {
                            Debug.WriteLine("Value added: " + receivercomboBox1.Items.Count );
                            receivercomboBox1.Items.Add(item);
                        }
                    }
                    else if (Role == "Employee")
                    {
                        if (mName.Success)
                        {
                            // caso seja o seu nome, não mostra o seu nome nos destinatarios
                        }
                        else
                        {
                            Debug.WriteLine("Value added");
                            receivercomboBox1.Items.Add(item); 
                        }        
                    }
                    

                }
                
                //MessageBox.Show((receivercomboBox1.SelectedItem as ComboboxItem).Value.ToString());
            }
            receivercomboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Title.Text == "" && content.Text == "")
            {
                titleContentRequired.Visible = true;
                contentRequired.Visible = false;
                titleRequired.Visible = false;
            }
            else if (Title.Text == "" && content.Text != "")
            {
                titleRequired.Visible = true;
                contentRequired.Visible = false;
                titleContentRequired.Visible = false;
            }
            else if (Title.Text != "" && content.Text == "")
            {
                contentRequired.Visible = true;
                titleRequired.Visible = false;
                titleContentRequired.Visible = false;
            }
            else //quando os dois estão preenchidos
            {
                string receiver_id = (receivercomboBox1.SelectedItem as ComboboxItem).Value.ToString();
                Debug.WriteLine(receiver_id);

                Person Sender = Person;
                Museum.Message message = new Museum.Message(); //cria msg
                message.Sender = Sender;
                message.LastUpdate = DateTime.Now.ToString();
                message.Title = Title.Text;
                message.Content = content.Text;
                Dictionary<string, string> recDictionary = message.Save(receiver_id); //guarda na db
                if (recDictionary != null)
                {
                    Person receiver = Person.checkRole(receiver_id); //instancia o receiver
                    receiver.Notifications.Add(message); //Adiciona a msg ao receiver
                }
                var index = this.ParentForm.Controls.IndexOfKey(AppForms.Messages_Control);
                MessagesControl messagesControl = (MessagesControl) this.ParentForm.Controls[index];
                messagesControl.ResetView();
                messagesControl.MessageSentNotification();
            }

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

        private void backButton_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Messages_Control);
            MessagesControl messagesControl = (MessagesControl)this.ParentForm.Controls[index];
            messagesControl.ResetView();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
