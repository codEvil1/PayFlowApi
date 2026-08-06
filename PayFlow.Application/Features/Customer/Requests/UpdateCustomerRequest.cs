using Microsoft.AspNetCore.Http;
using PayFlow.Application.Features.Address.Requests;

namespace PayFlow.Application.Features.Customer.Requests
{
    public class UpdateCustomerRequest
    {
        public string Name { get; set; } = string.Empty;
        public IFormFile Photo { get; set; } = null!;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<UpdateAddressRequest> Addresses { get; set; } = [];
    }
}