namespace HobbyApp.Mappers.Shared {
    public interface IMap<T, TDTO> {
        TDTO ToDTO(T t);
        //T ToDomain(TDTO tDTO);
    }
}