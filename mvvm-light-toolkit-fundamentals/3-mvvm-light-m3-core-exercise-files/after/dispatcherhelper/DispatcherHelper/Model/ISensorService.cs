using System;
using System.Device.Location;

namespace DispatcherHelperSample.Model
{
    public interface ISensorService
    {
        void RegisterForAcceleration(Action<double> callback);
    }
}
