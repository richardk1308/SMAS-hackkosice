using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HACKKOSICE_WPF
{
    class NurseDbs
    {
        public NurseDbs()
        {

        }

        public bool CheckNurseLogin(string id, string password)
        {
            try
            {
                var client = new MongoClient("mongodb://tomasj:tomas123@cluster0-shard-00-00-sqk5m.mongodb.net:27017,cluster0-shard-00-01-sqk5m.mongodb.net:27017,cluster0-shard-00-02-sqk5m.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true");
                var database = client.GetDatabase("hackkosice");

                var collection = database.GetCollection<BsonDocument>("nurse");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", MongoDB.Bson.ObjectId.Parse(id)) & Builders<BsonDocument>.Filter.Eq("password", password);
                var result = collection.Find(filter).ToList();
                if(result.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }
    }
}
