using System;
using System.Collections.Generic;

namespace Senai_SPMedGroup.Domains
{
    public partial class Especializacao
    {
        public Especializacao()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
