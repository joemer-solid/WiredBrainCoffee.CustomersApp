using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Models;

namespace WiredBrainCoffee.CustomersApp.Data
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>> GetAllAsync();
    }

    internal sealed class CustomerDataProvider : ICustomerDataProvider
    {
        async Task<IEnumerable<Customer>> ICustomerDataProvider.GetAllAsync()
        {
            await Task.Delay(100); // Simulate a bit of server work

            return new List<Customer>
             {
                new Customer{Id=1,FirstName="Linda",LastName="Darnell"},
                new Customer{Id=2,FirstName="Lisbeth",LastName="Scott"},
                new Customer{Id=3, FirstName="Victor",LastName="Mature"},
                new Customer{Id=4,FirstName="Anna",LastName="Karenina"},
                new Customer{Id=5,FirstName="Allie",LastName="Shaw",IsDeveloper=true},
                new Customer{Id=6,FirstName="Lauren",LastName="Bacall"},
                new Customer{Id=7,FirstName="Ayn", LastName="Rand",IsDeveloper=true}
             };
        }
    }
}
