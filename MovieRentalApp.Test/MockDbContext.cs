using Microsoft.EntityFrameworkCore;
using Moq;
using MovieRentalApp.Web.DAL;
using MovieRentalApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieRentalApp.Test
{
    public class MockDbContext
    {
        private readonly IQueryable<Customer> _customerData;
        private readonly IQueryable<Movie> _movieData;
        private readonly IQueryable<Rental> _rentalData;

        public MockDbContext()
        {
            //Seed queryable data
            _customerData = new List<Customer>
            {
                new Customer {CustomerId = 1, Name = "Peter"},
                new Customer {CustomerId = 2, Name = "Mary"}
            }.AsQueryable(); 

            _movieData = new List<Movie>
            {
                new Movie { MovieId = 1, Title = "Titanic", PriceCode = 111, Type = MovieType.Regular },
                new Movie { MovieId = 2, Title = "Tenet", PriceCode = 222, Type = MovieType.NewRelease },
                new Movie { MovieId = 3, Title = "Frozen", PriceCode = 233, Type = MovieType.Children },
                new Movie { MovieId = 4, Title = "Harry Potter", PriceCode = 112, Type = MovieType.Regular },
                new Movie { MovieId = 5, Title = "The Batman", PriceCode = 565, Type = MovieType.NewRelease },
                new Movie { MovieId = 6, Title = "Up", PriceCode = 235, Type = MovieType.Children },
                new Movie { MovieId = 7, Title = "Star Wars", PriceCode = 101, Type = MovieType.Regular },
                new Movie { MovieId = 8, Title = "Uncharted", PriceCode = 596, Type = MovieType.NewRelease },
                new Movie { MovieId = 9, Title = "Jungle Cruise", PriceCode = 235, Type = MovieType.Children }

            }.AsQueryable(); 

            _rentalData = new List<Rental>
            {
                new Rental { MovieId = 1, CustomerId = 1, RentalId = 1, DaysRented = 3 },
                new Rental { MovieId = 2, CustomerId = 1, RentalId = 2, DaysRented = 5 },
                new Rental { MovieId = 3, CustomerId = 1, RentalId = 3, DaysRented = 2 },
                new Rental { MovieId = 4, CustomerId = 2, RentalId = 4, DaysRented = 5 },
                new Rental { MovieId = 5, CustomerId = 2, RentalId = 5, DaysRented = 2 },
                new Rental { MovieId = 6, CustomerId = 2, RentalId = 6, DaysRented = 6 },
                new Rental { MovieId = 7, CustomerId = 2, RentalId = 7, DaysRented = 2 },
                new Rental { MovieId = 8, CustomerId = 2, RentalId = 8, DaysRented = 14 },
                new Rental { MovieId = 9, CustomerId = 2, RentalId = 9, DaysRented = 1 }

            }.AsQueryable();
        }

        /// <summary>
        /// The method creates a mock entity DbContext with data loaded
        /// </summary>
        /// <returns></returns>
        public Mock<VideoShopContext> CreateMockEntities()
        {
            var customerMockSet = new Mock<DbSet<Customer>>();
            customerMockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(_customerData.Provider);
            customerMockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(_customerData.Expression);
            customerMockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(_customerData.ElementType);
            customerMockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(() => _customerData.GetEnumerator());

            var movieMockSet = new Mock<DbSet<Movie>>();
            movieMockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(_movieData.Provider);
            movieMockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(_movieData.Expression);
            movieMockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(_movieData.ElementType);
            movieMockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(() => _movieData.GetEnumerator());

            var rentalMockSet = new Mock<DbSet<Rental>>();
            rentalMockSet.As<IQueryable<Rental>>().Setup(m => m.Provider).Returns(_rentalData.Provider);
            rentalMockSet.As<IQueryable<Rental>>().Setup(m => m.Expression).Returns(_rentalData.Expression);
            rentalMockSet.As<IQueryable<Rental>>().Setup(m => m.ElementType).Returns(_rentalData.ElementType);
            rentalMockSet.As<IQueryable<Rental>>().Setup(m => m.GetEnumerator()).Returns(() => _rentalData.GetEnumerator());

            var mockContext = new Mock<VideoShopContext>();
            mockContext.Setup(c => c.Customers).Returns(customerMockSet.Object);
            mockContext.Setup(c => c.Movies).Returns(movieMockSet.Object);
            mockContext.Setup(c => c.Rentals).Returns(rentalMockSet.Object);

            return mockContext;
        }
    }
}
