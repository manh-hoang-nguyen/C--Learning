using System;
using WhyMvvm.ViewModel;

namespace WhyMvvm
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void RefreshClick(object sender, EventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            vm.RefreshCommand.Execute(null);
        }
    }
}