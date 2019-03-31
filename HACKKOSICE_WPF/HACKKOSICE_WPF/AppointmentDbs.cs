using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HACKKOSICE_WPF
{
    class AppointmentDbs
    {
        public AppointmentDbs()
        {

        }

        public bool Appoint(string id, string reason, string date, string start, string end, string nurseId)
        {
            //date = date.Replace(",", "");
            try
            {
                var client = new MongoClient("mongodb://tomasj:tomas123@cluster0-shard-00-00-sqk5m.mongodb.net:27017,cluster0-shard-00-01-sqk5m.mongodb.net:27017,cluster0-shard-00-02-sqk5m.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true");
                var database = client.GetDatabase("hackkosice");
                var collection = database.GetCollection<BsonDocument>("appointment");
                var document = new BsonDocument
            {
                { "patientId", id },
                { "reason", reason },
                { "date", date.ToString() },
                { "start", start },
                { "end", end },
                { "nurseId", nurseId }
            };
                collection.InsertOne(document);
                return true;
            }

            catch (Exception ex)
            {

            }

            return false;
        }

        public DataTable GetAppointments(string date)
        {
            try
            {
                var client = new MongoClient("mongodb://tomasj:tomas123@cluster0-shard-00-00-sqk5m.mongodb.net:27017,cluster0-shard-00-01-sqk5m.mongodb.net:27017,cluster0-shard-00-02-sqk5m.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true");
                var database = client.GetDatabase("hackkosice");
                
                var collection = database.GetCollection<BsonDocument>("appointment");
                var filter = Builders<BsonDocument>.Filter.Eq("date", date);
                var result = collection.Find(filter).ToList();
                if (result.Count > 0)
                {
                    foreach (var doc in result)
                    {
                        
                    }
                }


            }
            catch (Exception ex)
            {

            }
            DataTable dt = new DataTable();
            return dt;
        }
    }
}
