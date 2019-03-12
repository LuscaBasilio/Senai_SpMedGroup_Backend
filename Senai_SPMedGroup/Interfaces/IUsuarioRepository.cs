using Senai_SPMedGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup.Interfaces
{
    interface IUsuarioRepository
    {
        void Alterar(Usuarios usuario);

        void Cadastrar(Usuarios usuario);

        void Deletar(int id);
    }
}
