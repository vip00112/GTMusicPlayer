using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTMusicPlayer
{
    public class MusicEventArgs : EventArgs
    {
        public Music Music { get; }

        public string Message { get; }

        public MusicEventArgs(Music music)
        {
            Music = music;
        }

        public MusicEventArgs(Music music, string msg)
        {
            Music = music;
            Message = msg;
        }
    }

    public class MusicListEventArgs : EventArgs
    {
        public List<Music> Musics { get; }

        public MusicListEventArgs(List<Music> musics)
        {
            Musics = musics;
        }
    }

    public class ChangedDurationEventArgs : EventArgs
    {
        public TimeSpan CurrentTime { get; }

        public ChangedDurationEventArgs(TimeSpan currentTime)
        {
            CurrentTime = currentTime;
        }
    }

    public class AlbumEventArgs : EventArgs
    {
        public Album Album { get; }

        public AlbumEventArgs(Album album)
        {
            Album = album;
        }
    }

    public class MusicItemListEventArgs : EventArgs
    {
        public List<MusicListItemControl> Items { get; }

        public MusicItemListEventArgs(List<MusicListItemControl> itmes)
        {
            Items = itmes;
        }
    }
}