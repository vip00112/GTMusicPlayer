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
    public static class ExtensionControl
    {
        public static void SetStyleManager(this Control control, MetroStyleManager styleManager)
        {
            if (control == null) return;

            // 현재 컨트롤 테마, 스타일 적용
            if (control is IMetroControl)
            {
                ((IMetroControl) control).Theme = styleManager.Theme;
                ((IMetroControl) control).Style = styleManager.Style;
                ((IMetroControl) control).StyleManager = styleManager;
            }

            // 현재 컨트롤의 자식 컨트롤 적용
            foreach (Control child in control.Controls)
            {
                child.SetStyleManager(styleManager);
            }

            control.Invalidate();
        }
    }
}
