using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS2
{
    class Program
    {
        /// <summary>
        /// đọc file đồ thị
        /// </summary>
        /// <param name="path">đường dẫn tới file đọc</param>
        /// <returns></returns>
        public static int[][] Read(string path)
        {
            int size = 0;
            int[][] arr;
            try
            {
                using (var sr = new StreamReader(path))
                {
                    size = int.Parse(sr.ReadLine());
                    arr = new int[size][];
                    for (int i = 0; i < size; i++)
                    {
                        arr[i] = sr.ReadLine().Split(' ').Select((c) => int.Parse(c)).ToArray(); //convert to int[]
                    }
                    return arr;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// thực hiện thuật toán GTS tìm chu trình với cost nhỏ nhất
        /// </summary>
        /// <param name="arr">đồ thị</param>
        /// <param name="start"> đỉnh bắt đầu</param>
        /// <returns>chu trình và chi phí (cost) của chu trình </returns>
        public static Tuple<List<int>, int> SolveTSP(int[][] arr, int start)
        {
            List<int> tour = new List<int>
            {
                start
            };
            int cost = 0;
            int size = arr.Length;
            int current = start;

            while (tour.Count < size + 1)
            {
                int minCost = int.MaxValue;
                int tmp = 0;
                for (int i = 0; i < size; i++)
                {
                    if (minCost > arr[current][i] && NotIn(tour, i))
                    {
                        minCost = arr[current][i];
                        tmp = i;
                    }
                }
                cost += minCost;
                tour.Add(tmp);
                if (tour.Count == size)
                {
                    tour.Add(start);
                    cost += arr[tmp][start];
                    continue;
                }
                current = tmp;
            }
            return new Tuple<List<int>, int>(tour, cost);
        }
        /// <summary>
        /// kiểm tra đỉnh đang xét đã có trong chu trình chưa
        /// </summary>
        /// <param name="tour">list các đỉnh đã đi qua</param>
        /// <param name="ver">đỉnh đang xet</param>
        /// <returns></returns>
        public static bool NotIn(List<int> tour, int ver)
        {
            foreach (var item in tour)
            {
                if (ver == item)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// tìm chu trình với cost ít nhất trong 1 danh sách bắt đầu
        /// </summary>
        /// <returns></returns>
        public static Tuple<List<int>, int> ImplementGTS2(int[][] arr) => new List<int> { 0, 1, 3, 5 }.Select(dinh => SolveTSP(arr, dinh)).Aggregate((a, b) => a.Item2 <= b.Item2? a : b);
    static void Main(string[] args)
        {
            var arr = Read(@"D:\projects\dotnet\CoSoTriTueNhanTao\ThucHanhCSTTNT\GTS2\path.txt");
            //foreach (var sub in arr)
            //{
            //    foreach (var item in sub)
            //    {
            //        Console.Write(item + " ");
            //    }
            //    Console.WriteLine();
            //}
            //var result = SolveTSP(arr, 3);
            var result = ImplementGTS2(arr);
           
            result.Item1.ForEach(t => Console.Write(t + " "));
            Console.WriteLine();
            Console.WriteLine("======================");
            Console.WriteLine(result.Item2);
            

        }
    }
}
