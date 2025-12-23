using TestApp.Infrastructure.Context;

namespace TestApp.Infrastructure.Repositories.Interfaces.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        TestAppDbContext Context { get; }
        void Commit();
    }
}
