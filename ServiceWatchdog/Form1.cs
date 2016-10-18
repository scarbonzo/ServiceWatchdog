using ServiceWatchdog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceWatchdog
{
    public partial class Form1 : Form
    {
        public List<Service> Services = new List<Service>(); //Global list of services

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            //BulkStatusCheck(tbServicesToMonitor.Lines);

            lvServiceStatus.Items.Clear(); //Clear the status list

            //Update the status list
            foreach (string service in WinServices.CheckServices(Services).ToArray()) //Iterate through the services
                lvServiceStatus.Items.Add(service); //Add each result to the listview

            for (int i = 0; i < lvServiceStatus.Items.Count; i++) //Color the status list
            {
                if (lvServiceStatus.Items[i].ToString().Contains("RUNNING")) //If the service is running, color it green, else white text with a red background
                {
                    lvServiceStatus.Items[i].BackColor = Color.White;
                    lvServiceStatus.Items[i].ForeColor = Color.Green;
                }
                else
                {
                    lvServiceStatus.Items[i].BackColor = Color.Red;
                    lvServiceStatus.Items[i].ForeColor = Color.White;
                }
            }

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if(timerUpdate.Enabled)
            { //If running stop everything and enable editing
                tbServicesToMonitor.Enabled = true; //Enable editing
                btnStartStop.Text = "Start"; //Change the button text to start
                timerUpdate.Enabled = false; //Stop the update timer
            }
            else
            { //If not running start everything and prevent editing
                Services = WinServices.EnumerateServices(tbServicesToMonitor.Lines); //Enumerate the services
                tbServicesToMonitor.Enabled = false; //Disable editing
                btnStartStop.Text = "Stop"; //Change the button text to stop
                timerUpdate.Enabled = true; //Start the update timer
            }
        }

        private void timerAlert_Tick(object sender, EventArgs e)
        {
            WinServices.GenerateAlerts(Services); //Send alerts as necessary
        }

        private void cbAlerts_CheckedChanged(object sender, EventArgs e)
        {
            timerAlert.Enabled = cbAlerts.Checked; //Enable and disable alerting based on checkbox status
        }
    }
}
