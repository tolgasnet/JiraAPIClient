using System.Collections.Generic;

namespace Jira.API.Entities
{
    public class Worklog
    {
        public IList<WorkLogItem> WorkLogs { get; set; }
    }
}