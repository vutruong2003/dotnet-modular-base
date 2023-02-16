using Microsoft.EntityFrameworkCore;
using Shared.Models.Entities;

namespace Shared.Core.Contracts;
public interface IModuleDbContext
{
    DbSet<UserEntity> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
}
