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
    public partial class MusicTagEditDialog : MetroForm
    {
        private Music _music;

        #region Constructor
        public MusicTagEditDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string Title { get { return metroTextBox_title.Text; } }

        public List<string> Singer { get { return new List<string>() { metroTextBox_singer.Text }; } }

        public string Album { get { return metroTextBox_album.Text; } }
        #endregion

        #region Control Event
        private void MusicTagEditDialog_Load(object sender, EventArgs e)
        {
            GlobalStyleManager.Instance.ApplyManagerToControl(this);
        }

        private void metroButton_save_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_music.FilePath))
            {
                MessageBoxUtil.Error(this, "Can't find file.");
                return;
            }

            using (TagLib.File file = TagLib.File.Create(_music.FilePath))
            {
                file.Tag.Title = metroTextBox_title.Text;
                file.Tag.Performers = new string[] { metroTextBox_singer.Text };
                file.Tag.Album = metroTextBox_album.Text;
                file.Save();
            }

            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Protected Method
        // 전역 키 설정
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Public Method
        public void InitEdit(Music music)
        {
            _music = music;
            metroTextBox_title.Text = music.Title;
            metroTextBox_singer.Text = music.ViewSinger;
            metroTextBox_album.Text = music.Album;
        }
        #endregion
    }
}
