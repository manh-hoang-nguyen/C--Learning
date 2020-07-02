using System;
using System.Linq;
using System.Windows;
using WhyMvvm.Model;
using WhyMvvm.ViewModel;

namespace WhyMvvm
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void RefreshClick(object sender, System.EventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            vm.RefreshCommand.Execute(null);
        }

    }
}