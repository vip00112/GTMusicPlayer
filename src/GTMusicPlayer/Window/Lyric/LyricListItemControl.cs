using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTMusicPlayer
{
    public class LyricListItemControl : Label, IStackItem, IMetroControl
    {
        public EventHandler OnClicked;

        private bool _isNow;
        private Font _originFont;
        private Font _nowFont;
        private MetroToolTip _tooltip;

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
            _tooltip = new MetroToolTip();
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
                if (Theme == MetroThemeStyle.Light)
                {
                    ForeColor = _isNow ? Color.Black : Color.Gray;
                }
                else
                {
                    ForeColor = _isNow ? Color.LightGray : Color.Gray;
                }
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

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            _tooltip.Show(Lyric.Time.ViewFull(), this, 1000);
        }
        #endregion

        #region IMetroControl Event & Properties
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;

        public int FixedY { get; set; }
        public MetroColorStyle Style { get; set; }
        public MetroThemeStyle Theme { get; set; }
        public MetroStyleManager StyleManager { get; set; }
        public bool UseCustomBackColor { get; set; }
        public bool UseCustomForeColor { get; set; }
        public bool UseStyleColors { get; set; }
        public bool UseSelectable { get; set; }
        #endregion
    }
}
