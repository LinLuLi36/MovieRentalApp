using System.Collections.Generic;
using System.Linq;
using MovieRentalApp.Web.Interfaces.Repositories;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Services
{
    public class RentalService: IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMovieService _movieService;

        public RentalService(IRentalRepository rentalRepository, IMovieService movieService)
        {
            _rentalRepository = rentalRepository;
            _movieService = movieService;
        }

        /// <summary>
        /// This method returns all rentals the customer have 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public IEnumerable<Rental> GetRentalsByCustomerId(int customerId)
        {
            return _rentalRepository.GetRentals().Where(r => r.CustomerId == customerId);
        }

        /// <summary>
        /// This method returns all the movies of a specific type the customer rented 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="movieType"></param>
        /// <returns></returns>
        public IEnumerable<Rental> GetCustomerRentalsByMovieType(int customerId, MovieType movieType)
        {
            return GetRentalsByCustomerId(customerId)
                .Where(r => _movieService.GetMovieTypeByMovieId(r.MovieId) == movieType);
        }
    }
}