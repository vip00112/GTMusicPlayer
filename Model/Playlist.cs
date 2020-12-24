using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTMusicPlayer
{
    public class Playlist
    {
        public readonly static Playlist Instance = new Playlist();

        public static readonly string[] GaneralExtensions = new string[] { ".mp3", ".mp4", ".wav", ".flac", ".m4a" };
        public static readonly string[] VorbisExtensions = new string[] { ".oga", ".ogg" };

        public EventHandler<AlbumEventArgs> OnChangedAlbum;

        private List<Music> _playedMusics;
        private List<Music> _waitMusics;

        #region Constructor
        private Playlist()
        {
            _playedMusics = new List<Music>();
            _waitMusics = new List<Music>();
            Musics = new List<Music>();
        }
        #endregion

        #region Properties
        [JsonIgnore]
        public RepeatType RepeatType { get { return (RepeatType) Setting.Instance.RepeatType; } }

        [JsonIgnore]
        public OrderType OrderType { get { return (OrderType) Setting.Instance.OrderType; } }

        [JsonIgnore]
        public Music CurrentMusic { get; set; }

        public List<Music> Musics { get; private set; }
        #endregion

        #region Public Method
        public bool ValidateExtension(string extension)
        {
            return GaneralExtensions.Contains(extension) || VorbisExtensions.Contains(extension);
        }

        public void AddMusic(Music music)
        {
            Musics.Add(music);
            _waitMusics.Add(music);
        }

        public void RemoveMusic(Music music)
        {
            Musics.Remove(music);
            _waitMusics.Remove(music);
            _playedMusics.Remove(music);
        }

        public Music GetPrevMusic(Music current)
        {
            int idx = _playedMusics.IndexOf(current) - 1;
            if (idx < 0) return null;

            Music prev = null;
            while (idx >= 0 && prev == null)
            {
                prev = _playedMusics[idx--];
                if (prev.IsError) prev = null;
            }

            return (prev == null) ? current : prev;
        }

        public Music GetNextMusic(Music current)
        {
            // 한곡 반복 재생일시 마지막 플레이한 곡 반환
            if (RepeatType == RepeatType.One && _playedMusics.Count > 0)
            {
                return _playedMusics.LastOrDefault();
            }

            // Prev곡 재생이었을시 처리
            if (current != null)
            {
                int idx = _playedMusics.IndexOf(current);
                if (idx > -1 && idx < _playedMusics.Count - 1)
                {
                    return _playedMusics[idx + 1];
                }
            }

            var next = _waitMusics.FirstOrDefault();
            if (next == null)
            {
                // 반복 재생 없을시 모든곡 재생 완료 후 종료
                if (RepeatType == RepeatType.None) return null;

                _playedMusics.Clear();
                _waitMusics.AddRange(Musics);
                if (OrderType == OrderType.Random)
                {
                    _waitMusics.Shuffle();
                }
                next = _waitMusics.FirstOrDefault();
            }

            _waitMusics.Remove(next);
            _playedMusics.Add(next);
            return next;
        }

        public void ChangeMusic(Music current)
        {
            if (OrderType == OrderType.Orderd)
            {
                _playedMusics.Clear();
                _waitMusics.Clear();

                int idx = Musics.IndexOf(current);
                List<Music> musics = new List<Music>();
                for (int i = 0; i < Musics.Count; i++)
                {
                    var music = Musics[i];
                    if (i < idx) _playedMusics.Add(music);
                    else _waitMusics.Add(music);
                }
            }
            else if (OrderType == OrderType.Random)
            {
                _playedMusics.Remove(current);
                _waitMusics.Remove(current);
                _waitMusics.Insert(0, current);
            }
        }

        public void RefreshOrder(List<Music> musics)
        {
            _playedMusics.Clear();
            _waitMusics.Clear();
            if (musics != null)
            {
                Musics.Clear();
                Musics.AddRange(musics);
            }

            if (OrderType == OrderType.Orderd)
            {
                if (CurrentMusic != null)
                {
                    int idx = Musics.IndexOf(CurrentMusic);
                    for (int i = 0; i < Musics.Count; i++)
                    {
                        var music = Musics[i];
                        if (i <= idx) _playedMusics.Add(music);
                        else _waitMusics.Add(music);
                    }
                }
                else
                {
                    _waitMusics.AddRange(Musics);
                }
            }
            else if (OrderType == OrderType.Random)
            {
                _waitMusics.AddRange(Musics);
                if (CurrentMusic != null)
                {
                    _waitMusics.Remove(CurrentMusic);
                    _playedMusics.Add(CurrentMusic);
                }
                _waitMusics.Shuffle();
            }
        }

        public void ChangeAlbum(Album album)
        {
            _playedMusics.Clear();
            _waitMusics.Clear();
            Musics.Clear();
            OnChangedAlbum?.Invoke(this, new AlbumEventArgs(album));
        }
        #endregion
    }
}