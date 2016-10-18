using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.IO;

namespace ServiceWatchdog.Models
{
    public class WinServices
    {
        public static string GetServiceStatus(string ServiceName, string Machine = "LOCALHOST") //Use this function to poll a machine for a service status
        {
            ServiceController sc = new ServiceController(ServiceName, Machine);

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "RUNNING";
                case ServiceControllerStatus.Stopped:
                    return "STOPPED";
                case ServiceControllerStatus.Paused:
                    return "PAUSED";
                case ServiceControllerStatus.StopPending:
                    return "STOPPING";
                case ServiceControllerStatus.StartPending:
                    return "STARTING";
                default:
                    return "STATUS CHANGING";
            }
        }

        public static List<string> CheckServices(List<Service> Services)
        {
            List<string> _status = new List<string>();

            foreach (Service service in Services)
            {
                service.CheckStatus();
                _status.Add(service.MACHINENAME + " : '" + service.SERVICENAME + "' is '" + service.STATUS + "' as of " + service.LASTCHECKED.ToString());
            }

            return _status;
        } //Use this function to poll all services in a list, generally on a timer

        public static List<Service> EnumerateServices(string[] ServiceArray)
        {
            List<Service> _services = new List<Service>();

            foreach (string service in ServiceArray)
            {
                try
                {
                    string[] fields = service.Split(',');
                    _services.Add(new Service(fields[1], fields[0])); //Assumes the following format -- MACHINENAME,SERVICENAME
                }
                catch { }
            }

            return _services;
        } //Use this function to create a List of Service objects from a string array (e.g. Multiline Textbox)

        public static void GenerateAlerts(List<Service> Services)
        {
            foreach (Service service in Services)
            {
                int MinutesSinceLastAlert = (int)DateTime.Now.Subtract(service.LASTALERT).TotalMinutes;

                if (service.ACTIVE && service.STATUS != "RUNNING" && (MinutesSinceLastAlert > service.HOLDDOWNTIMER) && !service.MUTED)
                {
                    service.SendAlertDown();
                    service.LASTALERT = DateTime.Now;
                }

                if (service.RECOVERED)
                    service.SendAlertUp();
            }
        }

        public static List<Service> LoadServicesFromFile(string Filename)
        {
            List<Service> _services = new List<Service>();

            try
            {
                if(File.Exists(Filename))
                {
                    string[] lines = File.ReadAllLines(Filename);
                    foreach(string line in lines)
                    {
                        if(!line.Contains('#'))
                        {
                            string[] fields = line.Split(',');
                            try
                            {
                                _services.Add(new Service(fields[1], fields[0], true, fields[2], fields[3], fields[4], Convert.ToInt32(fields[5])));
                            }
                            catch { }
                        }
                    }
                }

            }
            catch { }

            return _services;
        }
    }

    public class Service
    {
        public string MACHINENAME { get; set; } //Reachable Name of the machine (IP, NETBIOS, DNS, etc.)
        public string SERVICENAME { get; set; } //Actual Service name
        public string STATUS { get; set; }
        public bool ACTIVE { get; set; }
        public DateTime LASTCHECKED { get; set; }
        public DateTime LASTALERT { get; set; }
        public bool CHANGED { get; set; }
        public string SMTPRELAY { get; set; }
        public string ALERTADDRESS { get; set; }
        public string FROMADDRESS { get; set; }
        public int HOLDDOWNTIMER { get; set; }
        public bool MUTED { get; set; }
        public bool RECOVERED { get; set; }

        public Service(string ServiceName, string MachineName = "LOCALHOST", bool Active = true, string SMTPRelay = "relay.lsnj.org", string AlertAddress = "reodice@lsnj.org", string FromAddress = "alerts@lsnj.org", int HolddownTimer = 60, bool Muted = false)
        {
            SERVICENAME = ServiceName;
            MACHINENAME = MachineName;
            STATUS = WinServices.GetServiceStatus(SERVICENAME, MACHINENAME);
            LASTCHECKED = DateTime.Now;
            ACTIVE = Active;
            SMTPRELAY = SMTPRelay;
            ALERTADDRESS = AlertAddress;
            FROMADDRESS = FromAddress;
            HOLDDOWNTIMER = HolddownTimer;
            MUTED = Muted;
            RECOVERED = false;
        }

        public void CheckStatus()
        {
            string NEWSTATUS = WinServices.GetServiceStatus(SERVICENAME, MACHINENAME);

            if (STATUS != "RUNNING" && NEWSTATUS == "RUNNING")
                RECOVERED = true;

            if (STATUS != NEWSTATUS)
                CHANGED = true;
            else
                CHANGED = false;

            STATUS = NEWSTATUS;
            LASTCHECKED = DateTime.Now;
        }

        public void SendAlertDown()
        {
            if(ACTIVE)
            {
                string Subject = MACHINENAME + " : " + SERVICENAME + " is " + STATUS;
                string Body = MACHINENAME + " : " + SERVICENAME + " is " + STATUS;

                EmailHelper.SendEmail(FROMADDRESS, ALERTADDRESS, SMTPRELAY, Subject, Body);
                LASTALERT = DateTime.Now;
            }
        }

        public void SendAlertUp()
        {
            if (ACTIVE)
            {
                string Subject = MACHINENAME + " : " + SERVICENAME + " is " + STATUS;
                string Body = MACHINENAME + " : " + SERVICENAME + " is " + STATUS;

                EmailHelper.SendEmail(FROMADDRESS, ALERTADDRESS, SMTPRELAY, Subject, Body);
                RECOVERED = false;
            }
        }

    }
}
