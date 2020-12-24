using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTMusicPlayer
{
    public class Music
    {
        #region Constructor
        public Music()
        {
            Album = "Unknown";
            Title = "Unknown";
            Singers = new List<string>();
            Lyrics = new List<Lyric>();
        }
        #endregion

        #region Properties
        public string FilePath { get; set; }

        public string Album { get; set; }

        public string Title { get; set; }

        public List<string> Singers { get; set; }

        public TimeSpan DurationTime { get; set; }

        [JsonIgnore]
        public List<Lyric> Lyrics { get; set; }

        [JsonIgnore]
        public string ViewSinger
        {
            get
            {
                if (Singers == null || Singers.Count == 0) return "Unknown";
                return string.Join(" & ", Singers);
            }
        }

        [JsonIgnore]
        public bool IsError { get; set; }
        #endregion
    }
}