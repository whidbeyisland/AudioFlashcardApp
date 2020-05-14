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
using System.Linq;
using Google.Apis.Sheets.v4.Data;
using System.Windows.Forms.VisualStyles;

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
            this.Text = "Flashchords";
            UpdateDeckList();
            deckToEdit2 = "";
            deckToEdit2Name = "";
            AddCardsButton.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddCardsButton.Enabled = true;

            deckToEdit2 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            deckToEdit2Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void DeckCreateButton_Click(object sender, EventArgs e)
        {
            //add deck to google sheet, with name entered, created date, and modified date
            AddNewDeck(newDeckTextBox.Text);

            UpdateDeckList();
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
            table.Columns.Add(new DataColumn("Id"));
            table.Columns.Add(new DataColumn("Deck Name"));
            table.Columns.Add(new DataColumn("Created Date"));
            table.Columns.Add(new DataColumn("Updated Date"));

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

        private void testLabel_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeckListForm_Load(object sender, EventArgs e)
        {

        }

        private void newDeckTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            if (deckToEdit2 != "")
            {
                RenameDeck(deckToEdit2);
            }
            UpdateDeckList();
        }

        private void RenameDeck(string deckToEdit3)
        {
            string newDeckName = deckNameBox.Text;

            //just do a delete request and then an add request?
        }

        private void deckNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void deleteDeckButton_Click(object sender, EventArgs e)
        {
            //first queue a popup asking if they're sure
            DialogResult result1 = MessageBox.Show("Are you sure you want to delete this deck?",
            "Important Question",
            MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                //initialize deck row index to be handled later
                int indexToDelete = -1;

                //general request stuff
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
                        List<string[]> hiddenDeckList2 = new List<string[]>();
                        foreach (var row in values)
                        {
                            //update datagrid with what it finds
                            if (row.Count > 0)
                            {
                                hiddenDeckList2.Add(new string[] { row[0].ToString(), row[1].ToString(), row[4].ToString(), row[5].ToString() });
                            }
                        }

                        //FIRST: get the guids of the sound files to delete
                        for (int i = 0; i < hiddenDeckList2.Count; i++)
                        {
                            if (hiddenDeckList2.ElementAt(i)[0] == deckToEdit2)
                            {
                                indexToDelete = i;
                            }
                        }
                        MessageBox.Show(deckToEdit2);
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                }
                catch
                {

                }

                //SECOND: delete that record in DeckEntries
                List<Request> deleteRequestsList = new List<Request>();
                BatchUpdateSpreadsheetRequest _batchUpdateSpreadsheetRequest = new BatchUpdateSpreadsheetRequest();
                Request _deleteRequest = new Request();
                _deleteRequest.DeleteDimension = new DeleteDimensionRequest();
                DimensionRange dimRange = new DimensionRange();
                dimRange.StartIndex = indexToDelete + 1;
                dimRange.EndIndex = indexToDelete + 2;
                dimRange.Dimension = "ROWS";
                _deleteRequest.DeleteDimension.Range = dimRange;

                deleteRequestsList.Add(_deleteRequest);
                _batchUpdateSpreadsheetRequest.Requests = deleteRequestsList;
                service.Spreadsheets.BatchUpdate(_batchUpdateSpreadsheetRequest, spreadsheetId).Execute();

                //FINALLY: tell the user everything was deleted
                MessageBox.Show("Deck deleted.");

                UpdateDeckList();

                // ---------------------------------------------------------
                // Delete all cards associated with deck, and their files
                // ---------------------------------------------------------

                //initialize sound file guids and row indices to be handled later
                List<string> frontGuidsToDelete = new List<string>();
                List<string> backGuidsToDelete = new List<string>();
                List<int> indicesToDelete = new List<int>();

                // Use Google Sheets API service, credentials, etc. from earlier in this method

                // Define request parameters.
                String spreadsheetId2 = "18oiwCBXXA3vNm-1ugq26MJPN9lmJadGshMOfXu17tS4";
                String range2 = "A2:G101";
                SpreadsheetsResource.ValuesResource.GetRequest request2 =
                        service.Spreadsheets.Values.Get(spreadsheetId2, range2);

                // print data from sheet
                Data.ValueRange response2 = request.Execute();
                IList<IList<System.Object>> values2 = response2.Values;
                response2.MajorDimension = "COLUMNS";
                if (values2 != null && values2.Count > 0)
                {
                    List<string[]> hiddenCardList2 = new List<string[]>();

                    foreach (var row in values2)
                    {
                        //update datagrid with what it finds
                        if (row[2].ToString() == deckToEdit2)
                        {
                            hiddenCardList2.Add(new string[] { row[0].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString() });
                        }
                    }

                    //FIRST: get the guids of the sound files to delete
                    for (int i = 0; i < hiddenCardList2.Count; i++)
                    {
                        if (hiddenCardList2.ElementAt(i)[2] == deckToEdit2)
                        {
                            frontGuidsToDelete.Add(hiddenCardList2.ElementAt(i)[1]);
                            backGuidsToDelete.Add(hiddenCardList2.ElementAt(i)[2]);

                            indicesToDelete.Add(i);
                        }
                    }

                }
                else
                {
                    Console.WriteLine("No data found.");
                }

                //SECOND: delete that record in CardEntries
                List<Request> deleteRequestsList2 = new List<Request>();
                BatchUpdateSpreadsheetRequest _batchUpdateSpreadsheetRequest2 = new BatchUpdateSpreadsheetRequest();

                //add each row that should be deleted to the list of delete requests
                foreach(int indexToDelete2 in indicesToDelete)
                {
                    Request _deleteRequest2 = new Request();
                    _deleteRequest2.DeleteDimension = new DeleteDimensionRequest();
                    DimensionRange dimRange2 = new DimensionRange();
                    dimRange2.StartIndex = indexToDelete2 + 1;
                    dimRange2.EndIndex = indexToDelete2 + 2;
                    dimRange2.Dimension = "ROWS";
                    _deleteRequest2.DeleteDimension.Range = dimRange2;

                    deleteRequestsList2.Add(_deleteRequest2);
                }
                
                _batchUpdateSpreadsheetRequest2.Requests = deleteRequestsList2;
                service.Spreadsheets.BatchUpdate(_batchUpdateSpreadsheetRequest2, spreadsheetId2).Execute();

                //THIRD: delete the files in the user's folder with the Guids frontGuidToDelete and backGuidToDelete
                foreach(string frontGuidToDelete in frontGuidsToDelete)
                {
                    File.Delete(String.Format(@"C:\Users\davis\Desktop\NAudio\{0}.wav", frontGuidToDelete));
                }
                foreach (string backGuidToDelete in backGuidsToDelete)
                {
                    File.Delete(String.Format(@"C:\Users\davis\Desktop\NAudio\{0}.wav", backGuidToDelete));
                }

            }
        }
    }
}
