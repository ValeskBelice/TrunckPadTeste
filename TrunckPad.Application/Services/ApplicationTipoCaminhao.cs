using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Application.Interfaces;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Services;

namespace TrunckPad.Application.Services
{
    public class ApplicationTipoCaminhao : IApplicationTipoCaminhao
    {

        private readonly IServiceTipoCaminhao service;

        public ApplicationTipoCaminhao(IServiceTipoCaminhao _service)
        {
            service = _service;
        }

        public TipoCaminhao Add(TipoCaminhao tipoCaminhao)
        {
            return service.Add(tipoCaminhao);
        }

        public TipoCaminhao Update(TipoCaminhao tipoCaminhao, string id)
        {
            return service.Update(tipoCaminhao, id);
        }

        public TipoCaminhao Remove(string id)
        {
            return service.Remove(id);
        }

        public IEnumerable<TipoCaminhao> Get()
        {
            return service.Get();
        }

        public IEnumerable<TipoCaminhao> GetCodigo(int codigo)
        {
            return service.GetCodigo(codigo);
        }

        public TipoCaminhao GetId(string id)
        {
            return service.GetId(id);
        }
    }
}
