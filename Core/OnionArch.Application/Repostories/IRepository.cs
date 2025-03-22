using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities.Common;

namespace OnionArch.Application.Repostories
{
   public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
