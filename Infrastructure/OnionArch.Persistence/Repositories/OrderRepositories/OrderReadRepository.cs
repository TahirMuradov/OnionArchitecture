using OnionArch.Application.Repostories.OrderRepositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repositories.OrderRepositories
{
   public class OrderReadRepository :ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
