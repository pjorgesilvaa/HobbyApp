using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;

using HobbyApp.Models;
using HobbyApp.Infrastructure.Shared;
using HobbyApp.Services.Books;

namespace HobbyApp.Infrastructure {
    public class BookRepository : IBookRepository {
        private readonly IMongoCollection<Book> _books;

        public BookRepository(IHobbyDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public List<Book> GetAll() =>
            _books.Find(book => true).ToList();

        public Book GetByID(string id) =>
            _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public void Create(Book book) =>
            _books.InsertOne(book);

        public void Update(string id, Book bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void RemoveByID(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}