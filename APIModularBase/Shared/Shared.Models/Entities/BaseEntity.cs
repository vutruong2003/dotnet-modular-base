using Shared.Models.Contracts;

namespace Shared.Models.Entities;
public abstract class BaseEntity : IEntity, IAuditable, IDeletable
{
    public BaseEntity()
    {
        this.Id = Guid.NewGuid();
        CreatedOnUtc = DateTime.UtcNow;
    }

    public Guid Id { get; set; }

    public DateTime? UpdatedOnUtc { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? DeletedTime { get; set; }
}
