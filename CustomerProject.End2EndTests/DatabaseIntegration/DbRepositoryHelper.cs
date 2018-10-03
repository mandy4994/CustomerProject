using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CustomerProject.End2EndTests
{
    public class DbRepositoryHelper
    {
        private readonly IDatabase _database;

        public DbRepositoryHelper(IDatabase database)
        {
            _database = database;
        }

        internal static DbRepositoryHelper Create()
        {
            var database = new Database("Test");
            return new DbRepositoryHelper(database);
        }

        public int DeleteCustomer(string custCode)
        {
            var numberOfDeletions = _database.Delete<CustomerEntity>($"where CustCode = '{custCode}'");
            return numberOfDeletions;
        }
    }
}
