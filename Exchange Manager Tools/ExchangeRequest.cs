using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Manager
{
    public class ExchangeRequest
    {
        public string Name;
        public string Status;
        public string Filepath;
        public string SourceAlias;
        public string SourceMailboxIdentity;
        public string ContentFilter;
        public string OverallDuration;
        public string TotalQueuedDuration;
        public string TotalInProgressDuration;
        public string PercentComplete;
    }
}
