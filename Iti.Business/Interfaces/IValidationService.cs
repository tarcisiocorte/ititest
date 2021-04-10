using Iti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iti.Business.Interfaces
{
    public interface IValidationService
    {
        bool IsValid(EntityPassword passwordValidation);
    }
}
