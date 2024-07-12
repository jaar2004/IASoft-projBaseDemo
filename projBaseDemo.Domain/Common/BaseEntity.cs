// IAR jue 30MAY2024
// This file contains BaseEntity class that implements the IEntity interface. The BaseEntity class
// also contains a collection of domain events and also some helper methods to add, remove, and
// clean domain events from this collection. The idea of storing events in the collection and then
// dispatching them once the entity is saved is first introduced by Jimmy Bogard in his blog post
// A better domain events pattern and it is used in many clean architectures implementations
// since then.

using projBaseDemo.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace projBaseDemo.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        private readonly List<BaseEvent> _domainEvents = new();

        public int Id { get; set; }

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();

    }
}
