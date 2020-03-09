using MVVMHookupDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace MVVMHookupDemo.Customers
{
   public class CustomerListViewModel
    {
        private ICustomersRepository _repository = new CustomersRepository();
        public ObservableCollection<Customer> Customers { get; set; }
        public CustomerListViewModel()
        {
            //Guard Make sure code doesn't execute in the designer.
            //It can break the design surface where this VM is used in view's XAML
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) return;
             
            Customers =  new ObservableCollection<Customer>( _repository.GetCustomersAsync().Result);
        }
    }
}
