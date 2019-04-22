using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai_SPMedGroup.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=SENAI_SPMEDGROUP_MANHA;user id=sa; pwd=132";
        //Atualiza a descrição do prontuario de um paciente

        //NÃO QUERIA TER USADO ISSO ;-;
        public void DescricaoProntuario(Consulta desc)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Inserte = "INSERT INTO CONSULTA WHERE (OBSERVACAO) VALUES (@OBSERVACAO)";

                con.Open();

                using (SqlCommand ctx = new SqlCommand(Inserte, con))
                {
                    ctx.Parameters.AddWithValue("@OBSERVACAO", desc.Observacao);
                    ctx.ExecuteNonQuery();
                }
            }
        }

        public List<Consulta> VerConsultas(int Id)
        {
            List<Consulta> consultas = new List<Consulta>();

                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string Select = "SELECT * FROM CONSULTA WHERE ID_MEDICO = @ID";
                    con.Open();
                    SqlDataReader Reader;

                    using (SqlCommand cmd = new SqlCommand(Select, con))
                    {
                    Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        Consulta verConsulta = new Consulta
                        {
                           Id = Convert.ToInt32(Reader["@ID"])
                        };
                        consultas.Add(verConsulta);
                    }
                }
            }
            return consultas;
        }
    }
}
