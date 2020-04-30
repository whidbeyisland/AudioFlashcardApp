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
            this.testLabel = new System.Windows.Forms.Label();
            this.AddCardsButton = new System.Windows.Forms.Button();
            this.testLabel2 = new System.Windows.Forms.Label();
            this.SyncButton = new System.Windows.Forms.Button();
            this.restoreFromCloudButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(171, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(497, 180);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DeckCreateButton
            // 
            this.DeckCreateButton.Location = new System.Drawing.Point(433, 76);
            this.DeckCreateButton.Name = "DeckCreateButton";
            this.DeckCreateButton.Size = new System.Drawing.Size(142, 23);
            this.DeckCreateButton.TabIndex = 1;
            this.DeckCreateButton.Text = "Create";
            this.DeckCreateButton.UseVisualStyleBackColor = true;
            this.DeckCreateButton.Click += new System.EventHandler(this.DeckCreateButton_Click);
            // 
            // newDeckTextBox
            // 
            this.newDeckTextBox.Location = new System.Drawing.Point(274, 76);
            this.newDeckTextBox.Name = "newDeckTextBox";
            this.newDeckTextBox.Size = new System.Drawing.Size(100, 22);
            this.newDeckTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Create New Deck";
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Location = new System.Drawing.Point(373, 115);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(46, 17);
            this.testLabel.TabIndex = 4;
            this.testLabel.Text = "label2";
            // 
            // AddCardsButton
            // 
            this.AddCardsButton.Location = new System.Drawing.Point(171, 359);
            this.AddCardsButton.Name = "AddCardsButton";
            this.AddCardsButton.Size = new System.Drawing.Size(173, 23);
            this.AddCardsButton.TabIndex = 5;
            this.AddCardsButton.Text = "Add/Delete/Edit Cards";
            this.AddCardsButton.UseVisualStyleBackColor = true;
            this.AddCardsButton.Click += new System.EventHandler(this.EditDeckButton_Click);
            // 
            // testLabel2
            // 
            this.testLabel2.AutoSize = true;
            this.testLabel2.Location = new System.Drawing.Point(373, 406);
            this.testLabel2.Name = "testLabel2";
            this.testLabel2.Size = new System.Drawing.Size(46, 17);
            this.testLabel2.TabIndex = 6;
            this.testLabel2.Text = "label2";
            // 
            // SyncButton
            // 
            this.SyncButton.Location = new System.Drawing.Point(368, 359);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(109, 23);
            this.SyncButton.TabIndex = 7;
            this.SyncButton.Text = "Sync to Cloud";
            this.SyncButton.UseVisualStyleBackColor = true;
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // restoreFromCloudButton
            // 
            this.restoreFromCloudButton.Location = new System.Drawing.Point(500, 359);
            this.restoreFromCloudButton.Name = "restoreFromCloudButton";
            this.restoreFromCloudButton.Size = new System.Drawing.Size(168, 23);
            this.restoreFromCloudButton.TabIndex = 8;
            this.restoreFromCloudButton.Text = "Restore from Cloud";
            this.restoreFromCloudButton.UseVisualStyleBackColor = true;
            this.restoreFromCloudButton.Click += new System.EventHandler(this.restoreFromCloudButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.restoreFromCloudButton);
            this.Controls.Add(this.SyncButton);
            this.Controls.Add(this.testLabel2);
            this.Controls.Add(this.AddCardsButton);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newDeckTextBox);
            this.Controls.Add(this.DeckCreateButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button DeckCreateButton;
        private System.Windows.Forms.TextBox newDeckTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label testLabel;
        private System.Windows.Forms.Button AddCardsButton;
        private System.Windows.Forms.Label testLabel2;
        private System.Windows.Forms.Button SyncButton;
        private System.Windows.Forms.Button restoreFromCloudButton;
    }
}