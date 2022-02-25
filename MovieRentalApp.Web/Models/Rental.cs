namespace MovieRentalApp.Web.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int DaysRented { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
