using CustomerProject.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerProject.Tests
{
    [Trait("Category", "Unit")]
    public class RepositoryTests
    {
        private ICustomerRepository _repository;

        public RepositoryTests()
        {            
        }
        [Fact]
        public async Task AddCustomerAsync_AddsCustomerToDatabaseAsync()
        {
            _repository = new CustomerRepository(GetInMemoryCustomerContext());

            var customer = new Customer
            {
                FirstName = "Test",
                LastName = "Customer",
                DateOfBirth = new DateTime(1991, 1, 2),
                Email = "testcustomer@gmail.com",
                CustCode = "testcustomer19910102"
            };

            var result = await _repository.AddCustomerAsync(customer).ConfigureAwait(false);
            var totalCustomers = await _repository.GetAllCustomers().ConfigureAwait(false);

            Assert.Single(totalCustomers);
        }

        private CustomerContext GetInMemoryCustomerContext()
        {
            DbContextOptions<CustomerContext> options;
            var builder = new DbContextOptionsBuilder<CustomerContext>();
            InMemoryDbContextOptionsExtensions.UseInMemoryDatabase(builder, "InMemoryCustomerDb");
            options = builder.Options;
            CustomerContext customerDataContext = new CustomerContext(options);
            customerDataContext.Database.EnsureDeleted();
            customerDataContext.Database.EnsureCreated();
            return customerDataContext;
        }

        private void SeedDatabase(CustomerContext context)
        {
            //context.AddRange()
        }
    }
}
