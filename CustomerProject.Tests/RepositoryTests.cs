using CustomerProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using FluentAssertions;

namespace CustomerProject.Tests
{
    [Trait("Category", "Unit")]
    public class RepositoryTests
    {
        private ICustomerRepository _repository;

        [Fact]
        public async Task AddCustomerAsync_AddsCustomerToDatabaseAsync()
        {
            // Arrange
            _repository = new CustomerRepository(GetInMemoryCustomerContext());

            var customer = new Customer
            {
                FirstName = "Test",
                LastName = "Customer",
                DateOfBirth = new DateTime(1991, 1, 2),
                Email = "testcustomer@gmail.com",
                CustCode = "testcustomer19910102"
            };

            // Act
            var result = await _repository.AddCustomerAsync(customer).ConfigureAwait(false);
            var totalCustomers = await _repository.GetAllCustomers().ConfigureAwait(false);

            // Assert
            Assert.Single(totalCustomers);
        }

        [Fact]
        public async Task GivenCustomersExistInDb_WhenGetAllCustomersCalled_ReturnsAllCustomers()
        {
            // Arrange
            var context = GetInMemoryCustomerContext();
            await context.SeedAsync();
            _repository = new CustomerRepository(context);
            var expected = TestCustomerData.GetSampleCustomerData().ToList();

            // Act
            var result = await _repository.GetAllCustomers();

            // Assert
            Assert.Equal(7, result.Count);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GivenCustomersExistInDb_WhenGetTop5OldestCustomersCalled_ReturnsCorrectResult()
        {
            // Arrange
            var context = GetInMemoryCustomerContext();
            await context.SeedAsync();
            _repository = new CustomerRepository(context);
            var expected = TestCustomerData.GetSampleCustomerData().Take(5).ToList();

            // Act
            var result = await _repository.GetTop5oldestCustomers();

            // Assert
            Assert.Equal(5, result.Count);
            result.Should().BeEquivalentTo(expected);
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
    }
}
