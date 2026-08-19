namespace PayFlow.Domain.Entities
{
    public class EmailVerification
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string CodeHash { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime? UsedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; } = null!;
    }
}