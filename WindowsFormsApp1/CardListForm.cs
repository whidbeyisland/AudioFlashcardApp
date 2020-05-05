using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;
using Data = Google.Apis.Sheets.v4.Data;
using System.Threading;
using Google.Apis.Util.Store;
using System.IO;
using Google.Apis.Sheets.v4.Data;

namespace WindowsFormsApp1
{
    public partial class CardListForm : Form
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Flashchords";

        string deckToEdit2;
        string deckToEdit2Name;
        string cardToEdit2;
        string cardToEdit2Name;

        public CardListForm(string deckToEdit, string deckToEditName)
        {
            deckToEdit2 = "";
            deckToEdit2Name = "";
            cardToEdit2 = "";
            cardToEdit2Name = "";
            InitializeComponent();
            myTestLabel.Text = deckToEditName;
            deckToEdit2 = deckToEdit;
            UpdateCardList();

            DeleteCardButton.Enabled = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void AddNewCardButton_Click(object sender, EventArgs e)
        {
            SoundRecordForm form4 = new SoundRecordForm(deckToEdit2);
            form4.ShowDialog();
        }

        private void myTestLabel_Click(object sender, EventArgs e)
        {

        }

        private void UpdateCardList()
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
            String spreadsheetId = "18oiwCBXXA3vNm-1ugq26MJPN9lmJadGshMOfXu17tS4";
            String range = "A2:G101";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // print data from sheet
            Data.ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            response.MajorDimension = "COLUMNS";
            if (values != null && values.Count > 0)
            {
                List<string[]> hiddenCardList = new List<string[]>();

                foreach (var row in values)
                {
                    //update datagrid with what it finds
                    if (row[2].ToString() == deckToEdit2)
                    {
                        hiddenCardList.Add(new string[] { row[0].ToString(), row[1].ToString(), row[5].ToString(), row[6].ToString() });
                    }
                }

                DataTable table = ConvertListToDataTable(hiddenCardList);
                dataGridView1.DataSource = table;
            }
            else
            {
                Console.WriteLine("No data found.");
            }
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

        private void StudyDeckButton_Click(object sender, EventArgs e)
        {
            PlaybackForm form5 = new PlaybackForm(deckToEdit2);
            form5.ShowDialog();
        }

        private void DeleteCardButton_Click(object sender, EventArgs e)
        {
            //first queue a popup asking if they're sure

            DialogResult result1 = MessageBox.Show("Are you sure you want to delete this card?",
            "Important Question",
            MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                //initialize sound file guids and row index to be handled later
                string frontGuidToDelete = "";
                string backGuidToDelete = "";
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
                String spreadsheetId = "18oiwCBXXA3vNm-1ugq26MJPN9lmJadGshMOfXu17tS4";
                String range = "A2:G101";
                SpreadsheetsResource.ValuesResource.GetRequest request =
                        service.Spreadsheets.Values.Get(spreadsheetId, range);

                // print data from sheet
                Data.ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
                response.MajorDimension = "COLUMNS";
                if (values != null && values.Count > 0)
                {
                    List<string[]> hiddenCardList2 = new List<string[]>();

                    foreach (var row in values)
                    {
                        //update datagrid with what it finds
                        if (row[2].ToString() == deckToEdit2)
                        {
                            hiddenCardList2.Add(new string[] { row[0].ToString(), row[3].ToString(), row[4].ToString()});
                        }
                    }

                    //FIRST: get the guids of the sound files to delete
                    for (int i = 0; i < hiddenCardList2.Count; i++)
                    {
                        if (hiddenCardList2.ElementAt(i)[0] == cardToEdit2)
                        {
                            frontGuidToDelete = hiddenCardList2.ElementAt(i)[1];
                            backGuidToDelete = hiddenCardList2.ElementAt(i)[2];
                            indexToDelete = i;
                        }
                    }
                    MessageBox.Show(frontGuidToDelete + "..." + backGuidToDelete);

                }
                else
                {
                    Console.WriteLine("No data found.");
                }

                //SECOND: delete that record in CardEntries
                List<Request> deleteRequestsList = new List<Request>();
                BatchUpdateSpreadsheetRequest _batchUpdateSpreadsheetRequest = new BatchUpdateSpreadsheetRequest();
                Request _deleteRequest = new Request();
                _deleteRequest.DeleteDimension = new DeleteDimensionRequest();
                DimensionRange dimRange = new DimensionRange();
                dimRange.StartIndex = indexToDelete + 2;
                dimRange.EndIndex = indexToDelete + 3;
                dimRange.Dimension = "ROWS";
                _deleteRequest.DeleteDimension.Range = dimRange;

                deleteRequestsList.Add(_deleteRequest);
                _batchUpdateSpreadsheetRequest.Requests = deleteRequestsList;
                service.Spreadsheets.BatchUpdate(_batchUpdateSpreadsheetRequest, spreadsheetId).Execute();

                //THIRD: delete the files in the user's folder with the Guids frontGuidToDelete and backGuidToDelete
                File.Delete(String.Format(@"C:\Users\davis\Desktop\NAudio\{0}.wav", frontGuidToDelete));
                File.Delete(String.Format(@"C:\Users\davis\Desktop\NAudio\{0}.wav", backGuidToDelete));

                //FINALLY: tell the user everything was deleted
                MessageBox.Show("Card deleted.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DeleteCardButton.Enabled = true;

            cardToEdit2 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cardToEdit2Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            testLabel2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            File.Delete(@"C:\Users\davis\Desktop\NAudio\pumpkin.txt");
        }
    }
}
