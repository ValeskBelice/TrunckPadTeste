using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrunckPad.Application.Interfaces;
using TrunckPad.Domain.Entitys;
using Xunit;

namespace TrunckPad.Test.Checkins
{
    public class CheckinCrud : IClassFixture<DbFixture>
    {
        private ServiceProvider ServiceProvide;

        public CheckinCrud(DbFixture fixture)
        {
            ServiceProvide = fixture.ServiceProvider;
        }

        [Fact]
        public void T01Adicionar()
        {
            var app = ServiceProvide.GetService<IApplicationCheckin>();
            var appCaminhomeiro = ServiceProvide.GetService<IApplicationCaminhoneiro>();
            var appEndereco = ServiceProvide.GetService<IApplicationEndereco>();
            var appTipoCaminhao = ServiceProvide.GetService<IApplicationTipoCaminhao>();
            var ch = new Checkin
            {
                CaminhoneiroId = appCaminhomeiro.Get().ToList()[0].Id,
                ChegouCarregado = true,
                DataEntrada = DateTime.Parse("2019-03-23 14:00"),
                DataSaida = DateTime.Parse("2019-03-23 15:00"),
                EnderecoDestinoId = appEndereco.Get().ToList()[0].Id,
                EnderecoOrigemId = appEndereco.Get().ToList()[0].Id,
                TipoCaminhaoId = appTipoCaminhao.Get().ToList()[0].Id,
                VoltarCarregado = false
            };

            var checkin = app.Add(ch);
            Assert.False(checkin.ListaErros.Any(), (checkin.ListaErros.Any() ? checkin.ListaErros[0] : "Sucesso"));
        }

        [Fact]
        public void T02Adicionar()
        {
            var app = ServiceProvide.GetService<IApplicationCheckin>();
            var appCaminhomeiro = ServiceProvide.GetService<IApplicationCaminhoneiro>();
            var appEndereco = ServiceProvide.GetService<IApplicationEndereco>();
            var appTipoCaminhao = ServiceProvide.GetService<IApplicationTipoCaminhao>();
            var ch = new Checkin
            {
                CaminhoneiroId = appCaminhomeiro.Get().ToList()[0].Id,
                ChegouCarregado = true,
                DataEntrada = DateTime.Parse("2019-03-24 14:00"),
                DataSaida = DateTime.Parse("2019-03-24 15:00"),
                EnderecoDestinoId = appEndereco.Get().ToList()[0].Id,
                EnderecoOrigemId = appEndereco.Get().ToList()[0].Id,
                TipoCaminhaoId = appTipoCaminhao.Get().ToList()[0].Id,
                VoltarCarregado = false
            };

            var checkin = app.Add(ch);
            Assert.False(checkin.ListaErros.Any(), (checkin.ListaErros.Any() ? checkin.ListaErros[0] : "Sucesso"));
        }

        [Fact]
        public void T03Atualizar()
        {
            var app = ServiceProvide.GetService<IApplicationCheckin>();
            var chs = app.Get().ToList();
            var ch = app.GetId(chs[0].Id);
            ch.DataSaida = DateTime.Parse("2019-03-23 14:30");
            var checkin = app.Update(ch, ch.Id);
            Assert.False(checkin.ListaErros.Any(), (checkin.ListaErros.Any() ? checkin.ListaErros[0] : "Sucesso"));
        }


        [Fact]
        public void T04Get()
        {
            var app = ServiceProvide.GetService<IApplicationCheckin>();
            Assert.True(app.Get().Count() != 0);
        }

        [Fact]
        public void T05GetId()
        {
            var app = ServiceProvide.GetService<IApplicationCheckin>();
            Assert.NotNull(app.GetId(app.Get().ToList()[0].Id));
        }

        [Fact]
        public void T06GetCaminhoneiroSemCarga()
        {
            var app = ServiceProvide.GetService<IApplicationCheckin>();
            var resut = app.GetCaminhoneiroSemCarga(DateTime.Parse("2019-03-24"));
            Assert.True(resut.Count() != 0);
        }

        [Fact]
        public void T07GetCaminhoneiros()
        {
            var app = ServiceProvide.GetService<IApplicationCheckin>();
            Assert.True(app.GetCaminhoneiros(DateTime.Parse("2019-03-23 08:00"), DateTime.Parse("2019-03-25 08:00")).Count() != 0);
        }
    }
}
