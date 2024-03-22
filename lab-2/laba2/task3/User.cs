using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace task3
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("__v")]
        public int V { get; set; }
    }
}
