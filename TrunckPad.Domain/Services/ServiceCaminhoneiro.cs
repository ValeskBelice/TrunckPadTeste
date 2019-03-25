using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Repositorys;
using TrunckPad.Domain.Interfaces.Services;

namespace TrunckPad.Domain.Services
{
    public class ServiceCaminhoneiro : IServiceCaminhoneiro
    {
        private readonly IRepositoryCaminhoneiro repository;

        public ServiceCaminhoneiro(IRepositoryCaminhoneiro _repository)
        {
            repository = _repository;
        }

        #region Add
        public Caminhoneiro Add(Caminhoneiro caminhoneiro)
        {
            caminhoneiro = AptoAdd(caminhoneiro);
            if (caminhoneiro.ListaErros.Any()) return caminhoneiro;
            return repository.Add(caminhoneiro);
        }

        private Caminhoneiro AptoAdd(Caminhoneiro caminhoneiro)
        {
            if (!caminhoneiro.EstaConsistente()) return caminhoneiro;
            caminhoneiro = VerificaCpf(caminhoneiro);
            return caminhoneiro;
        }

        private Caminhoneiro VerificaCpf(Caminhoneiro caminhoneiro)
        {
            var result = repository.GetCpf(caminhoneiro.Cpf);
            if (result.Count() != 0)
                caminhoneiro.ListaErros.Add("Já existe um caminhoneiro com esse CPF!");
            return caminhoneiro;
        }
        #endregion

        #region Update
        public Caminhoneiro Update(Caminhoneiro caminhoneiro, string id)
        {
            caminhoneiro = AptoUpdate(caminhoneiro);
            if (caminhoneiro.ListaErros.Any()) return caminhoneiro;
            return repository.Update(caminhoneiro, id);
        }

        private Caminhoneiro AptoUpdate(Caminhoneiro caminhoneiro)
        {
            if (!caminhoneiro.EstaConsistente()) return caminhoneiro;
            caminhoneiro = VerificaUpdate(caminhoneiro);
            return caminhoneiro;
        }

        private Caminhoneiro VerificaUpdate(Caminhoneiro caminhoneiro)
        {
            var result = repository.GetCpf(caminhoneiro.Cpf).FirstOrDefault();
            if (result != null && result.Id != caminhoneiro.Id)
                caminhoneiro.ListaErros.Add("Existe outro caminhoneiro com esse CPF!");
            return caminhoneiro;
        }
        #endregion

        #region Remove
        public Caminhoneiro Remove(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Consulta
        public IEnumerable<Caminhoneiro> Get()
        {
            return repository.Get();
        }

        public IEnumerable<Caminhoneiro> GetCnh(string cnh)
        {
            return repository.GetCnh(cnh);
        }

        public IEnumerable<Caminhoneiro> GetCpf(string cpf)
        {
            return repository.GetCpf(cpf);
        }

        public Caminhoneiro GetId(string id)
        {
            return repository.GetId(id);
        }

        public IEnumerable<Caminhoneiro> GetVeiculoProprio()
        {
            return repository.GetVeiculoProprio();
        }
        #endregion
    }
}
