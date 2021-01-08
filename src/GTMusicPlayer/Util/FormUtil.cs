using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTMusicPlayer
{
    public class FormUtil
    {
        public static TForm FindForm<TForm>() where TForm : Form
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is TForm) return (TForm) form;
            }
            return default(TForm);
        }

        public static void ActiveForm<TForm>() where TForm : Form
        {
            var form = FindForm<TForm>();
            if (form == null) return;

            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            form.Show();
            form.Activate();
        }

        public static void ActiveForm(Form form)
        {
            if (form == null) return;

            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            form.Show();
            form.Activate();
        }

        public static bool HasFocusedForm(Form form)
        {
            if (form == null) return false;
            if (form.Focused) return true;
            return form.ActiveControl != null;
        }
    }
}
