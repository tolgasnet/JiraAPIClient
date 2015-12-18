using System;
using Jira.API;

namespace Jira.Console
{
    public class ConsoleCredentials
    {
        public static void SetPasswordFromUserInput()
        {
            System.Console.WriteLine("Password:");

            ConsoleKeyInfo key;
            var pass = "";

            do
            {
                key = System.Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    System.Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, pass.Length - 1);
                        System.Console.Write("\b \b");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);

            System.Console.Clear();

            Credentials.SetPassword(pass);
        }
    }
}