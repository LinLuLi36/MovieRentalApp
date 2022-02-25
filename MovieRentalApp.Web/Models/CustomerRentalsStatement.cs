namespace MovieRentalApp.Web.Models
{
    /// <summary>
    /// This viewModel is used to display the customer statement on the web page
    /// </summary>
    public class CustomerRentalsStatement: Customer
    {
        /// <summary>
        /// the statement is loaded by calling CustomerStatementService.GetCustomerStatement(this.CustomerId)
        /// </summary>
        public string Statement { get; set; }
    }
}
