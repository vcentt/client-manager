using Repository.Interfaces.IClientRepository;
using server.Models;
using Services.Interfaces.IClientService;

namespace Services.ClientService;

public class ClientService : IClientService {
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository){
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<SClient>> GetAllClients()
    {
        return await _clientRepository.GetAllClients();
    }

    public async Task<Client> AddNew(Client client)
    {
        return await _clientRepository.AddNew(client);
    }

    public async Task Delete(int id)
    {
        await _clientRepository.Delete(id);
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        return await _clientRepository.GetAll();
    }

    public async Task<Client> GetById(int id)
    {
        return await _clientRepository.GetById(id);
    }

    public async Task<Client> Update(Client client)
    {
        return await _clientRepository.Update(client);
    }
}
