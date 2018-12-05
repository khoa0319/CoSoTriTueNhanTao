using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SapXepHoiThao
{
    class Bang
    {
        public int[][] Graph { get; set; }
        public Node[] Dinh { get; set; }

        public Bang(int[][] graph = null)
        {
            Graph = graph ?? new int[1][];
            Dinh = graph == null ? null : new Node[graph.GetLength(0)];
        }
        public void CreateGraph(string path)
        {
            int size;
            using (var sr = new StreamReader(path))
            {
                try
                {
                    size = int.Parse(sr.ReadLine());
                    Graph = new int[size][];
                    for (int i = 0; i < size; i++)
                    {
                        Graph[i] = sr.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            InitBang();
        }
        private void InitBang()
        {
            Dinh = new Node[Graph.GetLength(0)];
            for (int i = 0; i < Dinh.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < Graph.GetLength(0); j++)
                    count = Graph[i][j] == 1 ? ++count : count;

                Dinh[i] = new Node
                {
                    Bac = count,
                    Colored = false,
                };
            }
        }
        private int ChonDinhBacCaoNhat()
        {
            int dinh = -1;
            int max = -1;
            for (int i = 0; i < Dinh.Length; i++)
            {
                if (max < Dinh[i].Bac)
                {
                    max = Dinh[i].Bac;
                    dinh = i;
                }
            }
            return dinh;
        }
        /// <summary>
        /// cap nhat lai bang sau khi da to mau
        /// </summary>
        /// <param name="p">dinh to mau</param>
        /// <param name="k">mau to</param>
        private void CapNhatBang(int p, int k)
        {
            for (int i = 0; i < Graph.GetLength(0); i++)
            {
                if (Graph[p][i] == 1)
                {
                    Dinh[i].Bac--;
                    Dinh[i].MauCamTo.Add(k);
                }
            }
            Dinh[p].Bac = -1;
        }
        public void ToMau()
        {
            if (Graph == null)
            {
                Console.WriteLine("nhap vao do thi truoc");
                return;
            }
            int k; //so mau to
            int x = 0; //so dinh da dc to
            int soDinh = Graph.GetLength(0);
            while (x < soDinh)
            {
                k = 0;
                int p = ChonDinhBacCaoNhat();
                while (Dinh[p].MauCamTo.Contains(k)) k++;
                Dinh[p].MauTo = k;
                Console.WriteLine($"To mau {k} cho dinh {p}");
                Dinh[p].Colored = true;
                CapNhatBang(p, k);
                x++;
            }
        }
    }
}
