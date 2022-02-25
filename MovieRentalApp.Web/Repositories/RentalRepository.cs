using System.Collections.Generic;
using MovieRentalApp.Web.DAL;
using MovieRentalApp.Web.Interfaces.Repositories;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly VideoShopContext _entities;

        public RentalRepository(VideoShopContext entities)
        {
            _entities = entities;
        }

        public void AddRental(Rental rental)
        {
            _entities.Rentals.Add(rental);
            _entities.SaveChanges();
        }

        public void UpdateRental(Rental rental)
        {
            _entities.Rentals.Update(rental);
            _entities.SaveChanges();
        }

        public void DeleteRental(Rental rental)
        {
            _entities.Remove(rental);
            _entities.SaveChanges();
        }

        public void DeleteRentals(IEnumerable<Rental> rentals)
        {
            _entities.RemoveRange(rentals);
            _entities.SaveChanges();
        }

        public IEnumerable<Rental> GetRentals()
        {
            return _entities.Rentals;
        }
    }
}
