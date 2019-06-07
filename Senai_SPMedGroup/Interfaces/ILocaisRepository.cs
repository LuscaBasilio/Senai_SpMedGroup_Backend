using Senai_SPMedGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup.Interfaces
{
    interface ILocaisRepository
    {
        void Cadastrar(Locais local);

        void Deletar();
    }
}
