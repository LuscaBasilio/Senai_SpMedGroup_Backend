using Senai_SPMedGroup.Domains;
using System.Collections.Generic;

namespace Senai_SPMedGroup.Interfaces
{
    interface IMedicoRepository
    {
        List<Consulta>VerConsultas();

        void CadastrarConsulta(Consulta consulta);
    }
}
