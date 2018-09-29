using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerProject.Data
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomerAsync(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
    }
}
