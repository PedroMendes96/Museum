using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumForm
{
    public partial class AppForms : Form
    {
        public static readonly string CreateAccount_Control = nameof(CreateAccountControl);
        public static readonly string Dashboard_Control = nameof(DashboardControl);
        public static readonly string Initial_Control = nameof(InitialControl);
        public static readonly string Login_Control = nameof(LoginControl);
        public static readonly string Schedule_Control = nameof(ScheduleControl);
        public static readonly string Settings_Control = nameof(SettingsControl);
        public static readonly string Exhibitions_Control = nameof(ExhibitionsControl);
        public static readonly string ForgotPassword_Control = nameof(ForgotPasswordControl);
        public static readonly string ProcessesExhibitorControl = nameof(MuseumForm.ProcessesExhibitorControl);
        public static readonly string EditPriceControl = nameof(MuseumForm.EditPriceControl);
        public static readonly string ProcessControl = nameof(MuseumForm.ProcessControl);
        public static readonly string AddArtPiece_Control = nameof(AddArtPieceControl);
        public static readonly string EditProcess_Control = nameof(MuseumForm.EditPriceControl);
        public static readonly string ProcessesEmployee_Control = nameof(ProcessesEmployeeControl);
        public static readonly string newProcess_Control = nameof(NewProcess);
        public static readonly string Messages_Control = nameof(MessagesControl);
        public static readonly string newMessage_Control = nameof(newMessageControl);
        public static readonly string singleMessage_Control = nameof(SingleMessageControl);
        public static readonly string AddRoomControl = nameof(AddRoom);


        public AppForms()
        {
            InitializeComponent();
        }

        private void initialControl1_Load_1(object sender, EventArgs e)
        {
            
            CreateAccountControl createAccountControl = new CreateAccountControl();
            createAccountControl.Location = new Point(0, 0);

            //Isto nao pode ficar aqui
            DashboardControl dashboardControl = new DashboardControl();
            dashboardControl.Location = new Point(0, 0);

            InitialControl initialControl = new InitialControl();
            initialControl.Location = new Point(0, 0);

            LoginControl loginControl = new LoginControl();
            loginControl.Location = new Point(0, 0);

            ScheduleControl scheduleControl = new ScheduleControl();
            scheduleControl.Location = new Point(185, 0);

            SettingsControl settingsControl = new SettingsControl();
            settingsControl.Location = new Point(185, 0);

            ExhibitionsControl exhibitionsControl = new ExhibitionsControl();
            exhibitionsControl.Location = new Point(185, 0);

            ForgotPasswordControl forgotPasswordControl = new ForgotPasswordControl();
            forgotPasswordControl.Location = new Point(0, 0);

            ProcessesExhibitorControl processesExhibitorControl = new ProcessesExhibitorControl();
            processesExhibitorControl.Location = new Point(185, 0);

            EditPriceControl editPriceControl = new EditPriceControl();
            editPriceControl.Location = new Point(185, 0);

            AddArtPieceControl addArtPieceControl = new AddArtPieceControl();
            addArtPieceControl.Location = new Point(185, 0);

            EditProcessControl editProcessControl = new EditProcessControl();
            editProcessControl.Location = new Point(185, 0);

            ProcessesEmployeeControl processesEmployeeControl = new ProcessesEmployeeControl();
            processesEmployeeControl.Location = new Point(185, 0);

            NewProcess newProcessControl = new NewProcess();
            newProcessControl.Location = new Point(185,0);

            ProcessControl processControl = new ProcessControl();
            processControl.Location = new Point(185, 0);

            MessagesControl messagesControl = new MessagesControl();
            messagesControl.Location = new Point(185, 0);

            newMessageControl newMessageControl = new newMessageControl();
            newMessageControl.Location = new Point(185, 0);

            SingleMessageControl singleMessageControl = new SingleMessageControl();
            singleMessageControl.Location = new Point(185, 0);
            AddRoom addRoomControl = new AddRoom();
            addRoomControl.Location = new Point(185, 0);
            this.Controls.Add(processControl);
            this.Controls.Add(processesEmployeeControl);
            this.Controls.Add(editProcessControl);
            this.Controls.Add(editPriceControl);
            this.Controls.Add(createAccountControl);
            this.Controls.Add(forgotPasswordControl);
            this.Controls.Add(dashboardControl);
            this.Controls.Add(initialControl);
            this.Controls.Add(loginControl);
            this.Controls.Add(scheduleControl);
            this.Controls.Add(newProcessControl);
            this.Controls.Add(settingsControl);
            this.Controls.Add(exhibitionsControl);
            this.Controls.Add(processesExhibitorControl);
            this.Controls.Add(messagesControl);
            this.Controls.Add(newMessageControl);
            this.Controls.Add(singleMessageControl);
            this.Controls.Add(addArtPieceControl);
            this.Controls.Add(addRoomControl);

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
  
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
           System.Diagnostics.Trace.WriteLine( "Paint");
        }

    }
}
