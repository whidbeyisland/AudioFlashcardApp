﻿namespace WindowsFormsApp1
{
    partial class CardListForm
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.AddNewCardButton = new System.Windows.Forms.Button();
			this.StudyDeckButton = new System.Windows.Forms.Button();
			this.EditCardButton = new System.Windows.Forms.Button();
			this.DeleteCardButton = new System.Windows.Forms.Button();
			this.testLabel2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(314, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(161, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Your Cards in This Deck";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(62, 93);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(680, 192);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// AddNewCardButton
			// 
			this.AddNewCardButton.Location = new System.Drawing.Point(332, 354);
			this.AddNewCardButton.Name = "AddNewCardButton";
			this.AddNewCardButton.Size = new System.Drawing.Size(126, 23);
			this.AddNewCardButton.TabIndex = 3;
			this.AddNewCardButton.Text = "Add New Card";
			this.AddNewCardButton.UseVisualStyleBackColor = true;
			this.AddNewCardButton.Click += new System.EventHandler(this.AddNewCardButton_Click);
			// 
			// StudyDeckButton
			// 
			this.StudyDeckButton.Location = new System.Drawing.Point(332, 397);
			this.StudyDeckButton.Name = "StudyDeckButton";
			this.StudyDeckButton.Size = new System.Drawing.Size(126, 23);
			this.StudyDeckButton.TabIndex = 4;
			this.StudyDeckButton.Text = "Study Deck";
			this.StudyDeckButton.UseVisualStyleBackColor = true;
			this.StudyDeckButton.Click += new System.EventHandler(this.StudyDeckButton_Click);
			// 
			// EditCardButton
			// 
			this.EditCardButton.Location = new System.Drawing.Point(255, 306);
			this.EditCardButton.Name = "EditCardButton";
			this.EditCardButton.Size = new System.Drawing.Size(75, 23);
			this.EditCardButton.TabIndex = 5;
			this.EditCardButton.Text = "Edit Card";
			this.EditCardButton.UseVisualStyleBackColor = true;
			this.EditCardButton.Click += new System.EventHandler(this.EditCardButton_Click);
			// 
			// DeleteCardButton
			// 
			this.DeleteCardButton.Location = new System.Drawing.Point(460, 306);
			this.DeleteCardButton.Name = "DeleteCardButton";
			this.DeleteCardButton.Size = new System.Drawing.Size(102, 23);
			this.DeleteCardButton.TabIndex = 6;
			this.DeleteCardButton.Text = "Delete Card";
			this.DeleteCardButton.UseVisualStyleBackColor = true;
			this.DeleteCardButton.Click += new System.EventHandler(this.DeleteCardButton_Click);
			// 
			// testLabel2
			// 
			this.testLabel2.Location = new System.Drawing.Point(0, 0);
			this.testLabel2.Name = "testLabel2";
			this.testLabel2.Size = new System.Drawing.Size(100, 23);
			this.testLabel2.TabIndex = 0;
			// 
			// CardListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.testLabel2);
			this.Controls.Add(this.DeleteCardButton);
			this.Controls.Add(this.EditCardButton);
			this.Controls.Add(this.StudyDeckButton);
			this.Controls.Add(this.AddNewCardButton);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label1);
			this.Name = "CardListForm";
			this.Text = "Form3";
			this.Load += new System.EventHandler(this.Form3_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddNewCardButton;
        private System.Windows.Forms.Button StudyDeckButton;
        private System.Windows.Forms.Button EditCardButton;
        private System.Windows.Forms.Button DeleteCardButton;
        private System.Windows.Forms.Label testLabel2;
    }
}