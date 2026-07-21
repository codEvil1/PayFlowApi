using System.Text.Json.Serialization;

namespace PayFlow.Infrastructure.Features.Address.DTOs
{
    public class ViaCepDto
    {
        [JsonPropertyName("cep")]
        public string PostalCode { get; set; } = string.Empty;

        [JsonPropertyName("logradouro")]
        public string Street { get; set; } = string.Empty;

        [JsonPropertyName("complemento")]
        public string Complement { get; set; } = string.Empty;

        [JsonPropertyName("unidade")]
        public string Unit { get; set; } = string.Empty;

        [JsonPropertyName("bairro")]
        public string Neighborhood { get; set; } = string.Empty;

        [JsonPropertyName("localidade")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("uf")]
        public string StateCode { get; set; } = string.Empty;

        [JsonPropertyName("estado")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("regiao")]
        public string Region { get; set; } = string.Empty;

        [JsonPropertyName("ibge")]
        public string IbgeCode { get; set; } = string.Empty;

        [JsonPropertyName("gia")]
        public string GiaCode { get; set; } = string.Empty;

        [JsonPropertyName("ddd")]
        public string AreaCode { get; set; } = string.Empty;

        [JsonPropertyName("siafi")]
        public string SiafiCode { get; set; } = string.Empty;

        [JsonPropertyName("erro")]
        public bool Error { get; set; }
    }
}