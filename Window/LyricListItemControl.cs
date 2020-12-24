﻿using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTMusicPlayer
{
    public class LyricListItemControl : Label
    {
        public EventHandler OnClicked;

        private bool _isNow;
        private Font _originFont;
        private Font _nowFont;

        #region Constructor
        private LyricListItemControl()
        {
            DoubleBuffered = true;
            AutoSize = true;
            Cursor = Cursors.Hand;
            ForeColor = Color.Gray;
            MaximumSize = new Size(250, 0);
            Size = new Size(250, 12);
            _originFont = Font;
            _nowFont = new Font(Font.Name, Font.Size, FontStyle.Bold);
        }

        public LyricListItemControl(Lyric lyric) : this()
        {
            Lyric = lyric;
            Text = lyric.Text;
        }
        #endregion

        #region Properties
        public Lyric Lyric { get; }

        public bool IsNow
        {
            get { return _isNow; }
            set
            {
                if (_isNow == value) return;

                _isNow = value;
                Font = _isNow ? _nowFont : _originFont;
                Invalidate();
            }
        }
        #endregion

        #region Protected Method
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            OnClicked?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
