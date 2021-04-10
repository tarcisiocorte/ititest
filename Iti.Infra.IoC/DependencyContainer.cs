using Iti.Business;
using Iti.Business.Interfaces;
using Iti.Domain.Interfaces;
using Iti.Domain.Validation;
using Iti.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Iti.Infra.IoC
{
    public class DependencyContainer
    {
        protected DependencyContainer()
        {

        }
        /// <summary>
        /// Reponsavel por total o gerenciamento de dependencias da aplicação
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(IServiceCollection services)
        {
            //Business application
            services.AddScoped<IValidationService, ValidationService>();

            //Domain.Interfaces e Repositories
            services.AddScoped<IPasswordValidationRepository, PasswordValidationRepository>();

            // FluentValidation
            services.AddScoped<IPasswordValidator, PasswordValidator>();
        }
    }
}
