using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Security;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace Exchange_Manager
{
    public class PSBGCompletedEventArgs : EventArgs
    {
        public string Output { get; set; }
        public int Id { get; set; }
        public RequestOutput OutData  { get; set; }
        public Boolean failed { get; set; }
        public String failmsg { get; set; }
    }
    public class PSBGWorker
    {
        private Collection<Command> workCMD;
        private BackgroundWorker PSWorker;
        private String username, password, ip, workScript;
        public Boolean completed = false,  scripting = false;
        public event EventHandler<PSBGCompletedEventArgs> Completed;
        public int Id;
        public PSBGWorker(String user, String pass, String ip, Collection<Command> workCommand, int Id)
        {
            this.workCMD = workCommand;
            this.PSWorker = new BackgroundWorker();
            this.PSWorker.WorkerReportsProgress = false;
            this.PSWorker.WorkerSupportsCancellation = true;
            this.PSWorker.DoWork += new DoWorkEventHandler(DoWork);
            this.username = user;
            this.password = pass;
            this.ip = ip;
            this.Id = Id;
            scripting = false;
        }
        public PSBGWorker(String user, String pass, String ip, String workScript)
        {
            this.workScript = workScript;
            this.PSWorker = new BackgroundWorker();
            this.PSWorker.WorkerReportsProgress = false;
            this.PSWorker.WorkerSupportsCancellation = true;
            this.PSWorker.DoWork += new DoWorkEventHandler(DoWork);
            this.username = user;
            this.password = pass;
            this.ip = ip;
            scripting = true;
        }
        public void InitTask()
        {
            PSWorker.RunWorkerAsync();
        }
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            BackgroundWorker worker = sender as BackgroundWorker;
            Runspace rSpace;
            SecureString secpass = new SecureString(); ;
            for (int i = 0; i < password.Length; i++)
                secpass.AppendChar(password[i]);

            PSCredential cred = new PSCredential(username, secpass);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(
              new Uri("https://" + ip + "/Powershell"),
              "http://schemas.microsoft.com/powershell/Microsoft.Exchange",
              cred);
            connectionInfo.SkipCACheck = true;
            connectionInfo.SkipRevocationCheck = true;
            connectionInfo.SkipCNCheck = true;
            LogMan.AddDebug("Trying to connect to \"https://" + ip + "/Powershell\"");
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;
            rSpace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace(connectionInfo);
            try
            {
                rSpace.Open();
                Pipeline pipeLine = rSpace.CreatePipeline();
                if (scripting)
                {
                    pipeLine.Commands.AddScript(this.workScript);
                    LogMan.AddDebug("Console Script: " + workScript.ToString());
                }
                else
                {
                    foreach (Command cmd in this.workCMD)
                    {
                        pipeLine.Commands.Add(cmd);
                        System.Console.WriteLine(cmd.ToString());
                        String parameters = "";
                        for (int i = 0; i < cmd.Parameters.Count; i++)
                            parameters += " -" + cmd.Parameters[i].Name + " "+cmd.Parameters[i].Value;
                        LogMan.AddDebug("Console: " + cmd.ToString() +parameters);
                    }
                }
                Collection<PSObject> commandResults = pipeLine.Invoke();
                RequestOutput outdata = new RequestOutput();
                foreach (PSObject cmdlet in commandResults)
                {
                    foreach (PSPropertyInfo prop in cmdlet.Properties)
                    {
                        try
                        {
                            outdata.Add(prop.Name.ToString(), prop.Value.ToString());
                        }
                        catch (Exception) { }
                    }
                }
                completed = true;
                PSBGCompletedEventArgs args = new PSBGCompletedEventArgs();
                LogMan.AddDebug("Outdata: " + outdata.ToString());
                args.Output = outdata.ToString();
                args.OutData = outdata;
                args.Id = this.Id;
                args.failed = false;
                pipeLine.Dispose();
                rSpace.Close();
                if (Completed != null)
                    Completed(this, args);
            }
            catch (Exception exc)
            {
                LogMan.AddDebug("Error: "+exc.Message);
                PSBGCompletedEventArgs args = new PSBGCompletedEventArgs();
                args.Id = this.Id;
                args.failed = true;
                args.failmsg = exc.Message;
                rSpace.Close();
                if (Completed != null)
                    Completed(this, args);                
            }
        }

    }
}
