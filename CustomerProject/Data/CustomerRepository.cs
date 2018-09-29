using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerProject.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }
        public async Task<int> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

    }
}
