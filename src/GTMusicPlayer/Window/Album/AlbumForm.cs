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
    public partial class AlbumForm : MetroForm
    {
        private List<Album> _albums;
        private Album _album;
        private SelectType _selectType;

        #region Constructor
        public AlbumForm()
        {
            InitializeComponent();

            _albums = new List<Album>();
        }
        #endregion

        #region Properties
        public Album CurrentAlbum
        {
            get { return _album; }
            set
            {
                if (_album == value) return;

                _album = value;

                WaitDialog.Process(this);

                musicListControl.ClearItems();
                foreach (var music in _album.Musics)
                {
                    musicListControl.AddMusic(music, false);
                }

                albumListControl.SelectAlbum(_album);

                if (_album.Musics.Count > 0)
                {
                    musicListControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
                else
                {
                    musicListControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                }
            }
        }
        #endregion

        #region Control Event
        private void AlbumForm_Load(object sender, EventArgs e)
        {
            GlobalStyleManager.Instance.ApplyManagerToControl(this);

            _albums.AddRange(Setting.Instance.Albums);
            _albums.ForEach(o => albumListControl.AddAlbum(o));
            if (_albums.Count > 0) CurrentAlbum = _albums[0];

            albumListControl.OnCreatedAlbum += OnCreatedAlbum;
            albumListControl.OnEditedAlbum += OnEditedAlbum;
            albumListControl.OnDeletedAlbum += OnDeletedAlbum;
            albumListControl.OnFocusedAlbum += OnFocusedAlbum;
            albumListControl.OnSelectedAlbum += OnSelectedAlbum;

            musicListControl.OnAddedMusic += OnAddedMusic;
            musicListControl.OnDeletedMusic += OnDeletedMusic;
            musicListControl.OnClickedMusic += OnClickedMusic;
            musicListControl.OnMovedMusic += OnMovedMusic;
        }

        private void AlbumForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey)
            {
                _selectType = SelectType.None;
            }
        }
        #endregion

        #region Event Handler
        private void OnCreatedAlbum(object sender, AlbumEventArgs e)
        {
            _albums.Add(e.Album);
            Setting.Instance.Albums.Add(e.Album);
            Setting.Instance.Save();
        }

        private void OnEditedAlbum(object sender, AlbumEventArgs e)
        {
            var album = _albums.FirstOrDefault(o => o == e.Album);
            if (album != null)
            {
                album.Name = e.Album.Name;
                album.Description = e.Album.Description;
                Setting.Instance.Save();
            }
        }

        private void OnDeletedAlbum(object sender, AlbumEventArgs e)
        {
            _albums.Remove(e.Album);
            Setting.Instance.Albums.Remove(e.Album);
            Setting.Instance.Save();
        }

        private void OnFocusedAlbum(object sender, AlbumEventArgs e)
        {
            CurrentAlbum = e.Album;
        }

        private void OnSelectedAlbum(object sender, AlbumEventArgs e)
        {
            Playlist.Instance.ChangeAlbum(e.Album);
        }

        private void OnAddedMusic(object sender, MusicEventArgs e)
        {
            if (e.Music == null) return;

            CurrentAlbum.Musics.Add(e.Music);
            Setting.Instance.Save();
        }

        private void OnDeletedMusic(object sender, MusicEventArgs e)
        {
            if (CurrentAlbum == null) return;

            CurrentAlbum.Musics.Remove(e.Music);
            Setting.Instance.Save();
        }

        private void OnClickedMusic(object sender, MusicEventArgs e)
        {
            if (e.Music == null) return;

            musicListControl.Select(_selectType, e.Music);
        }

        private void OnMovedMusic(object sender, MusicListEventArgs e)
        {
            CurrentAlbum.Musics.Clear();
            CurrentAlbum.Musics.AddRange(e.Musics);
            Setting.Instance.Save();
        }
        #endregion

        #region Protected Method
        // 전역 키 설정
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            #region Select
            if (keyData == (Keys.ControlKey | Keys.Control))
            {
                _selectType = SelectType.Ctrl;
                return true;
            }
            if (keyData == (Keys.ShiftKey | Keys.Shift))
            {
                _selectType = SelectType.Shift;
                return true;
            }
            if (keyData == Keys.Escape)
            {
                musicListControl.Unselect();
                return true;
            }
            #endregion

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}