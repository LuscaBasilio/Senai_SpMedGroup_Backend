using System;
using System.Linq;
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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuarioController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        //RESPOSTA DA VIDA ABAIXO vvv
        [HttpGet("Consultas")]
        [Authorize(Roles = "Administrador")]
        public IActionResult VisualizarConsul()
        {
            try
            {
                return Ok(new SpMedGroupContext().Consulta.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //RESPOSTA DA VIDA ACIMA ^w^

        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Alterar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Alterar(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Alterar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar([FromBody]int id)
        {
            try
            {
                UsuarioRepository.Deletar(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Usuarios")]
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarUsuarios()
        {
            try
            {
                return Ok(UsuarioRepository.ListarUsuarios());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Tipos")]
        [Authorize(Roles = "Administrador")]
        public IActionResult listarTipos()
        {
            try
            {
                return Ok(UsuarioRepository.listarTipos());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

}