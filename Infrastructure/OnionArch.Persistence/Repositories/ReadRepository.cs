using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Repostories;
using OnionArch.Domain.Entities.Common;
using System.Linq.Expressions;

namespace OnionArch.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        public ReadRepository(DbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;

        public async Task<T> GetByIdAsync(string id)
      =>await Table.FirstOrDefaultAsync(data=>data.Id == Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
     => await Table.SingleOrDefaultAsync(predicate);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        => Table.Where(predicate);
    }
}
