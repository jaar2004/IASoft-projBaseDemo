// IAR jue 30MAY2024
// This class is the child class of BaseEntity and it implements the IAuditableEntity interface

using projBaseDemo.Domain.Common.Interfaces;

namespace projBaseDemo.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
