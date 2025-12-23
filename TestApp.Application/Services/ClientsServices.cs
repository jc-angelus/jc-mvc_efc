
using AutoMapper;
using TestApp.Domain.Models;
using TestApp.Application.Interfaces;
using TestApp.Infrastructure.Entities;
using TestApp.Infrastructure.Repositories.Interfaces.Entities;

namespace TestApp.Application.Services
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: ClientsServices
    /// </summary>
    public class ClientsServices : IClientsServices
    {

        private readonly IClientsRepository _repositoryClients;
        private readonly IMapper _mapper;

        public ClientsServices(IClientsRepository repositorySeveclie, IMapper mapper)
        {
            _repositoryClients = repositorySeveclie;
            _mapper = mapper;
        }

        public async Task<int> ClientsCreate(ClientsModel clientsModel)
        {

            var clientEntity = _mapper.Map<Clients>(clientsModel);

            clientEntity = await _repositoryClients.CreateAsync(clientEntity);

            return clientEntity.Id;           
        }

        public async Task<ClientsModel> ClientsRead(int id)
        {

            var clientEntity = await _repositoryClients.ReadAsync(id);

            var clientEntityModel = _mapper.Map<ClientsModel>(clientEntity);

            return clientEntityModel;

        }


        public async Task<bool> ClientsUpdate(ClientsModel clientsModel)
        {

            var clientEntity = _mapper.Map<Clients>(clientsModel);

            return await _repositoryClients.UpdateAsync(clientEntity, clientEntity.Id);
        }

        public async Task<bool> ClientsDelete(int id)
        {
            return await _repositoryClients.DeleteAsync(id);
        }

        public async Task<List<ClientsModel>> ClientsList()
        {
            var clientsListEntities = await _repositoryClients.ListAsync();

            var clientsListModel = _mapper.Map<List<ClientsModel>>(clientsListEntities);

            return clientsListModel;

        }        
    }
}
