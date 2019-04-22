using System;
using System.Collections.Generic;

namespace Senai_SPMedGroup.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Pacientes = new HashSet<Pacientes>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }
        public DateTime DataNascimento { get; set; }

        public TiposUsuarios IdTipoUsuarioNavigation { get; set; }
        public Medicos Medicos { get; set; }
        public ICollection<Pacientes> Pacientes { get; set; }
    }
}
