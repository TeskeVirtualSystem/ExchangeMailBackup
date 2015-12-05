using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange_Manager
{
    public class ScheduledAction
    {
        public int Id, LastDays;
        public Boolean FullBackup;
        public String Mailbox, Target;
        public ScheduledDateTime ScheduleTime;
        public ScheduledAction()
        {

        }
        public ScheduledAction(String Mailbox, int FullBackup, int LastDays, String Target, String Hour, String Minute, String DayOfWeek, String DayOfMonth, String Month)
        {
            this.ScheduleTime = new ScheduledDateTime(Hour, Minute, DayOfWeek, DayOfMonth, Month);
            this.Id = -1;
            this.Mailbox = Mailbox;
            this.FullBackup = FullBackup > 0;
            this.LastDays = LastDays;
            this.Target = Target;
        }
        public ScheduledAction(int Id, String Mailbox, int FullBackup, int LastDays, String Target, String Hour, String Minute, String DayOfWeek, String DayOfMonth, String Month)
        {
            this.ScheduleTime = new ScheduledDateTime(Hour, Minute, DayOfWeek, DayOfMonth, Month);
            this.Id = Id;
            this.Mailbox = Mailbox;
            this.FullBackup = FullBackup > 0;
            this.LastDays = LastDays;
            this.Target = Target;
        }
        public ScheduledAction(String Mailbox, int FullBackup, int LastDays, String Target, ScheduledDateTime ScheduleTime)
        {
            this.ScheduleTime = ScheduleTime;
            this.Mailbox = Mailbox;
            this.FullBackup = FullBackup > 0;
            this.LastDays = LastDays;
            this.Target = Target;
        }
        public ScheduledAction(int Id, String Mailbox, int FullBackup, int LastDays, String Target, ScheduledDateTime ScheduleTime)
        {
            this.Id = Id;
            this.ScheduleTime = ScheduleTime;
            this.Mailbox = Mailbox;
            this.FullBackup = FullBackup > 0;
            this.LastDays = LastDays;
            this.Target = Target;
        }
        public override string ToString()
        {
            return "MBX(" + this.Mailbox + ") (LastDays: "+LastDays+" - FullBackup: "+FullBackup+") - " + this.ScheduleTime.ToString();    
        }
    }
}
