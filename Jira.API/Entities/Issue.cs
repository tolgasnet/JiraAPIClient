using System.Linq;

namespace Jira.API.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public Fields Fields { get; set; }

        public int GetHours()
        {
            if (Fields.Worklog?.WorkLogs != null)
            {
                return Fields.Worklog.WorkLogs.Sum(s => s.GetHours());
            }
            return 0;
        }
    }
}