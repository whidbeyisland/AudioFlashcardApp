namespace WindowsFormsApp1
{
    partial class DeckListForm
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.DeckCreateButton = new System.Windows.Forms.Button();
			this.newDeckTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.AddCardsButton = new System.Windows.Forms.Button();
			this.SyncButton = new System.Windows.Forms.Button();
			this.restoreFromCloudButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.renameButton = new System.Windows.Forms.Button();
			this.deckNameBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(171, 134);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(497, 195);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// DeckCreateButton
			// 
			this.DeckCreateButton.Location = new System.Drawing.Point(500, 51);
			this.DeckCreateButton.Name = "DeckCreateButton";
			this.DeckCreateButton.Size = new System.Drawing.Size(142, 23);
			this.DeckCreateButton.TabIndex = 1;
			this.DeckCreateButton.Text = "Create";
			this.DeckCreateButton.UseVisualStyleBackColor = true;
			this.DeckCreateButton.Click += new System.EventHandler(this.DeckCreateButton_Click);
			// 
			// newDeckTextBox
			// 
			this.newDeckTextBox.Location = new System.Drawing.Point(318, 51);
			this.newDeckTextBox.Name = "newDeckTextBox";
			this.newDeckTextBox.Size = new System.Drawing.Size(159, 22);
			this.newDeckTextBox.TabIndex = 2;
			this.newDeckTextBox.TextChanged += new System.EventHandler(this.newDeckTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(343, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Create New Deck";
			// 
			// AddCardsButton
			// 
			this.AddCardsButton.Location = new System.Drawing.Point(124, 335);
			this.AddCardsButton.Name = "AddCardsButton";
			this.AddCardsButton.Size = new System.Drawing.Size(173, 23);
			this.AddCardsButton.TabIndex = 5;
			this.AddCardsButton.Text = "Add/Delete/Edit Cards";
			this.AddCardsButton.UseVisualStyleBackColor = true;
			this.AddCardsButton.Click += new System.EventHandler(this.EditDeckButton_Click);
			// 
			// SyncButton
			// 
			this.SyncButton.Location = new System.Drawing.Point(253, 415);
			this.SyncButton.Name = "SyncButton";
			this.SyncButton.Size = new System.Drawing.Size(109, 23);
			this.SyncButton.TabIndex = 7;
			this.SyncButton.Text = "Sync to Cloud";
			this.SyncButton.UseVisualStyleBackColor = true;
			this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
			// 
			// restoreFromCloudButton
			// 
			this.restoreFromCloudButton.Location = new System.Drawing.Point(408, 415);
			this.restoreFromCloudButton.Name = "restoreFromCloudButton";
			this.restoreFromCloudButton.Size = new System.Drawing.Size(168, 23);
			this.restoreFromCloudButton.TabIndex = 8;
			this.restoreFromCloudButton.Text = "Restore from Cloud";
			this.restoreFromCloudButton.UseVisualStyleBackColor = true;
			this.restoreFromCloudButton.Click += new System.EventHandler(this.restoreFromCloudButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(198, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "Enter deck name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(343, 108);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "Edit Existing Deck";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(366, 338);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 17);
			this.label4.TabIndex = 11;
			this.label4.Text = "Rename Deck";
			// 
			// renameButton
			// 
			this.renameButton.Location = new System.Drawing.Point(647, 335);
			this.renameButton.Name = "renameButton";
			this.renameButton.Size = new System.Drawing.Size(75, 23);
			this.renameButton.TabIndex = 12;
			this.renameButton.Text = "Rename";
			this.renameButton.UseVisualStyleBackColor = true;
			// 
			// deckNameBox
			// 
			this.deckNameBox.Location = new System.Drawing.Point(469, 336);
			this.deckNameBox.Name = "deckNameBox";
			this.deckNameBox.Size = new System.Drawing.Size(162, 22);
			this.deckNameBox.TabIndex = 13;
			// 
			// DeckListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.deckNameBox);
			this.Controls.Add(this.renameButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.restoreFromCloudButton);
			this.Controls.Add(this.SyncButton);
			this.Controls.Add(this.AddCardsButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.newDeckTextBox);
			this.Controls.Add(this.DeckCreateButton);
			this.Controls.Add(this.dataGridView1);
			this.Name = "DeckListForm";
			this.Text = "Form2";
			this.Load += new System.EventHandler(this.DeckListForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button DeckCreateButton;
        private System.Windows.Forms.TextBox newDeckTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddCardsButton;
        private System.Windows.Forms.Button SyncButton;
        private System.Windows.Forms.Button restoreFromCloudButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button renameButton;
		private System.Windows.Forms.TextBox deckNameBox;
	}
}