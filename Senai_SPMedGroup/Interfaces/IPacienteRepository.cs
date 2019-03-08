using Senai_SPMedGroup.Domains;
using System.Collections.Generic;

namespace Senai_SPMedGroup.Interfaces
{
    interface IPacienteRepository
    {
        List<Consulta>VisualizarConsulta();
    }
}
