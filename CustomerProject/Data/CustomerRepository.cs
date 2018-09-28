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
        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }
    }
}
