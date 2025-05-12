
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace YT2D2MP3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            formatComboBox.SelectedIndexChanged += formatComboBox_SelectedIndexChanged;
            formatComboBox.SelectedIndex = 0;
        }
        private void formatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            qualityComboBox.Items.Clear();
            if (formatComboBox.SelectedItem?.ToString() == "mp3")
            {
                qualityComboBox.Items.AddRange(new[] { "Best (VBR) - 0", "High (V2)", "Medium (V5)", "Low (V9)" });
                qualityComboBox.SelectedIndex = 0;
            }
            else if (formatComboBox.SelectedItem?.ToString() == "mp4")
            {
                qualityComboBox.Items.AddRange(new[] {
                     "2160p (4K)", "1440p", "1080p", "720p", "480p", "360p", "240p", "144p"});
                qualityComboBox.SelectedIndex = 0;
            }
        }

        private void AppendText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendText), text);
                return;
            }
            statusBox.AppendText(text);
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

            if (!File.Exists(ytDlpPath) || !File.Exists(ffmpegPath))
            {
                MessageBox.Show("yt-dlp.exe or ffmpeg.exe not found in the application directory.");
                return;
            }

            if (formatComboBox.SelectedItem == null || qualityComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a format and quality.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedFormat = formatComboBox.SelectedItem.ToString();
            string selectedQuality = qualityComboBox.SelectedItem.ToString();

            string defaultExtension = selectedFormat == "mp3" ? "mp3" : "mp4";
            string filter = selectedFormat == "mp3" ? "MP3 Files (*.mp3)|*.mp3" : "MP4 Files (*.mp4)|*.mp4";

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = filter;
                saveDialog.Title = "Save File As";
                saveDialog.DefaultExt = defaultExtension;
                saveDialog.FileName = $"output.{defaultExtension}";

                if (saveDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string outputPath = saveDialog.FileName;

                downloadButton.Enabled = false;
                statusBox.Text = "Downloading... Please wait.\r\n";

                string arguments = string.Empty;

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
                    arguments = $"-x --audio-format mp3 --audio-quality {audioQuality} -o \"{outputPath}\" {url}";
                }
                else if (selectedFormat == "mp4")
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

                    arguments = $"-f {resolutionFilter} -o \"{outputPath}\" {url}";
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

                Process proc = new Process { StartInfo = psi, EnableRaisingEvents = true };

                proc.OutputDataReceived += (s, ea) =>
                {
                    if (!string.IsNullOrEmpty(ea.Data))
                        AppendText(ea.Data + "\r\n");
                };
                proc.ErrorDataReceived += (s, ea) =>
                {
                    if (!string.IsNullOrEmpty(ea.Data))
                        AppendText("[Error] " + ea.Data + "\r\n");
                };
                proc.Exited += (s, ea) =>
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        statusBox.AppendText("\r\nDone.\r\n");
                        downloadButton.Enabled = true;

                        string folder = Path.GetDirectoryName(outputPath);
                        if (Directory.Exists(folder))
                        {
                            Process.Start("explorer.exe", folder);
                        }
                    }));
                };

                try
                {
                    proc.Start();
                    proc.BeginOutputReadLine();
                    proc.BeginErrorReadLine();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error running yt-dlp: " + ex.Message);
                    downloadButton.Enabled = true;
                }
            }
        }
    }
}
