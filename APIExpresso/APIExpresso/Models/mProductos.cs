using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIExpreso.Models
{
    public class mProductos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string nombre { get; set; }
        public string detalle { get; set; }
        public string categoria { get; set; }
        public decimal precio { get; set; }
    }
}
