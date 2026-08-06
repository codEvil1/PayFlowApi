namespace PayFlow.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public int? Number { get; set; } = default;
        public string? Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}