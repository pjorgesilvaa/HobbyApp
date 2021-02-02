using HobbyApp.DTO.Reviews;
using HobbyApp.Mappers.Shared;
using HobbyApp.Models;

namespace HobbyApp.Services.Reviews {
    public interface IReviewMap : IMap<Review, ReviewDTO> {
    }
}