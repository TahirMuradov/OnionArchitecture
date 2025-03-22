using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Repostories.CustomerRepositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;


namespace OnionArch.Persistence.Repositories.CustomerRepositories
{
  public  class CustomerReadRepository:ReadRepository<Customer>,ICustomerReadRepository
    {
        public CustomerReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
