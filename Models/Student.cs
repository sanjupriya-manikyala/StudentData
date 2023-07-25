// Models/Student.cs
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Student
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; }

  [BsonElement("Name")]
  public string Name { get; set; }

}
