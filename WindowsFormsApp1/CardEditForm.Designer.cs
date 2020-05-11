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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.cardSaveButton = new System.Windows.Forms.Button();
			this.cardDiscardButton = new System.Windows.Forms.Button();
			this.frontRecordButton = new System.Windows.Forms.Button();
			this.frontStopButton = new System.Windows.Forms.Button();
			this.frontPlayButton = new System.Windows.Forms.Button();
			this.backRecordButton = new System.Windows.Forms.Button();
			this.backStopButton = new System.Windows.Forms.Button();
			this.backPlayButton = new System.Windows.Forms.Button();
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
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(366, 306);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 22);
			this.textBox1.TabIndex = 4;
			// 
			// cardSaveButton
			// 
			this.cardSaveButton.Location = new System.Drawing.Point(302, 364);
			this.cardSaveButton.Name = "cardSaveButton";
			this.cardSaveButton.Size = new System.Drawing.Size(75, 23);
			this.cardSaveButton.TabIndex = 5;
			this.cardSaveButton.Text = "Save";
			this.cardSaveButton.UseVisualStyleBackColor = true;
			// 
			// cardDiscardButton
			// 
			this.cardDiscardButton.Location = new System.Drawing.Point(440, 364);
			this.cardDiscardButton.Name = "cardDiscardButton";
			this.cardDiscardButton.Size = new System.Drawing.Size(135, 23);
			this.cardDiscardButton.TabIndex = 6;
			this.cardDiscardButton.Text = "Discard changes";
			this.cardDiscardButton.UseVisualStyleBackColor = true;
			this.cardDiscardButton.Click += new System.EventHandler(this.cardDiscardButton_Click);
			// 
			// frontRecordButton
			// 
			this.frontRecordButton.Location = new System.Drawing.Point(275, 124);
			this.frontRecordButton.Name = "frontRecordButton";
			this.frontRecordButton.Size = new System.Drawing.Size(75, 23);
			this.frontRecordButton.TabIndex = 7;
			this.frontRecordButton.Text = "Record";
			this.frontRecordButton.UseVisualStyleBackColor = true;
			// 
			// frontStopButton
			// 
			this.frontStopButton.Location = new System.Drawing.Point(418, 123);
			this.frontStopButton.Name = "frontStopButton";
			this.frontStopButton.Size = new System.Drawing.Size(75, 23);
			this.frontStopButton.TabIndex = 8;
			this.frontStopButton.Text = "Stop";
			this.frontStopButton.UseVisualStyleBackColor = true;
			// 
			// frontPlayButton
			// 
			this.frontPlayButton.Location = new System.Drawing.Point(569, 124);
			this.frontPlayButton.Name = "frontPlayButton";
			this.frontPlayButton.Size = new System.Drawing.Size(75, 23);
			this.frontPlayButton.TabIndex = 9;
			this.frontPlayButton.Text = "Play";
			this.frontPlayButton.UseVisualStyleBackColor = true;
			// 
			// backRecordButton
			// 
			this.backRecordButton.Location = new System.Drawing.Point(275, 225);
			this.backRecordButton.Name = "backRecordButton";
			this.backRecordButton.Size = new System.Drawing.Size(75, 23);
			this.backRecordButton.TabIndex = 10;
			this.backRecordButton.Text = "Record";
			this.backRecordButton.UseVisualStyleBackColor = true;
			// 
			// backStopButton
			// 
			this.backStopButton.Location = new System.Drawing.Point(418, 225);
			this.backStopButton.Name = "backStopButton";
			this.backStopButton.Size = new System.Drawing.Size(75, 23);
			this.backStopButton.TabIndex = 11;
			this.backStopButton.Text = "Stop";
			this.backStopButton.UseVisualStyleBackColor = true;
			// 
			// backPlayButton
			// 
			this.backPlayButton.Location = new System.Drawing.Point(569, 225);
			this.backPlayButton.Name = "backPlayButton";
			this.backPlayButton.Size = new System.Drawing.Size(75, 23);
			this.backPlayButton.TabIndex = 12;
			this.backPlayButton.Text = "Play";
			this.backPlayButton.UseVisualStyleBackColor = true;
			// 
			// CardEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.backPlayButton);
			this.Controls.Add(this.backStopButton);
			this.Controls.Add(this.backRecordButton);
			this.Controls.Add(this.frontPlayButton);
			this.Controls.Add(this.frontStopButton);
			this.Controls.Add(this.frontRecordButton);
			this.Controls.Add(this.cardDiscardButton);
			this.Controls.Add(this.cardSaveButton);
			this.Controls.Add(this.textBox1);
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
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button cardSaveButton;
		private System.Windows.Forms.Button cardDiscardButton;
		private System.Windows.Forms.Button frontRecordButton;
		private System.Windows.Forms.Button frontStopButton;
		private System.Windows.Forms.Button frontPlayButton;
		private System.Windows.Forms.Button backRecordButton;
		private System.Windows.Forms.Button backStopButton;
		private System.Windows.Forms.Button backPlayButton;
	}
}