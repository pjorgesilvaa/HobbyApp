using System;
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
        [BsonElement("FinishedWaching")]
        public string FinishedWaching { get; set; }
        [BsonElement("CreatedAt")]
        public string CreatedAt { get; set; }
        [BsonElement("LastUpdated")]
        public string LastUpdated { get; set; }

        public Media(int externalApiId, string finishedWatching, int type, Review[] reviews = null) {
            this.ExternalApiId = externalApiId;
            ChangeType(type);
            DateTime temp;
            if(!DateTime.TryParse(finishedWatching, out temp))
                throw new BusinessRuleValidationException("Finished Watching date is invalid.");
            this.FinishedWaching = finishedWatching;
            this.CreatedAt = DateTime.Now.ToString("dd/MM/yyyy");
            this.LastUpdated = DateTime.Now.ToString("dd/MM/yyyy");
            ChangeReviews(reviews);
        }

        public Media(string id, int externalApiId, string finishedWatching, int type, Review[] reviews = null) {
            this.Id = id;
            this.ExternalApiId = externalApiId;
            ChangeType(type);
            DateTime temp;
            if(!DateTime.TryParse(finishedWatching, out temp))
                throw new BusinessRuleValidationException("Finished Watching date is invalid.");
            this.FinishedWaching = finishedWatching;
            this.LastUpdated = DateTime.Now.ToString("dd/MM/yyyy");
            ChangeReviews(reviews);
        }
        public void ChangeType(int type) {
            if (type < 1 || type > 3)
                throw new BusinessRuleValidationException("Media type is invalid.");

            this.Type = type;
        }
        public void ChangeReviews(Review[] reviews){
            this.Reviews = reviews ?? new Review[0];
            this.LastUpdated = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}