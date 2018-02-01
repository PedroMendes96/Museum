using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MuseumForm
{
    public partial class AppForms : Form
    {
        public static readonly string CreateAccountControl = nameof(MuseumForm.CreateAccountControl);
        public static readonly string DashboardControl = nameof(MuseumForm.DashboardControl);
        public static readonly string InitialControl = nameof(MuseumForm.InitialControl);
        public static readonly string LoginControl = nameof(MuseumForm.LoginControl);
        public static readonly string ScheduleControl = nameof(MuseumForm.ScheduleControl);
        public static readonly string SettingsControl = nameof(MuseumForm.SettingsControl);
        public static readonly string ExhibitionsControl = nameof(MuseumForm.ExhibitionsControl);
        public static readonly string ForgotPasswordControl = nameof(MuseumForm.ForgotPasswordControl);
        public static readonly string ProcessesExhibitorControl = nameof(MuseumForm.ProcessesExhibitorControl);
        public static readonly string EditPriceControl = nameof(MuseumForm.EditPriceControl);
        public static readonly string ProcessControl = nameof(MuseumForm.ProcessControl);
        public static readonly string AddArtPieceControl = nameof(MuseumForm.AddArtPieceControl);
        public static readonly string EditProcessControl = nameof(MuseumForm.EditProcessControl);
        public static readonly string ProcessesEmployeeControl = nameof(MuseumForm.ProcessesEmployeeControl);
        public static readonly string NewProcessControl = "NewProcess";
        public static readonly string MessagesControl = nameof(MuseumForm.MessagesControl);
        public static readonly string NewMessageControl = nameof(MuseumForm.NewMessageControl);
        public static readonly string SingleMessageControl = nameof(MuseumForm.SingleMessageControl);
        public static readonly string AddRoomControl = "AddRoom";
        public static readonly string EmployeesControl = nameof(MuseumForm.EmployeesControl);
        public static readonly string NewEmployeeControl = nameof(MuseumForm.NewEmployeeControl);
        public static readonly string SingleEmployeeControl = nameof(MuseumForm.SingleEmployeeControl);

        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public new void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
            }
        }

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
            //
            //            Debug.WriteLine(addRoomControl.Name);
            //            Debug.WriteLine(AddRoomControl);

            var createAccountControl = new CreateAccountControl {Location = new Point(0, 0)};

            var dashboardControl = new DashboardControl {Location = new Point(0, 0)};

            var initialControl = new InitialControl {Location = new Point(0, 0)};

            var loginControl = new LoginControl {Location = new Point(0, 0)};

            var scheduleControl = new ScheduleControl {Location = new Point(185, 0)};

            var settingsControl = new SettingsControl {Location = new Point(185, 0)};

            var exhibitionsControl = new ExhibitionsControl {Location = new Point(185, 0)};

            var forgotPasswordControl = new ForgotPasswordControl {Location = new Point(0, 0)};

            var processesExhibitorControl = new ProcessesExhibitorControl {Location = new Point(185, 0)};

            var editPriceControl = new EditPriceControl {Location = new Point(185, 0)};

            var addArtPieceControl = new AddArtPieceControl {Location = new Point(185, 0)};

            var editProcessControl = new EditProcessControl {Location = new Point(185, 0)};

            var processesEmployeeControl = new ProcessesEmployeeControl {Location = new Point(185, 0)};

            var newProcessControl = new NewProcessControl {Location = new Point(185, 0)};

            var processControl = new ProcessControl {Location = new Point(185, 0)};

            var messagesControl = new MessagesControl {Location = new Point(185, 0)};

            var newMessageControl = new NewMessageControl {Location = new Point(185, 0)};

            var singleMessageControl = new SingleMessageControl {Location = new Point(185, 0)};

            var addRoomControl = new AddRoomControl {Location = new Point(185, 0)};

            var employeesControl = new EmployeesControl {Location = new Point(185, 0)};

            var newEmployeeControl = new NewEmployeeControl {Location = new Point(185, 0)};

            var singleEmployeeControl = new SingleEmployeeControl {Location = new Point(185, 0)};

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
            Controls.Add(newEmployeeControl);
            Controls.Add(singleEmployeeControl);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Trace.WriteLine("Paint");
        }


    }
}