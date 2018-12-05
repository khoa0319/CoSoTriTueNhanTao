using System;
using System.Collections.Generic;

namespace PhanViec
{
    class Machine
    {
        public int Name { get; set; }
        public int TotalTime { get; set; }

        public List<Job> JobList { get; set; }

        public Machine(int name)
        {
            this.Name = name;
            this.TotalTime = 0;
            JobList = new List<Job>();
        }
        /// <summary>
        /// Thêm công việc vào máy
        /// </summary>
        /// <param name="job">Công việc</param>
        public void AddJob(Job job)
        {
            JobList.Add(job);
            TotalTime += job.Time;
        }

        public void PrintJob()
        {
            Console.WriteLine("Machine: " + Name);
            foreach (var job in JobList)
            {
                Console.WriteLine("job: " + job.Name + " time: " + job.Time);
            }
        }
    }
}
