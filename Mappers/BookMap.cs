using HobbyApp.DTO.Books;
using HobbyApp.Models;
using HobbyApp.Services.Books;

namespace HobbyApp.Mappers {
    public class BookMap : IBookMap {
        public BookDTO ToDTO(Book book) {
            return new BookDTO(
                book.Id,
                book.BookName,
                book.Price,
                book.Category,
                book.Author
            );
        }
    }
}