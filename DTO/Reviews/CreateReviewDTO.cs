using Newtonsoft.Json;
namespace HobbyApp.DTO.Reviews {
    public class CreateReviewDTO {

        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("Score")]
        public double Score { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        public CreateReviewDTO(string subject, double score, string description) {
            this.Subject = subject;
            this.Score = score;
            this.Description = description;
        }
    }
}
