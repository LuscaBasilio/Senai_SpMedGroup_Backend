using Microsoft.EntityFrameworkCore;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

        public void CancelarAgendamento(int id)
        {
            using(SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Consulta exist = ctx.Consulta.Find(id);

                if(exist != null)
                {
                    exist.Progresso = 4;

                    ctx.Consulta.Update(exist);
                    ctx.SaveChanges();
                }
            }
        }

        //public List<Consulta> ConsultarConsulta(int IdUser)
        //{
        //    using (SpMedGroupContext ctx = new SpMedGroupContext())
        //    {
        //        Usuarios usuario = ctx.Usuarios.Find(IdUser);
        //        if (usuario.IdTipoUsuarioNavigation.Equals(IdUser))
        //        {
        //           return ctx.Consulta.Include(Convert.ToString(IdUser)).ToList();
        //        }
        //        return null;
        //    }
        //}

        public List<Progresso> ListarProgresso()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Progresso.ToList();
            }
        }
    }
}
