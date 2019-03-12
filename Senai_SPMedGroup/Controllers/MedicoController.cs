using Microsoft.AspNetCore.Mvc;
using Senai_SPMedGroup.Repositories;
using Microsoft.AspNetCore.Authorization;
using Senai_SPMedGroup.Domains;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Senai_SPMedGroup.Interfaces;

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

        //Favor colocar Authorized mais tarde ;-;
        [HttpGet("verConsultas")]
        public IActionResult verConsultas()
        {
            try
            {
                MedicoRepository.VerConsultas();
                return Ok(); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //Favor colocar Authorized mais tarde ;-;
        [HttpPost("descricao")]
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