using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrunckPad.Domain.Entitys
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            ListaErros = new List<string>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonIgnore]
        public List<string> ListaErros { get; set; }

        public abstract bool EstaConsistente();
    }
}
