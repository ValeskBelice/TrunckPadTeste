using System;
using System.Collections.Generic;
using System.Text;
using TrunckPad.Domain.Entitys;

namespace TrunckPad.Domain.Dto
{
    public class CaminhoneiroDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public string CnhTipo { get; set; }
        public DateTime CnhVencimento { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool VeiculoProprio { get; set; }
        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public bool ChegouCarregado { get; set; }
        public bool VoltarCarregado { get; set; }
        public string TipoCaminhao { get; set; }
    }
}
