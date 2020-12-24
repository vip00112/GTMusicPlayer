using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTMusicPlayer
{
    public static class ExtensionTimeSpan
    {
        public static string View(this TimeSpan timeSpan)
        {
            if (timeSpan.Minutes >= 1000)
            {
                return string.Format("{0:D4}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            }
            else if (timeSpan.Minutes >= 100)
            {
                return string.Format("{0:D3}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            }
            else
            {
                return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            }
        }
    }
}
