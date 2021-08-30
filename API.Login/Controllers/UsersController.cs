using API.Login.Models;
using API.Login.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Login.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <param name="userViewModelSignIn"></param>
        /// <returns>Retorna startus Ok, dados do usuário e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Autenticar", Type =typeof(UserViewModelSignIn))]
        [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", Type = typeof(ValidateFieldsModel))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn(UserViewModelSignIn userViewModelSignIn) 
        {
            return Ok(userViewModelSignIn);
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp(UserViewModelSignUp userViewModelSignUp)
        {
            return Created("", userViewModelSignUp);
        }
    }
}
