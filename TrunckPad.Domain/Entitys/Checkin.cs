using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrunckPad.Domain.Entitys
{
    public class Checkin : EntidadeBase
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string CaminhoneiroId { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string TipoCaminhaoId { get; set; }
        
        [BsonElement("DataEntrada")]
        [BsonDateTimeOptions]
        [BsonRequired]
        public DateTime DataEntrada { get; set; }

        [BsonElement("DataSaida")]
        [BsonDateTimeOptions]
        [BsonRequired]
        public DateTime DataSaida { get; set; }

        [BsonElement("ChegouCarregado")]
        public bool ChegouCarregado { get; set; }

        [BsonElement("VoltarCarregado")]
        public bool VoltarCarregado { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string EnderecoOrigemId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string EnderecoDestinoId { get; set; }
        
        public override bool EstaConsistente()
        {
            Requirido();
            return !ListaErros.Any();
        }

        protected void Requirido()
        {
            if (string.IsNullOrEmpty(CaminhoneiroId)) ListaErros.Add("O Campo CaminhoneiroId é obrigatório!");
            if (string.IsNullOrEmpty(TipoCaminhaoId)) ListaErros.Add("O Campo TipoCaminhaoId é obrigatório!");
            if (string.IsNullOrEmpty(DataEntrada.ToString())) ListaErros.Add("O Campo DataEntrada é obrigatório!");
            if (string.IsNullOrEmpty(DataSaida.ToString())) ListaErros.Add("O Campo DataSaida é obrigatório!");
            if (string.IsNullOrEmpty(EnderecoOrigemId)) ListaErros.Add("O Campo EnderecoOrigemId é obrigatório!");
            if (string.IsNullOrEmpty(EnderecoDestinoId)) ListaErros.Add("O Campo EnderecoDestinoId é obrigatório!");
        }

    }
}
