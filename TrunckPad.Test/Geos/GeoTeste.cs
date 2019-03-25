using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Services;
using Xunit;

namespace TrunckPad.Test.Geos
{
    public class GeoTeste : IClassFixture<DbFixture>
    {
        private ServiceProvider ServiceProvide;

        public GeoTeste(DbFixture fixture)
        {
            ServiceProvide = fixture.ServiceProvider;
        }

        [Fact]
        public void T01BuscaLatitudeeLongitude()
        {
            var endereco = new Endereco
            {
                Bairro = "Vila Dom Pedro I",
                Cep = "04277-010",
                Cidade = "São Paulo",
                Complemento = "",
                Numero = "546",
                Uf = "SP"
            };

            var service = ServiceProvide.GetService<IServiceGeo>();

            var result = service.GetLocation(endereco);

            Assert.NotNull(result);

        }
    }
}
