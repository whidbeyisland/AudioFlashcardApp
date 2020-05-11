namespace WindowsFormsApp1
{
    partial class SoundRecordForm
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
			this.SaveCardButton = new System.Windows.Forms.Button();
			this.FrontRecordButton = new System.Windows.Forms.Button();
			this.FrontStopButton = new System.Windows.Forms.Button();
			this.BackRecordButton = new System.Windows.Forms.Button();
			this.BackStopButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cardNameField = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.closeButton = new System.Windows.Forms.Button();
			this.frontPlayButton = new System.Windows.Forms.Button();
			this.backPlayButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SaveCardButton
			// 
			this.SaveCardButton.Location = new System.Drawing.Point(279, 380);
			this.SaveCardButton.Name = "SaveCardButton";
			this.SaveCardButton.Size = new System.Drawing.Size(75, 23);
			this.SaveCardButton.TabIndex = 0;
			this.SaveCardButton.Text = "Save";
			this.SaveCardButton.UseVisualStyleBackColor = true;
			this.SaveCardButton.Click += new System.EventHandler(this.SaveCardButton_Click);
			// 
			// FrontRecordButton
			// 
			this.FrontRecordButton.Location = new System.Drawing.Point(243, 135);
			this.FrontRecordButton.Name = "FrontRecordButton";
			this.FrontRecordButton.Size = new System.Drawing.Size(75, 23);
			this.FrontRecordButton.TabIndex = 1;
			this.FrontRecordButton.Text = "Record";
			this.FrontRecordButton.UseVisualStyleBackColor = true;
			this.FrontRecordButton.Click += new System.EventHandler(this.FrontRecordButton_Click);
			// 
			// FrontStopButton
			// 
			this.FrontStopButton.Location = new System.Drawing.Point(381, 135);
			this.FrontStopButton.Name = "FrontStopButton";
			this.FrontStopButton.Size = new System.Drawing.Size(75, 23);
			this.FrontStopButton.TabIndex = 2;
			this.FrontStopButton.Text = "Stop";
			this.FrontStopButton.UseVisualStyleBackColor = true;
			this.FrontStopButton.Click += new System.EventHandler(this.FrontStopButton_Click);
			// 
			// BackRecordButton
			// 
			this.BackRecordButton.Location = new System.Drawing.Point(243, 221);
			this.BackRecordButton.Name = "BackRecordButton";
			this.BackRecordButton.Size = new System.Drawing.Size(75, 23);
			this.BackRecordButton.TabIndex = 3;
			this.BackRecordButton.Text = "Record";
			this.BackRecordButton.UseVisualStyleBackColor = true;
			this.BackRecordButton.Click += new System.EventHandler(this.BackRecordButton_Click);
			// 
			// BackStopButton
			// 
			this.BackStopButton.Location = new System.Drawing.Point(381, 221);
			this.BackStopButton.Name = "BackStopButton";
			this.BackStopButton.Size = new System.Drawing.Size(75, 23);
			this.BackStopButton.TabIndex = 4;
			this.BackStopButton.Text = "Stop";
			this.BackStopButton.UseVisualStyleBackColor = true;
			this.BackStopButton.Click += new System.EventHandler(this.BackStopButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(94, 135);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "Front of card";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(94, 227);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "Back of card";
			// 
			// cardNameField
			// 
			this.cardNameField.Location = new System.Drawing.Point(368, 302);
			this.cardNameField.Name = "cardNameField";
			this.cardNameField.Size = new System.Drawing.Size(100, 22);
			this.cardNameField.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(97, 305);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(178, 17);
			this.label3.TabIndex = 9;
			this.label3.Text = "Enter a name for your card";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(356, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(123, 17);
			this.label4.TabIndex = 10;
			this.label4.Text = "Create a new card";
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(441, 380);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 11;
			this.closeButton.Text = "Cancel";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// frontPlayButton
			// 
			this.frontPlayButton.Location = new System.Drawing.Point(523, 135);
			this.frontPlayButton.Name = "frontPlayButton";
			this.frontPlayButton.Size = new System.Drawing.Size(75, 23);
			this.frontPlayButton.TabIndex = 12;
			this.frontPlayButton.Text = "Play";
			this.frontPlayButton.UseVisualStyleBackColor = true;
			// 
			// backPlayButton
			// 
			this.backPlayButton.Location = new System.Drawing.Point(523, 220);
			this.backPlayButton.Name = "backPlayButton";
			this.backPlayButton.Size = new System.Drawing.Size(75, 23);
			this.backPlayButton.TabIndex = 13;
			this.backPlayButton.Text = "Play";
			this.backPlayButton.UseVisualStyleBackColor = true;
			// 
			// SoundRecordForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.backPlayButton);
			this.Controls.Add(this.frontPlayButton);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cardNameField);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BackStopButton);
			this.Controls.Add(this.BackRecordButton);
			this.Controls.Add(this.FrontStopButton);
			this.Controls.Add(this.FrontRecordButton);
			this.Controls.Add(this.SaveCardButton);
			this.Name = "SoundRecordForm";
			this.Text = "Form4";
			this.Load += new System.EventHandler(this.SoundRecordForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveCardButton;
        private System.Windows.Forms.Button FrontRecordButton;
        private System.Windows.Forms.Button FrontStopButton;
        private System.Windows.Forms.Button BackRecordButton;
        private System.Windows.Forms.Button BackStopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cardNameField;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button frontPlayButton;
		private System.Windows.Forms.Button backPlayButton;
	}
}