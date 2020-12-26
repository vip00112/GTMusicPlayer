using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTMusicPlayer
{
    public partial class LyricEditDialog : MetroForm
    {
        private Lyric _lyric;

        #region Constructor
        private LyricEditDialog()
        {
            InitializeComponent();
        }

        public LyricEditDialog(MetroStyleManager styleManager) : this()
        {
            StyleManager = styleManager;
            this.SetStyleManager(StyleManager);
        }
        #endregion

        #region Properties
        public Lyric Lyric
        {
            get { return _lyric; }
            set
            {
                if (_lyric == value) return;

                _lyric = value;
                if (_lyric != null)
                {
                    metroTextBox_min.Text = _lyric.Time.ViewMinutes();
                    metroTextBox_sec.Text = _lyric.Time.ViewSeconds();
                    metroTextBox_ms.Text = _lyric.Time.ViewMilliseconds();
                    metroTextBox_text.Text = _lyric.Text;
                }
            }
        }
        #endregion

        #region Control Event
        private void metroButton_ok_Click(object sender, EventArgs e)
        {
            string text = metroTextBox_text.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBoxUtil.Error(this, "Please input lyric text.");
                return;
            }

            string value = CalcTimeToString();
            TimeSpan time;
            if (!TimeSpan.TryParseExact(value, "mm\\:ss\\.ff", System.Globalization.CultureInfo.InvariantCulture, out time))
            {
                MessageBoxUtil.Error(this, "Please input correct time format.");
                return;
            }

            text = text.Replace("\r\n", "");
            Lyric = new Lyric()
            {
                Time = time,
                Text = text,
            };
            DialogResult = DialogResult.OK;
        }

        private void metroTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as MetroTextBox;
            if (textBox == null) return;

            textBox.Text = Regex.Replace(textBox.Text, @"[^\d]", "");
            textBox.SelectionStart = textBox.Text.Length;
            textBox.SelectionLength = 0;
        }
        #endregion

        #region Private Method
        private string CalcTimeToString()
        {
            string min = metroTextBox_min.Text;
            int minValue;
            if (int.TryParse(min, out minValue))
            {
                if (minValue < 10) min = "0" + minValue;
                if (minValue >= 100) min = (minValue / 10).ToString();
            }
            else
            {
                min = "00";
            }

            string sec = metroTextBox_sec.Text;
            int secValue;
            if (int.TryParse(sec, out secValue))
            {
                if (secValue < 10) sec = "0" + secValue;
                if (secValue >= 100) sec = (secValue / 10).ToString();
            }
            else
            {
                sec = "00";
            }

            string ms = metroTextBox_ms.Text;
            int msValue;
            if (int.TryParse(ms, out msValue))
            {
                if (msValue < 10) ms = "0" + msValue;
                if (msValue >= 100) ms = (msValue / 10).ToString();
            }
            else
            {
                ms = "00";
            }
            return string.Format("{0}:{1}.{2}", min, sec, ms);
        }
        #endregion
    }
}