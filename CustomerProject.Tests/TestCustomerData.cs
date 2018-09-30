using CustomerProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerProject.Tests
{
    /// <summary>
    /// Customer data arranged in the order of DateOfBirth
    /// </summary>
    static class TestCustomerData
    {
        public static IEnumerable<Customer> GetSampleCustomerData()
        {
            return new List<Customer>
            {
                // Inserting Ids to make it easier to test from this sample data
                new Customer
                {
                    Id = 1,
                    FirstName = "Test1",
                    LastName = "Customer1",
                    DateOfBirth = new DateTime(1992, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19920102"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Test2",
                    LastName = "Customer2",
                    DateOfBirth = new DateTime(1993, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19930102"
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Test3",
                    LastName = "Customer3",
                    DateOfBirth = new DateTime(1994, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19940102"
                },
                new Customer
                {
                    Id = 4,
                    FirstName = "Test4",
                    LastName = "Customer4",
                    DateOfBirth = new DateTime(1995, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19950102"
                },
                new Customer
                {
                    Id = 5,
                    FirstName = "Test5",
                    LastName = "Customer5",
                    DateOfBirth = new DateTime(1996, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19960102"
                },
                new Customer
                {
                    Id = 6,
                    FirstName = "Test6",
                    LastName = "Customer6",
                    DateOfBirth = new DateTime(1997, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19970102"
                },
                 new Customer
                {
                    Id = 7,
                    FirstName = "Test7",
                    LastName = "Customer7",
                    DateOfBirth = new DateTime(1998, 1, 2),
                    Email = "testcustomer@gmail.com",
                    CustCode = "testcustomer19980102"
                }
            };
        }
    }
}
