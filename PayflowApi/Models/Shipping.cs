namespace PayFlowApi.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
