using System.Collections.Generic;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        public void AddCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(Customer customer);
        public IEnumerable<Customer> GetCustomers();
    }
}