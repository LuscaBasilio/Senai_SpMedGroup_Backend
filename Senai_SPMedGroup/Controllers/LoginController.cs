using System;
using Microsoft.AspNetCore.Mvc;
using Senai_SPMedGroup.Interfaces;
using Senai_SPMedGroup.Repositories;
using Senai_SPMedGroup.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Senai_SPMedGroup.Domains;

namespace Senai_SPMedGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuario = UsuarioRepository.EncontrarUsuario(login.Email, login.Senha);
                if (usuario == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Não Encontrado"
                    });
                }

                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Role, usuario.IdTipoUsuarioNavigation.Tipo.ToString()),
                        new Claim("auth", usuario.IdTipoUsuarioNavigation.Tipo)
                    };

                SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SpMedGroupAuthenticationKey"));

                SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "Senai_SPMedGroup",
                    audience: "Senai_SPMedGroup",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);
                Console.WriteLine(token);
                return Ok(new { Mensagem = "Acesso livre!", token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}