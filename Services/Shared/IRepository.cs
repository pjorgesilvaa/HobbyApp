using System.Collections.Generic;

namespace HobbyApp.Services.Shared {
    public interface IRepository<T> {
        List<T> GetAll();
        T GetByID(string id);
        void Create(T t);
        void Update(string id, T t);
        void RemoveByID(string id);
    }
}