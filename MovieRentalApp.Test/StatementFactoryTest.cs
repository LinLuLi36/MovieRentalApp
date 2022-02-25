using Microsoft.Extensions.DependencyInjection;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Modules;
using MovieRentalApp.Web.Utilities;
using Xunit;

namespace MovieRentalApp.Test
{
    public class StatementFactoryTest
    {
        private readonly int _firstCustomerId;
        private readonly int _secondCustomerId;
        private readonly IRentalService _rentalService;
        private readonly IMovieService _movieService;

        public StatementFactoryTest()
        {
            _firstCustomerId = 1;
            _secondCustomerId = 2;

            var serviceProvider = new DependencySetupFixture().ServiceProvider;
            using var scope = serviceProvider.CreateScope();
            _rentalService = scope.ServiceProvider.GetService<IRentalService>();
            _movieService = scope.ServiceProvider.GetService<IMovieService>();
        }

        [Fact]
        public void BuildNewMovieStatementTest()
        {
            double amount = 0;
            var newReleaseStatementFactory = new NewMovieStatementFactory();
            var statementResult = newReleaseStatementFactory.Build(_firstCustomerId, ref amount,
                _rentalService, _movieService);

            //For the movie "Tenet" the DaysRented = 5 and then amount = 5 * 3 = 15
            var statementExpected = StatementGenerator.CreateRentalStatementEachMovie(15, "Tenet");

            Assert.Equal(statementExpected, statementResult);
        }

        [Fact]
        public void BuildRegularMovieStatementTest()
        {
            double amount = 0;
            var statementFactory = new RegularMovieStatementFactory();
            var statementResult = statementFactory.Build(_firstCustomerId, ref amount, _rentalService,
                _movieService);

            //For the movie "Titanic" the DaysRented = 3 and then amount = 2 + 1 * 1.5 = 3.5
            var statementExpected = StatementGenerator.CreateRentalStatementEachMovie(3.5, "Titanic");

            Assert.Equal(statementExpected, statementResult);
        }

        [Fact]
        public void BuildChildrenMovieStatementTest()
        {
            double amount = 0;
            var statementFactory = new ChildrenMovieStatementFactory();
            var statementResult = statementFactory.Build(_firstCustomerId, ref amount, _rentalService,
                _movieService);

            //For the movie "Frozen" the DaysRented = 2 and then amount = 1.5 
            var statementExpected = StatementGenerator.CreateRentalStatementEachMovie(1.5, "Frozen");

            Assert.Equal(statementExpected, statementResult);
        }

        [Fact]
        public void BuildCombinedChildrenMovieStatementTest()
        {
            double amount = 0;
            var statementFactory = new ChildrenMovieStatementFactory();
            var statementResult = statementFactory.Build(_secondCustomerId, ref amount, _rentalService,
                _movieService);

            //For the movie "Jungle Cruise" the DaysRented = 1 and then amount = 1.5
            //For the movie "Up" the DaysRented = 6 and then amount = 1.5 + (6-3) * 1.5 = 6 
            var statementExpected = StatementGenerator.CreateRentalStatementEachMovie(6, "Up")
                                            + StatementGenerator.CreateRentalStatementEachMovie(1.5, "Jungle Cruise");

            Assert.Equal(statementExpected, statementResult);
        }

        [Fact]
        public void BuildCombinedNewMovieStatementTest()
        {
            double amount = 0;
            var statementFactory = new NewMovieStatementFactory();
            var statementResult = statementFactory.Build(_secondCustomerId, ref amount, _rentalService,
                _movieService);
            
            //For the movie "The Batman" the DaysRented = 2 and then amount = 2 * 3 = 6
            //For the movie "Uncharted" the DaysRented = 14 and then amount = 14 * 3 = 42 
            var statementExpected = StatementGenerator.CreateRentalStatementEachMovie(6, "The Batman") 
                                    +StatementGenerator.CreateRentalStatementEachMovie(42, "Uncharted");

            Assert.Equal(statementExpected, statementResult);
        }

        [Fact]
        public void BuildCombinedRegularMovieStatementTest()
        {
            double amount = 0;
            var statementFactory = new RegularMovieStatementFactory();
            var statementResult = statementFactory.Build(_secondCustomerId, ref amount, _rentalService,
                _movieService);

            //For the movie "Harry Potter" the DaysRented = 5 and then amount = 2 + (3 * 1.5) = 6.5 
            //For the movie "Star Wars" the DaysRented = 2 and then amount = 2   
            var statementExpected = StatementGenerator.CreateRentalStatementEachMovie(6.5, "Harry Potter")
                                    + StatementGenerator.CreateRentalStatementEachMovie(2, "Star Wars");

            Assert.Equal(statementExpected, statementResult);
        }
    }
}
