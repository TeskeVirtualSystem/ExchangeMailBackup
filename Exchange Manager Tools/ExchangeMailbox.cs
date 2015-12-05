using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange_Manager
{
    public class ExchangeMailbox
    {
        public String SamAccountName, Alias, DisplayName, EmailAddress;

        public ExchangeMailbox(String SamAccountName, String Alias, String DisplayName, String EmailAddress)
        {
            this.Alias = Alias;
            this.DisplayName = DisplayName;
            this.EmailAddress = EmailAddress;
            this.SamAccountName = SamAccountName;
        }
    }
}
