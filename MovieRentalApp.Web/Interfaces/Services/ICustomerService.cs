using System.Collections.Generic;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Interfaces.Services
{
    public interface ICustomerService
    {
        public string GetCustomerNameByCustomerId(int customerId);
    }
}