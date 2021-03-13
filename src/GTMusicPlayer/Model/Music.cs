using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        }
        #endregion

        #region Properties
        public string FilePath { get; set; }

        public string Album { get; set; }

        public string Title { get; set; }

        public List<string> Singers { get; set; }

        public string Lyric { get; set; }

        public TimeSpan DurationTime { get; set; }

        [JsonIgnore]
        public string FileName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FilePath)) return "Unknown";
                return Path.GetFileNameWithoutExtension(FilePath);
            }
        }

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

        #region Public Method
        public bool Load()
        {
            // 파일 존재 여부 확인
            if (!File.Exists(FilePath)) return false;

            return true;
        }
        #endregion
    }
}