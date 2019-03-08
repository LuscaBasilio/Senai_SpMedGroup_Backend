using Senai_SPMedGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios Cadastrar();

        void Alterar(Usuarios usuario);

        void Deletar(Usuarios usuario);
    }
}
