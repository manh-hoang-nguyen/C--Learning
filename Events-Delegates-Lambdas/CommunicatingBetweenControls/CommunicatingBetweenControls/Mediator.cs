using CommunicatingBetweenControls.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicatingBetweenControls
{
    public sealed class Mediator
    {
        //static members
        private static readonly Mediator _instance = new Mediator();
        private Mediator() {}

        public static Mediator GetInstance() => _instance;

        //Instance functionality
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            (JobChanged as EventHandler<JobChangedEventArgs>)?.Invoke(sender, new JobChangedEventArgs { Job = job });

             
        }
    }
}
