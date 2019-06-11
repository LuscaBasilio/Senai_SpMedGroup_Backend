using Microsoft.AspNetCore.Mvc;
using Senai_SPMedGroup.Repositories;
using Microsoft.AspNetCore.Authorization;
using System;
using Senai_SPMedGroup.Interfaces;
using Senai_SPMedGroup.Domains;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace Senai_SPMedGroup.Controllers
{
    [Produces("application/Json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository MedicoRepository { get; set; }

        public MedicoController()
        {
            MedicoRepository = new MedicoRepository();
        }

        [HttpGet("Consultas")]
        [Authorize(Roles = "Médico")]
        public IActionResult VerConsultas()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

                int idMedico = MedicoRepository.BuscarPorId(id).Id;
                
                return Ok(new MedicoRepository().VerConsultas(idMedico)); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Médico")]
        public IActionResult AlterarConsulta(Consulta consulta)
        {
            try
            {
                MedicoRepository.AlterarConsulta(consulta);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}