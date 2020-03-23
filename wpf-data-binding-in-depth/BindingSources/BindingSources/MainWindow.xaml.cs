using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zza.Data;

namespace BindingSources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (ZzaDbContext context = new ZzaDbContext())
            {
                Customers = new ObservableCollection<Customer>(context.Customers);
            }

           DeleteCustomerCommand = new RelayCommand<Customer>(OnDeleteCustomer);
            DeleteSelectedCommand = new RelayCommand<Customer>(OnDeleteCustomer, CanDeleteCustomer);
            //DataContext = this;
        }

        private bool CanDeleteCustomer(Customer arg)
        {
            return customerDataGrid.SelectedItem != null;
        }

        private void OnDeleteCustomer(Customer customer)
        {
            Customers.Remove(customer);
        }

        public ObservableCollection<Customer> Customers
        {
            get { return (ObservableCollection<Customer>)GetValue(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }

        public static readonly DependencyProperty CustomersProperty =
            DependencyProperty.Register("Customers",
            typeof(ObservableCollection<Customer>),
            typeof(MainWindow),
            new PropertyMetadata(null));

        private void customerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DeleteSelectedCommand.RaiseCanExecuteChanged();
        }



        public RelayCommand<Customer> DeleteCustomerCommand
        {
            get { return (RelayCommand<Customer>)GetValue(DeleteCustomerCommandProperty); }
            set { SetValue(DeleteCustomerCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteCustomerCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteCustomerCommandProperty =
            DependencyProperty.Register("DeleteCustomerCommand", typeof(RelayCommand<Customer>), typeof(MainWindow), new PropertyMetadata(null));



        public RelayCommand<Customer> DeleteSelectedCommand
            {
            get { return (RelayCommand<Customer>)GetValue(DeleteSelectedCommandProperty); }
            set { SetValue(DeleteSelectedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteSelectedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteSelectedCommandProperty =
            DependencyProperty.Register("DeleteSelectedCommand", typeof(RelayCommand<Customer>), typeof(MainWindow), new PropertyMetadata(null));

       




    }
}
