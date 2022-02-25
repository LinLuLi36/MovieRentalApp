using System;
using System.Linq;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Models;
using MovieRentalApp.Web.Utilities;

namespace MovieRentalApp.Web.Modules
{
    /// <summary>
    /// This module produces a statement for the children movies the customer has rented
    /// </summary>
    public class ChildrenMovieStatementFactory: StatementFactory
    {
        /// <summary>
        /// The method generates a result string that includes all the new released movies, the customer has rented
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="result"></param>
        /// <param name="totalAmount"></param>
        /// <param name="rentalService"></param>
        /// <param name="movieService"></param>
        /// <returns></returns>
        public override string Build(int customerId, ref double totalAmount, IRentalService rentalService, 
            IMovieService movieService)
        {
            double amountReplace = 0;
            var result = string.Empty;
            var customerRegularMovieRentals = rentalService
                .GetCustomerRentalsByMovieType(customerId, MovieType.Children)
                .OrderBy(r => r.MovieId).ToList();

            if (!customerRegularMovieRentals.Any())
                return result;

            customerRegularMovieRentals.ForEach(r =>
            {
                double thisAmount = 1.5 + (r.DaysRented > 3 ? (r.DaysRented - 3) * 1.5 : 0);
                result += StatementGenerator.CreateRentalStatementEachMovie(thisAmount,
                    movieService.GetMovieTitleByMovieId(r.MovieId));
                amountReplace += thisAmount;
            });

            totalAmount += amountReplace;
            return result;
        }
    }
}
