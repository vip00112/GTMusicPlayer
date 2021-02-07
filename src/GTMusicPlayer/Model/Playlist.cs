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

        public static readonly string[] GaneralExtensions = new string[] { ".mp3", ".mp4", ".wav", ".wma", ".flac", ".m4a" };
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
            if (string.IsNullOrWhiteSpace(extension)) return false;

            extension = extension.ToLower();
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

        public void ChangePosition(Music current)
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

        public void ChangePrevPosition()
        {
            int idx = _playedMusics.IndexOf(CurrentMusic) - 1;

            _playedMusics.Remove(CurrentMusic);
            _waitMusics.Insert(0, CurrentMusic);

            Music prev = null;
            while (idx >= 0 && prev == null)
            {
                prev = _playedMusics[idx--];
                _playedMusics.Remove(prev);
                _waitMusics.Insert(0, prev);

                // 에러 발생된 노래일시 이전 노래 다시 탐색
                if (prev.IsError) prev = null;
            }
        }

        public void NextMusic()
        {
            // 대기 목록이 없을시 처리
            if (_waitMusics.Count == 0)
            {
                Refresh();
            }

            Music next = _waitMusics.FirstOrDefault();
            _waitMusics.Remove(next);
            _playedMusics.Add(next);
            CurrentMusic = next;
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
                int idx = Musics.IndexOf(CurrentMusic);
                for (int i = 0; i < Musics.Count; i++)
                {
                    var music = Musics[i];
                    if (i <= idx) _playedMusics.Add(music);
                    else _waitMusics.Add(music);
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

            // MusicListControl.AddItem -> MainForm.OnAddedMusic에서 Playlist에 album의 Musics가 추가 됨
            OnChangedAlbum?.Invoke(this, new AlbumEventArgs(album));
        }
        #endregion

        #region Private Method
        // 재생완료/대기 목록 초기화 후 재 셋팅
        private void Refresh()
        {
            _playedMusics.Clear();
            _waitMusics.Clear();
            CurrentMusic = null;

            // 노래 목록 없을시 종료
            if (Musics.Count == 0) return;

            // 반복 재생 없을시 모든곡 재생 완료 후 종료
            if (RepeatType == RepeatType.None) return;

            // 대기 목록에 노래 목록 추가
            _waitMusics.AddRange(Musics);

            // 랜덤 재생일시 대기 목록 처리
            if (OrderType == OrderType.Random)
            {
                _waitMusics.Shuffle();
            }
        }
        #endregion
    }
}