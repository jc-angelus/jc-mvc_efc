using TestApp.Domain.Models;

namespace TestApp.Application.Interfaces
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Interface: IMaritalStatusServices
    /// </summary>
    public interface IMaritalStatusServices
    {
        Task<List<MaritalStatusModel>> MaritalStatusList();
    }
}
