using MovieRentalApp.Web.Interfaces.Services;

namespace MovieRentalApp.Web.Modules
{
    /// <summary>
    /// This class serves as a template for all statement factory modules
    /// </summary>
    public abstract class StatementFactory
    {
        public abstract string Build(int customerId, ref double totalAmount,
            IRentalService rentalService, IMovieService movieService);
    }
}
