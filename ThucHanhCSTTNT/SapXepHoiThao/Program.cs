using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapXepHoiThao
{
    class Program
    {
        static void Main(string[] args)
        {
            Bang bang = new Bang();
            bang.CreateGraph(@"D:\projects\dotnet\CoSoTriTueNhanTao\ThucHanhCSTTNT\SapXepHoiThao\path.txt");
            bang.ToMau();
        }
    }
}
