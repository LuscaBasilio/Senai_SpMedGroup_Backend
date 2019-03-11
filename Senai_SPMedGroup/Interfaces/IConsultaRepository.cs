using Senai_SPMedGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup.Interfaces
{
    interface IConsultaRepository
    {
        void CadastrarConsulta(Pacientes paciente, Medicos medico, Consulta dataConsulta);

        void CancelarAgendamento(int Id);
    }
}
