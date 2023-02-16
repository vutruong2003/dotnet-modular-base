using Microsoft.EntityFrameworkCore;
using Shared.Core.Contracts;

namespace Shared.Infrastructures.Persistences;

public partial class ModuleDbContext : DbContext, IModuleDbContext
{
    protected virtual string Schema { get; } = "dbo";

    public ModuleDbContext() { }

    public ModuleDbContext(DbContextOptions<ModuleDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!string.IsNullOrWhiteSpace(Schema))
        {
            modelBuilder.HasDefaultSchema(Schema);
        }

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
