﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace GTMusicPlayer
{
    public partial class LyricListControl : MetroUserControl
    {
        public EventHandler<LyricEventArgs> OnClickedLyric;

        private List<LyricListItemControl> _items;
        private LyricListItemControl _oldItem;

        #region Constructor
        public LyricListControl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _items = new List<LyricListItemControl>();
            stackPanel.ScrollMoveControlCount = 4;
        }
        #endregion

        #region Properties
        public List<Lyric> Lyrics
        {
            get { return _items.Select(o => o.Lyric).OrderBy(o => o.Time).ToList(); }
        }
        #endregion

        #region Public Method
        public bool InitUI(List<Lyric> lyrics)
        {
            if (lyrics == null || lyrics.Count == 0) return false;

            WaitDialog.Show(this, StyleManager);

            stackPanel.SuspendLayout();
            stackPanel.IsNotMove = true;
            foreach (var item in _items)
            {
                item.OnClicked -= OnClicked;
                stackPanel.Controls.Remove(item);
            }
            _items.Clear();

            foreach (var lyric in lyrics)
            {
                var item = new LyricListItemControl(lyric);
                item.SetStyleManager(StyleManager);
                item.OnClicked += OnClicked;

                item.Font = new Font(item.Font.Name, item.Font.Size, FontStyle.Bold);
                _items.Add(item);
                stackPanel.Controls.Add(item);
            }
            _items.ForEach(o => o.Font = new Font(o.Font.Name, o.Font.Size, FontStyle.Regular));
            stackPanel.IsNotMove = false;
            stackPanel.MoveControls();
            stackPanel.ResumeLayout();
            return true;
        }

        public void UpdateUI(TimeSpan currentTime)
        {
            if (!Visible || _items.Count == 0) return;

            LyricListItemControl nowItem = null;
            foreach (var item in _items)
            {
                if (currentTime >= item.Lyric.Time) nowItem = item;
            }
            if (_oldItem == nowItem) return;
            if (nowItem == null) return;

            if (_oldItem != null) _oldItem.IsNow = false;
            _oldItem = nowItem;
            _oldItem.IsNow = true;
            stackPanel.ScrollMove(_oldItem);
        }

        public void ReorderUI()
        {
            var lyrics = _items.Select(o => o.Lyric).OrderBy(o => o.Time).ToList();
            InitUI(lyrics);
        }
        #endregion

        #region Private Method
        private void OnClicked(object sender, EventArgs e)
        {
            var item = sender as LyricListItemControl;
            if (item == null) return;

            OnClickedLyric?.Invoke(this, new LyricEventArgs(item.Lyric));
        }
        #endregion
    }
}