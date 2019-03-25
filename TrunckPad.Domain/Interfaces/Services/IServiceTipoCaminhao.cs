﻿using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Domain.Entitys;

namespace TrunckPad.Domain.Interfaces.Services
{
    public interface IServiceTipoCaminhao
    {
        TipoCaminhao Add(TipoCaminhao tipoCaminhao);
        TipoCaminhao Update(TipoCaminhao tipoCaminhao, string id);
        TipoCaminhao Remove(string id);
        TipoCaminhao GetId(string id);
        IEnumerable<TipoCaminhao> GetCodigo(int codigo);
        IEnumerable<TipoCaminhao> Get();
    }
}
