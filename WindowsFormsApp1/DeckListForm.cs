using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;
using Data = Google.Apis.Sheets.v4.Data;
using System.Threading;
using Google.Apis.Util.Store;
using System.IO;

using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;

namespace WindowsFormsApp1
{
    public partial class DeckListForm : Form
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Flashchords";
        string deckToEdit2;
        string deckToEdit2Name;

        public DeckListForm()
        {
            InitializeComponent();
            UpdateDeckList();
            deckToEdit2 = "";
            deckToEdit2Name = "";
            AddCardsButton.Enabled = false;
        }

        public int returnFive()
        {
            return 5;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //testLabel2.Text = e.RowIndex.ToString();
            AddCardsButton.Enabled = true;

            deckToEdit2 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            deckToEdit2Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            testLabel2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void DeckCreateButton_Click(object sender, EventArgs e)
        {
            //add deck to google sheet, with name entered, created date, and modified date
            AddNewDeck(newDeckTextBox.Text);

            //UpdateDeckList();
        }

        private void UpdateDeckList()
        {
            //retrieve current list of decks from google sheet

            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.ReadWrite))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            String spreadsheetId = "1mo43FA8GI2foWplLAxkVwa1JiQEWzZcvvceOJ-9UDfM";
            String range = "A2:G101";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // print data from sheet
            try
            {
                Data.ValueRange response = request.Execute();
                IList<IList<System.Object>> values = response.Values;
                response.MajorDimension = "COLUMNS";
                if (values != null && values.Count > 0)
                {
                    List<string[]> hiddenDeckList = new List<string[]>();

                    foreach (var row in values)
                    {
                        //update datagrid with what it finds
                        if (row.Count > 0)
                        {
                            hiddenDeckList.Add(new string[] { row[0].ToString(), row[1].ToString(), row[4].ToString(), row[5].ToString() });
                        }
                    }

                    DataTable table = ConvertListToDataTable(hiddenDeckList);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    Console.WriteLine("No data found.");
                }
            } catch
            {

            }
            
        }

        private void AddNewDeck(string deckName)
        {
            SheetsService sheetsService = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = GetCredential(),
                ApplicationName = "Google-SheetsSample/0.1",
            });

            // The ID of the spreadsheet to update.
            string spreadsheetId = "1mo43FA8GI2foWplLAxkVwa1JiQEWzZcvvceOJ-9UDfM";

            // The A1 notation of a range to search for a logical table of data.
            // Values will be appended after the last row of the table.
            string range = "A2:G101";  // TODO: Update placeholder value.

            // How the input data should be interpreted.
            SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum valueInputOption = (SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum)2;  // TODO: Update placeholder value.

            // How the input data should be inserted.
            SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum insertDataOption = (SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum)1;  // TODO: Update placeholder value.

            // TODO: Assign values to desired properties of `requestBody`:
            Data.ValueRange requestBody = new Data.ValueRange();
            var oblist = new List<object>() { Guid.NewGuid(), deckName, 0, 0, DateTime.Now, DateTime.Now }; //, "Default2", 1, 4
            requestBody.Values = new List<IList<object>> { oblist };
            requestBody.MajorDimension = "ROWS";

            SpreadsheetsResource.ValuesResource.AppendRequest request = sheetsService.Spreadsheets.Values.Append(requestBody, spreadsheetId, range);
            request.ValueInputOption = valueInputOption;
            request.InsertDataOption = insertDataOption;

            // To execute asynchronously in an async method, replace `request.Execute()` as shown:
            Data.AppendValuesResponse response = request.Execute();
            // Data.AppendValuesResponse response = await request.ExecuteAsync();

            // TODO: Change code below to process the `response` object:
            testLabel.Text = JsonConvert.SerializeObject(response);
        }

        private static UserCredential GetCredential()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.ReadWrite))
            //should be Open/ReadWrite because this is for opening the credentials, you don't want to edit anything else
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            return credential;
        }

        private static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }

        private void EditDeckButton_Click(object sender, EventArgs e)
        {
            if (deckToEdit2 != "")
            {
                CardListForm form3 = new CardListForm(deckToEdit2, deckToEdit2Name);
                form3.ShowDialog();
            }
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            SyncFiles();
        }

        private void SyncFiles()
        {
            //find mp3 files in directory
            string targetdirectory = @"C:\Users\davis\Desktop\NAudio\";
            string[] mp3Files = Directory.GetFiles(targetdirectory);
            foreach(string mp3File in mp3Files)
            {
                if (mp3File.Contains(".wav"))
                {
                    UploadFile("audioflashcardbucket1", mp3File, mp3File);
                }
            }
            
        }

        private static void UploadFile(string bucketName, string localPath,
        string objectName = null)
        {
            var storage = StorageClient.Create();
            using (var f = File.OpenRead(localPath))
            {
                objectName = objectName ?? Path.GetFileName(localPath);
                storage.UploadObject(bucketName, objectName, null, f);
                Console.WriteLine($"Uploaded {objectName}.");
            }
        }

        private void restoreFromCloudButton_Click(object sender, EventArgs e)
        {
            RestoreFromCloud();
        }

        private void RestoreFromCloud()
        {
            //download files
            var storage = StorageClient.Create();
            foreach (var storageObject in storage.ListObjects("audioflashcardbucket1", ""))
            {
                DownloadObject("audioflashcardbucket1", storageObject.Name, storageObject.Name);
            }
        }

        private static void DownloadObject(string bucketName, string objectName,
        string localPath = null)
        {
            var storage = StorageClient.Create();
            localPath = localPath ?? Path.GetFileName(objectName);
            using (var outputFile = File.OpenWrite(localPath))
            {
                storage.DownloadObject(bucketName, objectName, outputFile);
            }
            Console.WriteLine($"downloaded {objectName} to {localPath}.");
        }
    }
}
