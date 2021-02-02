using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HobbyApp.Exceptions;

namespace HobbyApp.Models {
    public class Review {
        [BsonElement("Subject")]
        public string Subject { get; set; }
        [BsonElement("Score")]
        public double Score { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }

        public Review(string subject, double score, string description) {
            ChangeSubject(subject);
            ChangeScore(score);
            ChangeDescription(description);
        }
        public void ChangeSubject(string subject) {
            if (subject.Length < 1 || subject.Length > 20)
                throw new BusinessRuleValidationException("Review subject is invalid (Must not be empty and must have less than 20 characters).");

            this.Subject = subject;
        }

        public void ChangeScore(double score) {
            if (score < 0 || score > 10)
                throw new BusinessRuleValidationException("Review score is invalid (Must be greater than 0 and must have less than 10).");

            this.Score = score;
        }
        public void ChangeDescription(string description) {
            if (description.Length < 0 || description.Length > 500)
                throw new BusinessRuleValidationException("Review description is invalid (Must not be empty and have less than 500 characters). XXX");

            this.Description = description;
        }
    }
}