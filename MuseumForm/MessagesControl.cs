using System;
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
            msgtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            msgtext.Text = "";
            msgtext.Location = new System.Drawing.Point(200,165+y);
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
            UpdateText();
        }

        public void UpdateText()
        {
            
       
            headTitle.Text = "My Messages: " +Person.Name;
            nrlabel.Text = CurrentPage.ToString();
            
            showMessages();

            if (CurrentPage == TotalPages || TotalPages == 0)
            {
                nextbutton.Visible = false;
            }
            else
            {
                nextbutton.Visible = true;
            }

        }

        public void EmptyTextFields()
        {
            var label = msgsText.GetEnumerator();
            label.Reset();
              while (label.MoveNext())
              {
                Debug.WriteLine(label.Current.Text);
                label.Current.BackColor = Color.BurlyWood;
                label.Current.Text = null; //Limpa o texto dos campos com as msgs
              }
        }

        private void showMessages()
        {

            int c = 0;
            int nr_msg = (int) Person.Notifications.Count;
            Debug.WriteLine("totalpages:" + totalPages + " nr_msgs: " + nr_msg);
            Debug.WriteLine("currentpg: "+CurrentPage);
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
                    if (enumerator.MoveNext())
                    {
                        addMessage(c);
                        Debug.WriteLine("msg displayed:" + c);
                    }
                    c++;
                }
            }
            else
            {
                EmptyTextFields();
                addMessage(0);
              
            }
        }

        private void addMessage(int c)
        {
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
                    Label msgtext = addMessageField(70 * c); //Cria o campo do label no windows forms
                    msgtext.AutoSize = false;
                    msgtext.BackColor = Color.LightSalmon;
                    msgtext.Text = "Title: " + msg.Title + Environment.NewLine + "From:" + msg.Sender.Name +
                                   " - Received at: " + lastUpdate;

                    msgtext.TextAlign = ContentAlignment.MiddleCenter;
                    msgtext.Width = 500;
                    msgtext.Height = 45;
                    msgtext.Click += delegate { msgtext_Click(msg); };
                    Debug.WriteLine(enumerator.Current.Id);
                }
            }
            else
            {
                Label msgtext = addMessageField(70 * c); //Cria o campo no windows forms
                msgtext.AutoSize = false;
                msgtext.BackColor = Color.BurlyWood;
                msgtext.Text = "No messages";
                msgtext.TextAlign = ContentAlignment.MiddleCenter;
                msgtext.Width = 500;
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
            UpdateText();
           
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
  
    }
}
