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

        public IQueryable<T> GetAll(bool tracking = true)
            => tracking? Table:Table.AsQueryable().AsNoTracking();

        public async Task<T> GetByIdAsync(string id,bool tracking=true)
      =>tracking? await Table.FirstOrDefaultAsync(data=>data.Id == Guid.Parse(id))
            : await Table.AsQueryable().AsNoTracking().FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate,bool tracking=true)
     => tracking? await Table.SingleOrDefaultAsync(predicate)
            :await Table.AsQueryable().AsNoTracking().SingleOrDefaultAsync(predicate);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate,bool tracking)
        => tracking? Table.Where(predicate) :Table.AsQueryable().AsNoTracking().Where(predicate);
    }
}
