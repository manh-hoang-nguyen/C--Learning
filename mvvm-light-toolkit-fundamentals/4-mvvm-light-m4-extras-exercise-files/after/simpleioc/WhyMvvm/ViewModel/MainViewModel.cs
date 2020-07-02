using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        private RelayCommand _refreshCommand;
        private RelayCommand<Friend> _saveCommand;
        private RelayCommand<Friend> _showDetailsCommand;

        public ObservableCollection<Friend> Friends
        {
            get;
            private set;
        }

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

        public RelayCommand<Friend> ShowDetailsCommand
        {
            get
            {
                return _showDetailsCommand
                       ?? (_showDetailsCommand = new RelayCommand<Friend>(
                           friend => _navigationService.NavigateTo(
                               new Uri("/DetailsPage.xaml", UriKind.Relative),
                               friend)));
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

#if DEBUG
            if (IsInDesignMode)
            {
                Refresh();
            }
#endif
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
    }
}