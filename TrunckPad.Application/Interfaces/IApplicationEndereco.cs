using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Domain.Entitys;

namespace TrunckPad.Application.Interfaces
{
    public interface IApplicationEndereco
    {
        Endereco Add(Endereco endereco);
        Endereco Update(Endereco endereco, string id);
        Endereco Remove(string id);
        Endereco GetId(string id);
        IEnumerable<Endereco> Get();
    }
}
