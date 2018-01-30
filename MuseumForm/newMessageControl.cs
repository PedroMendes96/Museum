using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Museum;
using Message = Museum.Message;

namespace MuseumForm
{
    public partial class NewMessageControl : UserControl
    {
        public NewMessageControl()
        {
            InitializeComponent();
        }

        public Person Person { get; set; }

        public string Role { get; set; }

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
            var r = new Regex("(Employee -)");
            var rName = new Regex("(" + Person.Name + ")");

            var l = Person.GetAllPeople();
            bool valueExists;
            foreach (var d in l)
            {
                valueExists = false;
                var da = new DictionaryAdapter(d);

                var counter = 0;
                var cmbEnumerator = receivercomboBox1.Items.GetEnumerator();
                while (counter < receivercomboBox1.Items.Count && receivercomboBox1.Items.Count > 0)
                {
                    cmbEnumerator.MoveNext();
                    var cmbItem = (ComboboxItem) cmbEnumerator.Current;
                    if (cmbItem.Value == int.Parse(da.GetValue("id"))) valueExists = true;
                    Debug.WriteLine("Items count:" + receivercomboBox1.Items.Count + " counter: " + counter);

                    counter++;
                }

                if (!valueExists)
                {
                    var item = new ComboboxItem();
                    item.Value = int.Parse(da.GetValue("id"));
                    var queryex = Exhibitor.GetExhibitorByPersonId(da.GetValue("id"));
                    if (queryex.Count > 0)
                        item.Text = "Exhibitor - " + da.GetValue("name");
                    else
                        item.Text = "Employee - " + da.GetValue("name");
                    var m = r.Match(item.Text);
                    var mName = rName.Match(item.Text);
                    Debug.WriteLine(mName.Success);
                    if (Role == "Exhibitor" && m.Success)
                        if (mName.Success)
                        {
                            // caso seja o seu nome, não mostra o seu nome nos destinatarios
                        }
                        else
                        {
                            Debug.WriteLine("Value added: " + receivercomboBox1.Items.Count);
                            receivercomboBox1.Items.Add(item);
                        }
                    else if (Role == "Employee")
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
                var receiver_id = (receivercomboBox1.SelectedItem as ComboboxItem).Value.ToString();
                Debug.WriteLine(receiver_id);

                var Sender = Person;
                var message = new Message(); //cria msg
                message.Sender = Sender;
                message.LastUpdate = DateTime.Now.ToString();
                message.Title = Title.Text;
                message.Content = content.Text;
                var recDictionary = message.Save(receiver_id); //guarda na db
                if (recDictionary != null)
                {
                    var receiver = Person.checkRole(receiver_id); //instancia o receiver
                    receiver.Notifications.Add(message); //Adiciona a msg ao receiver
                }

                var index = ParentForm.Controls.IndexOfKey(AppForms.Messages_Control);
                var messagesControl = (MessagesControl) ParentForm.Controls[index];
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
            var index = ParentForm.Controls.IndexOfKey(AppForms.Messages_Control);
            var messagesControl = (MessagesControl) ParentForm.Controls[index];
            messagesControl.ResetView();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}