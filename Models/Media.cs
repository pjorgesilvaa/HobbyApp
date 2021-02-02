using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using HobbyApp.Exceptions;
using HobbyApp.DTO.Medias;

namespace HobbyApp.Models {
    public class Media {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("TVMazeId")]
        public int TVMazeId { get; set; }
        [BsonElement("Score")]
        public double Score { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Genres")]
        public string[] Genres { get; set; }
        [BsonElement("Status")]
        public string Status { get; set; }
        [BsonElement("Premiered")]
        public string Premiered { get; set; }
        [BsonElement("Network")]
        public string Network { get; set; }
        [BsonElement("Picture")]
        public string Picture { get; set; }
        [BsonElement("Summary")]
        public string Summary { get; set; }
        [BsonElement("Type")]
        public int Type { get; set; }

        public Media(int tvMazeId, double score, string name, string[] genres, string status, string premiered, string network, string picture, string summary, int type) {
            this.TVMazeId = tvMazeId;
            this.Score = score;
            this.Name = name;
            this.Genres = genres;
            this.Status = status;
            this.Premiered = premiered;
            this.Network = network;
            this.Picture = picture;
            this.Summary = summary;
            ChangeType(type);
        }

        public Media(string id, int tvMazeId, double score, string name, string[] genres, string status, string premiered, string network, string picture, string summary, int type) {
            this.Id = id;
            this.TVMazeId = tvMazeId;
            this.Score = score;
            this.Name = name;
            this.Genres = genres;
            this.Status = status;
            this.Premiered = premiered;
            this.Network = network;
            this.Picture = picture;
            this.Summary = summary;
            ChangeType(type);
        }
        public void ChangeType(int type) {
            if (type < 1)
                throw new BusinessRuleValidationException("XXX Show type is invalid. XXX");

            this.Type = type;
        }
    }
}