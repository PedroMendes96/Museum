using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Museum;
using Message = Museum.Message;

namespace MuseumForm
{
    public partial class MessagesControl : UserControl
    {
        private readonly IList<Label> _msgsText = new List<Label>();
        public IEnumerator<Message> Enumerator;

        public MessagesControl()
        {
            InitializeComponent();
        }

        public Label NotificationLabel
        {
            get => notificationLabel;
            set => notificationLabel = value;
        }
        public string Role { get; set; }

        public Person Person { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }


        public Label AddMessageField(int y)
        {
            var msgtext = new Label
            {
                AutoSize = true,
                BackColor = Color.BurlyWood,
                Font = new Font("Microsoft Sans Serif", 14F),
                Location = new Point(133, 140 + y),
                Size = new Size(64, 20)
            };
            Controls.Add(msgtext);
            _msgsText.Add(msgtext);
            msgtext.BringToFront();
            return msgtext;
        }

        public void ResetView() // função que volta a mostrar as mensagens inicialmente (da mais recente para a menos)
        {
            BringToFront();
            Person.GetMessages();
            notificationLabel.Visible = false;
            TotalPages = Person.GetMaxMessagesPages();
            Enumerator = Person.Notifications.GetEnumerator();
            CurrentPage = 1;
            UpdateText("initial");
        }

        public void UpdateText(string operation)
        {
            headTitle.Text = @"My Messages: " + Person.Name;
            nrlabel.Text = CurrentPage.ToString();
            if (operation == "initial")
                ShowMessages("initial");
            else if (operation == "next")
                ShowMessages("next");
            else
                ShowMessages("back");

            if (CurrentPage == TotalPages || TotalPages == 0)
                nextbutton.Visible = false;
            else
                nextbutton.Visible = true;

            backButton.Visible = CurrentPage != 1;
        }

        public void EmptyTextFields()
        {
            var label = _msgsText.GetEnumerator();
            if (_msgsText != null)
            {
                label.Reset();
                while (label.MoveNext())
                {
                    if (label.Current != null)
                    {
                        Debug.WriteLine(label.Current.Text);

                        label.Current.Dispose(); //destroy os msgs texts
                    }
                }
            }
        }

        public void ShowNotification()
        {
            notificationLabel.Visible = true;
            var timer = new Timer {Interval = 3000};
            timer.Tick += timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            notificationLabel.Visible = false;
        }

        private void ShowMessages(string operation)
        {
            if (operation == "next" || operation == "initial")
            {
                var c = 0;
                var nrMsg = Person.Notifications.Count;
                Debug.WriteLine("totalpages:" + TotalPages + " nr_msgs: " + nrMsg);
                Debug.WriteLine("currentpg: " + CurrentPage);
                if (nrMsg > 0)
                {
                    if (CurrentPage == TotalPages)
                        nrMsg = nrMsg - 5 * (TotalPages - 1);
                    else
                        nrMsg = 5;
                    EmptyTextFields();
                    while (c < nrMsg)
                    {
                       AddMessage(c);
                       Debug.WriteLine("msg displayed:" + c);
                       Enumerator.MoveNext();
                       c++;
                    }
                }
                else
                {
                    EmptyTextFields();
                    AddMessage(0);
                }
            }
            else
            {
                if (operation == "back")
                {
                    var prevPage = CurrentPage + 1;
                    var indexLastMsgShown = prevPage * 5 - 1;
                    var msgList = Person.Notifications;
                    Debug.WriteLine("index of: " + indexLastMsgShown);
                    Enumerator.Reset();
                    while (Enumerator.Current != msgList[indexLastMsgShown - 9])
                        Enumerator.MoveNext();
                    if (Enumerator.Current != null) Debug.WriteLine(Enumerator.Current.LastUpdate);

                    var c = 0;
                    var nrMsg = Person.Notifications.Count;
                    Debug.WriteLine("totalpages:" + TotalPages + " nr_msgs: " + nrMsg);
                    Debug.WriteLine("currentpg: " + CurrentPage);
                    if (nrMsg > 0)
                    {
                        nrMsg = 5;
                        EmptyTextFields();
                        while (c < nrMsg)
                        {
                            AddMessage(c);
                            Debug.WriteLine("msg displayed:" + c);
                            Enumerator.MoveNext();
                            c++;
                        }
                    }
                }
            }
        }


        private void AddMessage(int c)
        {
            if (Enumerator.Current == null) // caso inicial quando ainda n foi efetuado o primeiro movenext
            {
                Enumerator.MoveNext();
            }
            var msg = Enumerator.Current;
            var nrMsg = Person.Notifications.Count;
            if (nrMsg > 0)
            {
                Debug.WriteLine("nr_msg: " + nrMsg);
                if (msg != null)
                {
                    var list = Message.GetMessageLastUpdate(msg.Id.ToString());
                    string lastUpdate = null;
                    foreach (var msgdict in list)
                    {

                        var da = new DictionaryAdapter(msgdict);
                        lastUpdate = da.GetValue("lastUpdate");
                    }

                    if (lastUpdate != null)
                    {
                        var msgtext = AddMessageField(80 * c); //Cria o campo do label no windows forms
                        msgtext.AutoSize = false;
                        msgtext.BorderStyle = BorderStyle.FixedSingle;
                        msgtext.BackColor = Color.BurlyWood;
                        msgtext.Text = @"Title: " + msg.Title + Environment.NewLine + @"From: " +
                                       msg.Sender.Name +
                                       @" - Received at: " + lastUpdate;


                        msgtext.TextAlign = ContentAlignment.MiddleCenter;
                        msgtext.Width = 625;
                        msgtext.Height = 80;
                        msgtext.Click += delegate { msgtext_Click(msg); };
                        msgtext.MouseHover += delegate
                        {
                            msgtext.BackColor = Color.AntiqueWhite;
                            Cursor.Current = Cursors.Hand;
                        };
                        msgtext.MouseEnter += delegate
                        {
                            msgtext.BackColor = Color.AntiqueWhite;
                            Cursor.Current = Cursors.Hand;
                        };
                        msgtext.MouseLeave += delegate
                        {
                            msgtext.BackColor = Color.BurlyWood;
                            Cursor.Current = Cursors.Default;
                        };

                        if (Enumerator.Current != null) Debug.WriteLine(Enumerator.Current.Id);
                    }
                }
            }
            else
            {
                var msgtext = AddMessageField(20 * 1); //Cria o campo no windows forms
                msgtext.AutoSize = false;
                msgtext.Font = new Font("Microsoft Sans Serif", 18F);
                msgtext.BackColor = Color.BurlyWood;
                msgtext.Text = @"No messages";
                msgtext.TextAlign = ContentAlignment.MiddleCenter;
                msgtext.Width = 625;
                msgtext.Height = 80;
            }
        }


        private void MessagesControl_Load(object sender, EventArgs e)
        {
        }

        private void msgtext_Click(Message msg)
        {
            //MessageBox.Show(""+msg.Id);
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.SingleMessageControl);
                var singleMessageControl = (SingleMessageControl) ParentForm.Controls[index];
                singleMessageControl.Location = new Point(185, 0);
                singleMessageControl.Message = msg;
                singleMessageControl.UpdateText();
                ParentForm.Controls[index].BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.NewMessageControl);
                var newMessageControl = (NewMessageControl) ParentForm.Controls[index];
                newMessageControl.Location = new Point(185, 0);
                newMessageControl.Person = Person;
                newMessageControl.Role = Role;
                newMessageControl.GetUsers();
                newMessageControl.EmptyTextFields();
                ParentForm.Controls[index].BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentPage <= TotalPages)
                CurrentPage = CurrentPage + 1;
            Debug.WriteLine("curr page: " + CurrentPage);
            UpdateText("next");
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 0)
                CurrentPage = CurrentPage - 1;
            UpdateText("back");
        }
    }
}