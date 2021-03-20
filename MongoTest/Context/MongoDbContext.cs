using MongoDB.Driver;
using MongoTest.Entities;
using System;

namespace MongoTest.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext()
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase("DbTest");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Conection error " + ex.Message);
                Console.ReadLine();
            }
        }

        public IMongoCollection<User> Users { get => _database.GetCollection<User>("Users");}

    }
}
