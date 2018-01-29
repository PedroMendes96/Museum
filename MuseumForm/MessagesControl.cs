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
        private readonly IList<Label> msgsText = new List<Label>();
        public IEnumerator<Message> enumerator;
        private int tcounter = 0;

        public MessagesControl()
        {
            InitializeComponent();
        }


        public string Role { get; set; }

        public Person Person { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }


        public Label addMessageField(int y)
        {
            var msgtext = new Label();
            msgtext.AutoSize = true;
            msgtext.BackColor = Color.BurlyWood;
            msgtext.Font = new Font("Microsoft Sans Serif", 14F);
            msgtext.Location = new Point(133, 140 + y);
            msgtext.Size = new Size(64, 20);
            Controls.Add(msgtext);
            msgsText.Add(msgtext);
            msgtext.BringToFront();
            return msgtext;
        }

        public void ResetView() // função que volta a mostrar as mensagens inicialmente (da mais recente para a menos)
        {
            BringToFront();
            Person.getMessages();
            messageSentLabel.Visible = false;
            TotalPages = Person.GetMaxMessagesPages();
            enumerator = Person.Notifications.GetEnumerator();
            CurrentPage = 1;
            UpdateText("initial");
        }

        public void UpdateText(string operation)
        {
            headTitle.Text = "My Messages: " + Person.Name;
            nrlabel.Text = CurrentPage.ToString();
            if (operation == "initial")
                showMessages("initial");
            else if (operation == "next")
                showMessages("next");
            else
                showMessages("back");

            if (CurrentPage == TotalPages || TotalPages == 0)
                nextbutton.Visible = false;
            else
                nextbutton.Visible = true;

            if (CurrentPage == 1)
                backButton.Visible = false;
            else
                backButton.Visible = true;
        }

        public void EmptyTextFields()
        {
            var label = msgsText.GetEnumerator();
            label.Reset();
            while (label.MoveNext())
            {
                Debug.WriteLine(label.Current.Text);

                label.Current.Dispose(); //destroy os msgs texts
            }
        }

        public void MessageSentNotification()
        {
            Timer timer;
            messageSentLabel.Visible = true;
            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            messageSentLabel.Visible = false;
        }

        private void showMessages(string operation)
        {
            if (operation == "next" || operation == "initial")
            {
                var c = 0;
                var nr_msg = Person.Notifications.Count;
                Debug.WriteLine("totalpages:" + TotalPages + " nr_msgs: " + nr_msg);
                Debug.WriteLine("currentpg: " + CurrentPage);
                if (nr_msg > 0)
                {
                    if (CurrentPage == TotalPages)
                        nr_msg = nr_msg - 5 * (TotalPages - 1);
                    else
                        nr_msg = 5;
                    EmptyTextFields();
                    while (c < nr_msg)
                    {
                       addMessage(c);
                       Debug.WriteLine("msg displayed:" + c);
                       enumerator.MoveNext();
                       c++;
                    }
                }
                else
                {
                    EmptyTextFields();
                    addMessage(0);
                }
            }
            else
            {
                if (operation == "back")
                {
                    var PrevPage = CurrentPage + 1;
                    var indexLastMsgShown = 0;
                    indexLastMsgShown = PrevPage * 5 - 1;
                    var msgList = Person.Notifications;
                    Debug.WriteLine("index of: " + indexLastMsgShown);
                    enumerator.Reset();
                    while (enumerator.Current != msgList[indexLastMsgShown - 9])
                        enumerator.MoveNext();
                    Debug.WriteLine(enumerator.Current.LastUpdate);

                    var c = 0;
                    var nr_msg = Person.Notifications.Count;
                    Debug.WriteLine("totalpages:" + TotalPages + " nr_msgs: " + nr_msg);
                    Debug.WriteLine("currentpg: " + CurrentPage);
                    if (nr_msg > 0)
                    {
                        nr_msg = 5;
                        EmptyTextFields();
                        while (c < nr_msg)
                        {
                            addMessage(c);
                            Debug.WriteLine("msg displayed:" + c);
                            enumerator.MoveNext();
                            c++;
                        }
                    }
                }
            }
        }


        private void addMessage(int c)
        {
            if (enumerator.Current == null) // caso inicial quando ainda n foi efetuado o primeiro movenext
            {
                enumerator.MoveNext();
            }
            var msg = enumerator.Current;
            var nr_msg = Person.Notifications.Count;
            if (nr_msg > 0)
            {
                Debug.WriteLine("nr_msg: " + nr_msg);
                var so = SqlOperations.Instance;
                var db = DBConnection.Instance;
                string[] selvals = {"lastUpdate"};
                string[] tables = {"messages"};
                string[] keys = {"id"};
                string[] values = {msg.Id.ToString()};
                var select = so.Select(selvals, tables, keys, values);
                var list = db.Query(select);
                string lastUpdate = null;
                foreach (var msgdict in list)
                {

                    var da = new DictionaryAdapter(msgdict);
                    lastUpdate = da.GetValue("lastUpdate");
                }

                if (lastUpdate != null)
                {
                    var msgtext = addMessageField(80 * c); //Cria o campo do label no windows forms
                    msgtext.AutoSize = false;
                    msgtext.BorderStyle = BorderStyle.FixedSingle;
                    msgtext.BackColor = Color.BurlyWood;
                    msgtext.Text = "Title: " + msg.Title + Environment.NewLine + "From: " +
                                   msg.Sender.Name +
                                   " - Received at: " + lastUpdate;


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

                    Debug.WriteLine(enumerator.Current.Id);
                }
            }
            else
            {
                var msgtext = addMessageField(20 * 1); //Cria o campo no windows forms
                msgtext.AutoSize = false;
                msgtext.Font = new Font("Microsoft Sans Serif", 18F);
                msgtext.BackColor = Color.BurlyWood;
                msgtext.Text = "No messages";
                msgtext.TextAlign = ContentAlignment.MiddleCenter;
                msgtext.Width = 625;
                msgtext.Height = 80;
            }
        }


        private void MessagesControl_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void msgtext_Click(Message msg)
        {
            //MessageBox.Show(""+msg.Id);
            var index = ParentForm.Controls.IndexOfKey(AppForms.singleMessage_Control);
            var singleMessageControl = (SingleMessageControl) ParentForm.Controls[index];
            singleMessageControl.Location = new Point(185, 0);
            singleMessageControl.Message = msg;
            singleMessageControl.UpdateText();
            ParentForm.Controls[index].BringToFront();
        }

        private void msgtext_MouseHover()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.newMessage_Control);
            var newMessageControl = (NewMessageControl) ParentForm.Controls[index];
            newMessageControl.Location = new Point(185, 0);
            newMessageControl.Person = Person;
            newMessageControl.Role = Role;
            newMessageControl.getUsers();
            newMessageControl.EmptyTextFields();
            ParentForm.Controls[index].BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorCountItem_Click(object sender, EventArgs e)
        {
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

        private void button1_MouseHover(object sender, EventArgs e)
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