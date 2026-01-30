namespace PayflowApi.Dtos.Adress
{
    public class CreateAddressDto
    {
        public string Street { get; set; } = string.Empty;
        public string? Number { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
