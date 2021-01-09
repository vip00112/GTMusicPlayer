using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTMusicPlayer
{
    public class GlobalStyleManager
    {
        #region Constructor
        static GlobalStyleManager()
        {
            Instance = new GlobalStyleManager();
        }
        #endregion

        #region Properties
        public static GlobalStyleManager Instance { get; }

        public MetroStyleManager Manager { get; private set; }

        public MetroThemeStyle Theme
        {
            get { return (Manager == null) ? MetroThemeStyle.Default : Manager.Theme; }
            set
            {
                if (Manager == null) return;
                if (Manager.Theme == value) return;

                Manager.Theme = value;
                ApplyManagerToOpenForms();
            }
        }

        public MetroColorStyle Style
        {
            get { return (Manager == null) ? MetroColorStyle.Default : Manager.Style; }
            set
            {
                if (Manager == null) return;
                if (Manager.Style == value) return;

                Manager.Style = value;
                ApplyManagerToOpenForms();
            }
        }
        #endregion

        #region Public Method
        public void Init(MetroStyleManager manager)
        {
            Manager = manager;
        }

        public void ApplyManagerToOpenForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                ApplyManagerToControl(form);
            }
        }

        public void ApplyManagerToControl(Control control)
        {
            if (Manager == null) return;
            if (control == null) return;

            if (control is IMetroForm)
            {
                ((IMetroForm) control).StyleManager = Manager;
            }

            if (control is IMetroControl)
            {
                ((IMetroControl) control).StyleManager = Manager;
            }

            if (control is IMetroComponent)
            {
                ((IMetroComponent) control).StyleManager = Manager;
            }

            if (control is TabControl)
            {
                foreach (TabPage tp in ((TabControl) control).TabPages)
                {
                    ApplyManagerToControl(tp);
                }
            }

            if (control.ContextMenuStrip != null)
            {
                ApplyManagerToControl(control.ContextMenuStrip);
            }

            // 현재 컨트롤의 자식 컨트롤 적용
            foreach (Control child in control.Controls)
            {
                ApplyManagerToControl(child);
            }

            control.Invalidate();
        }
        #endregion

        #region Private Method
        private void ChangeTheme()
        {
            foreach (Form form in Application.OpenForms)
            {
                ChangeTheme(form);
            }
        }

        private void ChangeTheme(Control control)
        {
            if (Manager == null) return;
            if (control == null) return;

            if (control is IMetroControl)
            {
                ((IMetroControl) control).Theme = Manager.Theme;
            }

            if (control is IMetroComponent)
            {
                ((IMetroComponent) control).Theme = Manager.Theme;
            }

            if (control is TabControl)
            {
                foreach (TabPage tp in ((TabControl) control).TabPages)
                {
                    ChangeTheme(tp);
                }
            }

            if (control.ContextMenuStrip != null)
            {
                ChangeTheme(control.ContextMenuStrip);
            }

            // 현재 컨트롤의 자식 컨트롤 적용
            foreach (Control child in control.Controls)
            {
                ChangeTheme(child);
            }

            control.Invalidate();
        }

        private void ChangeStyle()
        {
            foreach (Form form in Application.OpenForms)
            {
                ChangeStyle(form);
            }
        }

        private void ChangeStyle(Control control)
        {
            if (Manager == null) return;
            if (control == null) return;

            if (control is IMetroControl)
            {
                ((IMetroControl) control).Style = Manager.Style;
            }

            if (control is IMetroComponent)
            {
                ((IMetroComponent) control).Style = Manager.Style;
            }

            if (control is TabControl)
            {
                foreach (TabPage tp in ((TabControl) control).TabPages)
                {
                    ChangeStyle(tp);
                }
            }

            if (control.ContextMenuStrip != null)
            {
                ChangeStyle(control.ContextMenuStrip);
            }

            // 현재 컨트롤의 자식 컨트롤 적용
            foreach (Control child in control.Controls)
            {
                ChangeStyle(child);
            }

            control.Invalidate();
        }
        #endregion
    }
}