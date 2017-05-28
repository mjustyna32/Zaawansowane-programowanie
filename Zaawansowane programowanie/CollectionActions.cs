using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaawansowane_programowanie
{
    class CollectionActions
    {
        private Random rnd = new Random();
        public void Swap<T>(ref List<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        public void Shuffle<T>(ref List<T> list)
        {
            for (var i = 0; i < list.Count; i++)
                Swap(ref list, i, rnd.Next(i, list.Count));
        }
    }
}
