using AutoMapper;
using TestApp.Application.Interfaces;
using TestApp.Domain.Models;
using TestApp.Infrastructure.Repositories.Interfaces;
using TestApp.Infrastructure.Repositories.Interfaces.Entities;

namespace TestApp.Application.Services
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: GenderServices
    /// </summary>
    public class GendersServices : IGendersServices
    {
        
        private readonly IGendersRepository _repositoryGender;
        private readonly IMapper _mapper;

        public GendersServices(IGendersRepository repositoryGender, IMapper mapper)
        {
            _repositoryGender = repositoryGender;
            _mapper = mapper;

        }        
        public async Task<List<GendersModel>> GenderList()
        {
            var genderListEntitys = await _repositoryGender.ListAsync();

            var genderListModels = _mapper.Map<List<GendersModel>>(genderListEntitys);

            return genderListModels;            
        }       
    }
}
