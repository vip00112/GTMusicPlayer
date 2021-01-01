using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace GTMusicPlayer
{
    public partial class MusicListItemControl : MetroUserControl, IStackItem
    {
        public EventHandler OnDeleted;
        public EventHandler OnDoubleClicked;
        public EventHandler<MouseEventArgs> OnMouseDowned;
        public EventHandler<MouseEventArgs> OnMouseMoved;
        public EventHandler<MouseEventArgs> OnMouseUped;

        #region Constructor
        private MusicListItemControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public MusicListItemControl(Music music) : this()
        {
            Music = music;
            ViewMusicInfo();
        }
        #endregion

        #region Properties
        public Music Music { get; }

        public string ErrorMessage { get; private set; }

        public int FixedY { get; set; }
        #endregion

        #region Control Event
        private void metroLabel_title_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ErrorMessage))
            {
                string msg = string.Format("{0}\r\n{1}", metroLabel_title.Text, metroLabel_singer.Text);
                metroToolTip.Show(msg, metroTile_play, 3000);
            }
            else
            {
                metroToolTip.Show(ErrorMessage, metroTile_play, 3000);
            }
        }

        private void metroLabel_title_MouseLeave(object sender, EventArgs e)
        {
            metroToolTip.Hide(metroTile_play);
        }

        private void metroLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            OnDoubleClicked?.Invoke(this, EventArgs.Empty);
        }

        private void metroLabel_delete_Click(object sender, EventArgs e)
        {
            if (!MessageBoxUtil.Confirm(this, "Are you sure you want to delete it?")) return;

            OnDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void metroLabel_move_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            OnMouseDowned?.Invoke(this, e);
        }

        private void metroLabel_move_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            OnMouseMoved?.Invoke(this, e);
        }

        private void metroLabel_move_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUped?.Invoke(this, e);
        }
        #endregion

        #region Public Method
        public void SetPlay(bool isPlay)
        {
            if (Disposing || IsDisposed) return;

            metroLabel_title.Invoke((MethodInvoker) delegate ()
            {
                metroTile_play.Visible = isPlay;
                Invalidate();
            });
        }

        public void SetError(string msg)
        {
            if (Disposing || IsDisposed) return;

            ErrorMessage = msg;
            metroLabel_title.Invoke((MethodInvoker) delegate ()
            {
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    metroLabel_title.UseCustomBackColor = true;
                    metroLabel_title.UseCustomForeColor = true;
                }
                else
                {
                    metroLabel_title.UseCustomBackColor = false;
                    metroLabel_title.UseCustomForeColor = false;
                }
                metroLabel_title.Invalidate();
            });
        }

        public void ViewMusicInfo()
        {
            if (Music == null) return;

            var type = (ViewType) Setting.Instance.ViewType;
            if (type == ViewType.TitleTag)
            {
                metroLabel_title.Text = Music.Title;
            }
            else if (type == ViewType.FileName)
            {
                metroLabel_title.Text = Music.FileName;
            }
            metroLabel_singer.Text = Music.ViewSinger;
            metroLabel_durationTime.Text = Music.DurationTime.View();

            metroLabel_title.Invalidate();
            metroLabel_singer.Invalidate();
            metroLabel_durationTime.Invalidate();
        }
        #endregion
    }
}