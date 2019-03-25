using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Repositorys;
using TrunckPad.Infra.Data.Context;

namespace TrunckPad.Infra.Data.Repository
{
    public class RepositoryEndereco : IRepositoryEndereco
    {

        private readonly ContextTruckPad Db;

        public RepositoryEndereco(ContextTruckPad _Db)
        {
            Db = _Db;
        }

        public Endereco Add(Endereco endereco)
        {
            Db.Enderecos.InsertOne(endereco);
            return endereco;
        }

        public Endereco Update(Endereco endereco, string id)
        {
            Db.Enderecos.ReplaceOne(x => x.Id == id, endereco);
            return endereco;
        }

        public Endereco Remove(string id)
        {
            var endereco = GetId(id);
            Db.Enderecos.DeleteOne(x => x.Id == id);
            return endereco;
        }

        public IEnumerable<Endereco> Get()
        {
            return Db.Enderecos.Find(_ => true).ToList();
        }

        public Endereco GetId(string id)
        {
            return Db.Enderecos.Find(x => x.Id == id).FirstOrDefault();
        }
    }
}
