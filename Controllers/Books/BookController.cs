using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using HobbyApp.DTO.Books;

namespace HobbyApp.Controllers.Books {
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService) {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<BookDTO>> GetAll() =>
            _bookService.GetAll();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<BookDTO> Get(string id) {
            BookDTO book = _bookService.GetByID(id);

            if (book == null)
                return NotFound("»»» [" + id + "] - Livro não encontrado! «««");

            return book;
        }

        [HttpPost]
        public ActionResult<BookDTO> Create(CriarBookDTO criarBook) {
            try {
                BookDTO book = _bookService.Create(criarBook);

                return CreatedAtRoute("GetBook", new { id = book.ID.ToString() }, "»»» Livro criado com sucesso! «««");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, CriarBookDTO bookIn) {
            BookDTO book = _bookService.GetByID(id);

            if (book == null) {
                return NotFound("»»» [" + id + "] - Livro não encontrado! «««");
            }

            _bookService.Update(id, bookIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id) {
            BookDTO book = _bookService.GetByID(id);

            if (book == null) {
                return NotFound("»»» [" + id + "] - Livro não encontrado! «««");
            }

            _bookService.RemoveByID(book.ID);
            return NoContent();
        }
    }
}