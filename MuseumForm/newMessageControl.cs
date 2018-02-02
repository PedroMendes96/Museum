using System;
using System.Diagnostics;
using System.Globalization;
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

        public void GetUsers()
        {
            sender.Text = Person.Name;
            var r = new Regex("(Employee -)");
            var rName = new Regex("(" + Person.Name + ")");

            var l = Person.GetAllPeople();
            foreach (var d in l)
            {
                var valueExists = false;
                var da = new DictionaryAdapter(d);

                var counter = 0;
                var cmbEnumerator = receivercomboBox1.Items.GetEnumerator();
                while (counter < receivercomboBox1.Items.Count && receivercomboBox1.Items.Count > 0)
                {
                    cmbEnumerator.MoveNext();
                    var cmbItem = (ComboboxItem) cmbEnumerator.Current;
                    if (cmbItem != null && cmbItem.Value == int.Parse(da.GetValue("id"))) valueExists = true;
                    Debug.WriteLine("Items count:" + receivercomboBox1.Items.Count + " counter: " + counter);

                    counter++;
                }

                if (!valueExists)
                {
                    var item = new ComboboxItem {Value = int.Parse(da.GetValue("id"))};
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
                var receiverId = (receivercomboBox1.SelectedItem as ComboboxItem)?.Value.ToString();
                Debug.WriteLine(receiverId);

                var senderPerson = Person;
                var message = new Message
                {
                    Sender = senderPerson,
                    LastUpdate = DateTime.Now.ToString(CultureInfo.CurrentCulture),
                    Title = Title.Text,
                    Content = content.Text
                }; //cria msg
                var recDictionary = message.Save(receiverId); //guarda na db
                if (recDictionary != null)
                {
                    var receiver = Person.CheckRole(receiverId); //instancia o receiver
                    receiver.Notifications.Add(message); //Adiciona a msg ao receiver
                }

                if (ParentForm != null)
                {
                    var index = ParentForm.Controls.IndexOfKey(AppForms.MessagesControl);
                    var messagesControl = (MessagesControl) ParentForm.Controls[index];
                    messagesControl.ResetView();
                    messagesControl.NotificationLabel.Text = @"Message sent with success!";
                    messagesControl.ShowNotification();
                }
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
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.MessagesControl);
                var messagesControl = (MessagesControl) ParentForm.Controls[index];
                messagesControl.ResetView();

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}