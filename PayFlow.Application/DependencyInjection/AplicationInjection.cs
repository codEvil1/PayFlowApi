using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PayFlow.Application.Features.Customer.Validators;
using PayFlow.Application.Features.Discount.Validators;
using PayFlow.Application.Features.Product.Validators;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Services;

namespace PayFlow.Application.DependencyInjection
{
    public static class ApplicationInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddService()
                .AddValidation();

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddValidatorsFromAssemblyContaining<CreateProductValidator>()
                .AddValidatorsFromAssemblyContaining<UpdateProductValidator>()
                .AddValidatorsFromAssemblyContaining<CreateCustomerValidator>()
                .AddValidatorsFromAssemblyContaining<UpdateCustomerValidator>()
                .AddValidatorsFromAssemblyContaining<CreateDiscountValidator>()
                .AddValidatorsFromAssemblyContaining<UpdateDiscountValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            return services;
        }

        private static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDiscountService, DiscountService>();

            return services;
        }
    }
}