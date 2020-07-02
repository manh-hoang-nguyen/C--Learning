using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using EventToCommandSamples.Sl.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace EventToCommandSamples.Sl.ViewModel
{
    public class DataItemViewModel : ViewModelBase
    {
        public DataItem Model
        {
            get;
            private set;
        }

        private RelayCommand _showItemCommand;

        /// <summary>
        /// Gets the ShowItemCommand.
        /// </summary>
        public RelayCommand ShowItemCommand
        {
            get
            {
                return _showItemCommand
                    ?? (_showItemCommand = new RelayCommand(
                                          () =>
                                          {
                                              MessageBox.Show(Model.Title);
                                          }));
            }
        }

        public DataItemViewModel(DataItem model)
        {
            Model = model;
        }
    }
}
