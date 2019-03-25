using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrunckPad.Application.Interfaces;
using TrunckPad.Domain.Entitys;
using Xunit;

namespace TrunckPad.Test.Enderecos
{
    public class EnderecoCrudTeste : IClassFixture<DbFixture>
    {
        private ServiceProvider ServiceProvide;

        public EnderecoCrudTeste(DbFixture fixture)
        {
            ServiceProvide = fixture.ServiceProvider;
        }

        [Fact]
        public void T01Adicionar()
        {
            var e = new Endereco
            {
                Bairro = "Vila Clementino",
                Cep = "04023-000",
                Cidade = "São Paulo",
                Logradouro = "Rua Gandavo",
                Numero = "70",
                Uf = "SP"
            };

            var app = ServiceProvide.GetService<IApplicationEndereco>();
            var endereco = app.Add(e);

            Assert.False(endereco.ListaErros.Any(), (endereco.ListaErros.Any() ? endereco.ListaErros[0] : "Sucesso"));
        }

        [Fact]
        public void T02Adicionar()
        {
            var e = new Endereco
            {
                Bairro = "Vila Dom Pedro I",
                Cep = "04277-010",
                Cidade = "São Paulo",
                Logradouro = "Rua Doutor Elisio de Castro",
                Numero = "540",
                Uf = "SP"
            };

            var app = ServiceProvide.GetService<IApplicationEndereco>();
            var endereco = app.Add(e);

            Assert.False(endereco.ListaErros.Any(), (endereco.ListaErros.Any() ? endereco.ListaErros[0] : "Sucesso"));
        }

        [Fact]
        public void T03Atualizar()
        {
            var app = ServiceProvide.GetService<IApplicationEndereco>();
            var ends = app.Get().ToList();
            var end = app.GetId(ends[1].Id);
            end.Numero = "546";
            var endereco = app.Update(end, end.Id);
            Assert.False(end.ListaErros.Any(), (end.ListaErros.Any() ? end.ListaErros[0] : "Sucesso"));
        }

        [Fact]
        public void T04Get()
        {
            var app = ServiceProvide.GetService<IApplicationEndereco>();
            Assert.True(app.Get().Count() != 0);
        }

        [Fact]
        public void T05GetId()
        {
            var app = ServiceProvide.GetService<IApplicationEndereco>();
            var ends = app.Get().ToList();
            Assert.NotNull(app.GetId(ends[0].Id));
        }
    }
}
