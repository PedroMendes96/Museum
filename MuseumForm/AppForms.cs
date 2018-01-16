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
        public static readonly string Exhibitions_Control = "Exhibitions";
        public AppForms()
        {
            InitializeComponent();
        }

        private void initialControl1_Load(object sender, EventArgs e)
        {
            CreateAccountControl createAccountControl = new CreateAccountControl();
            createAccountControl.Location = new Point(0, 0);

            DashboardControl dashboardControl = new DashboardControl();
            dashboardControl.Location = new Point(0, 0);

            InitialControl initialControl = new InitialControl();
            initialControl.Location = new Point(0, 0);

            LoginControl loginControl = new LoginControl();
            loginControl.Location = new Point(0, 0);

            ScheduleControl scheduleControl = new ScheduleControl();
            scheduleControl.Location = new Point(185,0);

            SettingsControl settingsControl = new SettingsControl();
            settingsControl.Location = new Point(185, 0);

            ExhibitionsControl exhibitionsControl = new ExhibitionsControl();
            exhibitionsControl.Location = new Point(185, 0);

            this.Controls.Add(createAccountControl);
            this.Controls.Add(dashboardControl);
            this.Controls.Add(initialControl);
            this.Controls.Add(loginControl);
            this.Controls.Add(scheduleControl);
            this.Controls.Add(settingsControl);
            this.Controls.Add(exhibitionsControl);
        }
    }
}
