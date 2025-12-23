using TestApp.Infrastructure.Entities;

namespace TestApp.Application.Interfaces
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Interface: ILoginServices
    /// </summary>
    public interface IUsersServices
    {
        Users Login(string usuario, string password);
    }
}
