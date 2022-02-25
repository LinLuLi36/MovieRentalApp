using System.Linq;
using MovieRentalApp.Web.Interfaces.Repositories;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        private Customer GetCustomerByCustomerId(int customerId)
        {
            return _customerRepository.GetCustomers().FirstOrDefault(m => m.CustomerId == customerId);
        }

        public string GetCustomerNameByCustomerId(int customerId)
        {
            return GetCustomerByCustomerId(customerId)?.Name;
        }
    }
}
