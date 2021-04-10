using Iti.Business.Interfaces;
using Iti.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Iti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IValidationService _service;

        /// <summary>
        /// Inicializa uma instancia ValidationService da camada de Business application
        /// </summary>
        /// <param name="service"></param>
        public PasswordController(IValidationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Validar a senha enviada
        /// </summary>
        /// <param name="password"></param>
        /// <response code="200">A senha passou pelo processo de validação - Retorna True ou False.</response>
        /// <response code="400">Não foi possível passar a senha enviada pelo processo de validação.</response>
        [HttpPost("validation")]
        public IActionResult IsValid(EntityPassword password)
        {
            if (password == null || string.IsNullOrEmpty(password.Password))
            {
                return BadRequest("Senha não pode ser nula");
            }
            return Ok(_service.IsValid(password));
        }
    }
}
