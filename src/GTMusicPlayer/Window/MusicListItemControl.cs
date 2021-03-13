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
using MetroFramework;
using System.Threading;

namespace GTMusicPlayer
{
    public partial class MusicListItemControl : MetroUserControl, IStackItem
    {
        public EventHandler OnDeleted;
        public EventHandler OnClicked;
        public EventHandler OnDoubleClicked;
        public EventHandler<MouseEventArgs> OnMouseDowned;
        public EventHandler<MouseEventArgs> OnMouseMoved;
        public EventHandler<MouseEventArgs> OnMouseUped;
        private Guid _lastState;
        private bool _isSelected;

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

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;

                _isSelected = value;

                UseStyleColors = _isSelected;
                metroLabel_title.UseStyleColors = _isSelected;
                metroLabel_singer.UseStyleColors = _isSelected;
                metroLabel_durationTime.UseStyleColors = _isSelected;
                metroLabel_move.UseStyleColors = _isSelected;

                Invalidate();
                metroLabel_title.Invalidate();
                metroLabel_singer.Invalidate();
                metroLabel_durationTime.Invalidate();
                metroLabel_move.Invalidate();

                // Custom Color 방식
                //Color backColor = Color.Empty;
                //Color foreColor = _isSelected ? Color.DeepSkyBlue : Color.Empty;

                //SetCustomColor(this, backColor, foreColor);
                //SetCustomColor(metroLabel_title, backColor, foreColor);
                //SetCustomColor(metroLabel_singer, backColor, foreColor);
                //SetCustomColor(metroLabel_durationTime, backColor, foreColor);
                //SetCustomColor(metroLabel_delete, backColor, foreColor);
                //SetCustomColor(metroLabel_move, backColor, foreColor);
            }
        }
        #endregion

        #region Control Event
        private void metroLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            OnDoubleClicked?.Invoke(this, EventArgs.Empty);
        }

        private void control_Click(object sender, EventArgs e)
        {
            OnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void metroLabel_title_MouseEnter(object sender, EventArgs e)
        {
            StartToolTipTimer();
        }

        private void metroLabel_title_MouseLeave(object sender, EventArgs e)
        {
            _lastState = Guid.Empty;
            metroToolTip.Hide(metroTile_play);
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

        #region Private Method
        private void SetCustomColor(Control control, Color backColor, Color foreColor)
        {
            if (control is IMetroControl == false) return;

            if (backColor == Color.Empty)
            {
                (control as IMetroControl).UseCustomBackColor = false;
            }
            else
            {
                control.BackColor = backColor;
                (control as IMetroControl).UseCustomBackColor = true;
            }

            if (foreColor == Color.Empty)
            {
                (control as IMetroControl).UseCustomForeColor = false;
            }
            else
            {
                control.ForeColor = foreColor;
                (control as IMetroControl).UseCustomForeColor = true;
            }

            control.Invalidate();
        }

        private void StartToolTipTimer()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += delegate (object sender, DoWorkEventArgs e)
            {
                Thread.Sleep(1000);
                e.Result = e.Argument;
            };
            bw.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
            {
                if (IsDisposed) return;

                var id = (Guid) e.Result;
                if (_lastState != id) return;

                if (string.IsNullOrWhiteSpace(ErrorMessage))
                {
                    string msg = string.Format("{0}\r\n{1}", metroLabel_title.Text, metroLabel_singer.Text);
                    metroToolTip.Show(msg, metroTile_play, 3000);
                }
                else
                {
                    metroToolTip.Show(ErrorMessage, metroTile_play, 3000);
                }
            };

            _lastState = Guid.NewGuid();
            bw.RunWorkerAsync(_lastState);
        }
        #endregion

        #region Public Method
        public void SetPlay(bool isPlay)
        {
            if (Disposing || IsDisposed) return;

            metroLabel_title.Invoke((MethodInvoker) delegate ()
            {
                ErrorMessage = null;
                SetCustomColor(metroLabel_title, Color.Empty, Color.Empty);

                metroTile_play.Visible = isPlay;
                Invalidate();
            });
        }

        public void SetError(string msg)
        {
            if (Disposing || IsDisposed) return;

            ErrorMessage = "Error : " + msg;
            metroLabel_title.Invoke((MethodInvoker) delegate ()
            {
                Color backColor = !string.IsNullOrWhiteSpace(msg) ? Color.Firebrick : Color.Empty;
                Color foreColor = !string.IsNullOrWhiteSpace(msg) ? Color.White : Color.Empty;
                SetCustomColor(metroLabel_title, backColor, foreColor);
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