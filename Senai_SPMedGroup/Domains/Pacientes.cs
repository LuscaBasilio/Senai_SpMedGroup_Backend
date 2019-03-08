using System;
using System.Collections.Generic;

namespace Senai_SPMedGroup.Domains
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public int? IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
