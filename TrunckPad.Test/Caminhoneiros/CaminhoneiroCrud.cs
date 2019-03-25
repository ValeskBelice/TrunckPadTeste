using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrunckPad.Application.Interfaces;
using TrunckPad.Domain.Entitys;
using Xunit;

namespace TrunckPad.Test.Caminhoneiros
{
    public class CaminhoneiroCrud : IClassFixture<DbFixture>
    {
        private ServiceProvider ServiceProvide;

        public CaminhoneiroCrud(DbFixture fixture)
        {
            ServiceProvide = fixture.ServiceProvider;
        }

        [Fact]
        public void T01Adicionar()
        {
            var c = new Caminhoneiro
            {
                Cnh = "04712183006",
                CnhTipo = "D",
                CnhVencimento = DateTime.Parse("11/11/2025"),
                Cpf = "400.419.480-68",
                DataNascimento = DateTime.Parse("09/09/1980"),
                Email = "thiagocardosorocha@jourrapide.com",
                Genero = "Masculino",
                Nome = "Thiago Rocha",
                VeiculoProprio = true
            };

            var app = ServiceProvide.GetService<IApplicationCaminhoneiro>();
            var caminhoneiro = app.Add(c);

            Assert.False(caminhoneiro.ListaErros.Any(), (caminhoneiro.ListaErros.Any() ? caminhoneiro.ListaErros[0] : "Sucesso"));
        }

        [Fact]
        public void T02Atualizar()
        {
            var app = ServiceProvide.GetService<IApplicationCaminhoneiro>();
            var cs = app.Get().ToList();
            var c = app.GetId(cs[0].Id);
            c.Email = "thiagocardosorocha@jourrapide.com.br";
            var caminhoneiro = app.Update(c, c.Id);
            Assert.False(caminhoneiro.ListaErros.Any(), (caminhoneiro.ListaErros.Any() ? caminhoneiro.ListaErros[0] : "Sucesso"));
        }

        [Fact]
        public void T03Get()
        {
            var app = ServiceProvide.GetService<IApplicationCaminhoneiro>();
            Assert.True(app.Get().Count() != 0);
        }

        [Fact]
        public void T04GetId()
        {
            var app = ServiceProvide.GetService<IApplicationCaminhoneiro>();
            var cs = app.Get().ToList();
            Assert.NotNull(app.GetId(cs[0].Id));
        }

        [Fact]
        public void T05GetVeiculoProprio()
        {
            var app = ServiceProvide.GetService<IApplicationCaminhoneiro>();
            var cs = app.GetVeiculoProprio().ToList();
            Assert.True(app.Get().Count() != 0);
        }
    }
}
