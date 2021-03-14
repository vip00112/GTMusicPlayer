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

        public static string ViewMinutes(this TimeSpan timeSpan)
        {
            if (timeSpan.Minutes >= 1000)
            {
                return string.Format("{0:D4}", timeSpan.Minutes);
            }
            else if (timeSpan.Minutes >= 100)
            {
                return string.Format("{0:D3}", timeSpan.Minutes);
            }
            else
            {
                return string.Format("{0:D2}", timeSpan.Minutes);
            }
        }

        public static string ViewSeconds(this TimeSpan timeSpan)
        {
            return string.Format("{0:D2}", timeSpan.Seconds);
        }

        public static string ViewMilliseconds(this TimeSpan timeSpan)
        {
            int ms = (timeSpan.Milliseconds >= 100) ? timeSpan.Milliseconds / 10 : timeSpan.Milliseconds;
            return string.Format("{0:D2}", ms);
        }

        public static string ViewFull(this TimeSpan timeSpan)
        {
            int ms = (timeSpan.Milliseconds >= 100) ? timeSpan.Milliseconds / 10 : timeSpan.Milliseconds;
            if (timeSpan.Minutes >= 1000)
            {
                return string.Format("{0:D4}:{1:D2}.{2:D2}", timeSpan.Minutes, timeSpan.Seconds, ms);
            }
            else if (timeSpan.Minutes >= 100)
            {
                return string.Format("{0:D3}:{1:D2}.{2:D2}", timeSpan.Minutes, timeSpan.Seconds, ms);
            }
            else
            {
                return string.Format("{0:D2}:{1:D2}.{2:D2}", timeSpan.Minutes, timeSpan.Seconds, ms);
            }
        }
    }
}