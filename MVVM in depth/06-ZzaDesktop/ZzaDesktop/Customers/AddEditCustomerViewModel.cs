namespace ZzaDesktop.Customers
{
    using System;
    using System.ComponentModel;
    using Zza.Data;

    internal class AddEditCustomerViewModel : BindableBase
    {
        public bool EditMode { get; set; }

        private SimpleEditableCustomer _customer;

        public SimpleEditableCustomer Customer
        {
            get => _customer; set { SetProperty(ref _customer, value); }
        }

        private Customer _editingCustomer = null;

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        public AddEditCustomerViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        private bool CanSave()
        {
            return !Customer.HasErrors;
        }

        private void OnSave()
        {
            Done();
        }

        private void OnCancel()
        {
            Done();
        }

        public void SetCustomer(Customer cust)
        {
            _editingCustomer = cust;
            if (Customer != null) Customer.ErrorsChanged -= RaiseCanExecuteChanged;
            Customer = new SimpleEditableCustomer();
            Customer.ErrorsChanged += RaiseCanExecuteChanged;
            CopyCustomer(cust, Customer);
        }

        private void RaiseCanExecuteChanged(object sender, DataErrorsChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyCustomer(Customer source, SimpleEditableCustomer target)
        {
            target.Id = source.Id;
            if (EditMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Phone = source.Phone;
                target.Email = source.Email;
            }
        }
    }
}
