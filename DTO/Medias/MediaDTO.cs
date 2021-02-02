using Newtonsoft.Json;

namespace HobbyApp.DTO.Medias {
    public class MediaDTO {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("Score")]
        public double Score { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Genres")]
        public string[] Genres { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("Premiered")]
        public string Premiered { get; set; }
        [JsonProperty("Network")]
        public string Network { get; set; }
        [JsonProperty("Picture")]
        public string Picture { get; set; }
        [JsonProperty("Summary")]
        public string Summary { get; set; }
        [JsonProperty("Type")]
        public int Type { get; set; }

        public MediaDTO(string id, double score, string name, string[] genres, string status, string premiered, string network, string picture, string summary, int type) {
            this.ID = id;
            this.Score = score;
            this.Name = name;
            this.Genres = genres;
            this.Status = status;
            this.Premiered = premiered;
            this.Network = network;
            this.Picture = picture;
            this.Summary = summary;
            this.Type = type;
        }
    }
}