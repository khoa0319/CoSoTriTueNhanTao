using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanViec
{
    class Program
    {
        static void Main(string[] args)
        {
            var jobLst = new List<Job>
            {
                new Job(2, 8),
                new Job(1, 5),
                new Job(1, 5),
                new Job(0, 2),
                new Job(3, 1),
                new Job(5, 1)
            };
            var machineLst = new List<Machine>
            {
                new Machine(0),
                new Machine(1),
                new Machine(2)
            };

            jobLst.OrderByDescending(job => job.Time).ToList()
                  .ForEach(job => machineLst.Aggregate((mca, mcb) => mca.TotalTime <= mcb.TotalTime ? mca : mcb).AddJob(job));

            //print machine and jobs
            foreach (var item in machineLst)
            {
                item.PrintJob();
                Console.WriteLine("======================");
            }

        }
        static void GetShitDone(List<Machine> mlst, List<Job> jlst)
        {
            foreach (Job job in jlst)
            {
                Machine tmp = mlst.Aggregate((a, b) => a.TotalTime <= b.TotalTime ? a : b);
                tmp.AddJob(job);
            }
        }

    }
}
