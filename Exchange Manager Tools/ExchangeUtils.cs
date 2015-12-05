using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Security;
using System.Globalization;
using System.Threading;

namespace Exchange_Manager
{
    public class ExchangeUtils
    {
        public static int BackupCount = 10;

        public static Collection<Command> ExportMailbox(int Id, String mailbox, String mindate, String maxdate, String target)
        {
            // Correção de bug no Powershell. A data precisa estar no formato inglês.
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Collection<Command> outcol = new Collection<Command>();
            Command myCommand = new Command("New-MailboxExportRequest");

            if (!mindate.Contains("*") && !maxdate.Contains("*"))
                myCommand.Parameters.Add("ContentFilter", "(Received -gt '" + mindate + "') -and (Received -lt '" + maxdate + "')");
            else if (mindate.Contains("*") && !maxdate.Contains("*"))
                myCommand.Parameters.Add("ContentFilter", "(Received -lt '" + maxdate + "')");
            else if (!mindate.Contains("*") && maxdate.Contains("*"))
                myCommand.Parameters.Add("ContentFilter", "(Received -gt '" + mindate + "')");

            myCommand.Parameters.Add("Mailbox", mailbox);
            myCommand.Parameters.Add("Filepath", target + "\\" + mailbox + "-" + DateTime.Now.Date.ToString().Substring(0, 10).Replace("\\","-").Replace("/","-")+".pst");
            Console.WriteLine(target + "\\" + mailbox + "-" + DateTime.Now.Date.ToString().Substring(0, 10).Replace("\\", "-").Replace("/", "-") + ".pst");
            myCommand.Parameters.Add("Name", "ExchMan-TVS-" + Id + "-" + (DateTime.Now.Date.ToString().Substring(0, 10) + "-C" + BackupCount));
            outcol.Add(myCommand);
            BackupCount++;
            return outcol;
        }
        public static Collection<Command> GetRoleExchangeImport(String user)
        {
            //New-ManagementRoleAssignment –Role “Mailbox Import Export” –user “teske”
            Collection<Command> outcol = new Collection<Command>();
            Command myCommand = new Command("New-ManagementRoleAssignment");
            myCommand.Parameters.Add("Role", "Mailbox Import Export");
            myCommand.Parameters.Add("user", user);
            outcol.Add(myCommand);
            return outcol;
        }
        public static Collection<Command> GetMailboxes()
        {
            Collection<Command> outcol = new Collection<Command>();
            Command myCommand = new Command("Get-Mailbox");
            myCommand.Parameters.Add("ResultSize", "unlimited");
            outcol.Add(myCommand);
            return outcol;
        }

        public static List<ExchangeMailbox> ProcessMBOXOutput(RequestOutput mboxoutput)
        {
            List<ExchangeMailbox> mailboxes = new List<ExchangeMailbox>();
            String SamAccountName = "", Alias = "", DisplayName = "", EmailAddress = ""; // SamAccountName -> Alias -> DisplayName -> PrimarySmtpAddress
            for (int i = 0, len = mboxoutput.ResponseTitles.Count(); i < len; i++)
            {
                if (mboxoutput.ResponseTitles[i].Contains("SamAccountName"))
                {
                    SamAccountName = mboxoutput.ResponseValues[i];
                }
                if (mboxoutput.ResponseTitles[i].Contains("Alias"))
                {
                    Alias = mboxoutput.ResponseValues[i];
                }
                if (mboxoutput.ResponseTitles[i].Contains("DisplayName"))
                {
                    DisplayName = mboxoutput.ResponseValues[i];
                }
                if (mboxoutput.ResponseTitles[i].Contains("PrimarySmtpAddress"))
                {
                    EmailAddress = mboxoutput.ResponseValues[i];
                    mailboxes.Add(new ExchangeMailbox(SamAccountName, Alias, DisplayName, EmailAddress));
                    SamAccountName = "";
                    Alias = "";
                    DisplayName = "";
                    EmailAddress = "";
                }
            }
            return mailboxes;
        }
        public static Collection<Command> CleanDoneRequests()
        {
            Collection<Command> outcol = new Collection<Command>();
            Command getmbxreq = new Command("Get-MailboxExportRequest");
            getmbxreq.Parameters.Add("Status", "Completed");
            outcol.Add(getmbxreq);
            Command removembxreq = new Command("Remove-MailboxExportRequest");
            removembxreq.Parameters.Add("Confirm", (System.Management.Automation.SwitchParameter)false);

            outcol.Add(removembxreq);
            return outcol;
        }
        public static Collection<Command> CleanFailedRequests()
        {
            Collection<Command> outcol = new Collection<Command>();
            Command getmbxreq = new Command("Get-MailboxExportRequest");
            getmbxreq.Parameters.Add("Status", "Failed");
            outcol.Add(getmbxreq);
            Command removembxreq = new Command("Remove-MailboxExportRequest");
            removembxreq.Parameters.Add("Confirm", (System.Management.Automation.SwitchParameter)false);

            outcol.Add(removembxreq);
            return outcol;
        }
        public static Collection<Command> GetRequests()
        {
            Collection<Command> outcol = new Collection<Command>();
            Command getmbxreq = new Command("Get-MailboxExportRequest");
            outcol.Add(getmbxreq);
            return outcol;
        }
    }
}
