using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Domain.Dto;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Repositorys;
using TrunckPad.Infra.Data.Context;
using System.Linq;
using TrunckPad.Infra.CrossCutting.Extensions;

namespace TrunckPad.Infra.Data.Repository
{
    public class RepositoryCheckin : IRepositoryCheckin
    {

        private readonly ContextTruckPad Db;

        public RepositoryCheckin(ContextTruckPad _Db)
        {
            Db = _Db;
        }

        public Checkin Add(Checkin checkin)
        {
            Db.Checkins.InsertOne(checkin);
            return checkin;
        }

        public Checkin Update(Checkin checkin, string id)
        {
            Db.Checkins.ReplaceOne(x => x.Id == id, checkin);
            return checkin;
        }

        public Checkin Remove(string id)
        {
            var checkin = GetId(id);
            Db.Checkins.DeleteOne(x => x.Id == id);
            return checkin;
        }

        public IEnumerable<Checkin> Get()
        {
            return Db.Checkins.Find(_ => true).ToList();
        }

        public Checkin GetId(string id)
        {
            return Db.Checkins.Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<CaminhoneiroDto> GetCaminhoneiroSemCarga(DateTime data)
        {
            return (from ch in Db.Checkins.AsQueryable()
                          join c in Db.Caminhoneiros.AsQueryable() on ch.CaminhoneiroId equals c.Id
                          join t in Db.TipoCaminhoes.AsQueryable() on ch.TipoCaminhaoId equals t.Id
                          join ed in Db.Enderecos.AsQueryable() on ch.EnderecoDestinoId equals ed.Id
                          join eo in Db.Enderecos.AsQueryable() on ch.EnderecoOrigemId equals eo.Id
                          select new CaminhoneiroDto
                          {
                              ChegouCarregado = ch.ChegouCarregado,
                              Cnh = c.Cnh,
                              CnhTipo = c.CnhTipo,
                              CnhVencimento = c.CnhVencimento,
                              Cpf = c.Cpf,
                              DataEntrada = ch.DataEntrada,
                              DataNascimento = c.DataNascimento,
                              DataSaida = ch.DataSaida,
                              Email = c.Email,
                              Genero = c.Genero,
                              Nome = c.Nome,
                              VeiculoProprio = c.VeiculoProprio,
                              VoltarCarregado = ch.VoltarCarregado,
                              TipoCaminhao = t.Caminhao,
                              Destino = new Endereco
                              {
                                  Bairro = ed.Bairro,
                                  Cep = ed.Bairro,
                                  Cidade = ed.Cidade,
                                  Complemento = ed.Complemento,
                                  Id = ed.Id,
                                  Latitude = ed.Latitude,
                                  Logradouro = ed.Logradouro,
                                  Longitude = ed.Longitude,
                                  Numero = ed.Numero,
                                  Uf = ed.Uf
                              },
                              Origem = new Endereco
                              {
                                  Bairro = eo.Bairro,
                                  Cep = eo.Bairro,
                                  Cidade = eo.Cidade,
                                  Complemento = eo.Complemento,
                                  Id = eo.Id,
                                  Latitude = eo.Latitude,
                                  Logradouro = eo.Logradouro,
                                  Longitude = eo.Longitude,
                                  Numero = eo.Numero,
                                  Uf = eo.Uf
                              },

                          }).ToList()
                         .Where(x => x.DataEntrada.Date == data.Date && x.VoltarCarregado == false);
        }

        public IEnumerable<CaminhoneiroDto> GetCaminhoneiros(DateTime dataInicio, DateTime dataTermino)
        {
            return (from ch in Db.Checkins.AsQueryable()
                    join c in Db.Caminhoneiros.AsQueryable() on ch.CaminhoneiroId equals c.Id
                    join t in Db.TipoCaminhoes.AsQueryable() on ch.TipoCaminhaoId equals t.Id
                    join ed in Db.Enderecos.AsQueryable() on ch.EnderecoDestinoId equals ed.Id
                    join eo in Db.Enderecos.AsQueryable() on ch.EnderecoOrigemId equals eo.Id
                    select new CaminhoneiroDto
                    {
                        ChegouCarregado = ch.ChegouCarregado,
                        Cnh = c.Cnh,
                        CnhTipo = c.CnhTipo,
                        CnhVencimento = c.CnhVencimento,
                        Cpf = c.Cpf,
                        DataEntrada = ch.DataEntrada,
                        DataNascimento = c.DataNascimento,
                        DataSaida = ch.DataSaida,
                        Email = c.Email,
                        Genero = c.Genero,
                        Nome = c.Nome,
                        VeiculoProprio = c.VeiculoProprio,
                        VoltarCarregado = ch.VoltarCarregado,
                        TipoCaminhao = t.Caminhao,
                        Destino = new Endereco
                        {
                            Bairro = ed.Bairro,
                            Cep = ed.Bairro,
                            Cidade = ed.Cidade,
                            Complemento = ed.Complemento,
                            Id = ed.Id,
                            Latitude = ed.Latitude,
                            Logradouro = ed.Logradouro,
                            Longitude = ed.Longitude,
                            Numero = ed.Numero,
                            Uf = ed.Uf
                        },
                        Origem = new Endereco
                        {
                            Bairro = eo.Bairro,
                            Cep = eo.Bairro,
                            Cidade = eo.Cidade,
                            Complemento = eo.Complemento,
                            Id = eo.Id,
                            Latitude = eo.Latitude,
                            Logradouro = eo.Logradouro,
                            Longitude = eo.Longitude,
                            Numero = eo.Numero,
                            Uf = eo.Uf
                        },

                    }).ToList()
                         .Where(x => x.DataEntrada.Date >= dataInicio.Date &&
                         x.DataEntrada.Date <= dataTermino.Date)
                         .OrderByDescending(x=>x.DataEntrada);
        }
    }
}
