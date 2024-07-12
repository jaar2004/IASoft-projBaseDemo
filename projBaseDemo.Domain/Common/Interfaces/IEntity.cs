// IAR jue 30MAY2024
// all domain entities will implement this interface either directly or indirectly.

namespace projBaseDemo.Domain.Common.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
