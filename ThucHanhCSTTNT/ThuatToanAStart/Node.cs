using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuatToanAStar
{
    public class Node
    {
        public int Index { get; set; }
        public int G { get; set; }
        public int F { get; set; }
        public int H { get; set; }
        public Node Parent { get; set; }
        public List<Tuple<int, int>> LstNode { get; set; }
        public Node(int h=0, Node parent=null)
        {
            LstNode = new List<Tuple<int, int>>();
            G = 0;
            H = h;
            F = H + G;
            Parent = parent;
        }

        
    }
}
