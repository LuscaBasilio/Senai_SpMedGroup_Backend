using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SPMedGroup.Domains;
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
                return Ok(new PacienteRepository().VisualizarConsulta());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}