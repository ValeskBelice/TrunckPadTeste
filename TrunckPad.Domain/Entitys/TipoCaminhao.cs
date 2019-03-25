using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrunckPad.Domain.Entitys
{
    public class TipoCaminhao: EntidadeBase
    {
        [BsonElement("Caminhao")]
        [BsonRequired]
        public string Caminhao { get; set; }
        [BsonElement("Codigo")]
        [BsonRequired]
        public int Codigo { get; set; }

        public override bool EstaConsistente()
        {
            Requirido();
            return !ListaErros.Any();
        }

        protected void Requirido()
        {
            if (string.IsNullOrEmpty(Caminhao)) ListaErros.Add("O Campo Caminhão é obrigatório!");
            if (Codigo == 0) ListaErros.Add("O Campo Códido é obrigatório");
        }


    }
}
