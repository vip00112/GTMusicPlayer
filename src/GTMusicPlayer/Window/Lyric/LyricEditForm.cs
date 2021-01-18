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
        enum Mode { Edit, Search }

        private List<ALSongLyricHeaderControl> _items;
        private ALSongLyricHeaderControl _selectedItem;
        private string _musicFilePath;
        private string _lyricFilePath;
        private Mode _mode;

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

        private void metroTextBox_title_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                metroTextBox_singer.Focus();
            }
        }

        private void metroTextBox_singer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SearchLyrics();
            }
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

            if (_mode == Mode.Edit)
            {
                string dirPath = Path.GetDirectoryName(_musicFilePath);
                string fileName = Path.GetFileNameWithoutExtension(_musicFilePath) + ".lyric";
                string filePath = Path.Combine(dirPath, fileName);
                File.WriteAllText(filePath, content);
            }
            else if (_mode == Mode.Search)
            {
                if (!string.IsNullOrWhiteSpace(_lyricFilePath))
                {
                    File.WriteAllText(_lyricFilePath, content);
                    return;
                }

                var sf = new SaveFileDialog();
                sf.Filter = "Lyric File|*.lyric;";
                if (sf.ShowDialog() != DialogResult.OK) return;

                File.WriteAllText(sf.FileName, content);
            }
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

        #region Protected Method
        // 전역 키 설정
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (lyricListControl.DoShortcutCommand(keyData)) return true;

            return base.ProcessCmdKey(ref msg, keyData);
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

        private void ClearUI()
        {
            stackPanel_header.SuspendLayout();
            stackPanel_header.IsNotMove = true;
            foreach (var item in _items)
            {
                item.OnClicked -= OnClickedHeader;
                stackPanel_header.Controls.Remove(item);
            }
            _items.Clear();
            stackPanel_header.IsNotMove = false;
            stackPanel_header.ResumeLayout();

            lyricListControl.ClearUI();
        }
        #endregion

        #region Public Method
        public bool InitEdit(Music music)
        {
            ClearUI();

            metroTextBox_title.Text = music.Title;
            metroTextBox_singer.Text = music.ViewSinger;
            _musicFilePath = music.FilePath;
            _mode = Mode.Edit;

            Text = Path.GetFileNameWithoutExtension(_musicFilePath) + ".lyric";
            Invalidate();
            return LoadLyrics(music.Lyrics);
        }

        public void InitSearch(Music music)
        {
            ClearUI();

            metroTextBox_title.Text = music.Title;
            metroTextBox_singer.Text = music.ViewSinger;
            _mode = Mode.Search;

            Text = "Search Lyric";
            Invalidate();
            SearchLyrics();
        }

        public void SearchLyrics()
        {
            string title = metroTextBox_title.Text;
            string singer = metroTextBox_singer.Text;
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBoxUtil.Error(this, "Please input title.");
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