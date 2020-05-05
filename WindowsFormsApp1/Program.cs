using System;
using System.Windows.Forms;
using Google.Apis.Sheets.v4;

namespace WindowsFormsApp1
{
    static class Program
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetVariables();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DeckListForm());
        }
        static void SetVariables()
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\GoogleCloudFiles\single-clock-264421-edfc58757462.json");
        }
    }
}
