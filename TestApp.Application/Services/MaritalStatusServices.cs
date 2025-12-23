using AutoMapper;
using TestApp.Application.Interfaces;
using TestApp.Domain.Models;
using TestApp.Infrastructure.Repositories.Interfaces.Entities;

namespace TestApp.Application.Services
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: GenderServices
    /// </summary>
    public class MaritalStatusServices : IMaritalStatusServices
    {
        
        private readonly IMaritalStatusRepository _repositoryMaritalStatus;
        private readonly IMapper _mapper;

        public MaritalStatusServices(IMaritalStatusRepository repositoryMaritalStatus, IMapper mapper)
        {
            _repositoryMaritalStatus = repositoryMaritalStatus;
            _mapper = mapper;

        }

        public async Task<List<MaritalStatusModel>> MaritalStatusList()
        {
            var maritalStatusListEntitys = await _repositoryMaritalStatus.ListAsync();

            var maritalStatusListModels = _mapper.Map<List<MaritalStatusModel>>(maritalStatusListEntitys);

            return maritalStatusListModels;            
        }
       
    }
}
