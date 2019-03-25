using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Domain.Dto;
using TrunckPad.Domain.Entitys;

namespace TrunckPad.Application.Interfaces
{
    public interface IApplicationCheckin
    {
        Checkin Add(Checkin checkin);
        Checkin Update(Checkin checkin, string id);
        Checkin Remove(string id);
        Checkin GetId(string id);
        IEnumerable<Checkin> Get();
        IEnumerable<CaminhoneiroDto> GetCaminhoneiroSemCarga(DateTime data);
        IEnumerable<CaminhoneiroDto> GetCaminhoneiros(DateTime dataInicio, DateTime dataTermino);
    }
}
