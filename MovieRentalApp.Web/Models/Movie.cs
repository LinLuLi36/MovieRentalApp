using System.Collections.Generic;

namespace MovieRentalApp.Web.Models
{
    public enum MovieType
    {
        Children,
        NewRelease,
        Regular
    }

    public class Movie
    {
        public int MovieId { get; set; }
        public MovieType Type { get; set; }
        public string Title { get; set; }
        public int PriceCode { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
