using System;
using System.Linq;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Models;
using MovieRentalApp.Web.Utilities;

namespace MovieRentalApp.Web.Modules
{
    public static class MovieTypesStatementBuilder
    {
        /// <summary>
        /// The method generates a result string that includes the movies of a specific movie type the customer has rented
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="movieType"></param>
        /// <param name="totalAmount"></param>
        /// <param name="rentalService"></param>
        /// <param name="movieService"></param>
        /// <param name="calculateAmount"></param>
        /// <returns></returns>
        public static string Build(int customerId, MovieType movieType, ref double totalAmount,
            IRentalService rentalService, IMovieService movieService, Func<int, double> calculateAmount)
        {
            double amountReplace = 0;
            var result = String.Empty;

            //Get all movies of a specific movie type the customer rented
            var customerRegularMovieRentals = rentalService
                .GetCustomerRentalsByMovieType(customerId, movieType)
                .OrderBy(r => r.MovieId).ToList();

            if (!customerRegularMovieRentals.Any())
                return result;

            //Create a statement of the amount which is calculated for each movie and add it to the result string
            customerRegularMovieRentals.ForEach(r =>
            {
                double thisAmount = calculateAmount(r.DaysRented);
                result += StatementGenerator.CreateRentalStatementEachMovie(thisAmount,
                    movieService.GetMovieTitleByMovieId(r.MovieId));
                amountReplace += thisAmount;
            });

            totalAmount += amountReplace;
            return result;
        }
    }
}