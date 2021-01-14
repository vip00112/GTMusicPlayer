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
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _ran.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
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
