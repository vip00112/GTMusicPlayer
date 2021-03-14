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
        public string FilePathForPlay
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FilePath)) return null;
                string dirPath = Path.GetDirectoryName(FilePath);
                string extension = Path.GetExtension(FilePath);
                return Path.Combine(dirPath, "CurrentMusic" + extension);
            }
        }

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
        public bool Load(bool isPlay)
        {
            // 파일 존재 여부 확인
            if (!File.Exists(FilePath)) return false;

            if (isPlay)
            {
                File.Copy(FilePath, FilePathForPlay, true);
            }

            return true;
        }
        #endregion
    }
}