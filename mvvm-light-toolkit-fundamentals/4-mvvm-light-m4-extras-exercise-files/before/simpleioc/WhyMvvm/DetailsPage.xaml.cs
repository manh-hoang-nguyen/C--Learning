using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Practices.ServiceLocation;
using WhyMvvm.ViewModel;

namespace WhyMvvm
{
    public partial class DetailsPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var state = Helpers.NavigationService.GetAndRemoveState(NavigationContext.QueryString);
            DataContext = state;
            base.OnNavigatedTo(e);
        }

        private async void SaveClick(object sender, EventArgs e)
        {
            UpdateBinding();

            var mainVm = ViewModelLocator.Instance.Main;
            mainVm.SaveCommand.Execute(DataContext);
        }

        private void UpdateBinding()
        {
            var textbox = FocusManager.GetFocusedElement() as TextBox;
            if (textbox != null)
            {
                var binding = textbox.GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }
    }
}