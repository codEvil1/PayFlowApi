namespace PayFlow.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int AddressId { get; set; } = default;
        public Address Address { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}
