using TestApp.Infrastructure.Entities;
using TestApp.Infrastructure.Repositories.Generic;
using TestApp.Infrastructure.Repositories.Interfaces.Entities;
using TestApp.Infrastructure.Repositories.Interfaces.Generic;

namespace TestApp.Infrastructure.Repositories.Entities
{
    public class ClientsRepository : GenericRepository<Clients>, IClientsRepository
    {       
        public ClientsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {        
        }       
    }
}
