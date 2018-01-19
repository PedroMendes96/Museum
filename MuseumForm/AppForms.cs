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
        public static readonly string CreateAccount_Control = "CreateAccountControl";
        public static readonly string Dashboard_Control = "DashboardControl";
        public static readonly string Initial_Control = "InitialControl";
        public static readonly string Login_Control = "LoginControl";
        public static readonly string Schedule_Control = "ScheduleControl";
        public static readonly string Settings_Control = "SettingsControl";
        public static readonly string Exhibitions_Control = "ExhibitionsControl";
        public static readonly string ForgotPasswprd_Control = "ForgotPasswordControl";
        public static readonly string ProcessesExhibitorControl = "ProcessesExhibitorControl";
        public static readonly string EditPriceControl = "EditPriceControl";
        public static readonly string ProcessControl = "ProcessControl";
        public static readonly string AddArtPiece_Control = "AddArtPieceControl";
        public static readonly string EditProcess_Control = "EditProcessControl";
        public static readonly string ProcessesEmployee_Control = "ProcessesEmployeeControl";
        public static readonly string newProcess_Control = "NewProcess";

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

            //Isto nao pode ficar aqui
            ScheduleControl scheduleControl = new ScheduleControl();
            scheduleControl.Location = new Point(185, 0);

            SettingsControl settingsControl = new SettingsControl();
            settingsControl.Location = new Point(185, 0);

            //Isto nao pode ficar aqui
            ExhibitionsControl exhibitionsControl = new ExhibitionsControl();
            exhibitionsControl.Location = new Point(185, 0);

            ForgotPasswordControl forgotPasswordControl = new ForgotPasswordControl();
            forgotPasswordControl.Location = new Point(0, 0);

            //Isto nao pode ficar aqui
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
        }
    }
}
