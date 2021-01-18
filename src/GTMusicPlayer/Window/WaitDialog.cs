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
    public partial class WaitDialog : MetroForm
    {
        private static WaitDialog _dialog;

        public Form OwnerForm { get; set; }

        public WaitDialog()
        {
            InitializeComponent();
        }

        public static void Process(Control control)
        {
            if (_dialog != null && !_dialog.IsDisposed) return;

            _dialog = new WaitDialog();
            GlobalStyleManager.Instance.ApplyManagerToControl(_dialog);
            _dialog.OwnerForm = FindOwnerForm(control);
            _dialog.Show();
            _dialog.Refresh();

            Application.Idle += Idle;
        }

        public new static void Hide()
        {
            if (_dialog == null || _dialog.IsDisposed) return;

            Idle(null, EventArgs.Empty);
        }

        private static void Idle(object sender, EventArgs e)
        {
            Application.Idle -= Idle;

            Form ownerForm = null;
            if (_dialog != null)
            {
                ownerForm = _dialog.OwnerForm;
                _dialog.Close();
                _dialog.Dispose();
                _dialog = null;
            }
            if (ownerForm != null)
            {
                ownerForm.Focus();
            }
        }

        private static Form FindOwnerForm(Control control)
        {
            if (control == null) return null;

            foreach (Form form in Application.OpenForms)
            {
                if (form == control) return form;

                if (HasControl(form, control)) return form;
            }
            return null;
        }

        private static bool HasControl(Control parent, Control control)
        {
            foreach (Control child in parent.Controls)
            {
                if (child == control) return true;
                if (child.HasChildren)
                {
                    if (HasControl(child, control)) return true;
                }
            }
            return false;
        }
    }
}