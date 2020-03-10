using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDesktop.Customers
{
    class AddEditCustomerViewModel:BindableBase
    {
        private bool _editMode;

        public bool EditMode
        {
            get { return _editMode; }
            set { _editMode = value; }
        }

        private Customer _editingCustomer = null;

        public void SetCustomer(Customer cust )
        {
            _editingCustomer = cust;
        }

    }
}
