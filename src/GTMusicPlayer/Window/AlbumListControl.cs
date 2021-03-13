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
    public partial class AlbumListControl : MetroUserControl
    {
        public EventHandler<AlbumEventArgs> OnCreatedAlbum;
        public EventHandler<AlbumEventArgs> OnEditedAlbum;
        public EventHandler<AlbumEventArgs> OnDeletedAlbum;
        public EventHandler<AlbumEventArgs> OnFocusedAlbum;
        public EventHandler<AlbumEventArgs> OnSelectedAlbum;

        private List<AlbumListItemControl> _items;

        #region Constructor
        public AlbumListControl()
        {
            InitializeComponent();

            DoubleBuffered = true;

            _items = new List<AlbumListItemControl>();
        }
        #endregion

        #region Control Event
        private void metroLabel_create_Click(object sender, EventArgs e)
        {
            using (var dialog = new AlbumCreateDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;

                var album = dialog.Album;
                AddAlbum(album);

                OnCreatedAlbum?.Invoke(this, new AlbumEventArgs(album));
            }
        }
        #endregion

        #region Event Handler
        private void OnEditedItem(object sender, EventArgs e)
        {
            var item = sender as AlbumListItemControl;
            if (item == null) return;

            OnEditedAlbum?.Invoke(this, new AlbumEventArgs(item.Album));
        }

        private void OnDeletedItem(object sender, EventArgs e)
        {
            var item = sender as AlbumListItemControl;
            if (item == null) return;

            item.OnEdited -= OnEditedItem;
            item.OnDeleted -= OnDeletedItem;
            item.OnClicked -= OnClickedItem;
            item.OnDoubleClicked -= OnDoubleClickedItem;
            _items.Remove(item);
            stackPanel.Controls.Remove(item);

            OnDeletedAlbum?.Invoke(this, new AlbumEventArgs(item.Album));
        }

        private void OnClickedItem(object sender, EventArgs e)
        {
            var item = sender as AlbumListItemControl;
            if (item == null) return;

            OnFocusedAlbum?.Invoke(this, new AlbumEventArgs(item.Album));
        }

        private void OnDoubleClickedItem(object sender, EventArgs e)
        {
            var item = sender as AlbumListItemControl;
            if (item == null) return;

            OnSelectedAlbum?.Invoke(this, new AlbumEventArgs(item.Album));
        }
        #endregion

        #region Public Method
        public void AddAlbum(Album album)
        {
            var item = new AlbumListItemControl(album);
            item.OnEdited += OnEditedItem;
            item.OnDeleted += OnDeletedItem;
            item.OnClicked += OnClickedItem;
            item.OnDoubleClicked += OnDoubleClickedItem;
            GlobalStyleManager.Instance.ApplyManagerToControl(item);

            _items.Add(item);
            stackPanel.Controls.Add(item);
        }

        public void SelectAlbum(Album album)
        {
            _items.ForEach(o => o.SelectAlbum(false));

            var item = _items.FirstOrDefault(o => o.Album == album);
            if (item == null) return;

            item.SelectAlbum(true);
        }
        #endregion
    }
}