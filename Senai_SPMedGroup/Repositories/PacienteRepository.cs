using Microsoft.EntityFrameworkCore;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        public List<Consulta> VisualizarConsulta()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Consulta.Include("Pacientes").ToList();
            }
        }
    }
}
