using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;

namespace LuisBot.Abstractions
{
    [Serializable]
    public class MongoAbstraction
    {
        private readonly string connectionString =
          @"mongodb://assessment-luis:AM6XaKgC1AVTHm6AZ22Mlz2mpGtsQq4vz3H25OLTZu4No2cPDP5EMxyGp2AEig1AQOAPboo0fgownFCZBHvqRw==@assessment-luis.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        private MongoClientSettings settings;
        private MongoClient mongoClient;
        public IMongoDatabase database;

        public MongoAbstraction()
        {
            settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            mongoClient = new MongoClient(settings);
            database = mongoClient.GetDatabase("AssessmentLUIS");
        }
    }
}