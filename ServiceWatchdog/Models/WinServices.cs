using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

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
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                default:
                    return "Status Changing";
            }
        }

        public static List<string> CheckServices(List<Service> Services)
        {
            List<string> _status = new List<string>();

            foreach (Service service in Services)
            {
                service.CheckStatus();
                _status.Add(service.MACHINENAME + " : " + service.SERVICENAME + " is " + service.STATUS);
            }

            return _status;
        } //Use this function to poll all services in a list, generally on a timer

        public static List<Service> EnumerateServices(string[] ServiceArray)
        {
            List<Service> _services = new List<Service>();

            foreach (string service in ServiceArray)
            {
                string[] fields = service.Split(',');
                _services.Add(new Service(fields[1], fields[0])); //Assumes the following format -- MACHINENAME,SERVICENAME
            }

            return _services;
        } //Use this function to create a List of Service objects from a string array (e.g. Multiline Textbox)
    }

    public class Service
    {
        public string MACHINENAME { get; set; } //Reachable Name of the machine (IP, NETBIOS, DNS, etc.)
        public string SERVICENAME { get; set; } //Actual Service name
        public string STATUS { get; set; }

        public Service(string ServiceName, string MachineName = "LOCALHOST")
        {
            SERVICENAME = ServiceName;
            MACHINENAME = MachineName;
            STATUS = WinServices.GetServiceStatus(SERVICENAME, MACHINENAME);
        }

        public void CheckStatus()
        {
            STATUS = WinServices.GetServiceStatus(SERVICENAME, MACHINENAME);
        }


    }
}
