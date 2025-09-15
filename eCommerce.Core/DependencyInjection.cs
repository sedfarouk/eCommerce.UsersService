using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
     /// <summary>
     /// Extension method to add core services to the dependency injection container
     /// </summary>
     /// <param name="services"></param>
     /// <returns></returns>
     public static IServiceCollection AddCore(this IServiceCollection services)
     {
          services.AddTransient<IUsersService, UsersService>();
          services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
          
          return services;
     }
}