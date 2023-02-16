using Shared.Models.Entities;

namespace Shared.Core.Contracts.Fakers;

public interface IEntityFaker<TEntity> : IBaseFaker<TEntity> where TEntity : BaseEntity
{
}