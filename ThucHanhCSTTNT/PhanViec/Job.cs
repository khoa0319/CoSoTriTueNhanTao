
namespace PhanViec
{
    class Job
    {
        public int Name { get; set; }
        public int Time { get; set; }

        public Job(int name, int time)
        {
            this.Name = name;
            this.Time = time;
        }
    }
}
