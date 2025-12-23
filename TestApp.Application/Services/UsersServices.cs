using AutoMapper;
using TestApp.Application.Interfaces;
using TestApp.Domain.Models;
using TestApp.Infrastructure.Entities;
using TestApp.Infrastructure.Repositories.Interfaces;
using TestApp.Infrastructure.Repositories.Interfaces.Entities;

namespace TestApp.Application.Services
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: LoginServices
    /// </summary>
    public class UsersServices : IUsersServices
    {
        
        private readonly IUsersRepository _repositoryUser;
        private readonly IMapper _mapper;

        public UsersServices(IUsersRepository repositoryUser, IMapper mapper)
        {            
            _repositoryUser = repositoryUser;
            _mapper = mapper;
        }

        public Users Login(string usuario, string password)
        {
            var userEntity = _repositoryUser.ReadByConditionAsync(x=> x.UserName == usuario.Trim() && x.Password == password.Trim());

            if (userEntity == null) {

                return new Users();            
            }

            var userModel = _mapper.Map<UsersModel>(userEntity);

            return userEntity;            
        }       
    }
}
