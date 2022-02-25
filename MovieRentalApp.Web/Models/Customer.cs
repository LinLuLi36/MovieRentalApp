using System.Collections.Generic;

namespace MovieRentalApp.Web.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        //Other information can also be added e.g. Email, Address, Password, UserName and so on

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
