﻿using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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
       
        [HttpPost("Cadastro")]
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
        public IActionResult CancelarConsulta([FromBody]int id)
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

        //[HttpPost ("admconsul")]
        //[Authorize(Roles = "Administrador")]
        //public IActionResult ConsultarConsulta(int IdUser)
        //{


        //    if (User.HasClaim(ClaimTypes.Role, "Adiministrador"))
        //    {
        //        ConsultaRepository.ConsultarConsulta(IdUser);
        //        return Ok();
        //    }

        //    if (User.HasClaim(ClaimTypes.Role, "Paciente"))
        //    {
        //        PacienteRepository.VisualizarConsulta(IdUser);
        //        return Ok();
        //    }

        //    if (User.HasClaim(ClaimTypes.Role, "Médico"))
        //    {
        //        MedicoRepository.VerConsultas(IdUser);
        //        return Ok();
        //    }
        //    else { return BadRequest("Como?"); }

        //}

        [HttpGet("Progresso")]
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarProgresso()
        {
            try
            {
                return Ok(ConsultaRepository.ListarProgresso());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}