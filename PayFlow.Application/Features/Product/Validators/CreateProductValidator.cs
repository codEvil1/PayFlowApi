using FluentValidation;
using PayFlow.Application.Features.Product.Requests;

namespace PayFlow.Application.Features.Product.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Id).IdRule();
            RuleFor(x => x.BarCode).BarCodeRule();
            RuleFor(x => x.Description).DescriptionRule();
            RuleFor(x => x.Image).ImageRule();
            RuleFor(x => x.Price).PriceRule();
            RuleFor(x => x.StockQuantity).StockRule();
        }
    }
}