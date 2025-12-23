using TestApp.Infrastructure.Context;
using TestApp.Infrastructure.Repositories.Interfaces.Generic;

namespace TestApp.Infrastructure.Repositories.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        public TestAppDbContext Context { get; }

        public UnitOfWork(TestAppDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
