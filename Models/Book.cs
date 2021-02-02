using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using HobbyApp.Exceptions;
using HobbyApp.DTO.Books;

namespace HobbyApp.Models {
    public class Book {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }

        public Book(CriarBookDTO criar) {
            ChangeBookName(criar.Name);
            ChangePrice(criar.Price);
            ChangeCategory(criar.Category);
            ChangeAuthor(criar.Author);
        }

        public Book(string id, CriarBookDTO criar) {
            this.Id = id;
            ChangeBookName(criar.Name);
            ChangePrice(criar.Price);
            ChangeCategory(criar.Category);
            ChangeAuthor(criar.Author);
        }

        public void ChangeBookName(string name) {
            if (name == null || name.Trim().Length == 0)
                throw new BusinessRuleValidationException("XXX O Livro necessita de um Nome. XXX");

            this.BookName = name;
        }

        public void ChangePrice(decimal price) {
            if (price < 0)
                throw new BusinessRuleValidationException("XXX Preço do Livro inválido. XXX");

            this.Price = price;
        }

        public void ChangeCategory(string category) {
            if (category == null || category.Trim().Length == 0)
                throw new BusinessRuleValidationException("XXX O Livro necessita de uma Categoria. XXX");

            this.Category = category;
        }

        public void ChangeAuthor(string author) {
            if (author == null || author.Trim().Length == 0)
                throw new BusinessRuleValidationException("XXX O Livro necessita de um/(a) Autor/(a). XXX");

            this.Author = author;
        }
    }
}