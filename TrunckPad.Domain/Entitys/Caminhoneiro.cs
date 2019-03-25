using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrunckPad.Domain.Shared;

namespace TrunckPad.Domain.Entitys
{
    public class Caminhoneiro:EntidadeBase
    {
        [BsonElement("DataCadastro")]
        [BsonDateTimeOptions]
        [BsonRequired]
        public DateTime DataCadastro { get; set; }

        [BsonElement("Nome")]
        [BsonRequired]
        public string Nome { get; set; }

        [BsonElement("Cpf")]
        [BsonRequired]
        public string Cpf { get; set; }

        [BsonElement("Cnh")]
        [BsonRequired]
        public string Cnh { get; set; }

        [BsonElement("CnhTipo")]
        [BsonRequired]
        public string CnhTipo { get; set; }

        [BsonElement("CnhVencimento")]
        [BsonDateTimeOptions]
        [BsonRequired]
        public DateTime CnhVencimento { get; set; }

        [BsonElement("Email")]
        [BsonRequired]
        public string Email { get; set; }

        [BsonElement("Genero")]
        public string Genero { get; set; }

        [BsonElement("DataNascimento")]
        [BsonDateTimeOptions]
        [BsonRequired]
        public DateTime DataNascimento { get; set; }

        [BsonElement("VeiculoProprio")]
        public bool VeiculoProprio { get; set; }

        public override bool EstaConsistente()
        {
            Requirido();
            ValidaCpf();
            ValidaEmail();
            return !ListaErros.Any();
        }

        protected void Requirido()
        {
            if (string.IsNullOrEmpty(Nome)) ListaErros.Add("O Campo Nome é obrigatório!");
            if (string.IsNullOrEmpty(Cpf)) ListaErros.Add("O Campo CPF é obrigatório!");
            if (string.IsNullOrEmpty(Cnh)) ListaErros.Add("O Campo CNH é obrigatório!");
            if (string.IsNullOrEmpty(CnhTipo)) ListaErros.Add("O Campo CNH é obrigatório!");
            if (string.IsNullOrEmpty(DataNascimento.ToString())) ListaErros.Add("O Campo DataNascimento é obrigatório!");
            if (string.IsNullOrEmpty(CnhTipo)) ListaErros.Add("O Campo CNH é obrigatório!");
        }

        protected void ValidaCpf()
        {
            var cpfVo = new CpfCnpjVo();
            if (!cpfVo.Validar(Cpf)) ListaErros.Add("CPF inválido!");
        }

        protected void ValidaEmail()
        {
            var emailVo = new EmailVo();
            if (!emailVo.Validar(Email)) ListaErros.Add("E-mail inválido");
        }


    }
}
