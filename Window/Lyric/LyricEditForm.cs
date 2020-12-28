using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTMusicPlayer
{
    public partial class LyricEditForm : MetroForm
    {
        private List<ALSongLyricHeaderControl> _items;
        private ALSongLyricHeaderControl _selectedItem;

        #region Constructor
        private LyricEditForm()
        {
            InitializeComponent();
            _items = new List<ALSongLyricHeaderControl>();
        }

        public LyricEditForm(MetroStyleManager styleManager) : this()
        {
            StyleManager = styleManager;
            this.SetStyleManager(StyleManager);
        }
        #endregion

        #region Control Event
        private void LyricEditForm_Load(object sender, EventArgs e)
        {
            lyricListControl.StyleManager = StyleManager;
            lyricListControl.SetStyleManager(StyleManager);
            lyricListControl.OnClickedLyric += OnClickedLyric;
        }

        private void metroButton_search_Click(object sender, EventArgs e)
        {
            string title = metroTextBox_title.Text;
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBoxUtil.Error(this, "Please input title.");
                return;
            }

            string singer = metroTextBox_singer.Text;
            if (string.IsNullOrWhiteSpace(singer))
            {
                MessageBoxUtil.Error(this, "Please input singer.");
                return;
            }

            WaitDialog.Show(this, StyleManager);
            var headers = LyricParser.GetALSongLyricHeaders(title, singer, 10);
            if (headers == null || headers.Count == 0)
            {
                MessageBoxUtil.Error(this, "Not found search results.");
                return;
            }

            stackPanel_header.SuspendLayout();
            foreach (var item in _items)
            {
                item.OnClicked -= OnClickedHeader;
                stackPanel_header.Controls.Remove(item);
            }
            _items.Clear();

            foreach (var header in headers)
            {
                var item = new ALSongLyricHeaderControl(header);
                item.StyleManager = StyleManager;
                item.SetStyleManager(StyleManager);
                item.OnClicked += OnClickedHeader;

                _items.Add(item);
                stackPanel_header.Controls.Add(item);
            }
            stackPanel_header.ResumeLayout();
        }

        private void metroButton_save_Click(object sender, EventArgs e)
        {
            var lyrics = lyricListControl.Lyrics;
            string content = LyricParser.Convert(lyrics);
            if (string.IsNullOrWhiteSpace(content)) return;

            var sf = new SaveFileDialog();
            sf.FileName = _selectedItem.Header.Title;
            sf.Filter = "Lyric File|*.lyric;";
            if (sf.ShowDialog() != DialogResult.OK) return;

            File.WriteAllText(sf.FileName, content);
        }

        private void metroButton_load_Click(object sender, EventArgs e)
        {
            var of = new OpenFileDialog();
            of.Filter = "Lyric File|*.lyric;";
            if (of.ShowDialog() != DialogResult.OK) return;

            string content = File.ReadAllText(of.FileName);
            var lyrics = LyricParser.Convert(content);
            if (lyrics == null) return;

            if (!lyricListControl.InitUI(lyrics)) return;
            if (_selectedItem != null) _selectedItem.IsSelected = false;
        }
        #endregion

        #region Event Handler
        private void OnClickedHeader(object sender, EventArgs e)
        {
            var item = sender as ALSongLyricHeaderControl;
            if (item == null) return;

            WaitDialog.Show(this, StyleManager);

            var lyrics = LyricParser.GetALSongLyrics(item.Header);
            if (lyricListControl.InitUI(lyrics))
            {
                if (_selectedItem != null) _selectedItem.IsSelected = false;
                item.IsSelected = true;
                _selectedItem = item;
            }
            else
            {
                _selectedItem.IsSelected = true;
            }
            lyricListControl.Focus();
            lyricListControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void OnClickedLyric(object sender, LyricEventArgs e)
        {
            using (var dialog = new LyricEditDialog(StyleManager))
            {
                dialog.Lyric = e.Lyric;
                if (dialog.ShowDialog() != DialogResult.OK) return;

                e.Lyric.Time = dialog.Lyric.Time;
                e.Lyric.Text = dialog.Lyric.Text;
                lyricListControl.ReorderUI();
            }
        }
        #endregion
    }
}