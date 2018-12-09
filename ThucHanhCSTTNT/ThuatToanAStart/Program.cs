using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuatToanAStar
{
    class Program
    {
        public static List<Node> ReadGraph(string path = null)
        {
            int size = 0;
            var graph = new List<Node>();
            using (var sr = new StreamReader(path))
            {
                size = int.Parse(sr.ReadLine());
                string[] lines = new string[size];
                for (int i = 0; i < lines.Length; i++)
                {
                    graph.Add(new Node() { Index = i });
                    lines[i] = sr.ReadLine();
                    var lst = lines[i].Split(' ').Select(item => int.Parse(item)).ToList();
                    graph[i].H = lst[0];
                    for (int j = 1; j < lst.Count; j += 2)
                    {
                        graph[i].LstNode.Add(new Tuple<int, int>(lst[j], lst[j + 1]));
                    }
                }
                //try
                //{

                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.Message);
                //}
            }
            return graph;
        }
        public static void ImplementAStar()
        {
            var open = new List<Node>();
            var close = new List<Node>();
            var graph = ReadGraph(@"D:\projects\dotnet\CoSoTriTueNhanTao\ThucHanhCSTTNT\ThuatToanAStart\file.txt");
            int input = 0;
            int output = 1;
            var start = graph[input];
            start.G = 0;
            var end = graph[output];
            open.Add(start);
            while (open.Count > 0) // bắt đầu tìm
            {
                var current = open.First();
                open.RemoveAt(0);
                close.Add(current);
                if (current == end) // chinh lai cho bang trang thai cuoi                
                    break;
                foreach (var item in current.LstNode) //current 
                {
                    Node adj = null;
                    foreach (var node in graph)
                    {
                        if (node.Index == item.Item1)
                        {
                            adj = node;
                        }
                    }
                    if (open.Contains(adj))
                    {
                        if (adj.G > current.G + item.Item2)
                        {
                            adj.G = current.G + item.Item2;
                            adj.F = adj.G + adj.H;
                            adj.Parent = current;
                        }
                    }
                    else if (close.Contains(adj))
                    {
                        if (adj.G > current.G + item.Item2)
                        {
                            adj.G = current.G + item.Item2;
                            adj.F = adj.G + adj.H;
                            adj.Parent = current;
                            open.Add(adj);
                            close.Remove(adj);
                        }
                    }
                    else
                    {
                        adj.G = current.G + item.Item2;
                        adj.F = adj.G + adj.H;
                        adj.Parent = current;
                        open.Add(adj);
                    }

                }
                open.Sort((a, b) => a.F.CompareTo(b.F));
            }
            Console.WriteLine(end.Index);
            while (end.Parent != null)
            {
                Console.WriteLine(end.Parent.Index);
                end = end.Parent;
            }
            Console.WriteLine();
        }
        public static void ImplementAKT()
        {
            var open = new List<Node>();
            var graph = ReadGraph(@"D:\projects\dotnet\CoSoTriTueNhanTao\ThucHanhCSTTNT\ThuatToanAStart\file.txt");
            int input = 0;
            int output = 1;
            var start = graph[input];
            start.G = 0;
            var end = graph[output];
            open.Add(start);
            while (open.Count > 0) // bắt đầu tìm
            {
                var current = open.First();
                open.RemoveAt(0);
                if (current == end) // chinh lai cho bang trang thai cuoi                
                    break;
                foreach (var item in current.LstNode) //current 
                {
                    Node adj = null;
                    foreach (var node in graph)
                    {
                        if (node.Index == item.Item1)
                        {
                            adj = node;
                        }
                    }
                    adj.G = current.G + item.Item2;
                    adj.F = adj.G + adj.H;
                    adj.Parent = current;
                    open.Add(adj);

                }
                open.Sort((a, b) => a.F.CompareTo(b.F));
            }
            Console.WriteLine(end.Index);
            while (end.Parent != null)
            {
                Console.WriteLine(end.Parent.Index);
                end = end.Parent;
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //ImplementAStar();
            ImplementAKT();
        }
    }
}
