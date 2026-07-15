using PayFlow.Infrastructure.Features.Address.Requests;

namespace PayFlow.Application.Features.Customer.Requests
{
    public class UpdateCustomerRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UpdateAddressRequest Address { get; set; } = new();
    }
}