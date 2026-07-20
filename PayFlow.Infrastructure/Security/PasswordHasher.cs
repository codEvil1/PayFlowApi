using PayFlow.Application.Interfaces;

namespace PayFlow.Application.Security
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            ArgumentNullException.ThrowIfNull(password);

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string passwordHash)
        {
            ArgumentNullException.ThrowIfNull(password);
            ArgumentNullException.ThrowIfNull(passwordHash);

            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}