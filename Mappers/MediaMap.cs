using HobbyApp.DTO.Medias;
using HobbyApp.Models;
using HobbyApp.Services.Medias;

namespace HobbyApp.Mappers {
    public class MediaMap : IMediaMap {
        public MediaDTO ToDTO(Media media) {

            return new MediaDTO(
                media.Id,
                media.Score,
                media.Name,
                media.Genres,
                media.Status,
                media.Premiered,
                media.Network,
                media.Picture,
                media.Summary,
                media.Type
            );
        }
    }
}