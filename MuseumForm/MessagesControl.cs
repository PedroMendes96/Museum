﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class MessagesControl : UserControl
    {
        private int currentPage = 1;
        private int totalPages = 0;
        private int tcounter = 0;
        private Person person;
        private IList<Label> msgsText = new List<Label>();

        public IEnumerator<Museum.Message> enumerator;

        public Label MessageSentLabel
        {
            get => messageSentLabel;
        }

        public Person Person
        {
            get => person;
            set => person = value;
        }

        public int CurrentPage
        {
            get => currentPage;
            set => currentPage = value;
        }

        public int TotalPages
        {
            get => totalPages;
            set => totalPages = value;
        }
        public MessagesControl()
        {
            InitializeComponent();

        }

       
        public Label addMessageField(int y)
        {
           
            Label msgtext = new Label();
            msgtext.AutoSize = true;
            msgtext.BackColor = System.Drawing.Color.BurlyWood;
            msgtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            msgtext.Location = new System.Drawing.Point(133,140 +y);
            msgtext.Size = new System.Drawing.Size(64, 20);
            this.Controls.Add(msgtext);
            msgsText.Add(msgtext);
            msgtext.BringToFront();
            return msgtext;

        }

        public void ResetView() // função que volta a mostrar as mensagens inicialmente (da mais recente para a menos)
        {
            BringToFront();
            Person.getMessages();
            MessageSentLabel.Visible = false;
            TotalPages = Person.GetMaxMessagesPages();
            enumerator = Person.Notifications.GetEnumerator();
            CurrentPage = 1;
            UpdateText("initial");
        }

        public void UpdateText(string operation)
        {     
            headTitle.Text = "My Messages: " +Person.Name;
            nrlabel.Text = CurrentPage.ToString();
            if (operation == "initial")
            {
                showMessages("initial");
            } else if (operation == "next")
            {
                showMessages("next");
            }
            else
            {
                showMessages("back");
            }

            if (CurrentPage == TotalPages || TotalPages == 0)
            {
                nextbutton.Visible = false;

            }
            else
            {
                nextbutton.Visible = true;
            }

            if (CurrentPage == 1)
            {
                backButton.Visible = false;
            }
            else
            {
                backButton.Visible = true;
            }

        }

        public void EmptyTextFields()
        {
            var label = msgsText.GetEnumerator();
            label.Reset();
              while (label.MoveNext())
              {
                Debug.WriteLine(label.Current.Text);
                
                  label.Current.Dispose();//destroy os msgs texts

              }
        }

        public void MessageSentNotification()
        {
            Timer timer;
            MessageSentLabel.Visible = true;
            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            MessageSentLabel.Visible = false;
        }

        private void showMessages(string operation)
        {
            if (operation == "next" || operation == "initial")
            {
                int c = 0;
                int nr_msg = (int) Person.Notifications.Count;
                Debug.WriteLine("totalpages:" + totalPages + " nr_msgs: " + nr_msg);
                Debug.WriteLine("currentpg: " + CurrentPage);
                if (nr_msg > 0)
                {
                    if (CurrentPage == TotalPages)
                    {
                        nr_msg = (nr_msg) - (5 * (TotalPages - 1));
                    }
                    else
                    {
                        nr_msg = 5;
                    }
                    EmptyTextFields();
                    while (c < nr_msg)
                    {

                        if (true)
                        {
                            addMessage(c);
                            Debug.WriteLine("msg displayed:" + c);
                        }
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
                    indexLastMsgShown = (PrevPage * 5) - 1;
                    var msgList = Person.Notifications;
                    Debug.WriteLine("index of: " + indexLastMsgShown);
                    enumerator.Reset();
                    while (enumerator.Current != msgList[indexLastMsgShown - 9])
                    {
                        enumerator.MoveNext();
                    }
                    Debug.WriteLine(enumerator.Current.LastUpdate);

                    int c = 0;
                    int nr_msg = (int)Person.Notifications.Count;
                    Debug.WriteLine("totalpages:" + totalPages + " nr_msgs: " + nr_msg);
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
            if (enumerator.Current == null)// caso inicial quando ainda n foi efetuado o primeiro movenext
            {
                enumerator.MoveNext();
            }
            Museum.Message msg = enumerator.Current;
            int nr_msg = (int)Person.Notifications.Count;
            if (nr_msg > 0)
            {
            Debug.WriteLine("nr_msg: "+nr_msg);
            SqlOperations so = Museum.SqlOperations.Instance;
            DBConnection db = DBConnection.Instance;
            string[] selvals = { "lastUpdate" };
            string[] tables = { "messages" };
            string[] keys = { "id" };
            string[] values = { msg.Id.ToString() };
            string select = so.Select(selvals, tables, keys, values);
            IList<Dictionary<string, string>> list = db.Query(select);
            string lastUpdate = null;
            foreach (Dictionary<string, string> msgdict in list)
            {
                DictonaryAdapter da = new DictonaryAdapter(msgdict);
                lastUpdate = da.GetValue("lastUpdate");
            }

                if (lastUpdate != null)
                {
                    Label msgtext = addMessageField(80 * c); //Cria o campo do label no windows forms
                    msgtext.AutoSize = false;
                    msgtext.BorderStyle = BorderStyle.FixedSingle;
                    msgtext.BackColor = Color.BurlyWood;
                    msgtext.Text = "Title: " + msg.Title + Environment.NewLine + "From:" + msg.Sender.Name +
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
                Label msgtext = addMessageField(20 * 1); //Cria o campo no windows forms
                msgtext.AutoSize = false;
                msgtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
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

        private void msgtext_Click(Museum.Message msg)
        {
            //MessageBox.Show(""+msg.Id);
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.singleMessage_Control);
            SingleMessageControl singleMessageControl = (SingleMessageControl) this.ParentForm.Controls[index];
            singleMessageControl.Location = new Point(185, 0);
            singleMessageControl.Message = msg;
            singleMessageControl.UpdateText();
            this.ParentForm.Controls[index].BringToFront();
        }

        private void msgtext_MouseHover()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.newMessage_Control);
            newMessageControl newMessageControl = (newMessageControl)this.ParentForm.Controls[index];
            newMessageControl.Location = new Point(185, 0);
            newMessageControl.Person = Person;   
            newMessageControl.getUsers();
            newMessageControl.EmptyTextFields();
            this.ParentForm.Controls[index].BringToFront();
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
            {
                CurrentPage = CurrentPage + 1;
            }
            Debug.WriteLine("curr page: "+CurrentPage);
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
            {
                CurrentPage = CurrentPage - 1;
            }
            UpdateText("back");
        }
    }
}
