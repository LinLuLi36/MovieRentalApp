namespace MovieRentalApp.Web.Utilities
{
    /// <summary>
    /// Generates different statement sections for customer rentals
    /// </summary>
    public static class StatementGenerator
    {
        public static string CreateRentalStatementEachMovie(double amount, string movieTitle)
        {
            return $" {movieTitle} {amount}\n";
        }

        public static string CreateCustomerNameStatement(string customerName)
        {
            return $"Rental Record for {customerName}\n";
        }

        public static string CreateTotalAmountStatement(double totalAmount)
        {
            return $"You owed {totalAmount}\n";
        }

        public static string CreateTotalFrequentRenterPointsStatement(int frequentRenterPoints)
        {
            return $"You earned {frequentRenterPoints} frequent renter points\n";
        }
    }
}
