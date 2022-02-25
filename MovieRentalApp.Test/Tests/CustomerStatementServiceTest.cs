using Microsoft.Extensions.DependencyInjection;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Utilities;
using Xunit;

namespace MovieRentalApp.Test
{
    public class CustomerStatementServiceTest
    {
        private readonly int _firstCustomerId;
        private readonly ICustomerStatementService _customerStatementService;

        public CustomerStatementServiceTest()
        {
            _firstCustomerId = 1;

            var serviceProvider = new DependencySetupFixture().ServiceProvider;
            using var scope = serviceProvider.CreateScope();
            _customerStatementService = scope.ServiceProvider.GetService<ICustomerStatementService>();
        }

        /// <summary>
        /// This test 
        /// </summary>
        [Fact]
        public void BuildNewMovieStatementTest()
        {
            var statementResult = _customerStatementService.GetCustomerStatement(_firstCustomerId);

            //For the movie "Frozen" the DaysRented = 2 and then amount = 1.5 
            //For the movie "Tenet" the DaysRented = 5 and then amount = 5 * 3 = 15
            //For the movie "Titanic" the DaysRented = 3 and then amount = 2 + 1 * 1.5 = 3.5
            var statementExpected = StatementGenerator.CreateCustomerNameStatement("Peter")
                                    + StatementGenerator.CreateRentalStatementEachMovie(1.5, "Frozen")
                                    + StatementGenerator.CreateRentalStatementEachMovie(15, "Tenet")
                                    + StatementGenerator.CreateRentalStatementEachMovie(3.5, "Titanic")
                                    + StatementGenerator.CreateTotalAmountStatement(20)
                                    + StatementGenerator.CreateTotalFrequentRenterPointsStatement(3);

            Assert.Equal(statementExpected, statementResult);
        }
    }
}


        