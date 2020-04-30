namespace WindowsFormsApp1
{
    partial class PlaybackForm
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
            this.testLabel = new System.Windows.Forms.Label();
            this.PlayDeckButton = new System.Windows.Forms.Button();
            this.SpeedControl = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.StopDeckButton = new System.Windows.Forms.Button();
            this.testLabel2 = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.reverseCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedControl)).BeginInit();
            this.SuspendLayout();
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Location = new System.Drawing.Point(394, 54);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(46, 17);
            this.testLabel.TabIndex = 0;
            this.testLabel.Text = "label1";
            // 
            // PlayDeckButton
            // 
            this.PlayDeckButton.Location = new System.Drawing.Point(358, 330);
            this.PlayDeckButton.Name = "PlayDeckButton";
            this.PlayDeckButton.Size = new System.Drawing.Size(109, 23);
            this.PlayDeckButton.TabIndex = 1;
            this.PlayDeckButton.Text = "Play";
            this.PlayDeckButton.UseVisualStyleBackColor = true;
            this.PlayDeckButton.Click += new System.EventHandler(this.PlayDeckButton_Click);
            // 
            // SpeedControl
            // 
            this.SpeedControl.Location = new System.Drawing.Point(363, 109);
            this.SpeedControl.Name = "SpeedControl";
            this.SpeedControl.Size = new System.Drawing.Size(104, 56);
            this.SpeedControl.TabIndex = 2;
            this.SpeedControl.Value = 10;
            this.SpeedControl.Scroll += new System.EventHandler(this.SpeedControl_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Speed";
            // 
            // StopDeckButton
            // 
            this.StopDeckButton.Location = new System.Drawing.Point(358, 372);
            this.StopDeckButton.Name = "StopDeckButton";
            this.StopDeckButton.Size = new System.Drawing.Size(109, 23);
            this.StopDeckButton.TabIndex = 4;
            this.StopDeckButton.Text = "Stop";
            this.StopDeckButton.UseVisualStyleBackColor = true;
            this.StopDeckButton.Click += new System.EventHandler(this.StopDeckButton_Click);
            // 
            // testLabel2
            // 
            this.testLabel2.AutoSize = true;
            this.testLabel2.Location = new System.Drawing.Point(397, 214);
            this.testLabel2.Name = "testLabel2";
            this.testLabel2.Size = new System.Drawing.Size(46, 17);
            this.testLabel2.TabIndex = 5;
            this.testLabel2.Text = "label2";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(598, 270);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(115, 23);
            this.testButton.TabIndex = 6;
            this.testButton.Text = "Test Button";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // reverseCheckBox
            // 
            this.reverseCheckBox.AutoSize = true;
            this.reverseCheckBox.Location = new System.Drawing.Point(270, 155);
            this.reverseCheckBox.Name = "reverseCheckBox";
            this.reverseCheckBox.Size = new System.Drawing.Size(271, 21);
            this.reverseCheckBox.TabIndex = 7;
            this.reverseCheckBox.Text = "Play cards in reverse (back sides first)";
            this.reverseCheckBox.UseVisualStyleBackColor = true;
            this.reverseCheckBox.CheckedChanged += new System.EventHandler(this.reverseCheckBox_CheckedChanged);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reverseCheckBox);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.testLabel2);
            this.Controls.Add(this.StopDeckButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpeedControl);
            this.Controls.Add(this.PlayDeckButton);
            this.Controls.Add(this.testLabel);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SpeedControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label testLabel;
        private System.Windows.Forms.Button PlayDeckButton;
        private System.Windows.Forms.TrackBar SpeedControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StopDeckButton;
        private System.Windows.Forms.Label testLabel2;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.CheckBox reverseCheckBox;
    }
}