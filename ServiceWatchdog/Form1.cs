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
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Service> _services = WinServices.EnumerateServices(tbServicesToMonitor.Lines);
            lbServiceStatus.Items.AddRange(WinServices.CheckServices(_services).ToArray());
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            List<Service> _services = WinServices.EnumerateServices(tbServicesToMonitor.Lines);

            lbServiceStatus.Items.Clear();
            lbServiceStatus.Items.AddRange(WinServices.CheckServices(_services).ToArray());
        }

        
        
    }
}
