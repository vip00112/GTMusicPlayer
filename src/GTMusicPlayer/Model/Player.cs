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
        public EventHandler OnStoped;
        public EventHandler<MusicEventArgs> OnError;
        public EventHandler<ChangedDurationEventArgs> OnChangedDuration;

        private object _playSync;
        private BackgroundWorker _bw;
        private IWavePlayer _wavePlayer;
        private WaveStream _reader;
        private float _volume;

        #region Constructor
        public Player()
        {
            _playSync = new object();

            _bw = new BackgroundWorker();
            _bw.DoWork += PlayThread;
            _bw.RunWorkerCompleted += PlayCompleted;

            _volume = 1.0F;
        }
        #endregion

        #region Properties
        public bool IsPlaying { get { return _bw != null && _bw.IsBusy; } }

        public TimeSpan CurrentTime
        {
            get
            {
                if (_reader == null) return new TimeSpan();
                return _reader.CurrentTime;
            }
        }
        #endregion

        #region Public Method
        public void Play(Music music)
        {
            // 현재 재생중인 곡이 있을시 대기
            while (_bw.IsBusy) { Thread.Sleep(10); }

            lock (_playSync)
            {
                _bw.RunWorkerAsync(music);
            }
        }

        public bool Resume()
        {
            try
            {
                return StartPlayer();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public bool Pause()
        {
            lock (_playSync)
            {
                if (_wavePlayer == null) return false;
                if (_wavePlayer.PlaybackState != PlaybackState.Playing) return false;

                _wavePlayer.Pause();
            }
            return true;
        }

        public void SetVolume(int value)
        {
            _volume = value / 100F;
            if (_wavePlayer != null) _wavePlayer.Volume = _volume;
        }

        public void Skip(int sec)
        {
            lock (_playSync)
            {
                if (_reader == null) return;

                _reader.Skip(sec);
            }
        }

        public void SkipToEnd()
        {
            lock (_playSync)
            {
                if (_reader == null) return;

                _reader.Position = _reader.Length;
            }
        }
        #endregion

        #region Private Method
        // 실제 재생 담당 쓰레드
        private void PlayThread(object sender, DoWorkEventArgs e)
        {
            var music = e.Argument as Music;
            if (music == null) return;

            try
            {
                if (!music.Load(true))
                {
                    OnError?.Invoke(this, new MusicEventArgs(music, "Load failed. file does not exist."));
                    return;
                }

                _reader = CreateReader(music.FilePathForPlay);
                _wavePlayer = new WaveOut(WaveCallbackInfo.FunctionCallback());
                _wavePlayer.Init(_reader);
                _wavePlayer.Volume = _volume;
                StartPlayer();
                OnStarted?.Invoke(this, new MusicEventArgs(music));

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
                OnError?.Invoke(this, new MusicEventArgs(music, ex.Message));
            }
        }

        private void PlayCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StopPlayer();
            OnStoped?.Invoke(this, EventArgs.Empty);
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

        private bool StartPlayer()
        {
            lock (_playSync)
            {
                if (_wavePlayer == null) return false;
                if (_wavePlayer.PlaybackState == PlaybackState.Playing) return false;

                _wavePlayer.Play();
                return true;
            }
        }

        private void StopPlayer()
        {
            lock (_playSync)
            {
                if (_wavePlayer != null)
                {
                    _wavePlayer.Stop();
                    _wavePlayer.Dispose();
                    _wavePlayer = null;
                }

                if (_reader != null)
                {
                    _reader.Dispose();
                    _reader = null;
                }
            }
        }
        #endregion
    }
}