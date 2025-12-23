using TestApp.Domain.Models;

namespace TestApp.Application.Interfaces
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Interface: IClientsServices
    /// </summary>
    public interface IClientsServices
    {
        Task<int> ClientsCreate(ClientsModel clientsModel);
        Task<ClientsModel> ClientsRead(int id);
        Task<bool> ClientsUpdate(ClientsModel clientsModel);
        Task<bool> ClientsDelete(int id);
        Task<List<ClientsModel>> ClientsList();
    }
}
