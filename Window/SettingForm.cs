using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Interfaces;
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
    public partial class SettingForm : MetroForm
    {
        #region Constructor
        private SettingForm()
        {
            InitializeComponent();
        }

        public SettingForm(MetroStyleManager styleManager) : this()
        {
            StyleManager = styleManager;
            this.SetStyleManager(styleManager);

            metroComboBox_theme.SelectedIndex = ((int) styleManager.Theme) - 1;
            metroComboBox_style.SelectedIndex = ((int) styleManager.Style) - 1;
            metroComboBox_repeat.SelectedIndex = Setting.Instance.RepeatType;
            metroComboBox_order.SelectedIndex = Setting.Instance.OrderType;
        }
        #endregion

        #region Control Event
        private void metroComboBox_theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            StyleManager.Theme = (MetroThemeStyle) metroComboBox_theme.SelectedIndex + 1;
            this.SetStyleManager(StyleManager);

            foreach (Form form in Application.OpenForms)
            {
                form.SetStyleManager(StyleManager);
            }

            Setting.Instance.UITheme = (int) StyleManager.Theme;
        }

        private void metroComboBox_style_SelectedIndexChanged(object sender, EventArgs e)
        {
            StyleManager.Style = (MetroColorStyle) metroComboBox_style.SelectedIndex + 1;
            this.SetStyleManager(StyleManager);

            foreach (Form form in Application.OpenForms)
            {
                form.SetStyleManager(StyleManager);
            }

            Setting.Instance.UIStyle = (int) StyleManager.Style;
        }

        private void metroComboBox_order_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.Instance.OrderType = metroComboBox_order.SelectedIndex;
        }

        private void metroComboBox_repeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.Instance.RepeatType = metroComboBox_repeat.SelectedIndex;
        }
        #endregion
    }
}