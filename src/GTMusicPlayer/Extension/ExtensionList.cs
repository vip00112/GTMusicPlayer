using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTMusicPlayer
{
    public static class ExtensionList
    {
        private static Random _ran = new Random();

        public static void Shuffle<T>(this List<T> list)
        {
            int to = list.Count;
            while (to > 1)
            {
                to--;
                int from = _ran.Next(to + 1);
                list.Swap(from, to);
            }
        }

        public static void Swap<T>(this List<T> list, int from, int to)
        {
            T tmp = list[from];
            list[from] = list[to];
            list[to] = tmp;
        }
    }
}
