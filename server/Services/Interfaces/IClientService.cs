using server.Models;

namespace Services.Interfaces.IClientService;

public interface IClientService {
    Task<IEnumerable<SClient>> GetAllClients();
    Task<IEnumerable<Client>> GetAll();
    Task<Client> GetById(int id);
    Task<Client> AddNew(Client client);
    Task<Client> Update(Client client);
    Task Delete(int id);
}