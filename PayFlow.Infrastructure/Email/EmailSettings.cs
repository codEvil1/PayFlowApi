namespace PayFlow.Infrastructure.Email
{
    public class EmailSettings
    {
        public const string SectionName = "Email";
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string DisplayName { get; set; } = "PayFlow";
        public string Security { get; set; } = "StartTls";
    }
}