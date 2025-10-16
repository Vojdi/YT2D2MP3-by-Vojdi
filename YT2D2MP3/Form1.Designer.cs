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
            label5 = new Label();
            fileNameTextBox = new TextBox();
            label6 = new Label();
            browseFolderButton = new Button();
            folderTextBox = new TextBox();
            playlistCheckBox = new CheckBox();
            stopButton = new Button();
            SuspendLayout();
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(483, 259);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(298, 34);
            downloadButton.TabIndex = 0;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // statusBox
            // 
            statusBox.Location = new Point(95, 341);
            statusBox.Name = "statusBox";
            statusBox.ReadOnly = true;
            statusBox.Size = new Size(1090, 144);
            statusBox.TabIndex = 3;
            statusBox.Text = "";
            // 
            // urlTextBox
            // 
            urlTextBox.Location = new Point(97, 12);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(1088, 115);
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
            label2.Location = new Point(31, 346);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 6;
            label2.Text = "Status";
            // 
            // formatComboBox
            // 
            formatComboBox.FormattingEnabled = true;
            formatComboBox.Items.AddRange(new object[] { "mp3", "mp4" });
            formatComboBox.Location = new Point(214, 238);
            formatComboBox.Name = "formatComboBox";
            formatComboBox.Size = new Size(212, 33);
            formatComboBox.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(142, 247);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 8;
            label3.Text = "format";
            // 
            // qualityComboBox
            // 
            qualityComboBox.FormattingEnabled = true;
            qualityComboBox.Location = new Point(214, 290);
            qualityComboBox.Name = "qualityComboBox";
            qualityComboBox.Size = new Size(212, 33);
            qualityComboBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(143, 297);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 10;
            label4.Text = "quality";
            // 
            // openFolderCheckBox
            // 
            openFolderCheckBox.AutoSize = true;
            openFolderCheckBox.BackColor = SystemColors.Window;
            openFolderCheckBox.Location = new Point(483, 222);
            openFolderCheckBox.Name = "openFolderCheckBox";
            openFolderCheckBox.Size = new Size(298, 29);
            openFolderCheckBox.TabIndex = 11;
            openFolderCheckBox.Text = "Open File Location on Download";
            openFolderCheckBox.UseVisualStyleBackColor = false;
            // 
            // interprets
            // 
            interprets.Location = new Point(920, 220);
            interprets.Name = "interprets";
            interprets.Size = new Size(265, 113);
            interprets.TabIndex = 12;
            interprets.Text = "";
            // 
            // labelPerformers
            // 
            labelPerformers.AutoSize = true;
            labelPerformers.BackColor = SystemColors.Window;
            labelPerformers.Location = new Point(954, 180);
            labelPerformers.Name = "labelPerformers";
            labelPerformers.Size = new Size(211, 25);
            labelPerformers.TabIndex = 13;
            labelPerformers.Text = "Performers(one line each)";
            // 
            // clear
            // 
            clear.Location = new Point(483, 297);
            clear.Name = "clear";
            clear.Size = new Size(298, 38);
            clear.TabIndex = 14;
            clear.Text = "Clear All";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(114, 187);
            label5.Name = "label5";
            label5.Size = new Size(94, 25);
            label5.TabIndex = 15;
            label5.Text = "File Name:";
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.Location = new Point(214, 184);
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.Size = new Size(212, 31);
            fileNameTextBox.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(97, 139);
            label6.Name = "label6";
            label6.Size = new Size(111, 25);
            label6.TabIndex = 17;
            label6.Text = "FIle Location";
            // 
            // browseFolderButton
            // 
            browseFolderButton.Location = new Point(214, 134);
            browseFolderButton.Name = "browseFolderButton";
            browseFolderButton.Size = new Size(212, 34);
            browseFolderButton.TabIndex = 18;
            browseFolderButton.Text = "Browse";
            browseFolderButton.UseVisualStyleBackColor = true;
            browseFolderButton.Click += browseFolderButton_Click_1;
            // 
            // folderTextBox
            // 
            folderTextBox.Location = new Point(454, 133);
            folderTextBox.Name = "folderTextBox";
            folderTextBox.ReadOnly = true;
            folderTextBox.Size = new Size(731, 31);
            folderTextBox.TabIndex = 19;
            // 
            // playlistCheckBox
            // 
            playlistCheckBox.AllowDrop = true;
            playlistCheckBox.AutoSize = true;
            playlistCheckBox.BackColor = SystemColors.Window;
            playlistCheckBox.Location = new Point(509, 180);
            playlistCheckBox.Name = "playlistCheckBox";
            playlistCheckBox.Size = new Size(232, 29);
            playlistCheckBox.TabIndex = 20;
            playlistCheckBox.Text = "Download whole playlist";
            playlistCheckBox.UseVisualStyleBackColor = false;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(802, 180);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(112, 153);
            stopButton.TabIndex = 21;
            stopButton.Text = "STOP";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 516);
            Controls.Add(stopButton);
            Controls.Add(playlistCheckBox);
            Controls.Add(folderTextBox);
            Controls.Add(browseFolderButton);
            Controls.Add(label6);
            Controls.Add(fileNameTextBox);
            Controls.Add(label5);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
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
        private Label label5;
        private TextBox fileNameTextBox;
        private Label label6;
        private Button browseFolderButton;
        private TextBox folderTextBox;
        private CheckBox playlistCheckBox;
        private Button stopButton;
    }
}
