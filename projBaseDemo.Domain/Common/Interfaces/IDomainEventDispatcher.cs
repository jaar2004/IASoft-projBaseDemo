// IAR jue 30MAY2024
// This interface declares a method that can be used to dispatch domain events throughout
// the application.

namespace projBaseDemo.Domain.Common.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
    }
}
