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
            VideoLoader._Form = this;
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
                FileManager.SaveData(Video);
                ApplyNewInfo(Title, Video.OwnerChannelName, Video.VideoViewsCount, Description, Tags.Count(), Video.VideoDownloadMaxQuality, (int)Video.VideoDownloadFPS, Video.VideoDownloadExtension);
                ChangeSoftStatusLabel(StringStatuses.InfoShowStatus);
                HeightAnimate();
            }
            catch (Exception ex)
            {
                ChangeSoftStatusLabel(StringStatuses.IDLEStatus);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyNewInfo(string VideoTitle, string ChannelName, string ViewsCount, string Description, int TagsCount, string VideoLoadQuality, int VideoLoadFPS, string VideoLoadExtension)
        {
            VideoTitleLabel.Text = VideoTitle;
            ChannelNameLabel.Text = ChannelName;
            ViewsCountLabel.Text = ViewsCount;
            TagsCountLabel.Text = TagsCount.ToString();
            DescriptionLabel.Text = Description;
            DownloadVideoButton.Text = $"({VideoLoadQuality} | {VideoLoadFPS} FPS | {VideoLoadExtension.ToUpper()}) Загружаем видео?";
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