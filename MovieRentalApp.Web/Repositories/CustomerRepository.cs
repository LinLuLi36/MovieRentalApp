using System.Collections.Generic;
using MovieRentalApp.Web.DAL;
using MovieRentalApp.Web.Interfaces.Repositories;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly VideoShopContext _entities;

        public CustomerRepository(VideoShopContext entities)
        {
            _entities = entities;
        }

        public void AddCustomer(Customer customer)
        {
            _entities.Customers.Add(customer);
            _entities.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _entities.Customers.Update(customer);
            _entities.SaveChanges();
        }

        public void DeleteCustomer (Customer customer)
        {
            _entities.Remove(customer);
            _entities.SaveChanges();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _entities.Customers;
        }
    }
}
