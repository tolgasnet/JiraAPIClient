using System;
using System.Configuration;
using System.Text;

namespace Jira.API
{
    public class Credentials
    {
        private static string _password;

        public static void SetPassword(string password)
        {
            _password = password;
        }

        public static string Get()
        {
            var userName = ConfigurationManager.AppSettings["userName"];
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + _password));
        }
    }
}
