using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class CardEditForm : Form
	{
		public WaveInEvent waveIn;

		public CardEditForm()
		{
			InitializeComponent();
			this.Text = "Edit";
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
	}
}
