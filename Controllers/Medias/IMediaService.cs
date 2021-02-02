using System.Collections.Generic;
using System.Threading.Tasks;
using HobbyApp.Controllers.Shared;
using HobbyApp.DTO.Medias;
using HobbyApp.Models;

namespace HobbyApp.Controllers.Medias {
    public interface IMediaService {
        List<MediaDTO> GetAll();
        MediaDTO GetByID(string id);
        MediaDTO Create(CreateMediaDTO ctDTO);
        void Update(string id, CreateMediaDTO tIn);
        void RemoveByID(string id);
    }
}