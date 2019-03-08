using System;
using System.Collections.Generic;

namespace Senai_SPMedGroup.Domains
{
    public partial class Progresso
    {
        public Progresso()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Progresso1 { get; set; }

        public ICollection<Consulta> Consulta { get; set; }
    }
}
