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
        public SettingForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Control Event
        private void SettingForm_Load(object sender, EventArgs e)
        {
            GlobalStyleManager.Instance.ApplyManagerToControl(this);

            metroComboBox_theme.SelectedIndex = ((int) GlobalStyleManager.Instance.Theme) - 1;
            metroComboBox_style.SelectedIndex = ((int) GlobalStyleManager.Instance.Style) - 1;
            metroComboBox_repeat.SelectedIndex = Setting.Instance.RepeatType;
            metroComboBox_order.SelectedIndex = Setting.Instance.OrderType;
            metroComboBox_view.SelectedIndex = Setting.Instance.ViewType;
        }

        private void metroComboBox_theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalStyleManager.Instance.Theme = (MetroThemeStyle) metroComboBox_theme.SelectedIndex + 1;
            Setting.Instance.UITheme = (int) GlobalStyleManager.Instance.Theme;
        }

        private void metroComboBox_style_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalStyleManager.Instance.Style = (MetroColorStyle) metroComboBox_style.SelectedIndex + 1;
            Setting.Instance.UIStyle = (int) GlobalStyleManager.Instance.Style;
        }

        private void metroComboBox_order_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.Instance.OrderType = metroComboBox_order.SelectedIndex;
        }

        private void metroComboBox_repeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.Instance.RepeatType = metroComboBox_repeat.SelectedIndex;
        }

        private void metroComboBox_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.Instance.ViewType = metroComboBox_view.SelectedIndex;
        }
        #endregion
    }
}