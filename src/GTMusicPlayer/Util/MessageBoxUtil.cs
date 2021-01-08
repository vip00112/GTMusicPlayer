using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTMusicPlayer
{
    public class MessageBoxUtil
    {
        public static void Info(IWin32Window owner, string msg)
        {
            WaitDialog.Hide();
            MetroMessageBox.Show(owner, msg, "GTMusicPlayer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(IWin32Window owner, string msg)
        {
            WaitDialog.Hide();
            MetroMessageBox.Show(owner, msg, "GTMusicPlayer", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(IWin32Window owner, string msg)
        {
            WaitDialog.Hide();
            var result = MetroMessageBox.Show(owner, msg, "GTMusicPlayer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //var result = MessageBox.Show(owner, msg, "GTMusicPlayer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }
    }
}
