using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using EventToCommandSamples.Sl.ViewModel;

namespace EventToCommandSamples.Sl
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void ItemMouseLeftButtonDown(
            object sender, MouseButtonEventArgs e)
        {
            var element = (FrameworkElement)e.OriginalSource;
            var item = (DataItemViewModel)element.DataContext;

            MessageBox.Show(item.Model.Title);
        }
    }
}
