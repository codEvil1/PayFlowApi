namespace PayflowApi.Dtos.Customer
{
    public class CashierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<int> Rating { get; set; } = [];
    }
}
