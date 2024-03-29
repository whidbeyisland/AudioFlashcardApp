﻿using System;
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
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace WindowsFormsApp1
{
    public partial class PlaybackForm : Form
    {
        public WaveOutEvent waveOut;
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Flashchords";
        string deckToEdit2;
        public WaveFileReader waveReader;
        public List<AudioFileReader> fileReaderList;
        public bool playInReverse;
        public int speedScrollPos;

        public PlaybackForm(string deckToEdit)
        {
            waveOut = new WaveOutEvent();
            deckToEdit2 = "";
            InitializeComponent();
            this.Text = "Review";
            deckToEdit2 = deckToEdit;
            fileReaderList = new List<AudioFileReader>();
            playInReverse = false;
            speedScrollPos = 0;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void PlayDeckButton_Click(object sender, EventArgs e)
        {
            PlayDeck();
        }

        private void StopDeckButton_Click(object sender, EventArgs e)
        {
            waveOut.Stop();
            waveOut.Dispose();

            foreach(AudioFileReader oneFileReader in fileReaderList)
            {
                oneFileReader.Dispose();
            }
        }

        private void PlayDeck()
        {
            //create a 2D array of strings containing one row for each row in the table,
            //each containing the front and back WAV file names for that row
            IList<IList<Object>> wavFileNamesInit = WavFileNames();

            //randomize the order of rows in that 2D array
            var wavFileNames = wavFileNamesInit.OrderBy(a => Guid.NewGuid()).ToList();

            //for each row, play the front and then the back WAV files
            var dummyFileReader = new AudioFileReader(String.Format(@"C:\Users\davis\Desktop\NAudio\dummy.wav"));
            var dummyFileReader2 = new AudioFileReader(String.Format(@"C:\Users\davis\Desktop\NAudio\dummy.wav"));
            var fileReaderConcat = dummyFileReader.FollowedBy(dummyFileReader2);

            //add AudioFileReaders to list so they can be disposed later
            fileReaderList.Add(dummyFileReader);
            fileReaderList.Add(dummyFileReader2);

            //calculate the delay that you should add based on the selected speed
            double speedScrollDelay = 5 - 0.5*speedScrollPos;

            foreach (IList<Object> cardRow in wavFileNames)
            {
                if (cardRow[1].ToString() == deckToEdit2.ToString())
                {
                    string newFrontGuid = cardRow[2].ToString();
                    string newBackGuid = cardRow[3].ToString();
                    var newFileReader = new AudioFileReader(String.Format(@"C:\Users\davis\Desktop\NAudio\{0}.wav", newFrontGuid));
                    var newFileReader2 = new AudioFileReader(String.Format(@"C:\Users\davis\Desktop\NAudio\{0}.wav", newBackGuid));

                    if (!playInReverse)
                    {
                        var newFileReaderConcat = fileReaderConcat.FollowedBy(TimeSpan.FromSeconds(speedScrollDelay), newFileReader).FollowedBy(TimeSpan.FromSeconds(speedScrollDelay), newFileReader2);
                        fileReaderConcat = newFileReaderConcat;
                    } else
                    {
                        var newFileReaderConcat = fileReaderConcat.FollowedBy(TimeSpan.FromSeconds(speedScrollDelay), newFileReader2).FollowedBy(TimeSpan.FromSeconds(speedScrollDelay), newFileReader);
                        fileReaderConcat = newFileReaderConcat;
                    }

                    //add AudioFileReaders to list so they can be disposed later
                    fileReaderList.Add(newFileReader);
                    fileReaderList.Add(newFileReader2);
                }
            }

            waveOut.Init(fileReaderConcat);
            waveOut.Play();
        }

        private IList<IList<Object>> WavFileNames()
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
            String range = "A2:F101";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // print data from sheet
            Data.ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            response.MajorDimension = "COLUMNS";

            return values;
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

        private void testButton_Click(object sender, EventArgs e)
        {
            if (waveReader != null) waveReader.Position = 0;
        }

        private void reverseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            playInReverse = reverseCheckBox.Checked;
        }

        private void SpeedControl_Scroll(object sender, EventArgs e)
        {
            speedScrollPos = SpeedControl.Value;
        }

        private void testLabel_Click(object sender, EventArgs e)
        {

        }

        private void testLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
