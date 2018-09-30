using Microsoft.EntityFrameworkCore;
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

        public Task<List<Customer>> GetAllCustomers()
        {
            var customers = _context.Customers.ToListAsync();
            return customers;
        }

        public Task<List<Customer>> GetTop5oldestCustomers()
        {
            var customers = _context.Customers
                                        .Where(c => c.DateOfBirth != null)
                                        .OrderBy(c => c.DateOfBirth)
                                        .Take(5)
                                        .OrderBy(c => c.LastName)
                                        .ToListAsync();
            return customers;
        }
    }
}
