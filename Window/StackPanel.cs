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

        private MusicListItemControl _movingControl;
        private int _startIdx;
        private Point _movePoint;
        private Point _mouseDownPoint;

        #region Constructor
        public StackPanel()
        {
            _controls = new List<Control>();

            DoubleBuffered = true;

            UseStyleColors = true;
            AutoScroll = true;
            VerticalScrollbar = true;
            VerticalScrollbarHighlightOnWheel = true;
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

        public int ScrollMoveControlCount { get; set; }
        #endregion

        #region Protected Method
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!_isLoaded) return;
            if (e.Control is IStackItem == false) return;

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
            if (e.Control is IStackItem == false) return;

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

            _movingControl = item;
            _startIdx = _controls.IndexOf(item);
            _movePoint = item.Location;
            _mouseDownPoint = e.Location;
            item.BorderStyle = BorderStyle.FixedSingle;
            item.BringToFront();
        }

        private void OnMouseMoved(object sender, MouseEventArgs e)
        {
            if (_movingControl == null) return;

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
                _movePoint = target.Location;
                MoveControls();
            }
        }

        private void OnMouseUped(object sender, MouseEventArgs e)
        {
            if (_movingControl == null) return;

            var item = sender as MusicListItemControl;
            if (item == null) return;

            _movingControl = null;
            item.Location = _movePoint;
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
            (control as IStackItem).FixedY = y - AutoScrollPosition.Y;
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

        private int GetCountInScreen()
        {
            var item = _controls.FirstOrDefault();
            if (item == null) return 0;

            int panelHeight = Height - EmptySpaceTop;
            int countInScreen = 0;
            int value = 0;
            while (value < panelHeight)
            {
                if (countInScreen > 0)
                {
                    value += EmptySpaceBetween;
                }
                value += item.Height;
                countInScreen++;
            }
            return countInScreen - 1;
        }
        #endregion

        #region Public Method
        public void ScrollMove(Control item)
        {
            if (ScrollMoveControlCount == 0) return;
            if (!_controls.Contains(item)) return;

            Control targetControl = null;
            int idx = _controls.IndexOf(item) - ScrollMoveControlCount;
            if (idx < 0)
            {
                targetControl = _controls[0];
            }
            else
            {
                targetControl = _controls[idx];
            }
            if (!_controls.Contains(targetControl)) return;

            int y = (targetControl as IStackItem).FixedY;
            AutoScrollPosition = new Point(AutoScrollPosition.X, y);
        }
        #endregion
    }
}