using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerProject.Data
{
    /* 
     - Used Repository pattern

	To isolates data access behind interface abstractions. All the code dealing with the database 
    is managed in the implementation of the interface, making other classes clean from 
    the using database related code.
	
	Using interface also allows the data repository to be mocked in the tests
   */
    public interface ICustomerRepository
    {
        Task<int> AddCustomerAsync(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetTop5oldestCustomers();
    }
}
