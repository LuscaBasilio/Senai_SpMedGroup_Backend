using Microsoft.EntityFrameworkCore;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Cadastrar(Usuarios usuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Alterar(Usuarios usuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Usuarios usuarioRemover = ctx.Usuarios.Find(id);
                if(usuarioRemover == null)
                {
                    // :v
                }
                ctx.Usuarios.Remove(usuarioRemover);
                ctx.SaveChanges();
            }
        }

        public Usuarios EncontrarUsuario(string email, string senha)
        {
            using(SpMedGroupContext ctx = new SpMedGroupContext())
            {
               return ctx.Usuarios.ToList().Find(x => x.Email == email && x.Senha == senha);
            }
        }
    }
}
