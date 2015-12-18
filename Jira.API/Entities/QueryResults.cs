using System.Collections.Generic;

namespace Jira.API.Entities
{
    public class QueryResults
    {
        public IList<Issue> Issues { get; set; }
    }
}