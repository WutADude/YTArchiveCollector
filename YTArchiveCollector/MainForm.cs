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
            Loader._Form = this;
            InfoBox.Height = 0;
            Height = StandartFormHeight;
            if (FileManager.FirstRunInDir)
            {
                Directory.CreateDirectory("Results");
                new Task(delegate () { FileManager.UnzipFFmpeg(); }).Start();
            }
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
#if !DEBUG
            try
            {
#endif
                VideoParser Video = new VideoParser(VideoURL);
                if ((bool)Video.VideoIsStream)
                {
                    ChangeSoftStatusLabel(StringStatuses.VideoIsStreamStatus);
                    return;
                }    
                string? Title = Video.VideoTitle;
                string? Description = Video.VideoDescription;
                List<string>? Tags = Video.VideoTags;
                ThumbnailBox.ImageLocation = Video.ThumbnailURL;
                FileManager.LastParsedVideo = Video;
                FileManager.SaveData();
                ApplyNewInfo(Video);
                ChangeSoftStatusLabel(StringStatuses.InfoShowStatus);
                HeightAnimate();
#if !DEBUG
            }
            catch (Exception ex)
            {
                ChangeSoftStatusLabel(StringStatuses.IDLEStatus);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#endif
        }

        private void ApplyNewInfo(VideoParser Video)
        {
            VideoTitleLabel.Text = Video.VideoTitle;
            ChannelNameLabel.Text = Video.OwnerChannelName;
            ViewsCountLabel.Text = Video.VideoViewsCount;
            TagsCountLabel.Text = Video.VideoTags?.Count().ToString();
            DescriptionLabel.Text = string.IsNullOrEmpty(Video.VideoDescription) ? "отсутствует..." : Video.VideoDescription;
            if (!string.IsNullOrEmpty(Video.VideoDownloadURL) && !string.IsNullOrEmpty(Video.AudioDownloadURL))
            {
                DownloadVideoButton.Enabled = true;
                DownloadVideoButton.Text = $"({Video.VideoDownloadMaxQuality} | {Video.VideoDownloadFPS} FPS | {Video.VideoDownloadExtension?.ToUpper()} | AUDIO QUALITY: {Video.AudioDownloadQuality}) Загружаем видео?";
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
            Loader.StartDownloading();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!VideoUniquealizer.IsUniqueiazingProcessHappening)
                return;
            e.Cancel = true;
            if (MessageBox.Show("Происходит процесс склейки дорожек и уникализации видео, вы точно хотите закрыть софт?\nЭто нормально, если процесс очень долгий!", "Происходит склейка и уникализация видео", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                e.Cancel = false;
                System.Diagnostics.Process.GetProcessesByName("ffmpeg").FirstOrDefault()?.Kill();
                Environment.Exit(0);
            }
        }

        internal void HeightAnimate()
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