using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceSimProject2.src.ECommerceSim.Infrastructure.NoSql.Documents
{
    public class ProductDocumentTest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
