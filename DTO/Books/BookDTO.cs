using Newtonsoft.Json;

namespace HobbyApp.DTO.Books {
    public class BookDTO {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Price")]
        public decimal Price { get; set; }
        [JsonProperty("Category")]
        public string Category { get; set; }
        [JsonProperty("Author")]
        public string Author { get; set; }

        public BookDTO(string id, string name, decimal price, string category, string author) {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.Author = author;
        }
    }
}