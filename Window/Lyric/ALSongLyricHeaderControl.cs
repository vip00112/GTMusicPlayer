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

namespace GTMusicPlayer
{
    public partial class ALSongLyricHeaderControl : MetroUserControl, IStackItem
    {
        public EventHandler OnClicked;

        private bool _isSelected;

        #region Constructor
        private ALSongLyricHeaderControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public ALSongLyricHeaderControl(ALSongLyricHeader header) : this()
        {
            Header = header;
            metroLabel_id.Text = header.LyricID.ToString();
            metroLabel_title.Text = header.Title;
            metroLabel_singer.Text = header.Artist;
        }
        #endregion

        #region Properties
        public ALSongLyricHeader Header { get; private set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;

                _isSelected = value;
                metroTile_select.Visible = _isSelected;
            }
        }

        public int FixedY { get; set; }
        #endregion

        #region Control Event
        private void metroLabel_Click(object sender, EventArgs e)
        {
            OnClicked?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
