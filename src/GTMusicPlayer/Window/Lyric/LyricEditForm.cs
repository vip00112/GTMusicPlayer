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
        private string _musicFilePath;
        private string _lyricFilePath;

        #region Constructor
        public LyricEditForm()
        {
            InitializeComponent();

            _items = new List<ALSongLyricHeaderControl>();
        }
        #endregion

        #region Control Event
        private void LyricEditForm_Load(object sender, EventArgs e)
        {
            GlobalStyleManager.Instance.ApplyManagerToControl(this);

            lyricListControl.OnClickedLyric += OnClickedLyric;
        }

        private void metroButton_search_Click(object sender, EventArgs e)
        {
            SearchLyrics();
        }

        private void metroButton_save_Click(object sender, EventArgs e)
        {
            var lyrics = lyricListControl.Lyrics;
            string content = LyricParser.Convert(lyrics);
            if (string.IsNullOrWhiteSpace(content)) return;

            var sf = new SaveFileDialog();
            sf.Filter = "Lyric File|*.lyric;";

            if (!string.IsNullOrWhiteSpace(_lyricFilePath))
            {
                sf.InitialDirectory = Path.GetDirectoryName(_lyricFilePath);
                sf.FileName = Path.GetFileNameWithoutExtension(_lyricFilePath);
            }
            else if (!string.IsNullOrWhiteSpace(_musicFilePath))
            {
                sf.InitialDirectory = Path.GetDirectoryName(_musicFilePath);
                sf.FileName = Path.GetFileNameWithoutExtension(_musicFilePath);
            }
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

            _lyricFilePath = of.FileName;
            LoadLyrics(lyrics);
        }
        #endregion

        #region Event Handler
        private void OnClickedHeader(object sender, EventArgs e)
        {
            var item = sender as ALSongLyricHeaderControl;
            if (item == null) return;

            WaitDialog.Process(this);

            var lyrics = LyricParser.GetALSongLyrics(item.Header);
            if (lyricListControl.InitUI(lyrics))
            {
                if (_selectedItem != null) _selectedItem.IsSelected = false;
                item.IsSelected = true;
                _selectedItem = item;
                _lyricFilePath = null;
            }
            else
            {
                if (_selectedItem != null) _selectedItem.IsSelected = true;
                MessageBoxUtil.Error(this, "Can not laod lyrics from this header.");
            }
            lyricListControl.Focus();
            lyricListControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void OnClickedLyric(object sender, LyricEventArgs e)
        {
            using (var dialog = new LyricEditDialog())
            {
                dialog.Lyric = e.Lyric;
                if (dialog.ShowDialog() != DialogResult.OK) return;

                e.Lyric.Time = dialog.Lyric.Time;
                e.Lyric.Text = dialog.Lyric.Text;
                lyricListControl.ReorderUI();
            }
        }
        #endregion

        #region Private Method
        private bool LoadLyrics(List<Lyric> lyrics)
        {
            if (lyrics == null) return false;
            if (lyricListControl.InitUI(lyrics))
            {
                if (_selectedItem != null) _selectedItem.IsSelected = false;
                return true;
            }
            return false;
        }
        #endregion

        #region Public Method
        public bool InitMusic(Music music)
        {
            metroTextBox_title.Text = music.Title;
            metroTextBox_singer.Text = music.ViewSinger;
            _musicFilePath = music.FilePath;
            return LoadLyrics(music.Lyrics);
        }

        public void SearchLyrics()
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

            var headers = LyricParser.GetALSongLyricHeaders(title, singer, 10);
            if (headers == null || headers.Count == 0)
            {
                MessageBoxUtil.Error(this, "Not found search results.");
                return;
            }

            stackPanel_header.SuspendLayout();
            stackPanel_header.IsNotMove = true;
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
                item.OnClicked += OnClickedHeader;
                GlobalStyleManager.Instance.ApplyManagerToControl(item);

                _items.Add(item);
                stackPanel_header.Controls.Add(item);
            }
            stackPanel_header.IsNotMove = false;
            stackPanel_header.MoveControls();
            stackPanel_header.ResumeLayout();
        }
        #endregion
    }
}