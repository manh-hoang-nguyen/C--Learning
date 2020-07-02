﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace NugetIntro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadJsonClick(object sender, RoutedEventArgs e)
        {
            var client = new WebClient();

            client.DownloadStringCompleted += ClientDownloadStringCompleted;
            client.DownloadStringAsync(new Uri("http://www.galasoft.ch/labs/pluralsight/nugetintro/jsonsample.txt"));
        }

        private void ClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null
                && !string.IsNullOrEmpty(e.Result))
            {
                try
                {
                    var myInstance = JsonConvert.DeserializeObject<MyClass>(e.Result);

                    MessageBox.Show(string.Format("String value: {0}", myInstance.Property1));
                    MessageBox.Show(string.Format("Int value: {0}", myInstance.Property2));
                }
                catch
                {
                    
                }
            }
        }
    }

    public class MyClass
    {
        public string Property1
        {
            get;
            set;
        }

        public int Property2
        {
            get;
            set;
        }
    }
}
