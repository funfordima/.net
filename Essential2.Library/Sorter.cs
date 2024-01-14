using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential2.Library
{
    public class Sorter<T> where T: class, IComparable<T>, new()
    {
        public void Sort(T[] items) { 
            for (int i = 1; i < items.Length; i++) { 
                if (items[i].CompareTo(items[i - 1]) < 0) {
                    Swap(items, i - 1, i);
                }
            }
        }

        private void Swap<T>(T[] items, int first, int second)
        {
            T temp = items[second];
            items[second] = items[first];
            items[first] = temp;
        }
    }
}
