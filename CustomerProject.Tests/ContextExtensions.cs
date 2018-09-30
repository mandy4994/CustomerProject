using CustomerProject.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Tests
{
    public static class ContextExtensions
    {
        public static async Task SeedAsync(this CustomerContext context)
        {
            IEnumerable<Customer> customers = TestCustomerData.GetSampleCustomerData();
            context.Customers.AddRange(customers);
            await context.SaveChangesAsync();
        }
    }
}
