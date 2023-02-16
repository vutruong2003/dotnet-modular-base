using Shared.Core.Contracts.Fakers;
using Shared.Models.Entities;

namespace Shared.Infrastructures.Fakers;

public abstract class EntityFaker<T> : BaseFaker<T>, IEntityFaker<T> where T : BaseEntity
{
    protected override void InitFaker(params object?[]? args)
    {
        base.InitFaker(args);

        FakerInstance.RuleFor(field => field.Id, m => m.Random.Guid())
            .RuleFor(field => field.CreatedOnUtc, m => DateTime.UtcNow);
    }
}
