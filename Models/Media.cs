using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HobbyApp.Exceptions;

namespace HobbyApp.Models {
    public class Media {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("ExternalApiId")]
        public int ExternalApiId { get; set; }
        public Review[] Reviews { get; set; }
        [BsonElement("Type")]
        public int Type { get; set; }

        public Media(int externalApiId, int type, Review[] reviews = null) {
            this.ExternalApiId = externalApiId;
            ChangeType(type);
            this.Reviews = reviews ?? new Review[0];
        }

        public Media(string id, int externalApiId, int type, Review[] reviews = null) {
            this.Id = id;
            this.ExternalApiId = externalApiId;
            ChangeType(type);
            this.Reviews = reviews ?? new Review[0];
        }
        public void ChangeType(int type) {
            if (type < 1 || type > 3)
                throw new BusinessRuleValidationException("Media type is invalid.");

            this.Type = type;
        }
    }
}