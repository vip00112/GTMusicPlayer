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
    public partial class MiniForm : MetroForm
    {
        private Music _music;

        public MiniForm()
        {
            InitializeComponent();
        }

        public Music Music
        {
            get { return _music; }
            set
            {
                if (_music == value) return;

                _music = value;
                metroLabel_title.Text = _music.Title;
            }
        }

        private void MiniForm_Load(object sender, EventArgs e)
        {
            GlobalStyleManager.Instance.ApplyManagerToControl(this);
        }

        private void MiniForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
