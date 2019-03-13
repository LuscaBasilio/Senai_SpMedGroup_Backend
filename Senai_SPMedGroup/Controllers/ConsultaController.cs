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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }

        public ConsultaController()
        {
            ConsultaRepository = new ConsultaRepository();
        }

        [HttpPost("cadastro")]
        [Authorize (Roles = "Administrador")]
        public IActionResult CadastrarConsulta(Consulta consulta)
        {
            try
            {
                ConsultaRepository.CadastrarConsulta(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult CancelarConsulta(int id)
        {
            try
            {
                ConsultaRepository.CancelarAgendamento(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}