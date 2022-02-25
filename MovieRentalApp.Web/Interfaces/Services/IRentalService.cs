using System.Collections.Generic;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Interfaces.Services
{
    public interface IRentalService
    {
        public IEnumerable<Rental> GetRentalsByCustomerId(int customerId);
        public IEnumerable<Rental> GetCustomerRentalsByMovieType(int customerId, MovieType movieType);
    }
}