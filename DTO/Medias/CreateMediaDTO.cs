using HobbyApp.DTO.Reviews;

namespace HobbyApp.DTO.Medias {
    public class CreateMediaDTO {
        public int TVMazeId { get; set; }
        public int Type { get; set; }
        public string finishedWatching { get; set; }
        public CreateReviewDTO[] Reviews { get; set; }
    }
}