using Iti.Domain.Entities;
using Iti.Domain.Interfaces;
using Iti.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iti.Infra.Data.Repositories
{
    public class PasswordValidationRepository : IPasswordValidationRepository
    {
        private readonly IPasswordValidator _passwordValidator;

        /// <summary>
        /// Instacia PasswordValidator
        /// </summary>
        /// <param name="passwordValidator"></param>
        public PasswordValidationRepository(IPasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }

        /// <summary>
        /// Executa as regras de validação de Password conforme dominio
        /// </summary>
        /// <param name="passwordValidation"></param>
        /// <returns></returns>
        public bool IsValid(EntityPassword passwordValidation)
        {
            return _passwordValidator.IsValid(passwordValidation);
        }
    }
}
