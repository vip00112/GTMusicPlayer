﻿using MetroFramework;
using MetroFramework.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace GTMusicPlayer
{
    public partial class MainForm : MetroForm
    {
        private Player _player;
        private bool _isPrev;
        private bool _isFocusedDurationTrackBar;

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Control Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            metroLabel_title.Tag = metroLabel_title.Text;
            metroLabel_singer.Tag = metroLabel_singer.Text;

            _player = new Player();
            _player.OnStarted += OnStarted;
            _player.OnStoped += OnStoped;
            _player.OnError += OnError;
            _player.OnChangedDuration += OnChangedDuration;

            musicListControl.OnAddedMusic += OnAddedMusic;
            musicListControl.OnDeletedMusic += OnDeletedMusic;
            musicListControl.OnSelectedMusic += OnSelectedMusic;
            musicListControl.OnMovedMusic += OnMovedMusic;

            Width = 305;
            lyricListControl.Visible = false;
            lyricListControl.OnClickedLyric += OnClickedLyric;

            Playlist.Instance.OnChangedAlbum += OnChangedAlbum;

            if (Setting.IsLoaded)
            {
                metroStyleManager.Theme = (MetroThemeStyle) Setting.Instance.UITheme;
                metroStyleManager.Style = (MetroColorStyle) Setting.Instance.UIStyle;
                metroTrackBar_volume.Value = Setting.Instance.Volume;
                _player.SetVolume(Setting.Instance.Volume);

                musicListControl.ClearItems();
                foreach (var music in Setting.Instance.RecentPlaylist)
                {
                    musicListControl.AddMusic(music);
                }

                Playlist.Instance.RefreshOrder(null);
            }
            else
            {
                Setting.Instance.UITheme = (int) metroStyleManager.Theme;
                Setting.Instance.UIStyle = (int) metroStyleManager.Style;
                Setting.Instance.RepeatType = (int) RepeatType.All;
                Setting.Instance.OrderType = (int) OrderType.Orderd;
                Setting.Instance.Volume = metroTrackBar_volume.Value;
                Setting.Instance.Save();
            }
            StyleManager = metroStyleManager;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.Instance.Save();
        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == metroTrackBar_duration)
            {
                _isFocusedDurationTrackBar = true;
            }
        }

        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender == metroTrackBar_duration)
            {
                _isFocusedDurationTrackBar = false;

                int value = metroTrackBar_duration.Value;
                int current = (int) _player.CurrentTime.TotalSeconds;
                _player.Skip(value - current);
            }

            metroLabel_title.Focus();
        }

        private void metroContextMenu_Opening(object sender, CancelEventArgs e)
        {
            var context = sender as ContextMenuStrip;
            if (context == null) return;

            if (context.SourceControl is MainForm)
            {
                menuItem_exit.Visible = false;
            }
            else
            {
                menuItem_exit.Visible = true;
            }
        }

        private void menuItem_toolLyric_Click(object sender, EventArgs e)
        {
            LyricEditForm lyricForm = null;
            foreach (Form form in Application.OpenForms)
            {
                if (form is LyricEditForm)
                {
                    lyricForm = form as LyricEditForm;
                    break;
                }
            }
            if (lyricForm == null)
            {
                lyricForm = new LyricEditForm(metroStyleManager);
            }

            if (lyricForm.WindowState == FormWindowState.Minimized)
            {
                lyricForm.WindowState = FormWindowState.Normal;
            }
            lyricForm.Activate();
            lyricForm.Show();
        }

        private void menuItem_setting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = null;
            foreach (Form form in Application.OpenForms)
            {
                if (form is SettingForm)
                {
                    settingForm = form as SettingForm;
                    break;
                }
            }
            if (settingForm == null)
            {
                settingForm = new SettingForm(metroStyleManager);
            }

            if (settingForm.WindowState == FormWindowState.Minimized)
            {
                settingForm.WindowState = FormWindowState.Normal;
            }
            settingForm.Activate();
            settingForm.Show();
        }

        private void menuItem_album_Click(object sender, EventArgs e)
        {
            AlbumForm albumForm = null;
            foreach (Form form in Application.OpenForms)
            {
                if (form is AlbumForm)
                {
                    albumForm = form as AlbumForm;
                    break;
                }
            }
            if (albumForm == null)
            {
                albumForm = new AlbumForm(metroStyleManager);
            }

            if (albumForm.WindowState == FormWindowState.Minimized)
            {
                albumForm.WindowState = FormWindowState.Normal;
            }
            albumForm.Activate();
            albumForm.Show();
        }

        private void menuItem_mode_Click(object sender, EventArgs e)
        {
            // TODO : 미니모드, 일반모드 전환
        }

        private void menuItem_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is MainForm)
                {
                    var mainForm = form as MainForm;
                    if (mainForm.WindowState == FormWindowState.Minimized)
                    {
                        mainForm.WindowState = FormWindowState.Normal;
                    }
                    mainForm.Activate();
                    mainForm.Show();
                }
            }
        }

        private void metroButton_play_Click(object sender, EventArgs e)
        {
            PlayOrPause();
        }

        private void metroLabel_prev_Click(object sender, EventArgs e)
        {
            Prev();
        }

        private void metroLabel_next_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void metroCheckBox_mute_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox_mute.Checked)
            {
                _player.SetVolume(0);
            }
            else
            {
                _player.SetVolume(metroTrackBar_volume.Value);
            }
        }

        private void metroTrackBar_volume_ValueChanged(object sender, EventArgs e)
        {
            int value = metroTrackBar_volume.Value;
            metroLabel_volume.Text = "Volume. " + value;

            if (!metroCheckBox_mute.Checked)
            {
                _player.SetVolume(value);
            }

            Setting.Instance.Volume = value;
        }
        #endregion

        #region EventHandler Method
        private void OnStarted(object sender, MusicEventArgs e)
        {
            if (Disposing || IsDisposed) return;

            metroLabel_title.Invoke((MethodInvoker) delegate ()
            {
                Text = e.Music.Title + " - " + e.Music.ViewSinger;
                metroLabel_title.Text = e.Music.Title;
                metroLabel_singer.Text = e.Music.ViewSinger;
                metroLabel_totalTime.Text = e.Music.DurationTime.View();

                metroButton_play.Enabled = true;
                metroButton_play.Text = "■";

                metroLabel_prev.Enabled = true;
                metroLabel_next.Enabled = true;
                metroTrackBar_duration.Enabled = true;
                metroTrackBar_duration.Maximum = (int) e.Music.DurationTime.TotalSeconds;
                metroTrackBar_duration.Value = 0;

                musicListControl.SetPlayUI(e.Music);

                if (lyricListControl.InitUI(e.Music.Lyrics))
                {
                    Width = 576;
                    lyricListControl.Visible = true;
                }
                else
                {
                    Width = 305;
                    lyricListControl.Visible = false;
                }
                metroLabel_title.Focus();
            });
        }

        private void OnStoped(object sender, MusicEventArgs e)
        {
            if (Disposing || IsDisposed) return;

            metroButton_play.Invoke((MethodInvoker) delegate ()
            {
                Music nextMusic = null;
                if (_isPrev)
                {
                    _isPrev = false;
                    nextMusic = Playlist.Instance.GetPrevMusic(e.Music);
                    if (nextMusic == null) nextMusic = e.Music;
                }
                else
                {
                    nextMusic = Playlist.Instance.GetNextMusic(e.Music);
                }

                if (nextMusic != null)
                {
                    _player.Play(nextMusic);
                    return;
                }

                InitUI();
            });
        }

        private void OnError(object sender, MusicEventArgs e)
        {
            if (Disposing || IsDisposed) return;

            musicListControl.SetErrorUI(e.Music, e.Message);
        }

        private void OnChangedDuration(object sender, ChangedDurationEventArgs e)
        {
            if (Disposing || IsDisposed) return;
            if (_isFocusedDurationTrackBar) return;

            metroTrackBar_duration.Invoke((MethodInvoker) delegate ()
            {
                int value = (int) e.CurrentTime.TotalSeconds;
                if (value <= metroTrackBar_duration.Maximum)
                {
                    metroTrackBar_duration.Value = value;
                    metroLabel_currentTime.Text = e.CurrentTime.View();
                }

                lyricListControl.UpdateUI(e.CurrentTime);
            });
        }

        private void OnAddedMusic(object sender, MusicEventArgs e)
        {
            if (e.Music == null) return;

            Playlist.Instance.AddMusic(e.Music);

            // 최초 등록시 표기
            if (Playlist.Instance.Musics.Count == 1)
            {
                metroLabel_title.Text = e.Music.Title;
                metroLabel_singer.Text = e.Music.ViewSinger;
                metroLabel_totalTime.Text = e.Music.DurationTime.View();
                metroButton_play.Text = "▶";
                metroButton_play.Enabled = true;
                _player.SetCurrentMusic(e.Music);
            }
        }

        private void OnDeletedMusic(object sender, MusicEventArgs e)
        {
            Playlist.Instance.RemoveMusic(e.Music);

            if (_player.CurrentMusic == e.Music) Next();
        }

        private void OnSelectedMusic(object sender, MusicEventArgs e)
        {
            if (e.Music.IsError) return;

            Playlist.Instance.ChangeMusic(e.Music);
            if (_player.IsPlaying)
            {
                Next();
                _player.SetCurrentMusic(null);
            }
            else
            {
                _player.Play(e.Music);
            }
        }

        private void OnMovedMusic(object sender, MusicListEventArgs e)
        {
            Playlist.Instance.RefreshOrder(e.Musics);
        }

        private void OnChangedAlbum(object sender, AlbumEventArgs e)
        {
            Next();
            _player.SetCurrentMusic(null);
            InitUI();

            musicListControl.ClearItems();
            foreach (var music in e.Album.Musics)
            {
                musicListControl.AddMusic(music);
            }
        }

        private void OnClickedLyric(object sender, LyricEventArgs e)
        {
            int value = (int) e.Lyric.Time.TotalSeconds;
            int current = (int) _player.CurrentTime.TotalSeconds;
            _player.Skip(value - current);
        }
        #endregion

        #region Protected Method
        // 전역 키 설정
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab) return true;

            #region Play/Pause
            if (keyData == Keys.Space)
            {
                PlayOrPause();
            }
            #endregion

            #region Volume
            if (keyData == Keys.Down)
            {
                int value = 5;
                if (metroTrackBar_volume.Value < value)
                {
                    value -= (value - metroTrackBar_volume.Value);
                }
                metroTrackBar_volume.Value -= value;
                return true;
            }
            if (keyData == Keys.Up)
            {
                int value = 5;
                if (metroTrackBar_volume.Value + value > metroTrackBar_volume.Maximum)
                {
                    value = metroTrackBar_volume.Maximum - metroTrackBar_volume.Value;
                }
                metroTrackBar_volume.Value += value;
                return true;
            }
            #endregion

            #region Duration
            if (keyData == Keys.PageUp)
            {
                if (!metroLabel_prev.Enabled) return true;

                Prev();
            }
            if (keyData == Keys.PageDown)
            {
                if (!metroLabel_next.Enabled) return true;

                Next();
            }
            if (keyData == Keys.Left)
            {
                if (!metroTrackBar_duration.Enabled) return true;

                int value = 5;
                if (metroTrackBar_duration.Value < value)
                {
                    value -= (value - metroTrackBar_duration.Value);
                }
                metroTrackBar_duration.Value -= value;
                _player.Skip(-value);
                return true;
            }
            if (keyData == Keys.Right)
            {
                if (!metroTrackBar_duration.Enabled) return true;

                int value = 5;
                if (metroTrackBar_duration.Value + value > metroTrackBar_duration.Maximum)
                {
                    value = metroTrackBar_duration.Maximum - metroTrackBar_duration.Value;
                }
                metroTrackBar_duration.Value += value;
                _player.Skip(value);
                return true;
            }
            #endregion

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Private Method
        private void InitUI()
        {
            metroLabel_title.Text = (string) metroLabel_title.Tag;
            metroLabel_singer.Text = (string) metroLabel_singer.Tag;
            metroButton_play.Text = "▶";
            metroLabel_prev.Enabled = false;
            metroLabel_next.Enabled = false;
            metroTrackBar_duration.Enabled = false;
            metroTrackBar_duration.Value = 0;
            metroLabel_currentTime.Text = "00:00";
        }

        private void PlayOrPause()
        {
            if (!metroButton_play.Enabled) return;

            if (metroButton_play.Text == "▶")
            {
                if (_player.CurrentMusic != null)
                {
                    _player.Resume();
                    metroButton_play.Text = "■";
                }
            }
            else
            {
                _player.Pause();
                metroButton_play.Text = "▶";
            }
        }

        private void Prev()
        {
            int current = (int) _player.CurrentTime.TotalSeconds;
            if (current <= 3)
            {
                _isPrev = true;
                Next();
            }
            else
            {
                _player.Skip(-current);
            }
        }

        private void Next()
        {
            int total = (int) _player.TotalTime.TotalSeconds;
            int current = (int) _player.CurrentTime.TotalSeconds;
            _player.Skip(total - current);
        }
        #endregion
    }
}