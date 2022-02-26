using System;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.Modules
{
    /// <summary>
    /// This module produces a statement for the children movies the customer has rented
    /// </summary>
    public class ChildrenMovieStatementFactory: StatementFactory
    {
        /// <summary>
        /// The method generates a result string that includes all the children movies, the customer has rented
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="totalAmount"></param>
        /// <param name="rentalService"></param>
        /// <param name="movieService"></param>
        /// <returns></returns>
        public override string BuildStatement(int customerId, ref double totalAmount, IRentalService rentalService,
            IMovieService movieService)
        {
            // How the amount of MovieType = new release is calculated
            var calculateAmount =
                new Func<int, double>(daysRented => 1.5 + (daysRented > 3 ? (daysRented - 3) * 1.5 : 0));
              
            return MovieTypesStatementBuilder.Build(customerId, MovieType.Children, ref totalAmount,
                    rentalService, movieService, calculateAmount);
        }
    }
}
