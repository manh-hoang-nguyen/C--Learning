﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WhyMvvm.Helpers;
using WhyMvvm.Model;

namespace WhyMvvm.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IFriendsService _dataService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<Friend> Friends
        {
            get;
            private set;
        }

        private Friend _selectedFriend;

        public Friend SelectedFriend
        {
            get
            {
                return _selectedFriend;
            }

            set
            {
                Set(() => SelectedFriend, ref _selectedFriend, value);
            }
        }

        private RelayCommand _refreshCommand;

        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand
                    ?? (_refreshCommand = new RelayCommand(
                                          async () =>
                                          {
                                              await Refresh();
                                          }));
            }
        }

        private async Task Refresh()
        {
            Friends.Clear();

            var friends = await _dataService.Refresh();

            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
        }

        private RelayCommand<Friend> _saveCommand;

        public RelayCommand<Friend> SaveCommand
        {
            get
            {
                return _saveCommand
                    ?? (_saveCommand = new RelayCommand<Friend>(
                                          async friend =>
                                          {
                                              try
                                              {
                                                  var service = _dataService;
                                                  var result = await service.Save(friend);

                                                  var id = int.Parse(result);

                                                  if (id > 0)
                                                  {
                                                      friend.Id = id;
                                                  }
                                                  else
                                                  {
                                                      _dialogService.ShowMessage("Error");
                                                  }
                                              }
                                              catch (Exception ex)
                                              {
                                                  _dialogService.ShowMessage(ex.Message);
                                              }
                                          }));
            }
        }

        private RelayCommand<Friend> _showDetailsCommand;

        public RelayCommand<Friend> ShowDetailsCommand
        {
            get
            {
                return _showDetailsCommand
                    ?? (_showDetailsCommand = new RelayCommand<Friend>(
                                          friend =>
                                          {
                                              SelectedFriend = friend;
                                              _navigationService.NavigateTo(
                                                  new Uri("/DetailsPage.xaml", UriKind.Relative));
                                          }));
            }
        }

        public MainViewModel(
            IFriendsService dataService,
            IDialogService dialogService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _navigationService = navigationService;
            Friends = new ObservableCollection<Friend>();
        }

        public MainViewModel()
            : this(
                (DesignerProperties.IsInDesignTool 
                    ? (IFriendsService)new Design.DesignFriendsService() 
                    : new FriendsService()), 
                new DialogService(), 
                new NavigationService())
        {
#if DEBUG
            if (DesignerProperties.IsInDesignTool)
            {
                Refresh();
                SelectedFriend = Friends[0];
            }
#endif
        }
    }
}
