using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail; //For Email Functionality

namespace ServiceWatchdog.Models
{
    class ADHelper
    {

        public static DataTable SearchEventLogsForLockouts(string[] DomainControllers, DateTime LastScan)
        {
            DataTable table = new DataTable(); //Build a table to house the results
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("User");
            table.Columns.Add("Machine");
            table.Columns.Add("DC");

            foreach (string dc in DomainControllers)
            {
                EventLogQuery eventsQuery = new EventLogQuery("Security", PathType.LogName, "*[System/EventID=4740]"); //Create an eventlog query to find 4740 events in the security log
                EventLogSession session = new EventLogSession(dc); //Create an eventlog session on the target machine
                eventsQuery.Session = session; //Invoke the session

                try
                {
                    EventLogReader logReader = new EventLogReader(eventsQuery); //start the eventlog reader

                    for (EventRecord eventdetail = logReader.ReadEvent(); eventdetail != null; eventdetail = logReader.ReadEvent()) //foreach the results of the reader
                    {
                        if (eventdetail.TimeCreated > LastScan) //find entries newer than the date specified
                        {
                            table.Rows.Add(eventdetail.TimeCreated, eventdetail.Properties[0].Value, eventdetail.Properties[1].Value, eventdetail.MachineName); //add the specific columns to the table
                        }
                    }
                }
                catch { }
            }
            return table; //return the table
        }
    }

    class EmailHelper
    {
        public static void SendEmail(string From, string To, string CC, string SMTPServer, string Subject, string HTMLBody)
        {
            SmtpClient SmtpClient = new SmtpClient(SMTPServer);
            MailAddress from = new MailAddress(From);
            MailAddress to = new MailAddress(To);
            MailAddress cc = new MailAddress(CC);
            MailMessage message = new System.Net.Mail.MailMessage(from, to);
            message.CC.Add(cc);
            message.Subject = Subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Body = HTMLBody;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient.Send(message);
        }
        public static void SendEmail(string From, string To, string SMTPServer, string Subject, string HTMLBody)
        {
            SmtpClient SmtpClient = new SmtpClient(SMTPServer);
            MailAddress from = new MailAddress(From);
            MailAddress to = new MailAddress(To);
            MailMessage message = new System.Net.Mail.MailMessage(from, to);
            message.Subject = Subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Body = HTMLBody;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient.Send(message);
        }
    }
}
