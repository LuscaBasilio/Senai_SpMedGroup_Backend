using Microsoft.EntityFrameworkCore;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai_SPMedGroup.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        //Atualiza a descrição do prontuario de um paciente
        public void DescricaoProntuario(Consulta desc)
        {
            using(SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consulta.Update(desc);
            }
        }

        public List<Consulta> VerConsultas()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Consulta.Include("Medicos").ToList();
            }
        }
    }
}
