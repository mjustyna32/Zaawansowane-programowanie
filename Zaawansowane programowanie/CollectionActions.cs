using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaawansowane_programowanie
{
    static class CollectionActions
    {
        private static Random rnd = new Random();
        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = 0; i < list.Count; i++)
                list.Swap(i, rnd.Next(i, list.Count));
        }
    }
}
