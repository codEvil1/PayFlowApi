using System.Net;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using PayFlow.Application.Interfaces;

namespace PayFlow.Infrastructure.Email;

public class EmailService(EmailSettings settings) : IEmailService
{
    public async Task SendAsync(string to, string subject, string body, CancellationToken cancellationToken)
    {
        var message = new MimeMessage();

        message.From.Add(
            new MailboxAddress(settings.DisplayName, settings.From));

        message.To.Add(
            MailboxAddress.Parse(to));

        message.Subject = subject;

        message.Body = new BodyBuilder
        {
            HtmlBody = body
        }.ToMessageBody();

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(
            settings.Host,
            settings.Port,
            SecureSocketOptions.StartTls,
            cancellationToken);

        await smtp.AuthenticateAsync(settings.Username, settings.Password, cancellationToken);
        await smtp.SendAsync(message, cancellationToken);
        await smtp.DisconnectAsync(true, cancellationToken);
    }

    public async Task SendVerificationCodeAsync(string email, string name, string code, string language, CancellationToken cancellationToken)
    {
        var template = await LoadTemplateAsync(language);

        var safeName = WebUtility.HtmlEncode(name);
        var safeCode = WebUtility.HtmlEncode(code);

        var body = template
            .Replace("{{name}}", safeName)
            .Replace("{{code}}", safeCode);

        var message = new MimeMessage();

        message.From.Add(
            new MailboxAddress(settings.DisplayName, settings.From));

        message.To.Add(
            new MailboxAddress(name, email));

        message.Subject = GetVerificationSubject(language);

        message.Body = new BodyBuilder
        {
            HtmlBody = body
        }.ToMessageBody();

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(settings.Host, settings.Port, GetSecurityOption(), cancellationToken);
        await smtp.AuthenticateAsync(settings.Username, settings.Password, cancellationToken);
        await smtp.SendAsync(message);
        await smtp.DisconnectAsync(true, cancellationToken);
    }

    private static async Task<string> LoadTemplateAsync(string language)
    {
        var normalizedLanguage = NormalizeLanguage(language);

        var fileName = $"VerificationCode.{normalizedLanguage}.html";

        var path = Path.Combine(
            AppContext.BaseDirectory,
            "Email",
            "Templates",
            fileName);

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"E-mail template not found: {fileName}",
                path);
        }

        return await File.ReadAllTextAsync(path);
    }

    private static string NormalizeLanguage(string language)
    {
        return language switch
        {
            "pt" => "pt-BR",
            "pt-BR" => "pt-BR",

            "en" => "en-US",
            "en-US" => "en-US",

            "es" => "es-ES",
            "es-ES" => "es-ES",

            _ => "pt-BR"
        };
    }

    private static string GetVerificationSubject(string language)
    {
        return NormalizeLanguage(language) switch
        {
            "pt-BR" => "Código de verificação - PayFlow",
            "en-US" => "Verification code - PayFlow",
            "es-ES" => "Código de verificación - PayFlow",

            _ => "Código de verificação - PayFlow"
        };
    }

    private SecureSocketOptions GetSecurityOption()
    {
        return settings.Security.ToLowerInvariant() switch
        {
            "starttls" => SecureSocketOptions.StartTls,
            "ssl" or "sslontconnect" => SecureSocketOptions.SslOnConnect,
            "none" => SecureSocketOptions.None,

            _ => SecureSocketOptions.StartTls
        };
    }
}