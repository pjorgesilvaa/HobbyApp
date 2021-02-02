using Newtonsoft.Json;
using HobbyApp.DTO.Reviews;

namespace HobbyApp.DTO.Medias {
    public class MediaDTO {
        [JsonProperty("ID")]
        public string Id { get; set; }
        [JsonProperty("ExternalApiId")]
        public int ExternalApiId { get; set; }
        [JsonProperty("Reviews")]
        public ReviewDTO[] Reviews { get; set; }
        [JsonProperty("Type")]
        public int Type { get; set; }
        [JsonProperty("CreatedAt")]
        public string CreatedAt { get; set; }
        [JsonProperty("LastUpdated")]
        public string LastUpdated { get; set; }

        public MediaDTO(string id, int externalApiId, int type, ReviewDTO[] reviews, string createdAt, string lastUpdated) {
            this.Id = id;
            this.ExternalApiId = externalApiId;
            this.Type = type;
            this.Reviews = reviews;
            this.CreatedAt = createdAt;
            this.LastUpdated = lastUpdated;
        }
    }
}