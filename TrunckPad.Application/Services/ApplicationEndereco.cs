using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Application.Interfaces;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Services;

namespace TrunckPad.Application.Services
{
    public class ApplicationEndereco : IApplicationEndereco
    {

        private readonly IServiceEndereco service;

        public ApplicationEndereco(IServiceEndereco _service)
        {
            service = _service;
        }

        public Endereco Add(Endereco endereco)
        {
            return service.Add(endereco);
        }

        public Endereco Update(Endereco endereco, string id)
        {
            return service.Update(endereco, id);
        }

        public Endereco Remove(string id)
        {
            return service.Remove(id);
        }

        public IEnumerable<Endereco> Get()
        {
            return service.Get();
        }

        public Endereco GetId(string id)
        {
            return service.GetId(id);
        }
    }
}
