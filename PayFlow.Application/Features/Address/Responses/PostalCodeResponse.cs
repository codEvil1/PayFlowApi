namespace PayFlow.Application.Features.Address.Responses
{
    public class PostalCodeResponse
    {
        public string Street { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
    }
}
