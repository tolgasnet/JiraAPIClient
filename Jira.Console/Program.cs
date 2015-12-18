using System;
using Jira.API;
using static System.Console;

namespace Jira.Console
{
    public class Program
    {
        static void Main()
        {
            ConsoleCredentials.SetPasswordFromUserInput();

            try
            {
                WriteLine("Querying JIRA. This might take several seconds...");

                var issuesForCurrentUser = new IssueRepository().GetIssuesForCurrentUser();

                Clear();

                foreach (var issue in issuesForCurrentUser)
                {
                    WriteLine($"{issue.Key} | {issue.GetHours()} hours");
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            
            WriteLine();
            WriteLine("Press any key...");
            ReadLine();
        }
    }
}
