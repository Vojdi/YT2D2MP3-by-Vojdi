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
        protected void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
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
            openFolderCheckBox = new CheckBox();
            interprets = new RichTextBox();
            labelPerformers = new Label();
            clear = new Button();
            SuspendLayout();
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(388, 237);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(298, 34);
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
            statusBox.Size = new Size(1169, 144);
            statusBox.TabIndex = 3;
            statusBox.Text = "";
            // 
            // urlTextBox
            // 
            urlTextBox.Location = new Point(97, 12);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(1169, 144);
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
            // openFolderCheckBox
            // 
            openFolderCheckBox.AutoSize = true;
            openFolderCheckBox.BackColor = SystemColors.Window;
            openFolderCheckBox.Location = new Point(388, 178);
            openFolderCheckBox.Name = "openFolderCheckBox";
            openFolderCheckBox.Size = new Size(298, 29);
            openFolderCheckBox.TabIndex = 11;
            openFolderCheckBox.Text = "Open File Location on Download";
            openFolderCheckBox.UseVisualStyleBackColor = false;
            // 
            // interprets
            // 
            interprets.Location = new Point(912, 174);
            interprets.Name = "interprets";
            interprets.Size = new Size(354, 113);
            interprets.TabIndex = 12;
            interprets.Text = "";
            // 
            // labelPerformers
            // 
            labelPerformers.AutoSize = true;
            labelPerformers.BackColor = SystemColors.Window;
            labelPerformers.Location = new Point(695, 179);
            labelPerformers.Name = "labelPerformers";
            labelPerformers.Size = new Size(211, 25);
            labelPerformers.TabIndex = 13;
            labelPerformers.Text = "Performers(one line each)";
            // 
            // clear
            // 
            clear.Location = new Point(706, 238);
            clear.Name = "clear";
            clear.Size = new Size(195, 32);
            clear.TabIndex = 14;
            clear.Text = "Clear All";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1288, 470);
            Controls.Add(clear);
            Controls.Add(labelPerformers);
            Controls.Add(interprets);
            Controls.Add(openFolderCheckBox);
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
        private CheckBox openFolderCheckBox;
        private RichTextBox interprets;
        private Label labelPerformers;
        private Button clear;
    }
}
