using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Jira.API.Entities;

namespace Jira.API
{
    public class IssueRepository
    {
        private readonly RestClient _restClient;
        private readonly string _jiraUrl;

        public IssueRepository()
        {
            _restClient = new RestClient();
            _jiraUrl = ConfigurationManager.AppSettings["jiraUrl"];
        }

        public IList<Issue> GetIssuesForCurrentUser()
        {
            var queryUrl =
                _jiraUrl + "/search?jql=assignee+%3D+currentUser()";

            var queryResults = _restClient.Get<QueryResults>(queryUrl);

            var allIssueKeys = queryResults.Issues.Select(issue => issue.Key);

            return allIssueKeys.Select(GetIssueByKey).ToList();
        }

        private Issue GetIssueByKey(string key)
        {
            var issueUrl = $"{_jiraUrl}/issue/{key}";
            return _restClient.Get<Issue>(issueUrl);
        }
    }
}