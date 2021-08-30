using API.Login.Filters;
using API.Login.Models;
using API.Login.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        [CustomizedModelStateValidation]
        public IActionResult SignIn(UserViewModelSignIn userViewModelSignIn) 
        {
            var userViewModelLogIn = new UserViewModelLogIn
            {
                Codigo = 1,
                Login = "marcus",
                Email = "eu@marcus.place"
            };

            var secret = Encoding.ASCII.GetBytes("Do_F'8-D{dob,yBvfF:T>rWQzJgd/F[lu-)vR~Ch#voLT#o.7A%?z.8sn+-Bw[o,");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                { 
                    new Claim(ClaimTypes.NameIdentifier, userViewModelLogIn.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, userViewModelLogIn.Login.ToString()),
                    new Claim(ClaimTypes.Email, userViewModelLogIn.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new 
            {
                Token = token,
                User = userViewModelLogIn
            });
        }

        [HttpPost]
        [Route("signup")]
        [CustomizedModelStateValidation]
        [Authorize]
        public IActionResult SignUp(UserViewModelSignUp userViewModelSignUp)
        {
            return Created("", userViewModelSignUp);
        }
    }
}
