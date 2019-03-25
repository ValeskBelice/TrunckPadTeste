using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Application.Interfaces;
using TrunckPad.Domain.Dto;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Services;

namespace TrunckPad.Application.Services
{
    public class ApplicationCheckin : IApplicationCheckin
    {

        private readonly IServiceCheckin service;

        public ApplicationCheckin(IServiceCheckin _service)
        {
            service = _service;
        }

        public Checkin Add(Checkin checkin)
        {
            return service.Add(checkin);
        }

        public Checkin Update(Checkin checkin, string id)
        {
            return service.Update(checkin, id);
        }

        public Checkin Remove(string id)
        {
            return service.Remove(id);
        }

        public IEnumerable<Checkin> Get()
        {
            return service.Get();
        }

        public IEnumerable<CaminhoneiroDto> GetCaminhoneiros(DateTime dataInicio, DateTime dataTermino)
        {
            return service.GetCaminhoneiros(dataInicio, dataTermino);
        }

        public IEnumerable<CaminhoneiroDto> GetCaminhoneiroSemCarga(DateTime data)
        {
            return service.GetCaminhoneiroSemCarga(data);
        }

        public Checkin GetId(string id)
        {
            return service.GetId(id);
        }
    }
}
