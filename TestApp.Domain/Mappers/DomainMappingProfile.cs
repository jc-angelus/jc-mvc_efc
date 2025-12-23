using TestApp.Infrastructure.Entities;
using AutoMapper;
using TestApp.Domain.Models;

namespace TestApp.Domain.Mappers
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: DomainMappingProfile
    /// </summary
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {   
            CreateMap<UsersModel, Users>().ReverseMap();
            CreateMap<GendersModel, Genders>().ReverseMap();
            CreateMap<MaritalStatusModel, MaritalStatus>().ReverseMap();
            CreateMap<ClientsModel, Clients>().ReverseMap();
        }
    }
}

