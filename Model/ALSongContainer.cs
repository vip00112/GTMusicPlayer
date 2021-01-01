using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTMusicPlayer
{
    public class ALSongWrapper
    {
        public ALSongWrapper()
        {
            HeaderContainer = new ALSongLyricContainer();
            ContentContainer = new ALSongLyricContainer();
        }

        [JsonProperty("GetResembleLyricList2Result")]
        public ALSongLyricContainer HeaderContainer { get; set; }

        [JsonProperty("GetLyricByID2Response")]
        public ALSongLyricContainer ContentContainer { get; set; }
    }

    public class ALSongLyricContainer
    {
        public ALSongLyricContainer()
        {
            Headers = new List<ALSongLyricHeader>();
            Content = new ALSongLyricContent();
        }

        [JsonProperty("ST_SEARCHLYRIC_LIST")]
        public List<ALSongLyricHeader> Headers { get; set; }

        [JsonProperty("output")]
        public ALSongLyricContent Content { get; set; }
    }

    public class ALSongLyricHeader
    {
        [JsonProperty("lyricID")]
        public int LyricID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("album")]
        public string Album { get; set; }
    }

    public class ALSongLyricContent
    {
        [JsonProperty("lyricID")]
        public string LyricID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("album")]
        public string Album { get; set; }

        [JsonProperty("lyric")]
        public string Lyric { get; set; }
    }
}
