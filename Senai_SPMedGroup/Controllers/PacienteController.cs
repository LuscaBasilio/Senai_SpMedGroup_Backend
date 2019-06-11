using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai_SPMedGroup.Interfaces;
using Senai_SPMedGroup.Repositories;

namespace Senai_SPMedGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository PacienteRepository { get; set; }

        public PacienteController()
        {
            PacienteRepository = new PacienteRepository();
        }

        [HttpGet]
        [Authorize (Roles = "Paciente")]
        public IActionResult VisualizarConsultas()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

                int idPaciente = PacienteRepository.BuscarID(id).Id;

                return Ok(new MedicoRepository().VerConsultas(idPaciente));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}