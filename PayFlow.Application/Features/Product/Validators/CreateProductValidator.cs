using FluentValidation;
using Microsoft.AspNetCore.Http;
using PayFlow.Application.Features.Product.UseCases;

namespace PayFlow.Application.Features.Product.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O SKU é obrigatório.")
                .Length(8)
                .WithMessage("O SKU deve possuir 8 caracteres.");

            RuleFor(x => x.BarCode)
                .NotEmpty()
                .WithMessage("O código de barras é obrigatório.")
                .Length(13)
                .WithMessage("O código de barras deve possuir 13 caracteres.");
        
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("A descrição é obrigatória.")
                .MaximumLength(150)
                .WithMessage("A descrição deve possuir no máximo 150 caracteres.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("O preço deve ser maior que zero.");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O estoque não pode ser negativo.");

            RuleFor(x => x.Image)
                .Must(BeValidImage)
                .When(x => x.Image != null)
                .WithMessage("A imagem deve no formato PNG.");

            RuleFor(x => x.Image)
                .Must(BeValidSize)
                .When(x => x.Image != null)
                .WithMessage("A imagem deve possuir no máximo 5 MB.");
        }

        private bool BeValidImage(IFormFile? file)
        {
            if (file == null)
                return true;

            return Path.GetExtension(file.FileName)
                .Equals(".png", StringComparison.OrdinalIgnoreCase);
        }

        private bool BeValidSize(IFormFile? file)
        {
            if (file == null)
                return true;

            return file.Length <= 5 * 1024 * 1024;
        }
    }
}