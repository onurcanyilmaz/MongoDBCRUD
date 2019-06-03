using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBActions
{
    class Program
    {
        private static readonly MongoClient _client = new MongoClient();
        private static readonly IMongoDatabase _db = _client.GetDatabase("Tender");
        private static readonly IMongoCollection<Person> _collection = _db.GetCollection<Person>("Person");
        static void Main(string[] args)
        {
            //Add();
            //Update("result");
            //Delete(1);
            //List();
            //Trying();
            Console.WriteLine("MongoDatabase kurun ve methodları çalştırın");
            Console.ReadKey();
        }

        public static void Add()
        {
            _collection.InsertOne(new Person() { age = 14, surname = "yilmaz", qwe = "qwe", id = Guid.NewGuid(), name = "deneme", asd = 22, onr = "onurcan", ert = "new column here", Content = new List<Content>() { new Content() { key = "key", value = 5 }, new Content() { key = "key2", value = 6 } } });
        }

        public static void Update(string q)
        {
            var filter = Builders<Person>.Filter.Eq("name", q);//where
            var update = Builders<Person>.Update.Set("name", "deneme22").Set("age", 16);//set
            var result = _collection.UpdateOne(filter, update);//execute
        }

        public static void Delete(int sayi)
        {
            long res = _collection.DeleteOne(o => o.asd == sayi).DeletedCount;

            //bson formatting data old usage
            BsonDocument doc = new BsonDocument();
            doc.Add("", "");
            doc.Add("number", new BsonInt32(4));
        }

        public static void List()
        {
            var q = _collection.AsQueryable().ToList();

            foreach (Person item in q)
            {
                Console.WriteLine(item.id + " " + item.name + " " + item.surname);
                Console.WriteLine("--");
            }
        }

        public static void Trying()
        {
            string coll = _collection.CollectionNamespace.CollectionName;
            var col = _collection.CollectionNamespace.FullName;
        }
    }
}