// IAR jue 30MAY2024
// defines a child interface of IEntity interfaces defined above.
// This interface adds additional properties to keep track of the entity’s audit trail information.

namespace projBaseDemo.Domain.Common.Interfaces
{
    public interface IAuditableEntity : IEntity
    {
        int? CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        int? UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }

    }
}
