using Microsoft.Extensions.DependencyInjection;
using MovieRentalApp.Web.Interfaces.Repositories;
using MovieRentalApp.Web.Interfaces.Services;
using MovieRentalApp.Web.Repositories;
using MovieRentalApp.Web.Services;

namespace MovieRentalApp.Test
{
    public class DependencySetupFixture
    {
        /// <summary>
        /// This class is made for dependency registration
        /// </summary>
        public DependencySetupFixture()
        {
            var serviceCollection = new ServiceCollection();
            var mockDbContext = new MockDbContext();
            var mockEntities = mockDbContext.CreateMockEntities();
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>(_ => new CustomerRepository(mockEntities.Object));
            serviceCollection.AddTransient<IRentalRepository, RentalRepository>(_ => new RentalRepository(mockEntities.Object));
            serviceCollection.AddTransient<IMovieRepository, MovieRepository>(_ => new MovieRepository(mockEntities.Object));
            serviceCollection.AddTransient<ICustomerService, CustomerService>();
            serviceCollection.AddTransient<IMovieService, MovieService>();
            serviceCollection.AddTransient<IRentalService, RentalService>();
            serviceCollection.AddTransient<ICustomerStatementService, CustomerStatementService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; }
    }
}
