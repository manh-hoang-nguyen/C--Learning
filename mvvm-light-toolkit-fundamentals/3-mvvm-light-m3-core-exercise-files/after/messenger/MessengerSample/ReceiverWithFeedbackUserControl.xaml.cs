using Windows.UI.Xaml;
using MessengerSample.ViewModel;

namespace MessengerSample
{
    public sealed partial class ReceiverWithFeedbackUserControl
    {
        public ReceiverWithFeedbackUserControl()
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
