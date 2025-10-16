using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TagLib;

namespace YT2D2MP3
{
    public partial class Form1 : Form
    {
        private Process currentDownloadProcess;
        private string currentDownloadFolder;

        public Form1()
        {
            InitializeComponent();

            // Only subscribe to events that are NOT assigned in designer
            formatComboBox.SelectedIndexChanged += formatComboBox_SelectedIndexChanged;
            formatComboBox.SelectedIndex = 0;

            stopButton.Enabled = false;
        }

        private void formatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            qualityComboBox.Items.Clear();
            bool isMp3 = formatComboBox.SelectedItem?.ToString() == "mp3";

            if (isMp3)
            {
                qualityComboBox.Items.AddRange(new[] { "Best (VBR) - 0", "High (V2)", "Medium (V5)", "Low (V9)" });
                qualityComboBox.SelectedIndex = 0;
            }
            else
            {
                qualityComboBox.Items.AddRange(new[] {
                    "2160p (4K)", "1440p", "1080p", "720p", "480p", "360p", "240p", "144p"
                });
                qualityComboBox.SelectedIndex = 0;
            }

            labelPerformers.Visible = isMp3;
            interprets.Visible = isMp3;
        }

        private void AppendText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendText), text);
                return;
            }
            statusBox.AppendText(text + "\r\n");
        }

        private void browseFolderButton_Click_1(object sender, EventArgs e)
        {
            using var folderDialog = new FolderBrowserDialog
            {
                Description = "Select download folder"
            };
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                folderTextBox.Text = folderDialog.SelectedPath;
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a YouTube URL.");
                return;
            }

            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string ytDlpPath = Path.Combine(exeDir, "yt-dlp.exe");
            string ffmpegPath = Path.Combine(exeDir, "ffmpeg.exe");

            if (!System.IO.File.Exists(ytDlpPath) || !System.IO.File.Exists(ffmpegPath))
            {
                MessageBox.Show("yt-dlp.exe or ffmpeg.exe not found in the application directory.");
                return;
            }

            if (formatComboBox.SelectedItem == null || qualityComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a format and quality.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedFormat = formatComboBox.SelectedItem.ToString();
            string selectedQuality = qualityComboBox.SelectedItem.ToString();

            string saveFolder = folderTextBox.Text.Trim();
            if (string.IsNullOrEmpty(saveFolder) || !Directory.Exists(saveFolder))
            {
                MessageBox.Show("Please select a valid folder to save the file.", "Folder Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileName = fileNameTextBox.Text.Trim();
            string extension = selectedFormat == "mp3" ? ".mp3" : ".mp4";

            bool isPlaylist = playlistCheckBox.Checked;

            string outputPath = isPlaylist
                ? Path.Combine(saveFolder, "%(title)s.%(ext)s")
                : Path.Combine(saveFolder, string.IsNullOrEmpty(fileName) ? "output" + extension : fileName + extension);

            currentDownloadFolder = saveFolder;

            downloadButton.Enabled = false;
            stopButton.Enabled = true;
            statusBox.Text = "Downloading... Please wait.\r\n";

            string playlistFlag = isPlaylist ? "" : "--no-playlist";

            string arguments;
            if (selectedFormat == "mp3")
            {
                string audioQuality = selectedQuality switch
                {
                    "Best (VBR) - 0" => "0",
                    "High (V2)" => "2",
                    "Medium (V5)" => "5",
                    "Low (V9)" => "9",
                    _ => "0"
                };
                arguments = $"-x --audio-format mp3 --audio-quality {audioQuality} -o \"{outputPath}\" --no-mtime {playlistFlag} {url}";
            }
            else // mp4
            {
                string resolutionFilter = selectedQuality switch
                {
                    "2160p (4K)" => "bestvideo[height<=2160][ext=mp4]+bestaudio[ext=m4a]/best[height<=2160][ext=mp4]",
                    "1440p" => "bestvideo[height<=1440][ext=mp4]+bestaudio[ext=m4a]/best[height<=1440][ext=mp4]",
                    "1080p" => "bestvideo[height<=1080][ext=mp4]+bestaudio[ext=m4a]/best[height<=1080][ext=mp4]",
                    "720p" => "bestvideo[height<=720][ext=mp4]+bestaudio[ext=m4a]/best[height<=720][ext=mp4]",
                    "480p" => "bestvideo[height<=480][ext=mp4]+bestaudio[ext=m4a]/best[height<=480][ext=mp4]",
                    "360p" => "bestvideo[height<=360][ext=mp4]+bestaudio[ext=m4a]/best[height<=360][ext=mp4]",
                    "240p" => "bestvideo[height<=240][ext=mp4]+bestaudio[ext=m4a]/best[height<=240][ext=mp4]",
                    "144p" => "bestvideo[height<=144][ext=mp4]+bestaudio[ext=m4a]/best[height<=144][ext=mp4]",
                    _ => "bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]"
                };
                arguments = $"-f {resolutionFilter} -o \"{outputPath}\" --no-mtime {playlistFlag} {url}";
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = ytDlpPath,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            currentDownloadProcess = new Process { StartInfo = psi, EnableRaisingEvents = true };

            currentDownloadProcess.OutputDataReceived += (s, ea) =>
            {
                if (!string.IsNullOrEmpty(ea.Data))
                    AppendText(ea.Data);
            };

            currentDownloadProcess.ErrorDataReceived += (s, ea) =>
            {
                if (!string.IsNullOrEmpty(ea.Data))
                    AppendText("[Error] " + ea.Data);
            };

            currentDownloadProcess.Exited += (s, ea) =>
            {
                Invoke((MethodInvoker)(() =>
                {
                    downloadButton.Enabled = true;
                    stopButton.Enabled = false;
                    statusBox.AppendText("\r\nDone.\r\n");
                    currentDownloadProcess = null;

                    if (!isPlaylist && selectedFormat == "mp3")
                    {
                        try
                        {
                            string title = Path.GetFileNameWithoutExtension(outputPath);
                            var file = TagLib.File.Create(outputPath);
                            file.Tag.Title = title;

                            var artistLines = interprets.Text
                                .Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                            file.Tag.Performers = artistLines;

                            file.Save();
                            AppendText($"[Tag Updated] Title: {title}, Interprets: {string.Join(", ", artistLines)}");
                        }
                        catch (Exception ex)
                        {
                            AppendText($"[Tag Error] Could not set MP3 metadata: {ex.Message}");
                        }
                    }

                    if (openFolderCheckBox.Checked && Directory.Exists(saveFolder))
                    {
                        Process.Start("explorer.exe", saveFolder);
                    }
                }));
            };

            try
            {
                currentDownloadProcess.Start();
                currentDownloadProcess.BeginOutputReadLine();
                currentDownloadProcess.BeginErrorReadLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running yt-dlp: " + ex.Message);
                downloadButton.Enabled = true;
                stopButton.Enabled = false;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopDownload();
        }

        private void StopDownload()
        {
            if (currentDownloadProcess != null && !currentDownloadProcess.HasExited)
            {
                try
                {
#if NET5_0_OR_GREATER
                    currentDownloadProcess.Kill(true);
#else
                    currentDownloadProcess.Kill();
#endif
                    AppendText("\r\n[Stopped] Download canceled by user.");
                }
                catch (Exception ex)
                {
                    AppendText($"[Error] Could not stop process: {ex.Message}");
                }
            }

            if (!string.IsNullOrEmpty(currentDownloadFolder) && Directory.Exists(currentDownloadFolder))
            {
                foreach (var file in Directory.GetFiles(currentDownloadFolder, "*.part"))
                {
                    try { System.IO.File.Delete(file); }
                    catch { }
                }
            }

            stopButton.Enabled = false;
            downloadButton.Enabled = true;
            currentDownloadProcess = null;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            interprets.Clear();
            urlTextBox.Clear();
            fileNameTextBox.Clear();
            folderTextBox.Clear();
            statusBox.Clear();
        }
    }
}
