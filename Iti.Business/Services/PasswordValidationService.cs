using Iti.Business.Interfaces;
using Iti.Domain.Entities;
using Iti.Domain.Interfaces;
using Iti.Domain.Validation;
using System;

namespace Iti.Business
{
    public class ValidationService : IValidationService
    {
        private readonly IPasswordValidationRepository _repository;

        /// <summary>
        /// Instancia a dependencia do repositorio
        /// </summary>
        /// <param name="passwordValidator"></param>
        public ValidationService(IPasswordValidationRepository passwordValidationRepository)
        {
            _repository = passwordValidationRepository;
        }

        /// <summary>
        /// Executa a validação do password conforme dominio da aplicação
        /// </summary>
        /// <param name="passwordValidation"></param>
        /// <returns>Retorna true ou false apos executar a validação</returns>
        public bool IsValid(EntityPassword passwordValidation)
        {
            return _repository.IsValid(passwordValidation);
        }
    }
}
