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
        private bool _isLoaded;

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

            metroComboBox_theme.DataSource = Enum.GetValues(typeof(MetroThemeStyle));
            metroComboBox_theme.SelectedItem = GlobalStyleManager.Instance.Theme;

            metroComboBox_style.DataSource = Enum.GetValues(typeof(MetroColorStyle));
            metroComboBox_style.SelectedItem = GlobalStyleManager.Instance.Style;

            metroComboBox_order.DataSource = Enum.GetValues(typeof(OrderType));
            metroComboBox_order.SelectedItem = Setting.Instance.OrderType;

            metroComboBox_repeat.DataSource = Enum.GetValues(typeof(RepeatType));
            metroComboBox_repeat.SelectedItem = Setting.Instance.RepeatType;

            metroComboBox_view.DataSource = Enum.GetValues(typeof(ViewType));
            metroComboBox_view.SelectedItem = Setting.Instance.ViewType;

            _isLoaded = true;
        }

        private void metroComboBox_theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return;

            GlobalStyleManager.Instance.Theme = (MetroThemeStyle) metroComboBox_theme.SelectedItem;
            Setting.Instance.UITheme = GlobalStyleManager.Instance.Theme;
        }

        private void metroComboBox_style_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return;

            GlobalStyleManager.Instance.Style = (MetroColorStyle) metroComboBox_style.SelectedItem;
            Setting.Instance.UIStyle = GlobalStyleManager.Instance.Style;
        }

        private void metroComboBox_order_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return;

            Setting.Instance.OrderType = (OrderType) metroComboBox_order.SelectedItem;
        }

        private void metroComboBox_repeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return;

            Setting.Instance.RepeatType = (RepeatType) metroComboBox_repeat.SelectedItem;
        }

        private void metroComboBox_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return;

            Setting.Instance.ViewType = (ViewType) metroComboBox_view.SelectedItem;
        }

        private void metroButton_default_Click(object sender, EventArgs e)
        {
            metroComboBox_theme.SelectedItem = MetroThemeStyle.Dark;
            metroComboBox_style.SelectedItem = MetroColorStyle.Red;
            metroComboBox_repeat.SelectedItem = RepeatType.All;
            metroComboBox_order.SelectedItem = OrderType.Orderd;
            metroComboBox_view.SelectedItem = ViewType.TitleTag;
        }
        #endregion
    }
}