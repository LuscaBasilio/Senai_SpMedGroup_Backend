using System;
using System.Collections.Generic;

namespace Senai_SPMedGroup.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Especializacao { get; set; }
        public string Crm { get; set; }
        public string Cnpj { get; set; }
        public int? IdUsuario { get; set; }

        public Especializacao EspecializacaoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
