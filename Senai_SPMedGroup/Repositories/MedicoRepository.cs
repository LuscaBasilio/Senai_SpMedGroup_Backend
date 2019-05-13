using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Senai_SPMedGroup.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public void AlterarConsulta(Consulta consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Consulta consultaExist = ctx.Consulta.Find(consulta.Id);

                if (consultaExist != null)
                {
                    consultaExist.Progresso = consulta.Progresso;
                    consultaExist.Observacao = consulta.Observacao;
                    ctx.Consulta.Update(consultaExist);
                    ctx.SaveChanges();
                }
                else
                {
                    string a = Convert.ToString(new { m = "Non ecziste" });
                }

            }
        }

        public List<Consulta> VerConsultas(int Id)
        {
            List<Consulta> consultas = new List<Consulta>();

            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Consulta consultaExist = new Consulta();
                Medicos medico = ctx.Medicos.Find(Id);

                if(consultaExist == null)
                {
                    string a = Convert.ToString(new { m = "Non ecziste" });
                }

                return ctx.Consulta.Where(x => x.IdMedico == medico.Id).ToList();

            }
        }
    }
}
