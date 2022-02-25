using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovieRentalApp.Web.Interfaces.Services
{
    public interface ICustomerStatementService
    {
        public string GetCustomerStatement(int customerId);
    }
}