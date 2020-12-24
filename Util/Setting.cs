using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTMusicPlayer
{
    public class Setting
    {
        private const string FileName = "Setting.josn";

        private int _uiTheme;
        private int _uistyle;
        private int _repeatType;
        private int _orderType;
        private int _volume;

        static Setting()
        {
            var load = Load();
            if (load != null)
            {
                IsLoaded = true;
                Instance = load;
                return;
            }

            Instance = new Setting();
        }

        private Setting()
        {
            Albums = new List<Album>();
            RecentPlaylist = new List<Music>();
        }

        public static Setting Instance { get; private set; }

        public static bool IsLoaded { get; private set; }

        public int UITheme
        {
            get { return _uiTheme; }
            set
            {
                if (_uiTheme == value) return;

                _uiTheme = value;
                if (IsLoaded) Save();
            }
        }

        public int UIStyle
        {
            get { return _uistyle; }
            set
            {
                if (_uistyle == value) return;

                _uistyle = value;
                if (IsLoaded) Save();
            }
        }

        public int RepeatType
        {
            get { return _repeatType; }
            set
            {
                if (_repeatType == value) return;

                _repeatType = value;
                if (IsLoaded) Save();
            }
        }

        public int OrderType
        {
            get { return _orderType; }
            set
            {
                if (_orderType == value) return;

                _orderType = value;
                if (IsLoaded)
                {
                    Save();
                    Playlist.Instance.RefreshOrder(null);
                }
            }
        }

        public int Volume
        {
            get { return _volume; }
            set
            {
                if (_volume == value) return;

                _volume = value;
                if (IsLoaded) Save();
            }
        }

        // 유저 생성 앨범 목록
        public List<Album> Albums { get; set; }

        // 최근 재생 목록
        public List<Music> RecentPlaylist { get; set; }

        public void Save()
        {
            RecentPlaylist = Playlist.Instance.Musics;

            string json = JsonConvert.SerializeObject(Instance, Formatting.Indented);
            File.WriteAllText(FileName, json);
        }

        private static Setting Load()
        {
            if (!File.Exists(FileName)) return null;

            try
            {
                string json = File.ReadAllText(FileName);
                return JsonConvert.DeserializeObject<Setting>(json);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
