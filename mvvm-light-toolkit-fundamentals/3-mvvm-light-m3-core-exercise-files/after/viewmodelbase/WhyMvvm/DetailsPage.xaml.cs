using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WhyMvvm.ViewModel;

namespace WhyMvvm
{
    public partial class DetailsPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        private async void SaveClick(object sender, System.EventArgs e)
        {
            UpdateBinding();

            var vm = (MainViewModel)DataContext;
            vm.SaveCommand.Execute(vm.SelectedFriend);
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