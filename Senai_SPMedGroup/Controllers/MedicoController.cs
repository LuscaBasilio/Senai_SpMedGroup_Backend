using Microsoft.AspNetCore.Mvc;
using Senai_SPMedGroup.Repositories;
using Microsoft.AspNetCore.Authorization;
using System;
using Senai_SPMedGroup.Interfaces;
using Senai_SPMedGroup.Domains;

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

        [HttpPost("verConsultas")]
        [Authorize(Roles = "Médico")]
        public IActionResult VerConsultas(int Id)
        {
            try
            {
                return Ok(new MedicoRepository().VerConsultas(Id)); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("descricao")]
        [Authorize(Roles = "Médico")]
        public IActionResult AlterarDescricao(Consulta desc)
        {
            try
            {
                MedicoRepository.DescricaoProntuario(desc);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}