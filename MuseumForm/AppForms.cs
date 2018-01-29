using System;
using System.Diagnostics;
using System.Drawing;
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
        public static readonly string Employees_Control = nameof(EmployeesControl);


        public AppForms()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void initialControl1_Load_1(object sender, EventArgs e)
        {
            var createAccountControl = new CreateAccountControl();
            createAccountControl.Location = new Point(0, 0);

            var dashboardControl = new DashboardControl();
            dashboardControl.Location = new Point(0, 0);

            var initialControl = new InitialControl();
            initialControl.Location = new Point(0, 0);

            var loginControl = new LoginControl();
            loginControl.Location = new Point(0, 0);

            var scheduleControl = new ScheduleControl();
            scheduleControl.Location = new Point(185, 0);

            var settingsControl = new SettingsControl();
            settingsControl.Location = new Point(185, 0);

            var exhibitionsControl = new ExhibitionsControl();
            exhibitionsControl.Location = new Point(185, 0);

            var forgotPasswordControl = new ForgotPasswordControl();
            forgotPasswordControl.Location = new Point(0, 0);

            var processesExhibitorControl = new ProcessesExhibitorControl();
            processesExhibitorControl.Location = new Point(185, 0);

            var editPriceControl = new EditPriceControl();
            editPriceControl.Location = new Point(185, 0);

            var addArtPieceControl = new AddArtPieceControl();
            addArtPieceControl.Location = new Point(185, 0);

            var editProcessControl = new EditProcessControl();
            editProcessControl.Location = new Point(185, 0);

            var processesEmployeeControl = new ProcessesEmployeeControl();
            processesEmployeeControl.Location = new Point(185, 0);

            var newProcessControl = new NewProcess();
            newProcessControl.Location = new Point(185, 0);

            var processControl = new ProcessControl();
            processControl.Location = new Point(185, 0);

            var messagesControl = new MessagesControl();
            messagesControl.Location = new Point(185, 0);

            var newMessageControl = new newMessageControl();
            newMessageControl.Location = new Point(185, 0);

            var singleMessageControl = new SingleMessageControl();
            singleMessageControl.Location = new Point(185, 0);

            var addRoomControl = new AddRoom();
            addRoomControl.Location = new Point(185, 0);

            var employeesControl = new EmployeesControl();
            employeesControl.Location = new Point(185, 0);

            Controls.Add(processControl);
            Controls.Add(processesEmployeeControl);
            Controls.Add(editProcessControl);
            Controls.Add(editPriceControl);
            Controls.Add(createAccountControl);
            Controls.Add(forgotPasswordControl);
            Controls.Add(dashboardControl);
            Controls.Add(initialControl);
            Controls.Add(loginControl);
            Controls.Add(scheduleControl);
            Controls.Add(newProcessControl);
            Controls.Add(settingsControl);
            Controls.Add(exhibitionsControl);
            Controls.Add(processesExhibitorControl);
            Controls.Add(messagesControl);
            Controls.Add(newMessageControl);
            Controls.Add(singleMessageControl);
            Controls.Add(addArtPieceControl);
            Controls.Add(addRoomControl);
            Controls.Add(employeesControl);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Trace.WriteLine("Paint");
        }
    }
}