using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
   
    class Program
    {
      
        static void Main(string[] args)
        {

            var worker = new Worker();
            //worker.WorkPerformerd += Worker_WorkPerformerd;
            worker.WorkPerformerd += new EventHandler<WorkPerformedEventArgs>(worker_WorkPerformed);
            //worker.WorkCompleted += new EventHandler(worker_WorkCompleted);

            worker.WorkCompleted += delegate (object sender, EventArgs e)
            {
                Console.WriteLine("Worker completed...");
            };


            //worker.WorkCompleted -= new EventHandler(worker_WorkCompleted); 

            worker.DoWork(8, WorkType.GenerateReports);
            Console.Read();

        }

        //private static void Worker_WorkPerformerd(object sender, WorkPerformedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private static void worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Worker completed...");
          
        }

        private static void worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
            
        }
    }

    public enum WorkType
    {
        GotoMeetings,
        Golf,
        GenerateReports
    }
}
