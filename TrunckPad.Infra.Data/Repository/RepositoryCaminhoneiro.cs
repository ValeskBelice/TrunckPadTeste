using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Repositorys;
using TrunckPad.Infra.Data.Context;

namespace TrunckPad.Infra.Data.Repository
{
    public class RepositoryCaminhoneiro : IRepositoryCaminhoneiro
    {
        private readonly ContextTruckPad Db;

        public RepositoryCaminhoneiro(ContextTruckPad _Db)
        {
            Db = _Db;
        }

        public Caminhoneiro Add(Caminhoneiro caminhoneiro)
        {
            Db.Caminhoneiros.InsertOne(caminhoneiro);
            return caminhoneiro;
        }

        public Caminhoneiro Update(Caminhoneiro caminhoneiro, string id)
        {
            Db.Caminhoneiros.ReplaceOne(x => x.Id == id, caminhoneiro);
            return caminhoneiro;
        }

        public Caminhoneiro Remove(string id)
        {
            var caminhoneiro = GetId(id);
            Db.Caminhoneiros.DeleteOne(x => x.Id == id);
            return caminhoneiro;
        }

        public IEnumerable<Caminhoneiro> Get()
        {
            return Db.Caminhoneiros.Find(_ => true).ToList();
        }

        public IEnumerable<Caminhoneiro> GetCnh(string cnh)
        {
            return Db.Caminhoneiros.Find(x => x.Cnh == cnh).ToList();
        }

        public IEnumerable<Caminhoneiro> GetCpf(string cpf)
        {
            return Db.Caminhoneiros.Find(x => x.Cpf == cpf).ToList();
        }

        public Caminhoneiro GetId(string id)
        {
            return Db.Caminhoneiros.Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Caminhoneiro> GetVeiculoProprio()
        {
            return Db.Caminhoneiros.Find(x => x.VeiculoProprio).ToList()
                .OrderBy(x=>x.Nome);
        }
    }
}
