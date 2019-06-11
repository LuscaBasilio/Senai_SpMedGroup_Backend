using Microsoft.EntityFrameworkCore;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;

namespace Senai_SPMedGroup.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        public List<Consulta> VisualizarConsulta()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Pacientes paciente = new Pacientes();
                return ctx.Consulta.ToList();
            }
        }

        public Pacientes BuscarID(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Pacientes.FirstOrDefault(x => x.IdUsuario == id);
            }
        }
    }
}
