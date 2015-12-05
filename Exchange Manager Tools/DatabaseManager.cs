using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Exchange_Manager
{
    public class DatabaseManager
    {
        public String dbConnection;
        public DatabaseManager(String file)
        {
            dbConnection = String.Format("Data Source={0}", file);
            if (!File.Exists(file))
            {
                LogMan.AddLog("Arquivo de Banco de Dados não existe. Criando " + file);
                SQLiteConnection.CreateFile(file);
                LogMan.AddLog("Abrindo banco de dados de cache.");
                SQLiteConnection cnn = new SQLiteConnection(dbConnection);
                cnn.Open();
                LogMan.AddLog("Criando tabelas iniciais.");
                SQLiteCommand cmd = new SQLiteCommand(cnn);
                cmd.CommandText = "CREATE TABLE schedules (Id INTEGER PRIMARY KEY, Mailbox STRING, FullBackup INTEGER, LastDays INTEGER, Target STRING, Hour STRING, Minute STRING, DayOfWeek STRING, DayOfMonth STRING, Month STRING )";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }

        public List<ScheduledAction> GetScheduledActions()
        {
            List<ScheduledAction> schedules = new List<ScheduledAction>();
            DataTable tmp = new DataTable();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection(dbConnection);
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn);
                mycommand.CommandText = "SELECT * FROM schedules";
                SQLiteDataReader reader = mycommand.ExecuteReader();
                tmp.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            if (tmp.Rows.Count > 0)
            {
                foreach (DataRow r in tmp.Rows)
                {
                    ScheduledAction tmpAction = new ScheduledAction(Int32.Parse(r["Id"].ToString()), r["Mailbox"].ToString(), Int32.Parse(r["FullBackup"].ToString()), Int32.Parse(r["LastDays"].ToString()), r["Target"].ToString(), r["Hour"].ToString(), r["Minute"].ToString(), r["DayOfWeek"].ToString(), r["DayOfMonth"].ToString(), r["Month"].ToString());
                    schedules.Add(tmpAction);
                }
            }
            return schedules;
        }
        public int ExecuteNonQuery(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }

        public void AddSchedule(ScheduledAction Schedule)
        {
            SQLiteParameter Mailbox = new SQLiteParameter("@Mailbox");
            SQLiteParameter FullBackup = new SQLiteParameter("@FullBackup");
            SQLiteParameter LastDays = new SQLiteParameter("@LastDays");
            SQLiteParameter Target = new SQLiteParameter("@Target");
            SQLiteParameter Hour = new SQLiteParameter("@Hour");
            SQLiteParameter Minute = new SQLiteParameter("@Minute");
            SQLiteParameter DayOfWeek = new SQLiteParameter("@DayOfWeek");
            SQLiteParameter DayOfMonth = new SQLiteParameter("@DayOfMonth");
            SQLiteParameter Month = new SQLiteParameter("@Month");

            Mailbox.Value = Schedule.Mailbox;
            FullBackup.Value = Schedule.FullBackup?1:0;
            LastDays.Value = Schedule.LastDays;
            Target.Value = Schedule.Target;
            Hour.Value = Schedule.ScheduleTime.hour;
            Minute.Value = Schedule.ScheduleTime.minute;
            DayOfWeek.Value = Schedule.ScheduleTime.dayofweek;
            DayOfMonth.Value = Schedule.ScheduleTime.dayofmonth;
            Month.Value = Schedule.ScheduleTime.month;

            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand cmd = new SQLiteCommand(cnn);
            cmd.Parameters.Add(Mailbox);
            cmd.Parameters.Add(FullBackup);
            cmd.Parameters.Add(LastDays);
            cmd.Parameters.Add(Target);
            cmd.Parameters.Add(Hour);
            cmd.Parameters.Add(Minute);
            cmd.Parameters.Add(DayOfWeek);
            cmd.Parameters.Add(DayOfMonth);
            cmd.Parameters.Add(Month);
            cmd.CommandText = "INSERT INTO schedules (Mailbox, FullBackup, LastDays, Target, Hour, Minute, DayOfWeek, DayOfMonth, Month) VALUES (@Mailbox, @FullBackup, @LastDays, @Target, @Hour, @Minute, @DayOfWeek, @DayOfMonth, @Month)";

            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        public void ChangeSchedule(int id, ScheduledAction Schedule)
        {
            SQLiteParameter Mailbox = new SQLiteParameter("@Mailbox");
            SQLiteParameter FullBackup = new SQLiteParameter("@FullBackup");
            SQLiteParameter LastDays = new SQLiteParameter("@LastDays");
            SQLiteParameter Target = new SQLiteParameter("@Target");
            SQLiteParameter Hour = new SQLiteParameter("@Hour");
            SQLiteParameter Minute = new SQLiteParameter("@Minute");
            SQLiteParameter DayOfWeek = new SQLiteParameter("@DayOfWeek");
            SQLiteParameter DayOfMonth = new SQLiteParameter("@DayOfMonth");
            SQLiteParameter Month = new SQLiteParameter("@Month");
            SQLiteParameter ID = new SQLiteParameter("@Id");

            Mailbox.Value = Schedule.Mailbox;
            FullBackup.Value = Schedule.FullBackup ? 1 : 0;
            LastDays.Value = Schedule.LastDays;
            Target.Value = Schedule.Target;
            Hour.Value = Schedule.ScheduleTime.hour;
            Minute.Value = Schedule.ScheduleTime.minute;
            DayOfWeek.Value = Schedule.ScheduleTime.dayofweek;
            DayOfMonth.Value = Schedule.ScheduleTime.dayofmonth;
            Month.Value = Schedule.ScheduleTime.month;

            ID.Value = id;
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand cmd = new SQLiteCommand(cnn);
            cmd.Parameters.Add(Mailbox);
            cmd.Parameters.Add(FullBackup);
            cmd.Parameters.Add(LastDays);
            cmd.Parameters.Add(Target);
            cmd.Parameters.Add(Hour);
            cmd.Parameters.Add(Minute);
            cmd.Parameters.Add(DayOfWeek);
            cmd.Parameters.Add(DayOfMonth);
            cmd.Parameters.Add(Month);
            cmd.Parameters.Add(ID);
            cmd.CommandText = "UPDATE schedules SET Mailbox = @Mailbox, FullBackup = @FullBackup, LastDays = @LastDays, Target = @Target, Hour = @Hour, Minute = @Minute, DayOfWeek = @DayOfWeek, DayOfMonth = @DayOfMonth, Month = @Month WHERE Id = @Id";

            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void DeleteSchedule(int Id)
        {
            SQLiteParameter p_Id = new SQLiteParameter("@Id");
            p_Id.Value = Id;

            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand cmd = new SQLiteCommand(cnn);
            cmd.Parameters.Add(p_Id);
            cmd.CommandText = "DELETE FROM schedules WHERE Id = @Id";
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
