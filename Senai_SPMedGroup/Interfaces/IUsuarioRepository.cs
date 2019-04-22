using Senai_SPMedGroup.Domains;

namespace Senai_SPMedGroup.Interfaces
{
    interface IUsuarioRepository
    {
        void Alterar(Usuarios usuario);

        void Cadastrar(Usuarios usuario);

        void Deletar(int id);

        Usuarios EncontrarUsuario( string email, string senha);
    }
}
