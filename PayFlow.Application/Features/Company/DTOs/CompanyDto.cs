using System.Text.Json.Serialization;

namespace PayFlow.Infrastructure.Features.Company.DTOs
{
    public class CompanyDto
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("ultima_atualizacao")]
        public DateTime? LastUpdate { get; set; }

        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; } = string.Empty;

        [JsonPropertyName("tipo")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("porte")]
        public string Size { get; set; } = string.Empty;

        [JsonPropertyName("nome")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("fantasia")]
        public string Fantasy { get; set; } = string.Empty;

        [JsonPropertyName("abertura")]
        public string OpeningDate { get; set; } = string.Empty;

        [JsonPropertyName("atividade_principal")]
        public List<ReceitaWsActivityDto> MainActivities { get; set; } = [];

        [JsonPropertyName("atividades_secundarias")]
        public List<ReceitaWsActivityDto> SecondaryActivities { get; set; } = [];

        [JsonPropertyName("natureza_juridica")]
        public string LegalNature { get; set; } = string.Empty;

        [JsonPropertyName("logradouro")]
        public string Street { get; set; } = string.Empty;

        [JsonPropertyName("numero")]
        public string Number { get; set; } = string.Empty;

        [JsonPropertyName("complemento")]
        public string Complement { get; set; } = string.Empty;

        [JsonPropertyName("cep")]
        public string ZipCode { get; set; } = string.Empty;

        [JsonPropertyName("bairro")]
        public string District { get; set; } = string.Empty;

        [JsonPropertyName("municipio")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("uf")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("telefone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("efr")]
        public string Efr { get; set; } = string.Empty;

        [JsonPropertyName("situacao")]
        public string Situation { get; set; } = string.Empty;

        [JsonPropertyName("data_situacao")]
        public string SituationDate { get; set; } = string.Empty;

        [JsonPropertyName("motivo_situacao")]
        public string SituationReason { get; set; } = string.Empty;

        [JsonPropertyName("situacao_especial")]
        public string SpecialSituation { get; set; } = string.Empty;

        [JsonPropertyName("data_situacao_especial")]
        public string SpecialSituationDate { get; set; } = string.Empty;

        [JsonPropertyName("capital_social")]
        public string CapitalSocial { get; set; } = string.Empty;

        [JsonPropertyName("qsa")]
        public List<ReceitaWsPartnerDto> Partners { get; set; } = [];

        [JsonPropertyName("simples")]
        public ReceitaWsTaxRegimeDto? Simples { get; set; }

        [JsonPropertyName("simei")]
        public ReceitaWsTaxRegimeDto? Simei { get; set; }

        [JsonPropertyName("billing")]
        public ReceitaWsBillingDto? Billing { get; set; }
    }

    public class ReceitaWsActivityDto
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        [JsonPropertyName("text")]
        public string Description { get; set; } = string.Empty;
    }

    public class ReceitaWsPartnerDto
    {
        [JsonPropertyName("nome")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("qual")]
        public string Qualification { get; set; } = string.Empty;

        [JsonPropertyName("pais_origem")]
        public string CountryOrigin { get; set; } = string.Empty;

        [JsonPropertyName("nome_rep_legal")]
        public string LegalRepresentativeName { get; set; } = string.Empty;

        [JsonPropertyName("qual_rep_legal")]
        public string LegalRepresentativeQualification { get; set; } = string.Empty;
    }

    public class ReceitaWsTaxRegimeDto
    {
        [JsonPropertyName("optante")]
        public bool Optant { get; set; }

        [JsonPropertyName("data_opcao")]
        public string? OptionDate { get; set; }

        [JsonPropertyName("data_exclusao")]
        public string? ExclusionDate { get; set; }

        [JsonPropertyName("ultima_atualizacao")]
        public string? LastUpdate { get; set; }
    }

    public class ReceitaWsBillingDto
    {
        [JsonPropertyName("free")]
        public bool Free { get; set; }

        [JsonPropertyName("database")]
        public bool Database { get; set; }
    }
}