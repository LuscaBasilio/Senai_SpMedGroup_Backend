using MongoDB.Driver;
using Senai_SPMedGroup.Domains;
using Senai_SPMedGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup.Repositories
{
    public class LocaisRepository : ILocaisRepository
    {
        private readonly IMongoCollection<Locais> _localizacoes;

        public void Cadastrar(Locais local)
        {
            MongoClient client = new MongoClient("mongodb://Lolcais:");


        }

        public void Deletar()
        {
            
        }
    }
}
