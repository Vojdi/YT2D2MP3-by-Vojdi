namespace YT2D2MP3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            downloadButton = new Button();
            statusBox = new RichTextBox();
            urlTextBox = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            formatComboBox = new ComboBox();
            label3 = new Label();
            qualityComboBox = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(378, 211);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(287, 34);
            downloadButton.TabIndex = 0;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // statusBox
            // 
            statusBox.Location = new Point(97, 293);
            statusBox.Name = "statusBox";
            statusBox.ReadOnly = true;
            statusBox.Size = new Size(578, 144);
            statusBox.TabIndex = 3;
            statusBox.Text = "";
            // 
            // urlTextBox
            // 
            urlTextBox.Location = new Point(97, 12);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(578, 144);
            urlTextBox.TabIndex = 4;
            urlTextBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 12);
            label1.Name = "label1";
            label1.Size = new Size(43, 25);
            label1.TabIndex = 5;
            label1.Text = "URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 293);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 6;
            label2.Text = "Status";
            // 
            // formatComboBox
            // 
            formatComboBox.FormattingEnabled = true;
            formatComboBox.Items.AddRange(new object[] { "mp3", "mp4" });
            formatComboBox.Location = new Point(181, 174);
            formatComboBox.Name = "formatComboBox";
            formatComboBox.Size = new Size(182, 33);
            formatComboBox.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 174);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 8;
            label3.Text = "format";
            // 
            // qualityComboBox
            // 
            qualityComboBox.FormattingEnabled = true;
            qualityComboBox.Location = new Point(181, 239);
            qualityComboBox.Name = "qualityComboBox";
            qualityComboBox.Size = new Size(182, 33);
            qualityComboBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(97, 242);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 10;
            label4.Text = "quality";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 470);
            Controls.Add(label4);
            Controls.Add(qualityComboBox);
            Controls.Add(label3);
            Controls.Add(formatComboBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(urlTextBox);
            Controls.Add(statusBox);
            Controls.Add(downloadButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "YT2D2MP3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button downloadButton;
        private RichTextBox statusBox;
        private RichTextBox urlTextBox;
        private Label label1;
        private Label label2;
        private ComboBox formatComboBox;
        private Label label3;
        private ComboBox qualityComboBox;
        private Label label4;
    }
}
