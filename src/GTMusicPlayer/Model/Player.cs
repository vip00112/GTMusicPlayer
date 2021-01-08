using NAudio.Vorbis;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace GTMusicPlayer
{
    public class Player
    {
        public EventHandler<MusicEventArgs> OnStarted;
        public EventHandler<MusicEventArgs> OnStoped;
        public EventHandler<MusicEventArgs> OnError;
        public EventHandler<ChangedDurationEventArgs> OnChangedDuration;

        private BackgroundWorker _bw;
        private IWavePlayer _player;
        private WaveStream _reader;
        private float _volume;
        private Music _currentMusic;

        #region Constructor
        public Player()
        {
            _bw = new BackgroundWorker();
            _bw.DoWork += PlayThread;
            _bw.RunWorkerCompleted += PlayCompleted;

            _player = new WaveOut(WaveCallbackInfo.FunctionCallback());
            _volume = 1.0F;
        }
        #endregion

        #region Properties
        public bool IsPlaying { get { return _bw != null && _bw.IsBusy; } }

        public Music CurrentMusic
        {
            get { return _currentMusic; }
            set
            {
                if (_currentMusic == value) return;

                _currentMusic = value;
                Playlist.Instance.CurrentMusic = _currentMusic;
            }
        }

        public TimeSpan CurrentTime
        {
            get
            {
                if (_reader == null) return new TimeSpan();
                return _reader.CurrentTime;
            }
        }

        public TimeSpan TotalTime
        {
            get
            {
                if (CurrentMusic == null) return new TimeSpan();
                return CurrentMusic.DurationTime;
            }
        }
        #endregion

        #region Public Method
        public void Play(Music music)
        {
            // 현재 재생중인 곡이 있을시 대기
            if (_bw.IsBusy)
            {
                while (_bw.IsBusy) { Thread.Sleep(10); }
            }

            _bw.RunWorkerAsync(music);
        }

        public bool Resume()
        {
            if (_player.PlaybackState == PlaybackState.Playing) return false;

            // 재생중이 아닐시 마지막 재생한 곡 리플레이
            if (!_bw.IsBusy)
            {
                if (CurrentMusic != null) Play(CurrentMusic);
                return true;
            }

            try
            {
                _player.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Next();
            }
            return true;
        }

        public bool Pause()
        {
            if (_player.PlaybackState != PlaybackState.Playing) return false;
            if (!_bw.IsBusy) return false;

            _player.Pause();
            return true;
        }

        public void SetVolume(int value)
        {
            _volume = value / 100F;
            _player.Volume = _volume;
        }

        public void Skip(int sec)
        {
            if (!_bw.IsBusy) return;
            if (_reader == null) return;

            _reader.Skip(sec);
        }

        public void Next()
        {
            if (!_bw.IsBusy) return;
            if (_reader == null) return;

            _reader.Position = _reader.Length;
        }

        public void SetCurrentMusic(Music music)
        {
            CurrentMusic = music;
        }
        #endregion

        #region Private Method
        // 실제 재생 담당 쓰레드
        private void PlayThread(object sender, DoWorkEventArgs e)
        {
            CurrentMusic = e.Argument as Music;
            if (CurrentMusic == null) return;

            if (!CurrentMusic.Load())
            {
                OnError?.Invoke(this, new MusicEventArgs(CurrentMusic, "Load failed. file does not exist."));
                return;
            }

            try
            {
                _reader = CreateReader(CurrentMusic.FilePath);
                _player = new WaveOut(WaveCallbackInfo.FunctionCallback());
                _player.Init(_reader);
                _player.Volume = _volume;
                _player.Play();
                OnStarted?.Invoke(this, new MusicEventArgs(CurrentMusic));

                while (true)
                {
                    int check = (int) Math.Ceiling(_reader.CurrentTime.TotalSeconds);
                    if (check >= _reader.TotalTime.TotalSeconds) break;
                    Thread.Sleep(10);

                    OnChangedDuration?.Invoke(this, new ChangedDurationEventArgs(_reader.CurrentTime));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                OnError?.Invoke(this, new MusicEventArgs(CurrentMusic, ex.Message));
            }
            finally
            {
                _player.Stop();
                if (_reader != null)
                {
                    _reader.Dispose();
                    _reader = null;
                }
            }
        }

        private void PlayCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnStoped?.Invoke(this, new MusicEventArgs(CurrentMusic));
            CurrentMusic = null;
        }

        private WaveStream CreateReader(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            extension = extension.ToLower();

            if (Playlist.VorbisExtensions.Contains(extension))
            {
                return new VorbisWaveReader(filePath);
            }
            else
            {
                return new AudioFileReader(filePath);
            }
        }
        #endregion
    }
}