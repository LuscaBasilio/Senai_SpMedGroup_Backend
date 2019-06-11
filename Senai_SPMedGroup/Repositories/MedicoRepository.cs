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

        public List<Consulta> VerConsultas(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Consulta.Where(x => x.IdMedico == id).ToList();
            }
        }

        public Medicos BuscarPorId(int id)
        {

            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Medicos.FirstOrDefault(x => x.IdUsuario == id);
            }
        }
    }
}
