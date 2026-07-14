namespace PayFlow.Application.Features.Address;
public class CreateAddress
{
    public string Street { get; set; } = string.Empty;
    public int? Number { get; set; } = default;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Uf { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
