namespace PayFlow.Application.Settings
{
    public class ReceitaWsSettings
    {
        public string BaseUrl { get; init; } = string.Empty;
        public int TimeoutSeconds { get; init; } = 30;
    }
}