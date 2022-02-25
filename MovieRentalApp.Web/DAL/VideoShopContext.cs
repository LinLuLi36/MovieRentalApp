using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Web.Models;

namespace MovieRentalApp.Web.DAL
{
    public class VideoShopContext : DbContext
    {
        public VideoShopContext(DbContextOptions<VideoShopContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Made for unittest
        /// </summary>
        public VideoShopContext()
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
    }
}
