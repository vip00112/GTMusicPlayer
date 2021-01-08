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
    public partial class AlbumListItemControl : MetroUserControl, IStackItem
    {
        public EventHandler OnEdited;
        public EventHandler OnDeleted;
        public EventHandler OnClicked;
        public EventHandler OnDoubleClicked;

        #region Constructor
        private AlbumListItemControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public AlbumListItemControl(Album album) : this()
        {
            Album = album;
            metroLabel_name.Text = album.Name;
            metroLabel_description.Text = album.Description;
            metroLabel_createdOn.Text = album.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region Properties
        public Album Album { get; private set; }

        public int FixedY { get; set; }
        #endregion

        #region Control Event
        private void metroLabel_delete_Click(object sender, EventArgs e)
        {
            if (!MessageBoxUtil.Confirm(this, "Are you sure you want to delete it?")) return;

            OnDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void metroLabel_edit_Click(object sender, EventArgs e)
        {
            using (var dialog = new AlbumCreateDialog(StyleManager))
            {
                dialog.Album = Album;
                if (dialog.ShowDialog() != DialogResult.OK) return;

                Album.Name = dialog.Album.Name;
                Album.Description = dialog.Album.Description;

                metroLabel_name.Text = Album.Name;
                metroLabel_description.Text = Album.Description;
                Invalidate();

                OnEdited?.Invoke(this, EventArgs.Empty);
            }
        }

        private void metroLabel_Click(object sender, EventArgs e)
        {
            OnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void metroLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            OnDoubleClicked?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Public Method
        public void SelectAlbum(bool isSelect)
        {
            metroTile_select.Visible = isSelect;
        }
        #endregion
    }
}