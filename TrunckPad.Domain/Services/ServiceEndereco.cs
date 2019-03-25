using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Repositorys;
using TrunckPad.Domain.Interfaces.Services;

namespace TrunckPad.Domain.Services
{
    public class ServiceEndereco : IServiceEndereco
    {

        private readonly IRepositoryEndereco repository;
        private readonly IServiceGeo serviceGeo;

        public ServiceEndereco(IRepositoryEndereco _repository,
                               IServiceGeo _serviceGeo)
        {
            repository = _repository;
            serviceGeo = _serviceGeo;
        }

        #region Add
        public Endereco Add(Endereco endereco)
        {
            endereco = AptoAdd(endereco);
            if (endereco.ListaErros.Any()) return endereco;
            var geo = serviceGeo.GetLocation(endereco);
            endereco.Latitude = float.Parse(geo.results[0].geometry.location.lat);
            endereco.Longitude = float.Parse(geo.results[0].geometry.location.lng);
            return repository.Add(endereco);
        }

        public Endereco AptoAdd(Endereco endereco)
        {
            if (!endereco.EstaConsistente()) return endereco;
            return endereco;
        }
        #endregion

        #region Update
        public Endereco Update(Endereco endereco, string id)
        {
            endereco = AptoAddUpdate(endereco);
            if (endereco.ListaErros.Any()) return endereco;
            var geo = serviceGeo.GetLocation(endereco);
            endereco.Latitude = float.Parse(geo.results[0].geometry.location.lat);
            endereco.Longitude = float.Parse(geo.results[0].geometry.location.lng);
            return repository.Update(endereco, id);
        }
        public Endereco AptoAddUpdate(Endereco endereco)
        {
            if (!endereco.EstaConsistente()) return endereco;
            return endereco;
        }
        #endregion

        #region Remove
        public Endereco Remove(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region consulta
        public IEnumerable<Endereco> Get()
        {
            return repository.Get();
        }

        public Endereco GetId(string id)
        {
            return repository.GetId(id);
        }
        #endregion
    }
}
