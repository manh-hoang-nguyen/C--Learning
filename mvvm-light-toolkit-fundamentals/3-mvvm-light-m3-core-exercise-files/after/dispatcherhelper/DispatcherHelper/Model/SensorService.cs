using System;
using System.Device.Location;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;

namespace DispatcherHelperSample.Model
{
    public class SensorService : ISensorService
    {
        private Action<double> _callback;

        public void RegisterForAcceleration(Action<double> callback)
        {
            _callback = callback;

            var accelerometer = new Accelerometer();
            accelerometer.CurrentValueChanged += AccelerometerCurrentValueChanged;
            accelerometer.Start();
        }

        void AccelerometerCurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            ExecuteCallback(e.SensorReading.Acceleration);
        }

        private void ExecuteCallback(Vector3 heading)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(
                () =>
                {
                    _callback(heading.Z);

                });

        }
    }
}