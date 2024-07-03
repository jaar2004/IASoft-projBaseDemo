// IAR jue 30MAY2024
// This file contains the BaseEvent class that will become the base class of all domain events
// throughout the application. It only has one property DateOccurred that tells us when a
// particular event has occurred.

using MediatR;

namespace projBaseDemo.Domain.Common
{
    public abstract class BaseEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
