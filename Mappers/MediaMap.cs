using System;
using System.Collections.Generic;
using HobbyApp.DTO.Medias;
using HobbyApp.DTO.Reviews;
using HobbyApp.Models;
using HobbyApp.Services.Medias;

namespace HobbyApp.Mappers {
    public class MediaMap : IMediaMap {
        public MediaDTO ToDTO(Media media) {

            ReviewMap rm = new ReviewMap();

            return new MediaDTO(
                media.Id,
                media.ExternalApiId,
                media.Type,
                Array.ConvertAll(media.Reviews, delegate(Review r) {return rm.ToDTO(r);}),
                media.CreatedAt,
                media.LastUpdated
            );
        }
    }
}