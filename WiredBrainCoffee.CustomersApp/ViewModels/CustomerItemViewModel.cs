using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Models;

namespace WiredBrainCoffee.CustomersApp.ViewModels
{
    public sealed class CustomerItemViewModel : ViewModelBase
    {
        private readonly Customer _customerModel;

        public CustomerItemViewModel(Customer customerModel)
        {
           _customerModel = customerModel ?? throw new ArgumentNullException(nameof(customerModel));
        }

        public int Id => _customerModel.Id;        

        public string? FirstName
        {
            get => _customerModel.FirstName;
            set
            {
                _customerModel.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string? LastName
        {
            get => _customerModel.LastName;
            set
            {
                _customerModel.LastName = value;
                OnPropertyChanged();
            }
        }

        public bool IsDeveloper 
        {
            get => _customerModel.IsDeveloper;
            set
            {
                _customerModel.IsDeveloper = value;
                OnPropertyChanged();
            }
        }

        public string FullName
        {
            get => string.Join(" ", new[] { FirstName, LastName });           
        }

    }
}
