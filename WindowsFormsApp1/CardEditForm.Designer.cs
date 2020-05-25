namespace WindowsFormsApp1
{
	partial class CardEditForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cardNameField = new System.Windows.Forms.TextBox();
			this.SaveCardButton = new System.Windows.Forms.Button();
			this.cardDiscardButton = new System.Windows.Forms.Button();
			this.FrontRecordButton = new System.Windows.Forms.Button();
			this.FrontStopButton = new System.Windows.Forms.Button();
			this.FrontPlayButton = new System.Windows.Forms.Button();
			this.BackRecordButton = new System.Windows.Forms.Button();
			this.BackStopButton = new System.Windows.Forms.Button();
			this.BackPlayButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(370, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Edit your card";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(120, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Front of card";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(123, 232);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Back of card";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(126, 309);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Name of card";
			// 
			// cardNameField
			// 
			this.cardNameField.Location = new System.Drawing.Point(366, 306);
			this.cardNameField.Name = "cardNameField";
			this.cardNameField.Size = new System.Drawing.Size(100, 22);
			this.cardNameField.TabIndex = 4;
			// 
			// SaveCardButton
			// 
			this.SaveCardButton.Location = new System.Drawing.Point(297, 364);
			this.SaveCardButton.Name = "SaveCardButton";
			this.SaveCardButton.Size = new System.Drawing.Size(75, 23);
			this.SaveCardButton.TabIndex = 5;
			this.SaveCardButton.Text = "Save";
			this.SaveCardButton.UseVisualStyleBackColor = true;
			this.SaveCardButton.Click += new System.EventHandler(this.SaveCardButton_Click);
			// 
			// cardDiscardButton
			// 
			this.cardDiscardButton.Location = new System.Drawing.Point(433, 364);
			this.cardDiscardButton.Name = "cardDiscardButton";
			this.cardDiscardButton.Size = new System.Drawing.Size(90, 23);
			this.cardDiscardButton.TabIndex = 6;
			this.cardDiscardButton.Text = "Cancel";
			this.cardDiscardButton.UseVisualStyleBackColor = true;
			this.cardDiscardButton.Click += new System.EventHandler(this.cardDiscardButton_Click);
			// 
			// FrontRecordButton
			// 
			this.FrontRecordButton.Location = new System.Drawing.Point(275, 124);
			this.FrontRecordButton.Name = "FrontRecordButton";
			this.FrontRecordButton.Size = new System.Drawing.Size(75, 23);
			this.FrontRecordButton.TabIndex = 7;
			this.FrontRecordButton.Text = "Record";
			this.FrontRecordButton.UseVisualStyleBackColor = true;
			this.FrontRecordButton.Click += new System.EventHandler(this.frontRecordButton_Click);
			// 
			// FrontStopButton
			// 
			this.FrontStopButton.Location = new System.Drawing.Point(418, 123);
			this.FrontStopButton.Name = "FrontStopButton";
			this.FrontStopButton.Size = new System.Drawing.Size(75, 23);
			this.FrontStopButton.TabIndex = 8;
			this.FrontStopButton.Text = "Stop";
			this.FrontStopButton.UseVisualStyleBackColor = true;
			this.FrontStopButton.Click += new System.EventHandler(this.FrontStopButton_Click);
			// 
			// FrontPlayButton
			// 
			this.FrontPlayButton.Location = new System.Drawing.Point(569, 124);
			this.FrontPlayButton.Name = "FrontPlayButton";
			this.FrontPlayButton.Size = new System.Drawing.Size(75, 23);
			this.FrontPlayButton.TabIndex = 9;
			this.FrontPlayButton.Text = "Play";
			this.FrontPlayButton.UseVisualStyleBackColor = true;
			// 
			// BackRecordButton
			// 
			this.BackRecordButton.Location = new System.Drawing.Point(275, 225);
			this.BackRecordButton.Name = "BackRecordButton";
			this.BackRecordButton.Size = new System.Drawing.Size(75, 23);
			this.BackRecordButton.TabIndex = 10;
			this.BackRecordButton.Text = "Record";
			this.BackRecordButton.UseVisualStyleBackColor = true;
			this.BackRecordButton.Click += new System.EventHandler(this.BackRecordButton_Click);
			// 
			// BackStopButton
			// 
			this.BackStopButton.Location = new System.Drawing.Point(418, 225);
			this.BackStopButton.Name = "BackStopButton";
			this.BackStopButton.Size = new System.Drawing.Size(75, 23);
			this.BackStopButton.TabIndex = 11;
			this.BackStopButton.Text = "Stop";
			this.BackStopButton.UseVisualStyleBackColor = true;
			this.BackStopButton.Click += new System.EventHandler(this.BackStopButton_Click);
			// 
			// BackPlayButton
			// 
			this.BackPlayButton.Location = new System.Drawing.Point(569, 225);
			this.BackPlayButton.Name = "BackPlayButton";
			this.BackPlayButton.Size = new System.Drawing.Size(75, 23);
			this.BackPlayButton.TabIndex = 12;
			this.BackPlayButton.Text = "Play";
			this.BackPlayButton.UseVisualStyleBackColor = true;
			// 
			// CardEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.BackPlayButton);
			this.Controls.Add(this.BackStopButton);
			this.Controls.Add(this.BackRecordButton);
			this.Controls.Add(this.FrontPlayButton);
			this.Controls.Add(this.FrontStopButton);
			this.Controls.Add(this.FrontRecordButton);
			this.Controls.Add(this.cardDiscardButton);
			this.Controls.Add(this.SaveCardButton);
			this.Controls.Add(this.cardNameField);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "CardEditForm";
			this.Text = "CardEditForm";
			this.Load += new System.EventHandler(this.CardEditForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox cardNameField;
		private System.Windows.Forms.Button SaveCardButton;
		private System.Windows.Forms.Button cardDiscardButton;
		private System.Windows.Forms.Button FrontRecordButton;
		private System.Windows.Forms.Button FrontStopButton;
		private System.Windows.Forms.Button FrontPlayButton;
		private System.Windows.Forms.Button BackRecordButton;
		private System.Windows.Forms.Button BackStopButton;
		private System.Windows.Forms.Button BackPlayButton;
	}
}