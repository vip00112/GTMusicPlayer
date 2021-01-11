namespace GTMusicPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroTrackBar_duration = new MetroFramework.Controls.MetroTrackBar();
            this.metroTrackBar_volume = new MetroFramework.Controls.MetroTrackBar();
            this.metroLabel_volume = new MetroFramework.Controls.MetroLabel();
            this.metroButton_play = new MetroFramework.Controls.MetroButton();
            this.metroLabel_title = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_singer = new MetroFramework.Controls.MetroLabel();
            this.metroCheckBox_mute = new MetroFramework.Controls.MetroCheckBox();
            this.metroContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_toolLyric = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_album = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_setting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_mode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel_currentTime = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_totalTime = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_prev = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_next = new MetroFramework.Controls.MetroLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lyricListControl = new GTMusicPlayer.LyricListControl();
            this.musicListControl = new GTMusicPlayer.MusicListControl();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.metroContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // metroTrackBar_duration
            // 
            resources.ApplyResources(this.metroTrackBar_duration, "metroTrackBar_duration");
            this.metroTrackBar_duration.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar_duration.Name = "metroTrackBar_duration";
            this.metroTrackBar_duration.TabStop = false;
            this.metroTrackBar_duration.Value = 0;
            this.metroTrackBar_duration.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            this.metroTrackBar_duration.MouseUp += new System.Windows.Forms.MouseEventHandler(this.control_MouseUp);
            // 
            // metroTrackBar_volume
            // 
            resources.ApplyResources(this.metroTrackBar_volume, "metroTrackBar_volume");
            this.metroTrackBar_volume.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar_volume.Name = "metroTrackBar_volume";
            this.metroTrackBar_volume.TabStop = false;
            this.metroTrackBar_volume.Value = 100;
            this.metroTrackBar_volume.ValueChanged += new System.EventHandler(this.metroTrackBar_volume_ValueChanged);
            this.metroTrackBar_volume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            this.metroTrackBar_volume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.control_MouseUp);
            // 
            // metroLabel_volume
            // 
            resources.ApplyResources(this.metroLabel_volume, "metroLabel_volume");
            this.metroLabel_volume.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_volume.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel_volume.Name = "metroLabel_volume";
            this.metroLabel_volume.UseStyleColors = true;
            // 
            // metroButton_play
            // 
            resources.ApplyResources(this.metroButton_play, "metroButton_play");
            this.metroButton_play.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton_play.Name = "metroButton_play";
            this.metroButton_play.TabStop = false;
            this.metroButton_play.UseSelectable = true;
            this.metroButton_play.UseStyleColors = true;
            this.metroButton_play.Click += new System.EventHandler(this.metroButton_play_Click);
            this.metroButton_play.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            this.metroButton_play.MouseUp += new System.Windows.Forms.MouseEventHandler(this.control_MouseUp);
            // 
            // metroLabel_title
            // 
            resources.ApplyResources(this.metroLabel_title, "metroLabel_title");
            this.metroLabel_title.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_title.Name = "metroLabel_title";
            this.metroLabel_title.Tag = "";
            this.metroLabel_title.UseStyleColors = true;
            // 
            // metroLabel_singer
            // 
            resources.ApplyResources(this.metroLabel_singer, "metroLabel_singer");
            this.metroLabel_singer.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_singer.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel_singer.Name = "metroLabel_singer";
            this.metroLabel_singer.Tag = "";
            this.metroLabel_singer.UseStyleColors = true;
            // 
            // metroCheckBox_mute
            // 
            resources.ApplyResources(this.metroCheckBox_mute, "metroCheckBox_mute");
            this.metroCheckBox_mute.Name = "metroCheckBox_mute";
            this.metroCheckBox_mute.TabStop = false;
            this.metroCheckBox_mute.UseSelectable = true;
            this.metroCheckBox_mute.UseStyleColors = true;
            this.metroCheckBox_mute.CheckedChanged += new System.EventHandler(this.metroCheckBox_mute_CheckedChanged);
            this.metroCheckBox_mute.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            this.metroCheckBox_mute.MouseUp += new System.Windows.Forms.MouseEventHandler(this.control_MouseUp);
            // 
            // metroContextMenu
            // 
            resources.ApplyResources(this.metroContextMenu, "metroContextMenu");
            this.metroContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolToolStripMenuItem,
            this.menuItem_album,
            this.menuItem_setting,
            this.menuItem_mode,
            this.menuItem_exit});
            this.metroContextMenu.Name = "metroContextMenu";
            this.metroContextMenu.UseStyleColors = true;
            this.metroContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.metroContextMenu_Opening);
            // 
            // toolToolStripMenuItem
            // 
            resources.ApplyResources(this.toolToolStripMenuItem, "toolToolStripMenuItem");
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_toolLyric});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            // 
            // menuItem_toolLyric
            // 
            resources.ApplyResources(this.menuItem_toolLyric, "menuItem_toolLyric");
            this.menuItem_toolLyric.Name = "menuItem_toolLyric";
            this.menuItem_toolLyric.Click += new System.EventHandler(this.menuItem_toolLyric_Click);
            // 
            // menuItem_album
            // 
            resources.ApplyResources(this.menuItem_album, "menuItem_album");
            this.menuItem_album.Name = "menuItem_album";
            this.menuItem_album.Click += new System.EventHandler(this.menuItem_album_Click);
            // 
            // menuItem_setting
            // 
            resources.ApplyResources(this.menuItem_setting, "menuItem_setting");
            this.menuItem_setting.Name = "menuItem_setting";
            this.menuItem_setting.Click += new System.EventHandler(this.menuItem_setting_Click);
            // 
            // menuItem_mode
            // 
            resources.ApplyResources(this.menuItem_mode, "menuItem_mode");
            this.menuItem_mode.Name = "menuItem_mode";
            this.menuItem_mode.Click += new System.EventHandler(this.menuItem_mode_Click);
            // 
            // menuItem_exit
            // 
            resources.ApplyResources(this.menuItem_exit, "menuItem_exit");
            this.menuItem_exit.Name = "menuItem_exit";
            this.menuItem_exit.Click += new System.EventHandler(this.menuItem_exit_Click);
            // 
            // metroLabel_currentTime
            // 
            resources.ApplyResources(this.metroLabel_currentTime, "metroLabel_currentTime");
            this.metroLabel_currentTime.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_currentTime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel_currentTime.Name = "metroLabel_currentTime";
            this.metroLabel_currentTime.UseStyleColors = true;
            // 
            // metroLabel_totalTime
            // 
            resources.ApplyResources(this.metroLabel_totalTime, "metroLabel_totalTime");
            this.metroLabel_totalTime.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_totalTime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel_totalTime.Name = "metroLabel_totalTime";
            this.metroLabel_totalTime.UseStyleColors = true;
            // 
            // metroLabel_prev
            // 
            resources.ApplyResources(this.metroLabel_prev, "metroLabel_prev");
            this.metroLabel_prev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_prev.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_prev.Name = "metroLabel_prev";
            this.metroLabel_prev.UseStyleColors = true;
            this.metroLabel_prev.Click += new System.EventHandler(this.metroLabel_prev_Click);
            // 
            // metroLabel_next
            // 
            resources.ApplyResources(this.metroLabel_next, "metroLabel_next");
            this.metroLabel_next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_next.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_next.Name = "metroLabel_next";
            this.metroLabel_next.UseStyleColors = true;
            this.metroLabel_next.Click += new System.EventHandler(this.metroLabel_next_Click);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.ContextMenuStrip = this.metroContextMenu;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // lyricListControl
            // 
            resources.ApplyResources(this.lyricListControl, "lyricListControl");
            this.lyricListControl.Name = "lyricListControl";
            this.lyricListControl.UseSelectable = true;
            // 
            // musicListControl
            // 
            resources.ApplyResources(this.musicListControl, "musicListControl");
            this.musicListControl.Name = "musicListControl";
            this.musicListControl.TabStop = false;
            this.musicListControl.UseSelectable = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.metroContextMenu;
            this.Controls.Add(this.lyricListControl);
            this.Controls.Add(this.musicListControl);
            this.Controls.Add(this.metroLabel_next);
            this.Controls.Add(this.metroLabel_prev);
            this.Controls.Add(this.metroCheckBox_mute);
            this.Controls.Add(this.metroButton_play);
            this.Controls.Add(this.metroLabel_totalTime);
            this.Controls.Add(this.metroLabel_currentTime);
            this.Controls.Add(this.metroLabel_singer);
            this.Controls.Add(this.metroLabel_title);
            this.Controls.Add(this.metroLabel_volume);
            this.Controls.Add(this.metroTrackBar_volume);
            this.Controls.Add(this.metroTrackBar_duration);
            this.DisplayHeader = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Tag = "";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.metroContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar_duration;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar_volume;
        private MetroFramework.Controls.MetroLabel metroLabel_volume;
        private MetroFramework.Controls.MetroButton metroButton_play;
        private MetroFramework.Controls.MetroLabel metroLabel_singer;
        private MetroFramework.Controls.MetroLabel metroLabel_title;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox_mute;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu;
        private MetroFramework.Controls.MetroLabel metroLabel_totalTime;
        private MetroFramework.Controls.MetroLabel metroLabel_currentTime;
        private System.Windows.Forms.ToolStripMenuItem menuItem_setting;
        private MetroFramework.Controls.MetroLabel metroLabel_next;
        private MetroFramework.Controls.MetroLabel metroLabel_prev;
        private MusicListControl musicListControl;
        private System.Windows.Forms.ToolStripMenuItem menuItem_album;
        private LyricListControl lyricListControl;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem menuItem_exit;
        private System.Windows.Forms.ToolStripMenuItem menuItem_mode;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_toolLyric;
    }
}

