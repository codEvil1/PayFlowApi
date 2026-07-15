using FluentValidation;
using PayFlow.Infrastructure.Features.Product.Requests;

namespace PayFlow.Infrastructure.Features.Product.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.BarCode).BarCodeRule();
            RuleFor(x => x.Description).DescriptionRule();
            RuleFor(x => x.Image).ImageRule();
            RuleFor(x => x.Price).PriceRule();
            RuleFor(x => x.StockQuantity).StockRule();
        }
    }
}