using HobbyApp.DTO.Reviews;
using HobbyApp.Models;
using HobbyApp.Services.Reviews;

namespace HobbyApp.Mappers {
    public class ReviewMap : IReviewMap {
        public ReviewDTO ToDTO(Review review) {

            return new ReviewDTO(
                review.Subject,
                review.Score,
                review.Description
            );
        }
    }
}