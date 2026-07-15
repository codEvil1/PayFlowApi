using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace PayFlow.Infrastructure.Features.Product.Validators
{
    public static class ProductRules
    {
        public static IRuleBuilderOptions<T, string> IdRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("Id é obrigatório.")
                .Length(8)
                .WithMessage("O id deve possuir 8 caracteres.");
        }

        public static IRuleBuilderOptions<T, string> BarCodeRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("O código de barras é obrigatório.")
                .Length(13)
                .WithMessage("O código de barras deve possuir 13 caracteres.")
                .Matches(@"^\d+$")
                .WithMessage("O código de barras deve conter apenas números.");
        }

        public static IRuleBuilderOptions<T, string> DescriptionRule<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .WithMessage("A descrição é obrigatória.")
                .MaximumLength(150)
                .WithMessage("A descrição deve possuir no máximo 150 caracteres.");
        }

        public static IRuleBuilderOptions<T, IFormFile?> ImageRule<T>(this IRuleBuilder<T, IFormFile?> rule)
        {
             return rule
                 .Must(BeValidImage)
                 .WithMessage("A imagem deve estar no formato PNG.")

                 .Must(HasContent)
                 .WithMessage("A imagem não pode estar vazia.")

                 .Must(BeValidContentType)
                 .WithMessage("O arquivo enviado não é uma imagem PNG válida.")

                 .Must(BeValidSize)
                 .WithMessage("A imagem deve possuir no máximo 5 MB.");
        }

        public static IRuleBuilderOptions<T, decimal> PriceRule<T>(this IRuleBuilder<T, decimal> rule)
        {
            return rule
                .GreaterThan(0)
                .WithMessage("O preço deve ser maior que zero.");
        }


        public static IRuleBuilderOptions<T, int> StockRule<T>(this IRuleBuilder<T, int> rule)
        {
            return rule
                .GreaterThanOrEqualTo(0)
                .WithMessage("O estoque não pode ser negativo.");
        }
        private static bool HasContent(IFormFile? file)
        {
            if (file is null)
                return false;

            return file.Length > 0;
        }

        private static bool BeValidImage(IFormFile? file)
        {
            if (file is null)
                return false;

            return Path.GetExtension(file.FileName).Equals(".png", StringComparison.OrdinalIgnoreCase);
        }

        private static bool BeValidContentType(IFormFile? file)
        {
            if (file is null)
                return false;

            return file.ContentType.Equals("image/png", StringComparison.OrdinalIgnoreCase);
        }

        private static bool BeValidSize(IFormFile? file)
        {
            if (file is null)
                return false;

            return file.Length <= 5 * 1024 * 1024;
        }
    }
}