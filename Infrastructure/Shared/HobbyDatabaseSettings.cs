namespace HobbyApp.Infrastructure.Shared {
    public class HobbyDatabaseSettings : IHobbyDatabaseSettings {
        public string BooksCollectionName { get; set; }
        public string MediasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IHobbyDatabaseSettings {
        string BooksCollectionName { get; set; }
        public string MediasCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}