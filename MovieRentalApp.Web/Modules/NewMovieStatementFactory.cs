using System;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Modules
{
    /// <summary>
    /// This module produces a statement for the new released movies the customer has rented
    /// </summary>
    public class NewMovieStatementFactory: StatementFactory
    {
        /// <summary>
        /// The method generates a result string that includes all the new released movies the customer has rented
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="totalAmount"></param>
        /// <param name="rentalService"></param>
        /// <param name="movieService"></param>
        /// <returns></returns>
        public override string BuildStatement(int customerId, ref double totalAmount,
            IRentalService rentalService, IMovieService movieService)
        {
            // How the amount of MovieType = children is calculated
            var calculateAmount = new Func<int, double>(daysRented => daysRented * 3);

            return MovieTypesStatementBuilder.Build(customerId, MovieType.NewRelease, ref totalAmount,
                rentalService, movieService, calculateAmount);
        }
    }
}
