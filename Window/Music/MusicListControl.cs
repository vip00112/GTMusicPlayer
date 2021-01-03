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
using System.IO;

namespace GTMusicPlayer
{
    public partial class MusicListControl : MetroUserControl
    {
        public EventHandler<MusicEventArgs> OnAddedMusic;
        public EventHandler<MusicEventArgs> OnDeletedMusic;
        public EventHandler<MusicEventArgs> OnSelectedMusic;
        public EventHandler<MusicListEventArgs> OnMovedMusic;

        private List<MusicListItemControl> _items;

        #region Constructor
        public MusicListControl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _items = new List<MusicListItemControl>();
            stackPanel.ScrollMoveControlCount = 2;
            stackPanel.OnMovedItem += OnMovedItem;
        }
        #endregion

        #region Control Event
        private void stackPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void stackPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[]) e.Data.GetData(DataFormats.FileDrop);
            paths = paths.OrderBy(o => o).ToArray();

            foreach (string path in paths)
            {
                AddMusic(path);
            }
        }

        private void metroContextMenu_Opening(object sender, CancelEventArgs e)
        {
            metroContextMenu.StyleManager = StyleManager;
            metroContextMenu.SetStyleManager(StyleManager);
        }

        private void menuItem_add_Click(object sender, EventArgs e)
        {
            SelectMusics();
        }

        private void metroLabel_add_Click(object sender, EventArgs e)
        {
            SelectMusics();
        }

        private void metroLabel_delete_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        private void menuItem_deleteSelected_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        private void menuItem_deleteWithoutSelected_Click(object sender, EventArgs e)
        {
            DeleteWithoutSelected();
        }

        private void menuItem_deleteAll_Click(object sender, EventArgs e)
        {
            DeleteAll();
        }
        #endregion

        #region Event Handler
        private void OnDoubleClickedItem(object sender, EventArgs e)
        {
            var item = sender as MusicListItemControl;
            if (item == null) return;

            OnSelectedMusic?.Invoke(this, new MusicEventArgs(item.Music));
        }

        private void OnDeletedItem(object sender, EventArgs e)
        {
            var item = sender as MusicListItemControl;
            if (item == null) return;

            item.OnDeleted -= OnDeletedItem;
            item.OnDoubleClicked -= OnDoubleClickedItem;

            _items.Remove(item);
            metroLabel_count.Text = string.Format("Total : {0}", _items.Count);
            stackPanel.Controls.Remove(item);

            OnDeletedMusic?.Invoke(this, new MusicEventArgs(item.Music));
        }

        private void OnMovedItem(object sender, MusicItemListEventArgs e)
        {
            var item = sender as MusicListItemControl;
            if (item == null) return;

            _items.Clear();
            _items.AddRange(e.Items);

            var musics = _items.Select(o => o.Music).ToList();
            OnMovedMusic?.Invoke(this, new MusicListEventArgs(musics));
        }
        #endregion

        #region Private Method
        private void SelectMusics()
        {
            var of = new OpenFileDialog();
            of.Multiselect = true;
            of.Filter = "Sound File|*.mp3;*.mp4;*.wav;*.flac;*.m4a;*.oga;*.ogg;";
            if (of.ShowDialog() != DialogResult.OK) return;

            string[] filePaths = of.FileNames;
            foreach (string filePath in filePaths)
            {
                AddMusic(filePath);
            }
        }

        private void AddMusic(string path)
        {
            WaitDialog.Show(this, StyleManager);

            if (Directory.Exists(path))
            {
                var root = new DirectoryInfo(path);
                foreach (var fi in root.GetFiles("*", SearchOption.AllDirectories))
                {
                    AddMusic(fi.FullName);
                }
            }
            else if (File.Exists(path))
            {
                string extension = Path.GetExtension(path);
                if (!Playlist.Instance.ValidateExtension(extension)) return;

                Music music = null;
                using (TagLib.File file = TagLib.File.Create(path))
                {
                    music = new Music()
                    {
                        FilePath = path,
                        Album = file.Tag.Album,
                        Title = file.Tag.Title,
                        Singers = file.Tag.Performers.ToList(),
                        DurationTime = file.Properties.Duration,
                    };
                    if (string.IsNullOrWhiteSpace(music.Album)) music.Album = "Unknown";
                    if (string.IsNullOrWhiteSpace(music.Title)) music.Title = "Unknown";
                }
                if (music == null) return;

                AddMusic(music);
            }
        }

        private void DeleteSelected()
        {

        }

        private void DeleteWithoutSelected()
        {

        }

        private void DeleteAll()
        {

        }
        #endregion

        #region Public Method
        public void AddMusic(Music music)
        {
            var item = new MusicListItemControl(music);
            item.StyleManager = StyleManager;
            item.SetStyleManager(StyleManager);
            item.OnDeleted += OnDeletedItem;
            item.OnDoubleClicked += OnDoubleClickedItem;

            _items.Add(item);
            metroLabel_count.Text = string.Format("Total : {0}", _items.Count);
            stackPanel.Controls.Add(item);

            if (!music.Load())
            {
                SetErrorUI(music, "Load failed. file does not exist.");
            }

            OnAddedMusic?.Invoke(this, new MusicEventArgs(music));
        }

        public void ClearItems()
        {
            stackPanel.SuspendLayout();
            foreach (var item in _items)
            {
                item.OnDeleted -= OnDeletedItem;
                item.OnDoubleClicked -= OnDoubleClickedItem;
                stackPanel.Controls.Remove(item);
            }
            stackPanel.ResumeLayout();
            _items.Clear();
            metroLabel_count.Text = string.Format("Total : {0}", _items.Count);
        }

        public void ChangeViewType()
        {
            _items.ForEach(o => o.ViewMusicInfo());
        }

        public void SetPlayUI(Music music)
        {
            _items.ForEach(o => o.SetPlay(false));

            var item = _items.FirstOrDefault(o => o.Music == music);
            if (item == null) return;

            item.SetPlay(true);
            stackPanel.ScrollMove(item);
        }

        public void SetErrorUI(Music music, string message)
        {
            music.IsError = true;

            var item = _items.FirstOrDefault(o => o.Music == music);
            if (item == null) return;

            item.SetPlay(false);
            item.SetError(message);
        }
        #endregion
    }
}