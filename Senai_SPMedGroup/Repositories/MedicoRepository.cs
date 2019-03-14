using Microsoft.EntityFrameworkCore;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Senai_SPMedGroup.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=SENAI_SPMEDGROUP_MANHA;user id=sa; pwd=132";
        //Atualiza a descrição do prontuario de um paciente

        //NÃO QUERIA TER USADO ISSO ;-;
        public void DescricaoProntuario(Consulta desc)
        {
            using (SqlConnection con = new SqlConnection())
            {
                string Inserte = "INSERT INTO CONSULTA WHERE (OBSERVACAO) VALUES (@OBSERVACAO)";

                con.Open();
                
                using(SqlCommand ctx = new SqlCommand(Inserte, con))
                {
                    ctx.Parameters.AddWithValue("@OBSERVACAO", desc.Observacao);

                    ctx.ExecuteNonQuery();
                }
            }
        }

        public List<Consulta> VerConsultas()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                //Lambda pra encontrar a FOREIGN KEY REFERENCES MEDICOS(ID)
                return ctx.Consulta.Include(x => x.IdMedicoNavigation).ToList();
            }
        }
    }
}
