using CustomerProject.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Tests
{
    public class CustomerSeeder
    {
        private readonly CustomerContext _context;

        public CustomerSeeder(CustomerContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            IEnumerable<Customer> customers = new List<Customer>
            {

                new Customer
                {
                    FirstName = "Test1",
                    LastName = "Customer1",
                    DateOfBirth = new DateTime(1992, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19920102"
                },
                new Customer
                {
                    FirstName = "Test2",
                    LastName = "Customer2",
                    DateOfBirth = new DateTime(1993, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19930102"
                },
                new Customer
                {
                    FirstName = "Test3",
                    LastName = "Customer3",
                    DateOfBirth = new DateTime(1994, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19940102"
                },
                new Customer
                {
                    FirstName = "Test4",
                    LastName = "Customer4",
                    DateOfBirth = new DateTime(1995, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19950102"
                },
                new Customer
                {
                    FirstName = "Test5",
                    LastName = "Customer5",
                    DateOfBirth = new DateTime(1996, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19960102"
                },
                new Customer
                {
                    FirstName = "Test6",
                    LastName = "Customer6",
                    DateOfBirth = new DateTime(1997, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19970102"
                },
                 new Customer
                {
                    FirstName = "Test7",
                    LastName = "Customer7",
                    DateOfBirth = new DateTime(1998, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19980102"
                }
        };
            //_context.AddRange()
        }
    }
}
