using Microsoft.EntityFrameworkCore;
using Shared.Core.Contracts;
using Shared.Models.Entities;

namespace Shared.Infrastructures.Persistences;

public partial class ModuleDbContext : IModuleDbContext
{
    public DbSet<UserEntity> Users { get; set; }
}
