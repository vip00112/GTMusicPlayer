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
    public partial class LyricListControl : MetroUserControl
    {
        public EventHandler<LyricEventArgs> OnClickedLyric;

        private List<LyricListItemControl> _items;
        private LyricListItemControl _oldItem;
        private Dictionary<Keys, ToolStripMenuItem> _menuItemShortcuts;

        #region Constructor
        public LyricListControl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _items = new List<LyricListItemControl>();
            stackPanel.ScrollMoveControlCount = 4;

            _menuItemShortcuts = new Dictionary<Keys, ToolStripMenuItem>();
            _menuItemShortcuts.Add(menuItem_minus01.ShortcutKeys, menuItem_minus01);
            _menuItemShortcuts.Add(menuItem_plus01.ShortcutKeys, menuItem_plus01);
            _menuItemShortcuts.Add(menuItem_minus05.ShortcutKeys, menuItem_minus05);
            _menuItemShortcuts.Add(menuItem_plus05.ShortcutKeys, menuItem_plus05);
            _menuItemShortcuts.Add(menuItem_minus10.ShortcutKeys, menuItem_minus10);
            _menuItemShortcuts.Add(menuItem_plus10.ShortcutKeys, menuItem_plus10);
        }
        #endregion

        #region Properties
        public List<Lyric> Lyrics
        {
            get { return _items.Select(o => o.Lyric).OrderBy(o => o.Time).ToList(); }
        }
        #endregion

        #region Control Event
        private void metroContextMenu_Opening(object sender, CancelEventArgs e)
        {
            menuItem_sync.Enabled = _items.Count > 0;
        }

        private void menuItem_minus01_Click(object sender, EventArgs e)
        {
            UpdateSync(-100);
        }

        private void menuItem_plus01_Click(object sender, EventArgs e)
        {
            UpdateSync(100);
        }

        private void menuItem_minus05_Click(object sender, EventArgs e)
        {
            UpdateSync(-500);
        }

        private void menuItem_plus05_Click(object sender, EventArgs e)
        {
            UpdateSync(500);
        }

        private void menuItem_minus10_Click(object sender, EventArgs e)
        {
            UpdateSync(-1000);
        }

        private void menuItem_plus10_Click(object sender, EventArgs e)
        {
            UpdateSync(1000);
        }
        #endregion

        #region Event Handler
        private void OnClicked(object sender, EventArgs e)
        {
            var item = sender as LyricListItemControl;
            if (item == null) return;

            OnClickedLyric?.Invoke(this, new LyricEventArgs(item.Lyric));
        }
        #endregion

        #region Public Method
        public bool InitUI(List<Lyric> lyrics)
        {
            if (lyrics == null || lyrics.Count == 0) return false;

            WaitDialog.Process(this);

            stackPanel.SuspendLayout();
            stackPanel.IsNotMove = true;
            foreach (var item in _items)
            {
                item.OnClicked -= OnClicked;
                stackPanel.Controls.Remove(item);
            }
            _items.Clear();

            foreach (var lyric in lyrics)
            {
                var item = new LyricListItemControl(lyric);
                item.OnClicked += OnClicked;
                GlobalStyleManager.Instance.ApplyManagerToControl(item);

                item.Font = new Font(item.Font.Name, item.Font.Size, FontStyle.Bold);
                _items.Add(item);
                stackPanel.Controls.Add(item);
            }
            _items.ForEach(o => o.Font = new Font(o.Font.Name, o.Font.Size, FontStyle.Regular));
            stackPanel.IsNotMove = false;
            stackPanel.MoveControls();
            stackPanel.ResumeLayout();
            return true;
        }

        public void UpdateUI(TimeSpan currentTime)
        {
            if (!Visible || _items.Count == 0) return;

            LyricListItemControl nowItem = null;
            foreach (var item in _items)
            {
                if (currentTime >= item.Lyric.Time) nowItem = item;
            }
            if (_oldItem == nowItem) return;
            if (nowItem == null) return;

            if (_oldItem != null) _oldItem.IsNow = false;
            _oldItem = nowItem;
            _oldItem.IsNow = true;
            stackPanel.ScrollMove(_oldItem);
        }

        public void ClearUI()
        {
            stackPanel.SuspendLayout();
            stackPanel.IsNotMove = true;
            foreach (var item in _items)
            {
                item.OnClicked -= OnClicked;
                stackPanel.Controls.Remove(item);
            }
            _items.Clear();
            stackPanel.IsNotMove = false;
            stackPanel.ResumeLayout();
        }

        public void ReorderUI()
        {
            var lyrics = _items.Select(o => o.Lyric).OrderBy(o => o.Time).ToList();
            InitUI(lyrics);
        }

        public bool DoShortcutCommand(Keys keyData)
        {
            // TODO : 단축키로 일괄 싱크 변경시 ReorderUI 후 OwnerForm에 포커스가 안가있음.

            if (!_menuItemShortcuts.ContainsKey(keyData)) return false;
            _menuItemShortcuts[keyData].PerformClick();

            return true;
        }
        #endregion

        #region Private Method
        private void UpdateSync(int milliseconds)
        {
            foreach (var item in _items)
            {
                item.Lyric.Time = item.Lyric.Time.Add(new TimeSpan(0, 0, 0, 0, milliseconds));
            }
            ReorderUI();
        }
        #endregion
    }
}