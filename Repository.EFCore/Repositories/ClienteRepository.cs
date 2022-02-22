using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.EFCore.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>  
    {
        private readonly ApplicationDbContext Context;
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}