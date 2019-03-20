using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.EntityFrameworkCore;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using Senai_SPMedGroup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_SPMedGroup.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void CadastrarConsulta(Consulta consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consulta.Add(consulta);
                ctx.SaveChanges();
            }
        }

        //Acho que além de cancelar, ele muda o status de progresso da consulta
        public void CancelarAgendamento(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Consulta consulta = ctx.Consulta.Find(id);

                if (id == consulta.Id)
                {
                    ctx.Consulta.Update(consulta);
                    ctx.SaveChanges();
                }
            }
        }

        public List<Consulta> ConsultarConsulta(int IdUser)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Usuarios usuario = ctx.Usuarios.Find(IdUser);
                if (usuario.IdTipoUsuarioNavigation.Equals(IdUser))
                {
                   return ctx.Consulta.Include(Convert.ToString(IdUser)).ToList();
                }
                return null;
            }
        }
    }
}
