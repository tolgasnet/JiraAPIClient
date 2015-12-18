using System;

namespace Jira.API.Entities
{
    public class WorkLogItem
    {
        public Author Author { get; set; }
        public DateTime Started { get; set; }
        public string TimeSpent { get; set; }
        public int TimeSpentSeconds { get; set; }

        public int GetHours()
        {
            return TimeSpentSeconds / 60 / 60;
        }
    }
}