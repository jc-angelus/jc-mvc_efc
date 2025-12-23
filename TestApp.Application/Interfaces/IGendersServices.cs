using TestApp.Domain.Models;
using TestApp.Infrastructure.Entities;

namespace TestApp.Application.Interfaces
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Interface: IGenderServices
    /// </summary>
    public interface IGendersServices
    {
        Task<List<GendersModel>> GenderList();        

    }
}
