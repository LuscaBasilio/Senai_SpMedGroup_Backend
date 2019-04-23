using Microsoft.EntityFrameworkCore;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Senai_SPMedGroup.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=SENAI_SPMEDGROUP_MANHA;user id=sa; pwd=132";

        public void CadastrarConsulta(Consulta consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consulta.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public void CancelarAgendamento(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Alter = "UPDATE CONSULTA SET PROGRESSO = 4 WHERE ID = @ID";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(Alter, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public List<Consulta> ConsultarConsulta(int IdUser)
        //{
        //    using (SpMedGroupContext ctx = new SpMedGroupContext())
        //    {
        //        Usuarios usuario = ctx.Usuarios.Find(IdUser);
        //        if (usuario.IdTipoUsuarioNavigation.Equals(IdUser))
        //        {
        //           return ctx.Consulta.Include(Convert.ToString(IdUser)).ToList();
        //        }
        //        return null;
        //    }
        //}
    }
}
