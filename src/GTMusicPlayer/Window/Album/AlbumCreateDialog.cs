using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTMusicPlayer
{
    public partial class AlbumCreateDialog : MetroForm
    {
        private Album _album;

        #region Constructor
        public AlbumCreateDialog()
        {
            InitializeComponent();
        }

        private void AlbumCreateDialog_Load(object sender, EventArgs e)
        {
            GlobalStyleManager.Instance.ApplyManagerToControl(this);
        }
        #endregion

        #region Properties
        public Album Album
        {
            get { return _album; }
            set
            {
                if (_album == value) return;

                _album = value;
                if (_album != null)
                {
                    Text = "Edit Album";
                    metroTextBox_name.Text = _album.Name;
                    metroTextBox_description.Text = _album.Description;
                }
            }
        }
        #endregion

        #region Control Event
        private void metroButton_ok_Click(object sender, EventArgs e)
        {
            string name = metroTextBox_name.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBoxUtil.Error(this, "Please input album name.");
                return;
            }

            string desc = metroTextBox_description.Text;
            if (string.IsNullOrWhiteSpace(desc))
            {
                MessageBoxUtil.Error(this, "Please input album description.");
                return;
            }

            Album = new Album()
            {
                Name = name,
                Description = desc,
                CreatedOn = DateTime.Now,
            };
            DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
