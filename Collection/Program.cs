// [Скоморохов Максим]

// Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
// 1) для целых чисел;
// 2) *для обобщенной коллекции;
// 3) **используя Linq.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> data = new List<int>() { 1, 2, 3, 4, 5, 6, 1, 6, 7, 5, 3, 1, 5, 1 };
            foreach (int elem in data)
                Console.Write(elem + ", ");
            Console.WriteLine(); Console.WriteLine();

            Dictionary<int, int> stat = GetStat(data);

            foreach (KeyValuePair<int, int> pair in stat)
                Console.WriteLine($"{pair.Key} - {pair.Value}");

            Console.ReadKey();
        }

        //---------------------------------------------------------------------
        private static Dictionary<T, int> GetStat<T>(ICollection<T> list)
        {
            // Для подсчета элементов используйте словарь 
            Dictionary<T, int> found = new Dictionary<T, int>();

            foreach (T item in list)
            {
               if (!found.ContainsKey(item))
                    found.Add(item, 1);
               else
                    found[item]++;
            }
            return found;

        }
    }
}
