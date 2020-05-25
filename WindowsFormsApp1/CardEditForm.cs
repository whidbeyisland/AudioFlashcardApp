using Google.Apis.Sheets.v4;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

		public CardEditForm(string cardToEdit)
		{
			InitializeComponent();
			this.Text = "Edit";
			cardToEdit2 = cardToEdit;
		}

		private void CardEditForm_Load(object sender, EventArgs e)
		{

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
	}
}
