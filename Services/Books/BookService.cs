using System;
using System.Collections.Generic;

using HobbyApp.Controllers.Books;
using HobbyApp.DTO.Books;
using HobbyApp.Models;

namespace HobbyApp.Services.Books {
    public class BookService : IBookService {
        private readonly IBookRepository _repo;
        private readonly IBookMap _map;

        public BookService(IBookRepository repo, IBookMap map) {
            this._repo = repo;
            this._map = map;
        }

        public List<BookDTO> GetAll() {
            var list = this._repo.GetAll();

            return list.ConvertAll<BookDTO>(book => this._map.ToDTO(book));
        }

        public BookDTO GetByID(string id) {
            Book book = this._repo.GetByID(id);

            if (book == null) return null;

            return this._map.ToDTO(book);
        }

        public BookDTO Create(CriarBookDTO bookDTO) {
            Book book = new Book(bookDTO);

            this._repo.Create(book);

            return this._map.ToDTO(book);
        }

        public void Update(string id, CriarBookDTO bookIn) {
            Book book = new Book(id, bookIn);

            this._repo.Update(id, book);
        }

        public void RemoveByID(string id) {
            this._repo.RemoveByID(id);
        }
    }
}