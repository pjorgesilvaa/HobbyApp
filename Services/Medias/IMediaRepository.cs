using System.Collections.Generic;
using HobbyApp.Models;
using HobbyApp.Services.Shared;

namespace HobbyApp.Services.Medias {
    public interface IMediaRepository {
        List<Media> GetAll();
        void Create(Media t);
        Media GetByID(string id);
        void Update(string id, Media t);
        void RemoveByID(string id);
    }
}