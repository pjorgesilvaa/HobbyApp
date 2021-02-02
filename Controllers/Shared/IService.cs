using System.Collections.Generic;

namespace HobbyApp.Controllers.Shared {
    public interface IService<T, TDTO, CriarTDTO> {
        List<TDTO> GetAll();
        TDTO GetByID(string id);
        TDTO Create(CriarTDTO ctDTO);
        void Update(string id, CriarTDTO tIn);
        void RemoveByID(string id);
    }
}