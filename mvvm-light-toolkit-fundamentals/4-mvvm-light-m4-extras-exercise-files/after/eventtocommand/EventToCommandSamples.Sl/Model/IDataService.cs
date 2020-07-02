using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventToCommandSamples.Sl.Model
{
    public interface IDataService
    {
        void GetData(Action<IList<DataItem>> callback);
    }
}
