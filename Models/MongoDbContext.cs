// MongoDbContext.cs
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

public class MongoDbContext
{
  private readonly IMongoDatabase _database;

  public MongoDbContext(IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("MongoDBConnection");
    var client = new MongoClient(connectionString);
    _database = client.GetDatabase(configuration["MongoDBName"]);
  }

  public IMongoCollection<Student> Students => _database.GetCollection<Student>("Students");
}
