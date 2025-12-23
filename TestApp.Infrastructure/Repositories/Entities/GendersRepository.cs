using TestApp.Infrastructure.Entities;
using TestApp.Infrastructure.Repositories.Generic;
using TestApp.Infrastructure.Repositories.Interfaces.Entities;
using TestApp.Infrastructure.Repositories.Interfaces.Generic;

namespace TestApp.Infrastructure.Repositories.Entities
{
    public class GendersRepository : GenericRepository<Genders>, IGendersRepository
    {       
        public GendersRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {        
        
        }       
    }
}
