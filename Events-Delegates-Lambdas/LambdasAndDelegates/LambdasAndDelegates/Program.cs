using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasAndDelegates
{
    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiDel = (x, y) => x * y;
            var data = new ProcessData();
            data.Process(2, 3, addDel);

            //using action
            Action<int, int> myAction = (x, y) => Console.WriteLine(x+y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x*y);
            data.ProcessAction(3, 3, myAction);

            //Using Func
            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiDel = (x, y) => x * y;
            data.ProcessFunc(4, 4, funcAddDel);
            data.ProcessFunc(4, 4, funcMultiDel);

            //Custom delegate
            var worker = new Worker();
            worker.WorkPerformed += (s, e) => Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType); 
            worker.WorkCompleted += (s, e) => Console.WriteLine("Work is complete!");
            worker.DoWork(3, WorkType.GenerateReports);

            Console.Read();
        }
 
    }
}
