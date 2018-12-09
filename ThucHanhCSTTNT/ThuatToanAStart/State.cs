using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuatToanAStar
{
    public class State<T>
    {
        public List<Node> Open { get; set; }
        public List<Node> Close { get; set; }
        public List<List<Tuple<int, T>>> Graph { get; set; }
    }
}
