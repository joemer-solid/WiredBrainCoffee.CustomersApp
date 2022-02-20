using System.Collections.ObjectModel;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WiredBrainCoffee.CustomersApp.ViewModels
{
    internal sealed class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider
                ?? throw new ArgumentNullException(nameof(customerDataProvider));
        }

        /// <summary>
        /// ObservableCollection<T> raises a collectionchanged event when customers are added or removed to the collection
        /// </summary>
        public ObservableCollection<CustomerItemViewModel>? Customers { get; } = new();

      
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            } 
        }

        public async Task LoadAsync()
        {
            if (Customers != null && Customers.Any()) { return; }

            IEnumerable<Customer>? customersDto = await _customerDataProvider.GetAllAsync();

            customersDto?
                .ToList()
                .ForEach(customerDto =>
                {
                    Customers?.Add(new CustomerItemViewModel(customerDto));
                  
                });
        }

        internal void Add()
        {
            var newCustomerItem = new CustomerItemViewModel(new Customer { FirstName = "New" });

            Customers?.Add(newCustomerItem);

            SelectedCustomer = newCustomerItem;
        }

      
    }
}
