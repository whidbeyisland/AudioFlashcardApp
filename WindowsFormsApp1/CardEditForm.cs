﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Data = Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using NAudio.Wave;
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

namespace WindowsFormsApp1
{
	public partial class CardEditForm : Form
	{
		string frontSoundGuid;
		string backSoundGuid;
		public WaveInEvent waveIn;
		public WaveFileWriter writer;
		static string[] Scopes = { SheetsService.Scope.Spreadsheets };
		static string ApplicationName = "Flashchords";
		string cardToEdit2;
		string deckToEdit2;

		public CardEditForm(string cardToEdit, string cardToEditName, string deckToEdit2)
		{
			InitializeComponent();
			this.Text = "Edit";
			cardToEdit2 = cardToEdit;
			cardNameField.Text = cardToEditName;
		}

		private void CardEditForm_Load(object sender, EventArgs e)
		{

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
			try
			{
				if (waveIn != null)
				{
					waveIn.StopRecording();
				}
			}
			catch
			{

			}
		}

		private void cardDiscardButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void frontRecordButton_Click(object sender, EventArgs e)
		{
			frontSoundGuid = Guid.NewGuid().ToString();

			var outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NAudio");
			Directory.CreateDirectory(outputFolder);
			var outputFilePath = Path.Combine(outputFolder, String.Concat(frontSoundGuid, ".wav"));

			waveIn = new WaveInEvent();

			writer = null;

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

		private void SaveCardButton_Click(object sender, EventArgs e)
		{
			if (frontSoundGuid != "" && backSoundGuid != "")
			{
				SaveCard();
				SaveCardButton.Enabled = false;
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

		private void SaveCard()
		{
			//update name to what user's selected, if anything
			if (cardNameField.Text != "" && cardNameField.Text != null)
			{
				
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
			var oblist = new List<object>() { Guid.NewGuid(), cardNameField.Text, deckToEdit2, frontSoundGuid, backSoundGuid, DateTime.Now, DateTime.Now };
			requestBody.Values = new List<IList<object>> { oblist };
			requestBody.MajorDimension = "ROWS";

			SpreadsheetsResource.ValuesResource.AppendRequest request = sheetsService.Spreadsheets.Values.Append(requestBody, spreadsheetId, range);
			request.ValueInputOption = valueInputOption;
			request.InsertDataOption = insertDataOption;

			// To execute asynchronously in an async method, replace `request.Execute()` as shown:
			Data.AppendValuesResponse response = request.Execute();
		}
	}
}
