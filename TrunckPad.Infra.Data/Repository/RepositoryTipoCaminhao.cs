using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Repositorys;
using TrunckPad.Infra.Data.Context;

namespace TrunckPad.Infra.Data.Repository
{
    public class RepositoryTipoCaminhao : IRepositoryTipoCaminhao
    {
        private readonly ContextTruckPad Db;

        public RepositoryTipoCaminhao(ContextTruckPad _Db)
        {
            Db = _Db;
        }

        public TipoCaminhao Add(TipoCaminhao tipoCaminhao)
        {
            Db.TipoCaminhoes.InsertOne(tipoCaminhao);
            return tipoCaminhao;
        }

        public TipoCaminhao Update(TipoCaminhao tipoCaminhao, string id)
        {
            Db.TipoCaminhoes.ReplaceOne(x => x.Id == id, tipoCaminhao);
            return tipoCaminhao;
        }

        public TipoCaminhao Remove(string id)
        {
            var tipoCaminhao = GetId(id);
            Db.TipoCaminhoes.DeleteOne(x => x.Id == id);
            return tipoCaminhao;
        }

        public IEnumerable<TipoCaminhao> GetCodigo(int codigo)
        {
            return Db.TipoCaminhoes.Find(x => x.Codigo == codigo).ToList();
        }

        public TipoCaminhao GetId(string id)
        {
            return Db.TipoCaminhoes.Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<TipoCaminhao> Get()
        {
            return Db.TipoCaminhoes.Find(_ => true).ToList();
        }
    }
}
