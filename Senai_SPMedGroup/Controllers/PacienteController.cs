using System;
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

        [HttpPost ("consulta")]
        [Authorize (Roles = "Paciente, Administrador")]
        public IActionResult VisualizarConsultas(int Id)
        {
            try
            {
                return Ok(new PacienteRepository().VisualizarConsulta(Id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}