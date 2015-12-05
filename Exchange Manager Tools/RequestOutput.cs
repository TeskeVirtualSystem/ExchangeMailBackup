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

namespace Exchange_Manager
{
    public class RequestOutput
    {
        public Collection<String> ResponseTitles;
        public Collection<String> ResponseValues;
        public RequestOutput()
        {
            this.ResponseValues = new Collection<string>();
            this.ResponseTitles = new Collection<string>();
        }
        public RequestOutput(Collection<String> ResponseTitles, Collection<String> ResponseValues)
        {
            this.ResponseTitles = ResponseTitles;
            this.ResponseValues = ResponseValues;
        }
        public void Add(String title, String value)
        {
            this.ResponseTitles.Add(title);
            this.ResponseValues.Add(value);
        }
        override public String ToString()
        {
            String output = "";
            for (int i = 0; i < ResponseTitles.Count; i++)
                output += ResponseTitles[i] + ": " + ResponseValues[i] + "\r\n";
            return output;
        }
    }
}
