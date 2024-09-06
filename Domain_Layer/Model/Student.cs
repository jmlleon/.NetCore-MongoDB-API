
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace Domain_Layer.Model
{  

    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("age")]
        public int Age { get; set; }
        
    }
    


}
