using System.Linq;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Modules;
using MovieRentalApp.Web.Utilities;

namespace MovieRentalApp.Web.Services
{
    public class CustomerStatementService: ICustomerStatementService
    {
        private readonly ICustomerService _customerService;
        private readonly IRentalService _rentalService;
        private readonly IMovieService _movieService;

        public CustomerStatementService(ICustomerService customerService, IRentalService rentalService,
            IMovieService movieService)
        {
            _customerService = customerService;
            _rentalService = rentalService;
            _movieService = movieService;
        }

        /// <summary>
        /// This method returns the complete statement of all movies the customer has rented
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public string GetCustomerStatement(int customerId)
        {
            var result = string.Empty;
            double totalAmount = 0;

            //Find all movies the customer has rented
            var customerRentals = _rentalService.GetRentalsByCustomerId(customerId).ToList();
            if (!customerRentals.Any()) return result;

            var frequentRenterPoints = customerRentals.Count;
            var customerName = _customerService.GetCustomerNameByCustomerId(customerId);

            if (string.IsNullOrEmpty(customerName)) return result; //or log this error: the customerId is missing 

            result += StatementGenerator.CreateCustomerNameStatement(customerName);

            //Load all statement factory modules and the use them to build a combined statement for all movies the customer has rented
            var statementModules = ModulesLoader.LoadModules<StatementFactory>().ToList();
            statementModules.ForEach(m =>
                result += m.Build(customerId, ref totalAmount, _rentalService, _movieService));

            result += StatementGenerator.CreateTotalAmountStatement(totalAmount) 
                      + StatementGenerator.CreateTotalFrequentRenterPointsStatement(frequentRenterPoints);

            return result;
        }
    }
}