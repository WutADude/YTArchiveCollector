using System;
using System.Windows.Forms;
using YTArchiveCollector.Helpers;
using YTArchiveCollector.Modules;

namespace YTArchiveCollector
{
    public partial class MainForm : Form
    {
        const int StandartFormHeight = 100, RaisedFormHeight = 544;
        const int RaisedInfoBoxHeight = 444;

        public MainForm()
        {
            InitializeComponent();
#if DEBUG
            CheckForIllegalCrossThreadCalls = false;
#endif
            VideoLoader._Form = this;
            InfoBox.Height = 0;
            Height = StandartFormHeight;
            if (FileManager.FirstRunInDir)
                Directory.CreateDirectory("Results");
        }

        private void ProcessNewString(object sender)
        {
            string ClipString = Clipboard.GetText();
            if (!ClipString.IsYTUrl() || (sender as Label).Text == ClipString)
                return;
            if (Height != StandartFormHeight)
                HeightAnimate();
            (sender as Label).Text = ClipString;
            DoSomeWork(ClipString);
        }

        private void DoSomeWork(string VideoURL)
        {
            ChangeSoftStatusLabel(StringStatuses.InfoGetingStatus);
            try
            {
                VideoParser Video = new VideoParser(VideoURL);
                string? Title = Video.VideoTitle;
                string? Description = Video.VideoDescription;
                List<string>? Tags = Video.VideoTags;
                ThumbnailBox.ImageLocation = Video.ThumbnailURL;
#if !DEBUG
                FileManager.SaveData(Video);
#endif
                ApplyNewInfo(Video);
                ChangeSoftStatusLabel(StringStatuses.InfoShowStatus);
                HeightAnimate();
            }
            catch (Exception ex)
            {
                ChangeSoftStatusLabel(StringStatuses.IDLEStatus);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyNewInfo(VideoParser Video)
        {
            VideoTitleLabel.Text = Video.VideoTitle;
            ChannelNameLabel.Text = Video.OwnerChannelName;
            ViewsCountLabel.Text = Video.VideoViewsCount;
            TagsCountLabel.Text = Video.VideoTags?.Count().ToString();
            DescriptionLabel.Text = string.IsNullOrEmpty(Video.VideoDescription) ? "отсутствует..." : Video.VideoDescription;
            if (!string.IsNullOrEmpty(Video.VideoDownloadURL))
            {
                DownloadVideoButton.Enabled = true;
                DownloadVideoButton.Text = $"({Video.VideoDownloadMaxQuality} | {Video.VideoDownloadFPS} FPS | {Video.VideoDownloadExtension?.ToUpper()}) Загружаем видео?";
            }
            else
            {
                DownloadVideoButton.Enabled = false;
                DownloadVideoButton.Text = "Не возможно выполнить загрузку видео...";
            }
        }

        internal void ChangeSoftStatusLabel(string Status)
        {
            Invoke(delegate()
            {
                StatusLabel.Text = $"{Status}";
            });
        }

        private void MainLabel_Click(object sender, EventArgs e) => ProcessNewString(sender);

        private void MainForm_Load(object sender, EventArgs e) => ChangeSoftStatusLabel(StringStatuses.IDLEStatus);

        private void DownloadVideoButton_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            (sender as Button).Text = "Загружаю видео...";
            Directory.CreateDirectory($"{FileManager._SaveFolder}\\Video");
            VideoLoader.DownloadVideo(FileManager.LastVideoLoadURL, $"{FileManager._SaveFolder}\\Video", FileManager.LastVideoLoadExtension);
        }

        private void HeightAnimate()
        {
            BeginInvoke(delegate ()
            {
                if (Height <= StandartFormHeight)
                {
                    AnimationManager.AnimatedChangeControlHeight(this, RaisedFormHeight);
                    InfoBox.Height = 50;
                    AnimationManager.AnimatedChangeControlHeight(InfoBox, RaisedInfoBoxHeight);
                    InfoPanel.Visible = true;
                }
                else
                {
                    InfoPanel.Visible = false;
                    InfoBox.Height = 0;
                    AnimationManager.AnimatedChangeControlHeight(this, StandartFormHeight);
                }
            });
        }
    }
}