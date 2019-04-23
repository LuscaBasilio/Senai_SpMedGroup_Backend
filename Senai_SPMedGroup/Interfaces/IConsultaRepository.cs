using Senai_SPMedGroup.Domains;
using System.Collections.Generic;

namespace Senai_SPMedGroup.Interfaces
{
    interface IConsultaRepository
    {
        void CadastrarConsulta(Consulta consulta);

        void CancelarAgendamento(int Id);

        //List<Consulta> ConsultarConsulta(int IdUser);
    }
}
