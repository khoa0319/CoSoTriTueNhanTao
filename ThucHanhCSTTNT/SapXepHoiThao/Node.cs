using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapXepHoiThao
{
    class Node
    {
        public int Bac { get; set; }
        public bool Colored { get; set; }
        public List<int> MauCamTo { get; set; }
        public int MauTo { get; set; }

        public Node()
        {
            Bac = -1;
            Colored = false;
            MauCamTo = new List<int>();
            MauTo = -1;
        }
    }
}
