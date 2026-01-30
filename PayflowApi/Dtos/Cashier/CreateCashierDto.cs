namespace PayflowApi.Dtos.Cashier
{
    public class CreateCashierDto
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<int> Rating { get; set; } = [];
    }
}
