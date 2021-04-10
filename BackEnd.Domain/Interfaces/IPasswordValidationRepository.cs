using Iti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iti.Domain.Interfaces
{
    public interface IPasswordValidationRepository
    {
        /// <summary>
        /// Executa as regras de validação de Password conforme dominio
        /// </summary>
        /// <param name="passwordValidation"></param>
        /// <returns></returns>
        bool IsValid(EntityPassword passwordValidation);
    }
}
