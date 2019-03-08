using System;
using System.Collections.Generic;

namespace Senai_SPMedGroup.Domains
{
    public partial class Consulta
    {
        public int Id { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public DateTime DataConsulta { get; set; }
        public int? Progresso { get; set; }
        public string Observacao { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public Pacientes IdPacienteNavigation { get; set; }
        public Progresso ProgressoNavigation { get; set; }
    }
}
