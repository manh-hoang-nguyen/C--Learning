using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MessengerSample.Helpers;

namespace MessengerSample.ViewModel
{
    public class SenderViewModel
    {
        private RelayCommand<string> _sendCommand;
        private RelayCommand<string> _sendWithFeedbackCommand;

        public RelayCommand<string> SendCommand
        {
            get
            {
                return _sendCommand
                    ?? (_sendCommand = new RelayCommand<string>(
                        text =>
                        {
                            var message = new LogMessage(
                                text,
                                DateTime.Now);

                            Messenger.Default.Send(message);
                        }));
            }
        }

        public RelayCommand<string> SendWithFeedbackCommand
        {
            get
            {
                return _sendWithFeedbackCommand
                    ?? (_sendWithFeedbackCommand = new RelayCommand<string>(
                        text =>
                        {
                            var message = new LogMessageWithFeedback(
                                text,
                                DateTime.Now,
                                result =>
                                {
                                    var dialog = new MessageDialog(result ? "OK" : "Cancel");
                                    dialog.ShowAsync();
                                });

                            Messenger.Default.Send(message);
                        }));
            }
        }
    }
}
