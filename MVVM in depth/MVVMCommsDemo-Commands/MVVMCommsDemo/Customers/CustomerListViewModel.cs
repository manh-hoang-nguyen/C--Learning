using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMCommsDemo.Services;
using Zza.Data;

namespace MVVMCommsDemo.Customers
{
    public class CustomerListViewModel
    {
        private ObservableCollection<Customer> _customers;
        private ICustomersRepository _repository = new CustomersRepository();
        private Customer _selectedCustomer;

        public RelayCommand DeleteCommand { get; private set; }

        public Customer SelectedCustomer { get => _selectedCustomer; set { _selectedCustomer = value; DeleteCommand.RaiseCanExecuteChanged(); } }
        public CustomerListViewModel()
        {
           
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
          
        }

        private bool CanDelete()
        {
            return SelectedCustomer !=null;
        }

        private void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
            }
        }
        public async void LoadCustomers()
        {
            if (DesignerProperties.GetIsInDesignMode(
               new System.Windows.DependencyObject())) return;
            Customers = new ObservableCollection<Customer>( await _repository.GetCustomersAsync());
        }
    }
}
