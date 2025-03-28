﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionArch.Application.Repostories;
using OnionArch.Domain.Entities.Common;

namespace OnionArch.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public WriteRepository(DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T data)
        {
          EntityEntry<T> entityEntry=await Table.AddAsync(data);
            return entityEntry.State == EntityState.Added;

        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
         await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T data)
        {
          EntityEntry<T> entityEntry =  Table.Remove(data);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveByIdAsync(string id)
        {
       T model=await  Table.FirstOrDefaultAsync(data=>data.Id == Guid.Parse(id));
      return Remove(model);

        }

        public bool RemoveRange(List<T> datas)
        {
           Table.RemoveRange(datas);
            return true;
        }

        public async Task<int> SaveAsync()
      =>await _context.SaveChangesAsync();

        public bool Update(T data)
        {
        EntityEntry<T> entityEntry = Table.Update(data);
            return entityEntry.State == EntityState.Modified;  
        }
    }
}
