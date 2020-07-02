using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WhyMvvm.Design;
using WhyMvvm.Helpers;
using WhyMvvm.Model;

namespace WhyMvvm.ViewModel
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance
        {
            get
            {
                return Application.Current.Resources["Locator"] as ViewModelLocator;
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IFriendsService, DesignFriendsService>();
            }
            else
            {
                SimpleIoc.Default.Register<IFriendsService, FriendsService>();
            }

            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<MainViewModel>();
        }
    }
}