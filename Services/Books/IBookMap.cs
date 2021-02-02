using HobbyApp.DTO.Books;
using HobbyApp.Mappers.Shared;
using HobbyApp.Models;

namespace HobbyApp.Services.Books {
    public interface IBookMap : IMap<Book, BookDTO> {
    }
}