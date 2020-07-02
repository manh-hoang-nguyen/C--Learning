using System.Device.Location;
using DispatcherHelperSample.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DispatcherHelperSample.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly ISensorService _sensorService;

        private RelayCommand _startAccelerometerCommand;

        /// <summary>
        /// Gets the StartAccelerometerCommand.
        /// </summary>
        public RelayCommand StartAccelerometerCommand
        {
            get
            {
                return _startAccelerometerCommand
                    ?? (_startAccelerometerCommand = new RelayCommand(
                                          () => _sensorService.RegisterForAcceleration(HandleHeading)));
            }
        }
        
        /// <summary>
        /// The <see cref="StatusMessage" /> property's name.
        /// </summary>
        public const string StatusMessagePropertyName = "StatusMessage";

        private string _statusMessage = "Initializing";

        /// <summary>
        /// Sets and gets the StatusMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                Set(StatusMessagePropertyName, ref _statusMessage, value);
            }
        }

        public MainViewModel(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        private void HandleHeading(double heading)
        {
            StatusMessage = string.Format(
                "({0:N2})",
                heading);
        }
    }
}