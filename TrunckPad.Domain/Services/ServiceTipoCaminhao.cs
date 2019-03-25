using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Repositorys;
using TrunckPad.Domain.Interfaces.Services;

namespace TrunckPad.Domain.Services
{
    public class ServiceTipoCaminhao : IServiceTipoCaminhao
    {

        private readonly IRepositoryTipoCaminhao repository;

        public ServiceTipoCaminhao(IRepositoryTipoCaminhao _repository)
        {
            repository = _repository;
        }

        #region Add
        public TipoCaminhao Add(TipoCaminhao tipoCaminhao)
        {
            tipoCaminhao = AptoAdd(tipoCaminhao);
            if (tipoCaminhao.ListaErros.Any()) return tipoCaminhao;
            return repository.Add(tipoCaminhao);
        }

        private TipoCaminhao AptoAdd(TipoCaminhao tipoCaminhao)
        {
            if (!tipoCaminhao.EstaConsistente()) return tipoCaminhao;
            tipoCaminhao = VerificaCodigo(tipoCaminhao);
            tipoCaminhao = VerificaCaminhao(tipoCaminhao);
            return tipoCaminhao;
        }

        private TipoCaminhao VerificaCodigo(TipoCaminhao tipoCaminhao)
        {
            var result = repository.GetCodigo(tipoCaminhao.Codigo);
            if (result.Count() != 0) tipoCaminhao.ListaErros.Add("Esse código já está cadastrado.");
            return tipoCaminhao;
        }

        private TipoCaminhao VerificaCaminhao(TipoCaminhao tipoCaminhao)
        {
            var result = repository.Get().Where(x=>x.Caminhao == tipoCaminhao.Caminhao);
            if (result.Count() != 0) tipoCaminhao.ListaErros.Add("Esse caminhão já está cadastrado.");
            return tipoCaminhao;
        }
        #endregion

        #region Update
        public TipoCaminhao Update(TipoCaminhao tipoCaminhao, string id)
        {
            tipoCaminhao = AptoUpdate(tipoCaminhao);
            if (tipoCaminhao.ListaErros.Any()) return tipoCaminhao;
            return repository.Update(tipoCaminhao, id);
        }

        private TipoCaminhao AptoUpdate(TipoCaminhao tipoCaminhao)
        {
            if (!tipoCaminhao.EstaConsistente()) return tipoCaminhao;
            tipoCaminhao = VerificaCodigoUpdate(tipoCaminhao);
            tipoCaminhao = VerificaCaminhaoUpdate(tipoCaminhao);
            return tipoCaminhao;
        }

        private TipoCaminhao VerificaCodigoUpdate(TipoCaminhao tipoCaminhao)
        {
            var result = repository.GetCodigo(tipoCaminhao.Codigo).FirstOrDefault();
            if (result != null && result.Id != tipoCaminhao.Id)
                tipoCaminhao.ListaErros.Add("Esse código já está em uso.");
            return tipoCaminhao;
        }

        private TipoCaminhao VerificaCaminhaoUpdate(TipoCaminhao tipoCaminhao)
        {
            var result = repository.Get()
                .Where(x => x.Caminhao == tipoCaminhao.Caminhao)
                .FirstOrDefault();
            if (result != null && result.Id != tipoCaminhao.Id)
                tipoCaminhao.ListaErros.Add("Esse caminhão já está em uso.");
            return tipoCaminhao;
        }
        #endregion

        #region Remover
        public TipoCaminhao Remove(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region consulta
        public IEnumerable<TipoCaminhao> GetCodigo(int codigo)
        {
            return repository.GetCodigo(codigo);
        }

        public TipoCaminhao GetId(string id)
        {
            return repository.GetId(id);
        }

        public IEnumerable<TipoCaminhao> Get()
        {
            return repository.Get();
        }
        #endregion
    }
}
