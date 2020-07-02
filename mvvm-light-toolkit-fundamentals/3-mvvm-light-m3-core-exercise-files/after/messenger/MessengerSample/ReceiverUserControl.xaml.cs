using System.Diagnostics;
using GalaSoft.MvvmLight.Messaging;
using MessengerSample.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MessengerSample.ViewModel;

namespace MessengerSample
{
    public sealed partial class ReceiverUserControl
    {
        public ReceiverUserControl()
        {
            InitializeComponent();
            Unloaded += ReceiverUserControlUnloaded;
        }

        void ReceiverUserControlUnloaded(object sender, RoutedEventArgs e)
        {
            ((ReceiverViewModel)DataContext).Unload();
        }
    }
}
