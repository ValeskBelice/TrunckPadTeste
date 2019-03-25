using MongoDB.Driver;
using TrunckPad.Domain.Entitys;

namespace TrunckPad.Infra.Data.Context
{
    public class ContextTruckPad
    {
        private readonly IMongoDatabase database;

        public ContextTruckPad()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("TrunckPadDb");
        }

        public IMongoCollection<Caminhoneiro> Caminhoneiros
        {
            get
            {
                return database.GetCollection<Caminhoneiro>("Caminhoneiros");
            }
        }

        public IMongoCollection<Checkin> Checkins
        {
            get
            {
                return database.GetCollection<Checkin>("Checkins");
            }
        }

        public IMongoCollection<Endereco> Enderecos
        {
            get
            {
                return database.GetCollection<Endereco>("Enderecos");
            }
        }

        public IMongoCollection<TipoCaminhao> TipoCaminhoes
        {
            get
            {
                return database.GetCollection<TipoCaminhao>("TipoCaminhoes");
            }
        }

    }
}
