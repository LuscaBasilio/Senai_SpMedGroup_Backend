using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai_SPMedGroup.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public void CadastrarConsulta(Consulta consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consulta.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public List<Consulta> VerConsultas()
        {
            using(SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Consulta.ToList();
            }
        }
    }
}
