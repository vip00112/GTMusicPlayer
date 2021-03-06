﻿using MetroFramework;
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

        private MetroThemeStyle _uiTheme;
        private MetroColorStyle _uistyle;
        private RepeatType _repeatType;
        private OrderType _orderType;
        private ViewType _viewType;
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

        public MetroThemeStyle UITheme
        {
            get { return _uiTheme; }
            set
            {
                if (_uiTheme == value) return;

                _uiTheme = value;
                if (IsLoaded) Save();
            }
        }

        public MetroColorStyle UIStyle
        {
            get { return _uistyle; }
            set
            {
                if (_uistyle == value) return;

                _uistyle = value;
                if (IsLoaded) Save();
            }
        }

        public RepeatType RepeatType
        {
            get { return _repeatType; }
            set
            {
                if (_repeatType == value) return;

                _repeatType = value;
                if (IsLoaded) Save();
            }
        }

        public OrderType OrderType
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

        public ViewType ViewType
        {
            get { return _viewType; }
            set
            {
                if (_viewType == value) return;

                _viewType = value;
                if (IsLoaded)
                {
                    Save();

                    var mainForm = FormUtil.FindForm<MainForm>();
                    if (mainForm != null) mainForm.ChangeViewType();

                    var albumForm = FormUtil.FindForm<AlbumForm>();
                    if (albumForm != null) albumForm.ChangeViewType();
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
