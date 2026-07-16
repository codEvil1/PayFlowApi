using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PayFlow.Application.Features.Address.Validators;
using PayFlow.Application.Features.Cashier.Validators;
using PayFlow.Application.Features.Customer.Validators;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Services;
using PayFlow.Infrastructure.Features.Discount.Validators;
using PayFlow.Infrastructure.Features.Product.Validators;
using PayFlow.Infrastructure.Services;

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
                .AddValidatorsFromAssemblyContaining<CreateCashierValidator>()
                .AddValidatorsFromAssemblyContaining<UpdateCustomerValidator>()
                .AddValidatorsFromAssemblyContaining<CreateDiscountValidator>()
                .AddValidatorsFromAssemblyContaining<UpdateDiscountValidator>()
                .AddValidatorsFromAssemblyContaining<GetAddressByPostalCodeValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            return services;
        }

        private static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<ICashierService, CashierService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}