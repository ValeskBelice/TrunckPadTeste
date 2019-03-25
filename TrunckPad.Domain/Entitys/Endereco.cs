using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrunckPad.Domain.Entitys
{
    public class Endereco : EntidadeBase
    {
        [BsonElement("Cep")]
        public string Cep { get; set; }
        [BsonElement("Logradouro")]
        public string Logradouro { get; set; }
        [BsonElement("Numero")]
        public string Numero { get; set; }
        [BsonElement("Complemento")]
        public string Complemento { get; set; }
        [BsonElement("Bairro")]
        public string Bairro { get; set; }
        [BsonElement("Cidade")]
        public string Cidade { get; set; }
        [BsonElement("Uf")]
        public string Uf { get; set; }
        [BsonElement("Latitude")]
        public float Latitude { get; set; }
        [BsonElement("Longitude")]
        public float Longitude { get; set; }

        public override bool EstaConsistente()
        {
            Requirido();
            return !ListaErros.Any();
        }

        protected void Requirido()
        {
            if (string.IsNullOrEmpty(Logradouro)) ListaErros.Add("O campo Logradouro é obrigatório");
            if (string.IsNullOrEmpty(Bairro)) ListaErros.Add("O campo Bairro é obrigatório");
            if (string.IsNullOrEmpty(Cep)) ListaErros.Add("O campo Cep é obrigatório");
            if (string.IsNullOrEmpty(Cidade)) ListaErros.Add("O campo Cidade é obrigatório");
            if (string.IsNullOrEmpty(Uf)) ListaErros.Add("O campo UF é obrigatório");
        }
    }
}
