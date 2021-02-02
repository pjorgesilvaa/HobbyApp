using System;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;

using HobbyApp.Models;
using HobbyApp.Infrastructure.Shared;
using HobbyApp.Services.Medias;
using HobbyApp.Exceptions;

namespace HobbyApp.Infrastructure {
    public class MediaRepository : IMediaRepository {
        private readonly IMongoCollection<Media> _medias;

        public MediaRepository(IHobbyDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _medias = database.GetCollection<Media>(settings.MediasCollectionName);


            /* var options = new CreateIndexOptions() { Unique = true };
            var field = new StringFieldDefinition<Media>("ExternalApiId");
            var indexDefinition = new IndexKeysDefinitionBuilder<Media>().Ascending(field);

            var indexModel = new CreateIndexModel<Media>(indexDefinition,options);
            _medias.Indexes.CreateOne(indexModel); */

        }

        public List<Media> GetAll() =>
            _medias.Find(media => true).ToList();

        public Media GetByID(string id) =>
            _medias.Find<Media>(media => media.Id == id).FirstOrDefault();

        public void Create(Media media){
            try{
                _medias.InsertOne(media);
            } catch(MongoWriteException ex){
                Console.WriteLine(ex);
                throw new BusinessRuleValidationException(media.ExternalApiId + " already seen.");
            }
            
        }
            

        public void Update(string id, Media mediaIn) =>
            _medias.ReplaceOne(media => media.Id == id, mediaIn);

        public void RemoveByID(string id) =>
            _medias.DeleteOne(media => media.Id == id);
    }
}