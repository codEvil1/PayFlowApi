using PayFlow.Application.Features.Address.DTOs;

namespace PayFlow.Application.Features.Customer.DTOs
{
    public class CustomerDto
    {
        public string Identifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhotoUrl {  get; set; }
        public IEnumerable<AddressDto> Addresses { get; set; } = [];
    }
}
