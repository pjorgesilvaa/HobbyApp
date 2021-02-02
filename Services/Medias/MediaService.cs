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

        public MediaDTO Create(CreateMediaDTO mediaDTO) {
            List<Review> reviews = new List<Review>();
            if (mediaDTO.Reviews.Length > 0) {
                foreach (var r in mediaDTO.Reviews) {
                    reviews.Add(new Review(r.Subject, r.Score, r.Description));
                }
            }

            Media media = new Media(mediaDTO.TVMazeId, mediaDTO.finishedWatching, mediaDTO.Type, reviews.ToArray());

            this._repo.Create(media);

            return this._map.ToDTO(media);
        }

        public void Update(string id, CreateMediaDTO mediaIn) {
            List<Review> reviews = new List<Review>();
            if (mediaIn.Reviews.Length > 0) {
                foreach (var r in mediaIn.Reviews) {
                    reviews.Add(new Review(r.Subject, r.Score, r.Description));
                }
            }

            Media media = this._repo.GetByID(id);

            media.ChangeReviews(reviews.ToArray());

            this._repo.Update(id, media);
        }

        public void RemoveByID(string id) {
            this._repo.RemoveByID(id);
        }
    }
}