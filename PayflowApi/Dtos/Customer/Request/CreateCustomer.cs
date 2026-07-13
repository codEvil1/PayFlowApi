using PayflowApi.Models;

namespace PayflowApi.Dtos.Customer.Request
{
    public class CreateCustomer
    {
        public string Identifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
    }
}
