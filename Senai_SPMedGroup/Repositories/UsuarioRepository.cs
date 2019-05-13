using Microsoft.EntityFrameworkCore;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Usuarios userExist = ctx.Usuarios.Find(usuario.Id);
                if (userExist != null)
                {
                    userExist.Nome = usuario.Nome;
                    userExist.Email = usuario.Email;
                    userExist.Senha = usuario.Senha;
                    userExist.IdTipoUsuario = usuario.IdTipoUsuario;
                    userExist.DataNascimento = usuario.DataNascimento;
                    ctx.Usuarios.Update(userExist);
                    ctx.SaveChanges();
                }
            }
        }

        public void Deletar(int id)
        {
            using(SpMedGroupContext ctx = new SpMedGroupContext())
            {
                string a;

                Usuarios usuarioRemover = ctx.Usuarios.Find(id);
                if(usuarioRemover == null)
                {
                    a = Convert.ToString(new { m ="Non ecziste" });
                }
                ctx.Usuarios.Remove(usuarioRemover);
                ctx.SaveChanges();
            }
        }

        public Usuarios EncontrarUsuario(string email, string senha)
        {
            using(SpMedGroupContext ctx = new SpMedGroupContext())
            {
               return ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == email && x.Senha == senha);
            }
        }

        public List<Usuarios> ListarUsuarios()
        {
            using(SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
