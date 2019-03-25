using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Domain.Entitys;

namespace TrunckPad.Domain.Interfaces.Repositorys
{
    public interface IRepositoryCaminhoneiro
    {
        Caminhoneiro Add(Caminhoneiro caminhoneiro);
        Caminhoneiro Update(Caminhoneiro caminhoneiro, string id);
        Caminhoneiro Remove(string id);
        Caminhoneiro GetId(string id);
        IEnumerable<Caminhoneiro> GetCpf(string cpf);
        IEnumerable<Caminhoneiro> GetCnh(string cnh);
        IEnumerable<Caminhoneiro> Get();
        IEnumerable<Caminhoneiro> GetVeiculoProprio();
    }
}
