using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTMusicPlayer
{
    public class Album
    {
        public Album()
        {
            Musics = new List<Music>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Music> Musics { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
