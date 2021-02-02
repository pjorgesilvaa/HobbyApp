using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Globalization;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using HobbyApp.Controllers.Medias;
using HobbyApp.DTO.Medias;
using HobbyApp.Models;

namespace HobbyApp.Services.Medias {
    public class MediaService : IMediaService {
        private readonly IConfiguration _config;
        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());
        private readonly IMediaRepository _repo;
        private readonly IMediaMap _map;

        public MediaService(IMediaRepository repo, IMediaMap map, IConfiguration config) {
            this._repo = repo;
            this._map = map;
            this._config = config;
        }

        public List<MediaDTO> GetAll() {
            var list = this._repo.GetAll();

            return list.ConvertAll<MediaDTO>(media => this._map.ToDTO(media));
        }

        public MediaDTO GetByID(string id) {
            Media media = this._repo.GetByID(id);

            if (media == null) return null;

            return this._map.ToDTO(media);
        }

        public async Task<MediaDTO> Create(CreateMediaDTO mediaDTO) {

            Console.WriteLine(this._config.GetValue<string>("TVMaze"+ "shows/" + mediaDTO.TVMazeId));

            HttpResponseMessage response = await HttpClient.GetAsync(this._config.GetValue<string>("TVMaze") + "shows/" + mediaDTO.TVMazeId);
            var TVMazeDTO = JsonConvert.DeserializeObject<TVMazeDTO>(response.Content.ReadAsStringAsync().Result);

            System.DateTime dt= Convert.ToDateTime(TVMazeDTO.Premiered,new CultureInfo("en-US"));
            TVMazeDTO.Premiered = dt.ToString("dd-MM-yyyy");

            Media media = new Media(TVMazeDTO.Id, TVMazeDTO.Rating.Average, TVMazeDTO.Name, TVMazeDTO.Genres.ToArray(), TVMazeDTO.Status, TVMazeDTO.Premiered, TVMazeDTO.Network.Name, TVMazeDTO.Image.Medium, TVMazeDTO.Summary, mediaDTO.Type);

            this._repo.Create(media);

            return this._map.ToDTO(media);
        }

        public async void Update(string id, CreateMediaDTO mediaIn) {

            HttpResponseMessage response = await HttpClient.GetAsync(this._config.GetValue<string>("TVMaze") + "shows/" + mediaIn.TVMazeId);
            var TVMazeDTO = JsonConvert.DeserializeObject<TVMazeDTO>(response.Content.ReadAsStringAsync().Result);

            Media media = new Media(id, TVMazeDTO.Id, TVMazeDTO.Rating.Average, TVMazeDTO.Name, TVMazeDTO.Genres.ToArray(), TVMazeDTO.Status, TVMazeDTO.Premiered, TVMazeDTO.Network.Name, TVMazeDTO.Image.Medium, TVMazeDTO.Summary, mediaIn.Type);

            this._repo.Update(id, media);
        }

        public void RemoveByID(string id) {
            this._repo.RemoveByID(id);
        }
    }
}