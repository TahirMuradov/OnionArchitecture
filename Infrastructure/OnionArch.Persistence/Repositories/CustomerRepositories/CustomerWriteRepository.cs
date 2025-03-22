using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Repostories.CustomerRepositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repositories.CustomerRepositories
{
    public class CustomerWriteRepository:WriteRepository<Customer>, ICustomerWriteRepository    
    {
        public CustomerWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
