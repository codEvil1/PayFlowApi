namespace PayFlowApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int AddressId { get; set; }

        public Address Address { get; set; } = new Address();
    }
}
