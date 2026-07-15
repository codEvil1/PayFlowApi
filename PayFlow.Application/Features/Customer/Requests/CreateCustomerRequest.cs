using PayFlow.Infrastructure.Features.Address.Requests;

namespace PayFlow.Infrastructure.Features.Customer.Requests
{
    public class CreateCustomerRequest
    {
        public string Identifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public CreateAddressRequest Address { get; set; } = new();
    }
}
