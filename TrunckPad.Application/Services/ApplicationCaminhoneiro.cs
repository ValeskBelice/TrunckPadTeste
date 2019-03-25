using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Application.Interfaces;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Services;

namespace TrunckPad.Application.Services
{
    public class ApplicationCaminhoneiro : IApplicationCaminhoneiro
    {
        private readonly IServiceCaminhoneiro service;

        public ApplicationCaminhoneiro(IServiceCaminhoneiro _service)
        {
            service = _service;
        }

        public Caminhoneiro Add(Caminhoneiro caminhoneiro)
        {
            return service.Add(caminhoneiro);
        }

        public Caminhoneiro Update(Caminhoneiro caminhoneiro, string id)
        {
            return service.Update(caminhoneiro, id);
        }

        public Caminhoneiro Remove(string id)
        {
            return service.Remove(id);
        }

        public IEnumerable<Caminhoneiro> Get()
        {
            return service.Get();
        }

        public IEnumerable<Caminhoneiro> GetCnh(string cnh)
        {
            return service.GetCnh(cnh);
        }

        public IEnumerable<Caminhoneiro> GetCpf(string cpf)
        {
            return service.GetCpf(cpf);
        }

        public Caminhoneiro GetId(string id)
        {
            return service.GetId(id);
        }

        public IEnumerable<Caminhoneiro> GetVeiculoProprio()
        {
            return service.GetVeiculoProprio();
        }
    }
}
