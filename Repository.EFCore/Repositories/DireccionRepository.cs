using Domain.Entities;

namespace Repository.EFCore.Repositories
{
    public class DireccionRepository : RepositoryBase<Direccion>
    {
        private readonly ApplicationDbContext Context;
        public DireccionRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}