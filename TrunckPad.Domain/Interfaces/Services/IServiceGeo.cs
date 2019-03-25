using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrunckPad.Domain.Dto;
using TrunckPad.Domain.Entitys;

namespace TrunckPad.Domain.Interfaces.Services
{
    public interface IServiceGeo
    {
        GoogleGeoCodeResponse GetLocation(Endereco endereco);
    }
}
