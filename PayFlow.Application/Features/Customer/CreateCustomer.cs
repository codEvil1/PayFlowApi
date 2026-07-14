using PayFlow.Application.Features.Address;

namespace PayFlow.Application.Features.Customer;
public class CreateCustomer
{
    public string Identifier { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public AddressResponse Address { get; set; } = new AddressResponse();
}
