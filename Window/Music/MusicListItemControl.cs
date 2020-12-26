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
    public partial class MusicListItemControl : MetroUserControl
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

        public MusicListItemControl(string title, string singer, string durationTime) : this()
        {
            metroLabel_title.Text = title;
            metroLabel_singer.Text = singer;
            metroLabel_durationTime.Text = durationTime;
        }
        #endregion

        #region Properties
        public Music Music { get; set; }

        public string ErrorMessage { get; private set; }
        #endregion

        #region Control Event
        private void metroLabel_MouseHover(object sender, EventArgs e)
        {
            metroToolTip.Show(ErrorMessage, metroTile_play, 1000);
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
            if (e.Button != MouseButtons.Left) return;

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
        #endregion
    }
}