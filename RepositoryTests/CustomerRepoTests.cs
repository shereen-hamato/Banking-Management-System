using Entity;
using Repository;
using RepositoryTests.Mocks;
using Xunit;

namespace RepositoryTests
{
    public class CustomerRepoTests
    {
        [Fact]
        public void InsertCustomer_ReturnsTrue_ForValidInput()
        {
            var db = new InMemoryDbConnection();
            var repo = new CustomerRepo(db);
            var cust = new Customer { CustId = "C1", Name = "Alice", PhnNumber = "0123" };

            var result = repo.InsertCustomer(cust);

            Assert.True(result);
        }

        [Fact]
        public void GetCustomer_ReturnsInsertedRecord()
        {
            var db = new InMemoryDbConnection();
            var repo = new CustomerRepo(db);
            var cust = new Customer { CustId = "C2", Name = "Bob", PhnNumber = "9876" };
            repo.InsertCustomer(cust);

            var loaded = repo.GetCustomer("C2");

            Assert.NotNull(loaded);
            Assert.Equal("Bob", loaded.Name);
            Assert.Equal("9876", loaded.PhnNumber);
        }
    }
}
