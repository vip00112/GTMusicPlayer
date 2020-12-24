using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTMusicPlayer
{
    public class StackPanel : MetroPanel
    {
        public EventHandler<MusicItemListEventArgs> OnMovedItem;

        private bool _isLoaded;
        private List<Control> _controls;

        private Point _originPoint;
        private Point _mouseDownPoint;
        private bool _isMouseDowned;

        #region Constructor
        public StackPanel()
        {
            _controls = new List<Control>();

            DoubleBuffered = true;

            UseStyleColors = true;
            AutoScroll = true;
            VerticalScrollbarSize = 5;
            HorizontalScrollbar = false;
            HorizontalScrollbarHighlightOnWheel = false;
            HorizontalScrollbarSize = 5;

            EmptySpaceTop = 5;
            EmptySpaceLeft = 5;
            EmptySpaceBetween = 15;

            _isLoaded = true;
        }
        #endregion

        #region Properties
        public int EmptySpaceTop { get; set; }

        public int EmptySpaceLeft { get; set; }

        public int EmptySpaceBetween { get; set; }
        #endregion

        #region Protected Method
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!_isLoaded) return;

            _controls.Add(e.Control);
            MoveControl(e.Control);

            if (e.Control is MusicListItemControl)
            {
                var item = e.Control as MusicListItemControl;
                item.OnMouseDowned += OnMouseDowned;
                item.OnMouseMoved += OnMouseMoved;
                item.OnMouseUped += OnMouseUped;
            }
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            if (!_isLoaded) return;

            _controls.Remove(e.Control);
            MoveControls();

            if (e.Control is MusicListItemControl)
            {
                var item = e.Control as MusicListItemControl;
                item.OnMouseDowned -= OnMouseDowned;
                item.OnMouseMoved -= OnMouseMoved;
                item.OnMouseUped -= OnMouseUped;
            }
        }
        #endregion

        #region Event Handler
        private void OnMouseDowned(object sender, MouseEventArgs e)
        {
            var item = sender as MusicListItemControl;
            if (item == null) return;

            _isMouseDowned = true;
            _originPoint = item.Location;
            _mouseDownPoint = e.Location;
            item.BorderStyle = BorderStyle.FixedSingle;
            item.BringToFront();
        }

        private void OnMouseMoved(object sender, MouseEventArgs e)
        {
            if (!_isMouseDowned) return;

            var item = sender as MusicListItemControl;
            if (item == null) return;

            item.Location = new Point(item.Location.X, item.Location.Y + (e.Location.Y - _mouseDownPoint.Y));
            item.Invalidate();

            var target = FindItem(item.Location.Y);
            if (target != null)
            {
                int oldIdx = _controls.IndexOf(item);
                int newIdx = _controls.IndexOf(target);

                _controls.Remove(item);
                _controls.Remove(target);

                if (oldIdx < newIdx)
                {
                    _controls.Insert(oldIdx, target);
                    _controls.Insert(newIdx, item);
                }
                else
                {
                    _controls.Insert(newIdx, item);
                    _controls.Insert(oldIdx, target);
                }
                _originPoint = target.Location;
                MoveControls();
            }
        }

        private void OnMouseUped(object sender, MouseEventArgs e)
        {
            var item = sender as MusicListItemControl;
            if (item == null) return;

            _isMouseDowned = false;
            item.Location = _originPoint;
            item.BorderStyle = BorderStyle.None;
            item.Invalidate();

            var items = _controls.Where(o => o is MusicListItemControl)
                                 .Select(o => o as MusicListItemControl).ToList();
            OnMovedItem?.Invoke(sender, new MusicItemListEventArgs(items));
        }
        #endregion

        #region Private Method
        private void MoveControls()
        {
            foreach (var control in _controls)
            {
                MoveControl(control);
            }
        }

        private void MoveControl(Control control)
        {
            if (control == null) return;

            int x = EmptySpaceLeft;
            int y = EmptySpaceTop + AutoScrollPosition.Y;

            int idx = _controls.IndexOf(control);
            if (idx != -1)
            {
                for (int i = 0; i < idx; i++)
                {
                    var added = _controls[i];
                    y += added.Height + EmptySpaceBetween;
                }
            }
            else
            {
                foreach (var added in _controls)
                {
                    y += added.Height + EmptySpaceBetween;
                }
            }

            control.Location = new System.Drawing.Point(x, y);
            control.Invalidate();
        }
        
        private MusicListItemControl FindItem(int y)
        {
            foreach (var control in _controls)
            {
                if (control is MusicListItemControl == false) continue;

                int value = control.Height / 4;
                int startY = control.Location.Y + value;
                int endY = control.Location.Y + control.Height - value;
                if (y >= startY && y <= endY) return control as MusicListItemControl;
            }
            return null;
        }
        #endregion
    }
}