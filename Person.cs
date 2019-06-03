using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBActions
{
    public class Person
    {
        [BsonId]
        public ObjectId _id { get { return ObjectId.GenerateNewId(); } private set { } }        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string qwe { get; set; }
        public string ert { get; set; }
        public string onr { get; set; }
        public int asd { get; set; }

        public List<Content> Content { get; set; }
    }
}