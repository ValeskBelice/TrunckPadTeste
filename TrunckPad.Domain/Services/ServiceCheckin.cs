using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrunckPad.Domain.Dto;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Repositorys;
using TrunckPad.Domain.Interfaces.Services;

namespace TrunckPad.Domain.Services
{
    public class ServiceCheckin : IServiceCheckin
    {

        private readonly IRepositoryCheckin repository;

        public ServiceCheckin(IRepositoryCheckin _repository)
        {
            repository = _repository;
        }

        #region Add
        public Checkin Add(Checkin checkin)
        {
            checkin = AptoAdd(checkin);
            if (checkin.ListaErros.Any()) return checkin;
            return repository.Add(checkin);
        }

        private Checkin AptoAdd(Checkin checkin)
        {
            if (!checkin.EstaConsistente()) return checkin;
            checkin = VerificaDuplicidade(checkin);
            return checkin;
        }

        private Checkin VerificaDuplicidade(Checkin checkin)
        {
            var result = repository.Get()
                .Where(x => x.CaminhoneiroId == checkin.CaminhoneiroId && 
                x.DataEntrada == checkin.DataEntrada);
            if (result.Count() != 0) checkin.ListaErros.Add("Esse caminhoneiro já está cadastrado nessa data e horário!");
            return checkin;
        }
        #endregion

        #region Update
        public Checkin Update(Checkin checkin, string id)
        {
            checkin = AptoUpdate(checkin);
            if (checkin.ListaErros.Any()) return checkin;
            return repository.Update(checkin, id);
        }
        private Checkin AptoUpdate(Checkin checkin)
        {
            if (!checkin.EstaConsistente()) return checkin;
            return checkin;
        }
        #endregion

        #region Remove
        public Checkin Remove(string id)
        {
            return repository.Remove(id);
        }
        #endregion

        #region Consulta
        public IEnumerable<Checkin> Get()
        {
            return repository.Get();
        }

        public IEnumerable<CaminhoneiroDto> GetCaminhoneiros(DateTime dataInicio, DateTime dataTermino)
        {
            return repository.GetCaminhoneiros(dataInicio, dataTermino);
        }

        public IEnumerable<CaminhoneiroDto> GetCaminhoneiroSemCarga(DateTime data)
        {
            return repository.GetCaminhoneiroSemCarga(data);
        }

        public Checkin GetId(string id)
        {
            return repository.GetId(id);
        }
        #endregion
    }
}
