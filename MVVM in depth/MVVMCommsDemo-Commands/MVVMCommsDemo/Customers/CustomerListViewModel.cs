namespace MVVMCommsDemo.Customers
{
    using MVVMCommsDemo.Services;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Zza.Data;

    public class CustomerListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Customer> _customers;

        private ICustomersRepository _repository = new CustomersRepository();

        private Customer _selectedCustomer;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public RelayCommand DeleteCommand { get; private set; }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            { 
                _selectedCustomer = value;
                DeleteCommand.RaiseCanExecuteChanged();
                PropertyChanged(null, new PropertyChangedEventArgs("SelectedCustomer"));
            }
        }

        public CustomerListViewModel()
        {

            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }

        /// <summary>
        /// The CanDelete
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }

        /// <summary>
        /// The OnDelete
        /// </summary>
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
                PropertyChanged(null, new PropertyChangedEventArgs("Customers"));
            }
        }

        /// <summary>
        /// The LoadCustomers
        /// </summary>
        public async void LoadCustomers()
        {
            if (DesignerProperties.GetIsInDesignMode(
               new System.Windows.DependencyObject())) return;
            Customers = new ObservableCollection<Customer>(await _repository.GetCustomersAsync());
        }
    }
}
