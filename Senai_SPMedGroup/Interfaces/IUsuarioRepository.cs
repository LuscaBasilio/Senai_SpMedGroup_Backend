using Senai_SPMedGroup.Domains;
using System.Collections.Generic;

namespace Senai_SPMedGroup.Interfaces
{
    interface IUsuarioRepository
    {
        void Alterar(Usuarios usuario);

        void Cadastrar(Usuarios usuario);

        void Deletar(int id);

        Usuarios EncontrarUsuario( string email, string senha);

        List<Usuarios> ListarUsuarios();
    }
}
