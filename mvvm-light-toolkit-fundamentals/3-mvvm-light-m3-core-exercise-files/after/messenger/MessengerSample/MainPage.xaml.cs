using Windows.UI.Xaml;
using MessengerSample.ViewModel;

namespace MessengerSample
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddReceiverClick(object sender, RoutedEventArgs e)
        {
            ReceiversPanel.Children.Add(new ReceiverUserControl
            {
                DataContext = new ReceiverViewModel(false)
            });
        }

        private void RemoveReceiverClick(object sender, RoutedEventArgs e)
        {
            ReceiversPanel.Children.RemoveAt(ReceiversPanel.Children.Count - 1);
        }

        private void AddReceiverWithFeedbackClick(object sender, RoutedEventArgs e)
        {
            ReceiversPanel.Children.Add(new ReceiverWithFeedbackUserControl
            {
                DataContext = new ReceiverViewModel(true)
            });
        }
    }
}
