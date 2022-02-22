using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repository.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        DbSet<Domain.Entities.Cliente> Clientes { get; set; }
        DbSet<Domain.Entities.Direccion> Direcciones { get; set; }
        DbSet<Domain.Entities.Estatu> Estatus { get; set; }
    }

    /// <summary>
    /// A factory for creating derived DbContext instances. Implement this interface to enable design-time services for context types that do not have a public default constructor. At design-time, derived DbContext instances can be created in order to enable specific design-time experiences such as Migrations. Design-time services will automatically discover implementations of this interface that are in the startup assembly or the same assembly as the derived context.
    /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.design.idesigntimedbcontextfactory-1?view=efcore-6.0
    /// </summary>
    public class AplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            OptionsBuilder.UseSqlServer("Data Source = .;Initial Catalog = OrionTek; Integrated Security = True;");

            return new ApplicationDbContext(OptionsBuilder.Options);
        }
    }
}