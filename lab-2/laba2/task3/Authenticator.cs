using MongoDB.Driver;

namespace task3
{
    public class Authenticator
    {
        private static Authenticator instance;
        private static readonly object lockObject = new object();
        private IMongoCollection<User> usersCollection;

        private Authenticator()
        {
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "test_db";
            string collectionName = "users";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(collectionName);
        }

        public static Authenticator GetInstance()
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Authenticator();
                }
            }
            return instance;
        }

        public bool Authenticate(string username, string password)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Name, username) & Builders<User>.Filter.Eq(u => u.Password, password);
            var user = usersCollection.Find(filter).FirstOrDefault();
            return user != null;
        }
    }
}
