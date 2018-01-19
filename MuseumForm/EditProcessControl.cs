using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class EditProcessControl : UserControl
    {
        public Process process;
        public EditProcessControl()
        {
            InitializeComponent();
        }

        private void onChange(object sender, EventArgs e)
        {
            if (properties.Text.Equals("Name") || properties.Text.Equals("Description") || properties.Text.Equals("Title"))
            {
                newValue.Visible = true;

                startBox.Visible = false;
                endBox.Visible = false;

                day.Visible = false;
                month.Visible = false;
                year.Visible = false;

            }
            else if (properties.Text.Equals("From") || properties.Text.Equals("Until"))
            {
                newValue.Visible = false;

                startBox.Visible = true;
                endBox.Visible = true;

                day.Visible = false;
                month.Visible = false;
                year.Visible = false;
            }
            else if (properties.Text == "Schedule")
            {
                newValue.Visible = false;

                startBox.Visible = false;
                endBox.Visible = false;

                day.Visible = true;
                month.Visible = true;
                year.Visible = true;
            }
        }

        private void UpdateProcess_Click(object sender, EventArgs e)
        {
            if (properties.Text.Equals("Name") || properties.Text.Equals("Description") || properties.Text.Equals("Title"))
            {
                if (!newValue.Text.Trim().Equals(""))
                {
                    var sql = "UPDATE processes SET ";
                    if (properties.Text.Equals("Name"))
                    {
                        sql += "name=";
                    }
                    else if (properties.Text.Equals("Description"))
                    {
                        sql += "description=";
                    }
                    else if (properties.Text.Equals("Title"))
                    {
                        sql += "title=";
                    }
                    sql += newValue.Text + " WHERE id=" + process.Id;
                    DBConnection.Instance.Execute(sql);
                }
            }
            else if (properties.Text.Equals("From") || properties.Text.Equals("Until"))
            {
                if (endBox.Text != null || startBox != null)
                {
                    var sql = "UPDATE schedules SET ";
                    if (properties.Text.Equals("From"))
                    {
                        sql += "startDay=" + day + " startMonth=" + month + " startYear=" + year;
                    }
                    else if (properties.Text.Equals("Until"))
                    {
                        sql += "endDay=" + day + " endMonth=" + month + " endYear=" + year;
                    }
                    sql += " WHERE id=" + process.Schedule.Id;
                    DBConnection.Instance.Execute(sql);
                }
            }
            else if (properties.Text == "Schedule")
            {
                var sql = "UPDATE schedules SET startTime="+startBox.Text+" endTime="+endBox.Text+ " WHERE id=" + process.Schedule.Id;
                DBConnection.Instance.Execute(sql);
            }
        }
    }
}
