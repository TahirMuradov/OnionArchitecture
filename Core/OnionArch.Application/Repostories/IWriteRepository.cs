using OnionArch.Domain.Entities.Common;

namespace OnionArch.Application.Repostories
{
  public  interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
    {
        Task<bool>AddAsync (T data);
        Task<bool>AddRangeAsync (List<T> datas);
        bool Update(T data);
        bool Remove(T data);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveByIdAsync(string id);
        Task<int> SaveAsync();
    }
}
    