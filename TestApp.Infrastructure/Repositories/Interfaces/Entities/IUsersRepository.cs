using TestApp.Infrastructure.Entities;
using TestApp.Infrastructure.Repositories.Interfaces.Generic;
using System.Linq.Expressions;

namespace TestApp.Infrastructure.Repositories.Interfaces.Entities
{
    public interface IUsersRepository : IGenericRepository<Users>
    {     
    }
}
