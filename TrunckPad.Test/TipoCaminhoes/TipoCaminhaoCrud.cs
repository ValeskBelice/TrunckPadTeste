using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrunckPad.Application.Interfaces;
using TrunckPad.Domain.Entitys;
using Xunit;

namespace TrunckPad.Test.TipoCaminhoes
{
    public class TipoCaminhaoCrud : IClassFixture<DbFixture>
    {
        private ServiceProvider ServiceProvide;

        public TipoCaminhaoCrud(DbFixture fixture)
        {
            ServiceProvide = fixture.ServiceProvider;
        }

        [Fact]
        public void T01Adicionar()
        {
            var tc = new TipoCaminhao
            {
                Codigo = 1,
                Caminhao = "Caminhão 3/4"
            };

            var app = ServiceProvide.GetService<IApplicationTipoCaminhao>();
            var tipoCaminhao = app.Add(tc);

            Assert.False(tipoCaminhao.ListaErros.Any(), (tipoCaminhao.ListaErros.Any() ? tipoCaminhao.ListaErros[0] : "Sucesso"));
        }

        [Fact]
        public void T02Atualizar()
        {
            var app = ServiceProvide.GetService<IApplicationTipoCaminhao>();
            var tcs = app.Get().ToList();
            var tc = app.GetId(tcs[0].Id);
            tc.Caminhao = "Caminhão Toco";
            tc.Codigo = 2;
            var tipoCaminhao = app.Update(tc, tc.Id);
            Assert.False(tipoCaminhao.ListaErros.Any(), (tipoCaminhao.ListaErros.Any() ? tipoCaminhao.ListaErros[0] : "Sucesso"));
        }

        [Fact]
        public void T03Get()
        {
            var app = ServiceProvide.GetService<IApplicationTipoCaminhao>();
            Assert.True(app.Get().Count() != 0);
        }

        [Fact]
        public void T04GetId()
        {
            var app = ServiceProvide.GetService<IApplicationTipoCaminhao>();
            var tcs = app.Get().ToList();
            Assert.NotNull(app.GetId(tcs[0].Id));
        }
    }
}
