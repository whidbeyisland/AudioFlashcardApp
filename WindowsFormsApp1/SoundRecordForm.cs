using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data = Google.Apis.Sheets.v4.Data;

namespace WindowsFormsApp1
{
    public partial class SoundRecordForm : Form
    {
        string frontSoundGuid;
        string backSoundGuid;
        public WaveInEvent waveIn;
        public WaveFileWriter writer;
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        string deckToEdit2;
        string cardName;

        public SoundRecordForm(string deckToEdit)
        {
            deckToEdit2 = "";
            InitializeComponent();
            frontSoundGuid = "";
            backSoundGuid = "";
            deckToEdit2 = deckToEdit;
            testLabel.Text = deckToEdit;
            cardName = ".";

            FrontStopButton.Enabled = false;
            BackStopButton.Enabled = false;
            SaveCardButton.Enabled = false;
        }

        private void FrontRecordButton_Click(object sender, EventArgs e)
        {
            frontSoundGuid = Guid.NewGuid().ToString();

            var outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NAudio");
            Directory.CreateDirectory(outputFolder);
            var outputFilePath = Path.Combine(outputFolder, String.Concat(frontSoundGuid, ".wav"));

            waveIn = new WaveInEvent();

            writer = null;

            bool closing = false;

            writer = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);
            waveIn.StartRecording();
            FrontRecordButton.Enabled = false;
            FrontStopButton.Enabled = true;
            BackRecordButton.Enabled = false;
            BackStopButton.Enabled = false;
            SaveCardButton.Enabled = false;

            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
            };

            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
                if (writer.Position > waveIn.WaveFormat.AverageBytesPerSecond * 30)
                {
                    waveIn.StopRecording();
                }
            };
        }

        private void FrontStopButton_Click(object sender, EventArgs e)
        {
            waveIn.StopRecording();

            writer?.Dispose();
            writer = null;
            FrontRecordButton.Enabled = true;
            FrontStopButton.Enabled = false;
            BackRecordButton.Enabled = true;
            BackStopButton.Enabled = false;

            if (frontSoundGuid != "" && backSoundGuid != "")
            {
                SaveCardButton.Enabled = true;
            }
        }

        private void BackRecordButton_Click(object sender, EventArgs e)
        {
            backSoundGuid = Guid.NewGuid().ToString();

            var outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NAudio");
            Directory.CreateDirectory(outputFolder);
            var outputFilePath = Path.Combine(outputFolder, String.Concat(backSoundGuid, ".wav"));

            waveIn = new WaveInEvent();

            writer = null;

            bool closing = false;

            writer = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);
            waveIn.StartRecording();
            FrontRecordButton.Enabled = false;
            FrontStopButton.Enabled = false;
            BackRecordButton.Enabled = false;
            BackStopButton.Enabled = true;
            SaveCardButton.Enabled = false;

            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
            };

            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
                if (writer.Position > waveIn.WaveFormat.AverageBytesPerSecond * 30)
                {
                    waveIn.StopRecording();
                }
            };
        }

        private void BackStopButton_Click(object sender, EventArgs e)
        {
            waveIn.StopRecording();

            writer?.Dispose();
            writer = null;
            FrontRecordButton.Enabled = true;
            FrontStopButton.Enabled = false;
            BackRecordButton.Enabled = true;
            BackStopButton.Enabled = false;

            if (frontSoundGuid != "" && backSoundGuid != "")
            {
                SaveCardButton.Enabled = true;
            }
        }

        private void SaveCardButton_Click(object sender, EventArgs e)
        {
            if (frontSoundGuid != "" && backSoundGuid != "")
            {
                AddNewCard();
                SaveCardButton.Enabled = false;
            }
        }

        private void AddNewCard()
        {
            //update name to what user's selected, if anything
            if (cardNameField.Text != "" && cardNameField.Text != null)
            {
                cardName = cardNameField.Text;
            }

            //general request stuff
            SheetsService sheetsService = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = GetCredential(),
                ApplicationName = "Google-SheetsSample/0.1",
            });

            // The ID of the spreadsheet to update.
            string spreadsheetId = "18oiwCBXXA3vNm-1ugq26MJPN9lmJadGshMOfXu17tS4";

            // The A1 notation of a range to search for a logical table of data.
            // Values will be appended after the last row of the table.
            string range = "A2:F101";  // TODO: Update placeholder value.

            // How the input data should be interpreted.
            SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum valueInputOption = (SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum)2;  // TODO: Update placeholder value.

            // How the input data should be inserted.
            SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum insertDataOption = (SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum)1;  // TODO: Update placeholder value.

            // TODO: Assign values to desired properties of `requestBody`:
            Data.ValueRange requestBody = new Data.ValueRange();
            var oblist = new List<object>() { Guid.NewGuid(), cardName, deckToEdit2, frontSoundGuid, backSoundGuid, DateTime.Now, DateTime.Now };
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
            //Console.WriteLine(JsonConvert.SerializeObject(response));
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Code
            //closing = true;
            try
            {
                waveIn.StopRecording();
            } catch
            {

            }
        }
    }
}
