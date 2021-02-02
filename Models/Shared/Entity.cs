namespace HobbyApp.Domain.Shared {
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class Entity<TEntityID>
    where TEntityID : EntityID {
        public TEntityID ID { get; protected set; }
    }
}