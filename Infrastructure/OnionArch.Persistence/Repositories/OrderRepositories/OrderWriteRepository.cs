using OnionArch.Application.Repostories.OrderRepositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repositories.OrderRepositories
{
   public class OrderWriteRepository :WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
