namespace YTArchiveCollector
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SoftStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainGB = new System.Windows.Forms.GroupBox();
            this.MainLabel = new System.Windows.Forms.Label();
            this.InfoBox = new System.Windows.Forms.GroupBox();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ThumbnailBox = new System.Windows.Forms.PictureBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DownloadVideoButton = new System.Windows.Forms.Button();
            this.TagsCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ChannelNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewsCountLabel = new System.Windows.Forms.Label();
            this.ViewsLabel = new System.Windows.Forms.Label();
            this.VideoTitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SoftStatusStrip.SuspendLayout();
            this.MainGB.SuspendLayout();
            this.InfoBox.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SoftStatusStrip
            // 
            this.SoftStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.StatusLabel});
            this.SoftStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.SoftStatusStrip.Location = new System.Drawing.Point(0, 485);
            this.SoftStatusStrip.Name = "SoftStatusStrip";
            this.SoftStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.SoftStatusStrip.Size = new System.Drawing.Size(514, 20);
            this.SoftStatusStrip.SizingGrip = false;
            this.SoftStatusStrip.TabIndex = 0;
            this.SoftStatusStrip.Text = "SoftStatusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 15);
            this.toolStripStatusLabel1.Text = "Статус:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(101, 15);
            this.StatusLabel.Text = "ожидаю задачи...";
            // 
            // MainGB
            // 
            this.MainGB.Controls.Add(this.MainLabel);
            this.MainGB.Location = new System.Drawing.Point(12, -3);
            this.MainGB.Name = "MainGB";
            this.MainGB.Size = new System.Drawing.Size(490, 42);
            this.MainGB.TabIndex = 2;
            this.MainGB.TabStop = false;
            // 
            // MainLabel
            // 
            this.MainLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainLabel.Location = new System.Drawing.Point(6, 13);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(478, 23);
            this.MainLabel.TabIndex = 2;
            this.MainLabel.Text = "Скопируйте ссылку и нажмите на надпись ЛКМ...";
            this.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MainLabel.Click += new System.EventHandler(this.MainLabel_Click);
            // 
            // InfoBox
            // 
            this.InfoBox.Controls.Add(this.InfoPanel);
            this.InfoBox.Location = new System.Drawing.Point(12, 39);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(490, 444);
            this.InfoBox.TabIndex = 3;
            this.InfoBox.TabStop = false;
            // 
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.groupBox1);
            this.InfoPanel.Controls.Add(this.DescriptionLabel);
            this.InfoPanel.Controls.Add(this.label5);
            this.InfoPanel.Controls.Add(this.DownloadVideoButton);
            this.InfoPanel.Controls.Add(this.TagsCountLabel);
            this.InfoPanel.Controls.Add(this.label4);
            this.InfoPanel.Controls.Add(this.ChannelNameLabel);
            this.InfoPanel.Controls.Add(this.label3);
            this.InfoPanel.Controls.Add(this.ViewsCountLabel);
            this.InfoPanel.Controls.Add(this.ViewsLabel);
            this.InfoPanel.Controls.Add(this.VideoTitleLabel);
            this.InfoPanel.Controls.Add(this.label1);
            this.InfoPanel.Location = new System.Drawing.Point(6, 13);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(478, 424);
            this.InfoPanel.TabIndex = 3;
            this.InfoPanel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ThumbnailBox);
            this.groupBox1.Location = new System.Drawing.Point(54, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 214);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // ThumbnailBox
            // 
            this.ThumbnailBox.Location = new System.Drawing.Point(7, 15);
            this.ThumbnailBox.Name = "ThumbnailBox";
            this.ThumbnailBox.Size = new System.Drawing.Size(353, 191);
            this.ThumbnailBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ThumbnailBox.TabIndex = 3;
            this.ThumbnailBox.TabStop = false;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Location = new System.Drawing.Point(64, 325);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(410, 62);
            this.DescriptionLabel.TabIndex = 13;
            this.DescriptionLabel.Text = "{NotFullDescriptionText}";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Описание:";
            // 
            // DownloadVideoButton
            // 
            this.DownloadVideoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DownloadVideoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadVideoButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DownloadVideoButton.Location = new System.Drawing.Point(5, 390);
            this.DownloadVideoButton.Name = "DownloadVideoButton";
            this.DownloadVideoButton.Size = new System.Drawing.Size(469, 31);
            this.DownloadVideoButton.TabIndex = 11;
            this.DownloadVideoButton.Text = "{DownloadVideoButtonText}";
            this.DownloadVideoButton.UseVisualStyleBackColor = true;
            this.DownloadVideoButton.Click += new System.EventHandler(this.DownloadVideoButton_Click);
            // 
            // TagsCountLabel
            // 
            this.TagsCountLabel.Location = new System.Drawing.Point(80, 308);
            this.TagsCountLabel.Name = "TagsCountLabel";
            this.TagsCountLabel.Size = new System.Drawing.Size(126, 15);
            this.TagsCountLabel.TabIndex = 10;
            this.TagsCountLabel.Text = "{TagsCount}";
            this.TagsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Кол-во тегов:";
            // 
            // ChannelNameLabel
            // 
            this.ChannelNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.ChannelNameLabel.Location = new System.Drawing.Point(42, 274);
            this.ChannelNameLabel.Name = "ChannelNameLabel";
            this.ChannelNameLabel.Size = new System.Drawing.Size(204, 15);
            this.ChannelNameLabel.TabIndex = 8;
            this.ChannelNameLabel.Text = "{ChannelName}";
            this.ChannelNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Канал:";
            // 
            // ViewsCountLabel
            // 
            this.ViewsCountLabel.Location = new System.Drawing.Point(119, 291);
            this.ViewsCountLabel.Name = "ViewsCountLabel";
            this.ViewsCountLabel.Size = new System.Drawing.Size(126, 15);
            this.ViewsCountLabel.TabIndex = 6;
            this.ViewsCountLabel.Text = "{ViewsCount}";
            this.ViewsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewsLabel
            // 
            this.ViewsLabel.AutoSize = true;
            this.ViewsLabel.Location = new System.Drawing.Point(3, 291);
            this.ViewsLabel.Name = "ViewsLabel";
            this.ViewsLabel.Size = new System.Drawing.Size(120, 15);
            this.ViewsLabel.TabIndex = 5;
            this.ViewsLabel.Text = "Кол-во просмотров:";
            // 
            // VideoTitleLabel
            // 
            this.VideoTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.VideoTitleLabel.Location = new System.Drawing.Point(5, 249);
            this.VideoTitleLabel.Name = "VideoTitleLabel";
            this.VideoTitleLabel.Size = new System.Drawing.Size(469, 23);
            this.VideoTitleLabel.TabIndex = 4;
            this.VideoTitleLabel.Text = "{VideoTitle}";
            this.VideoTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Информация о видео";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(514, 505);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.MainGB);
            this.Controls.Add(this.SoftStatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArchiveCollector by wDude";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SoftStatusStrip.ResumeLayout(false);
            this.SoftStatusStrip.PerformLayout();
            this.MainGB.ResumeLayout(false);
            this.InfoBox.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip SoftStatusStrip;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel StatusLabel;
        private GroupBox MainGB;
        private Label MainLabel;
        private GroupBox InfoBox;
        private Panel InfoPanel;
        private Label label1;
        private PictureBox ThumbnailBox;
        private Label VideoTitleLabel;
        private Label ChannelNameLabel;
        private Label label3;
        private Label ViewsCountLabel;
        private Label ViewsLabel;
        private Label TagsCountLabel;
        private Label label4;
        private Label DescriptionLabel;
        private Label label5;
        internal Button DownloadVideoButton;
        private GroupBox groupBox1;
    }
}