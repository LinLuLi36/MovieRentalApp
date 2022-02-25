using System.Collections.Generic;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Interfaces.Repositories
{
    public interface IRentalRepository
    {
        public void AddRental(Rental rental);
        public void UpdateRental(Rental rental);
        public void DeleteRental(Rental rental);
        public void DeleteRentals(IEnumerable<Rental> rentals);
        public IEnumerable<Rental> GetRentals();
    }
}