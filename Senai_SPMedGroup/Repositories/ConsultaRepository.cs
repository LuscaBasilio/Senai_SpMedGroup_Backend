using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
