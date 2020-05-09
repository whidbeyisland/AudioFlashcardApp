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
			// CardEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
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
	}
}