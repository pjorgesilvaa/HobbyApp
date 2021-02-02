using Newtonsoft.Json;
using System.Collections.Generic;

namespace HobbyApp.DTO.Medias {

    public class Schedule    {
        [JsonProperty("time")]
        public string Time { get; set; } 

        [JsonProperty("days")]
        public List<string> Days { get; set; } 
    }

    public class Rating    {
        [JsonProperty("average")]
        public double Average { get; set; } 
    }

    public class Country    {
        [JsonProperty("name")]
        public string Name { get; set; } 

        [JsonProperty("code")]
        public string Code { get; set; } 

        [JsonProperty("timezone")]
        public string Timezone { get; set; } 
    }

    public class Network    {
        [JsonProperty("id")]
        public int Id { get; set; } 

        [JsonProperty("name")]
        public string Name { get; set; } 

        [JsonProperty("country")]
        public Country Country { get; set; } 
    }

    public class WebChannel    {
        [JsonProperty("id")]
        public int Id { get; set; } 

        [JsonProperty("name")]
        public string Name { get; set; } 

        [JsonProperty("country")]
        public Country Country { get; set; } 
    }

    public class Externals    {
        [JsonProperty("tvrage")]
        public int Tvrage { get; set; } 

        [JsonProperty("thetvdb")]
        public int Thetvdb { get; set; } 

        [JsonProperty("imdb")]
        public string Imdb { get; set; } 
    }

    public class Image    {
        [JsonProperty("medium")]
        public string Medium { get; set; } 

        [JsonProperty("original")]
        public string Original { get; set; } 
    }

    public class Self    {
        [JsonProperty("href")]
        public string Href { get; set; } 
    }

    public class Previousepisode    {
        [JsonProperty("href")]
        public string Href { get; set; } 
    }

    public class Links    {
        [JsonProperty("self")]
        public Self Self { get; set; } 

        [JsonProperty("previousepisode")]
        public Previousepisode Previousepisode { get; set; } 
    }

    public class TVMazeDTO    {
        [JsonProperty("id")]
        public int Id { get; set; } 

        [JsonProperty("url")]
        public string Url { get; set; } 

        [JsonProperty("name")]
        public string Name { get; set; } 

        [JsonProperty("type")]
        public string Type { get; set; } 

        [JsonProperty("language")]
        public string Language { get; set; } 

        [JsonProperty("genres")]
        public List<string> Genres { get; set; } 

        [JsonProperty("status")]
        public string Status { get; set; } 

        [JsonProperty("runtime")]
        public int Runtime { get; set; } 

        [JsonProperty("premiered")]
        public string Premiered { get; set; } 

        [JsonProperty("officialSite")]
        public string OfficialSite { get; set; } 

        [JsonProperty("schedule")]
        public Schedule Schedule { get; set; } 

        [JsonProperty("rating")]
        public Rating Rating { get; set; } 

        [JsonProperty("weight")]
        public int Weight { get; set; } 

        [JsonProperty("network")]
        public Network Network { get; set; } 

        [JsonProperty("webChannel")]
        public WebChannel WebChannel { get; set; } 

        [JsonProperty("externals")]
        public Externals Externals { get; set; } 

        [JsonProperty("image")]
        public Image Image { get; set; } 

        [JsonProperty("summary")]
        public string Summary { get; set; } 

        [JsonProperty("updated")]
        public int Updated { get; set; } 

        [JsonProperty("_links")]
        public Links Links { get; set; } 
    }
}