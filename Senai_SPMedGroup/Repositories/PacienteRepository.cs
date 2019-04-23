using Microsoft.EntityFrameworkCore;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;

namespace Senai_SPMedGroup.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=SENAI_SPMEDGROUP_MANHA;user id=sa; pwd=132";

        public List<Consulta> VisualizarConsulta(int Id)
        {
            List<Consulta> consultas = new List<Consulta>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT ID, ID_PACIENTE, ID_MEDICO, DATA_CONSULTA, PROGRESSO, OBSERVACAO FROM CONSULTA WHERE ID_PACIENTE = @ID";
                con.Open();
                SqlDataReader Reader;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", Id);
                    Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        Consulta verConsulta = new Consulta
                        {
                            Id = Convert.ToInt32(Reader["ID"]),
                            IdPaciente = Convert.ToInt32(Reader["ID_PACIENTE"]),
                            IdMedico = Convert.ToInt32(Reader["ID_MEDICO"]),
                            DataConsulta = Convert.ToDateTime(Reader["DATA_CONSULTA"]),
                            Observacao = Convert.ToString(Reader["OBSERVACAO"]),
                            Progresso = Convert.ToInt32(Reader["PROGRESSO"])
                        };
                        consultas.Add(verConsulta);
                    }
                }
            }
            return consultas;
        }

    }
        }
