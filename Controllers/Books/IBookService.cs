using HobbyApp.Controllers.Shared;
using HobbyApp.DTO.Books;
using HobbyApp.Models;

namespace HobbyApp.Controllers.Books {
    public interface IBookService : IService<Book, BookDTO, CriarBookDTO> {
    }
}