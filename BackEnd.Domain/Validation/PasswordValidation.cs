using FluentValidation;
using Iti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Iti.Domain.Validation
{
    public class PasswordValidation : AbstractValidator<EntityPassword>
    {
        /// <summary>
        /// Executa as regras de validação de Password
        /// </summary>
        public PasswordValidation()
        {
            RuleFor(o => o.Password)
                .MinimumLength(9).WithMessage("Nove ou mais caracteres");

            RuleFor(o => o.Password)
                .Matches(@"[0-9]+").WithMessage("Ao menos 1 dígito")
                .Matches(@"[A-Z]+").WithMessage("Ao menos 1 letra minúscula")
                .Matches(@"[a-z]+").WithMessage("Ao menos 1 letra maiúscula")
                .Matches(@"[\.\!\@\#\$\%\^\&\*\(\)\+\-]+").WithMessage("Ao menos 1 caractere especial");

            RuleFor(x => x.Password).Custom((password, context) =>
            {
                int p = password.Length - password.ToCharArray().Distinct().Count();
                if (p > 0)
                {
                    context.AddFailure("Não possuir caracteres repetidos dentro do conjunto");
                }
            });
        }
    }

    /// <summary>
    /// Implementa as regras de validação de Password
    /// </summary>
    public class PasswordValidator : IPasswordValidator
    {
        /// <summary>
        /// Consome as regras de validação de Password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool IsValid(EntityPassword request)
        {
            if (request == null)
            {
                return false;
            }

            var validationResult = new PasswordValidation().Validate(request);
            return validationResult.IsValid;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IPasswordValidator
    {
        bool IsValid(EntityPassword request);
    }
}

