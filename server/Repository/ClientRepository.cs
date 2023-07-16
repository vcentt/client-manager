using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IClientRepository;
using server.Models;

namespace Repository.ClientRepository;

public class ClientRepository : IClientRepository
{
    private readonly ClientContext _context;

    public ClientRepository(ClientContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SClient>> GetAllClients()
    {
        var query = from n in _context.Clients
                    select new SClient
                    {
                        ClientId = n.ClientId,
                        FirstName = n.FirstName,
                        LastName = n.LastName,
                        Email = n.Email
                    };

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        var query = from client in _context.Clients
                    join profile in _context.Profiles on client.ClientId equals profile.ClientId
                    join address in _context.Addresses on client.ClientId equals address.ClientId
                    select new Client
                    {
                        ClientId = client.ClientId,
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        Email = client.Email,
                        Profile = new Profile
                        {
                            ClientId = client.ClientId,
                            Age = profile.Age,
                            Gender = profile.Gender,
                            MaritalStatus = profile.MaritalStatus,

                        },
                        Address = new Address
                        {
                            ClientId = client.ClientId,
                            Country = address.Country,
                            StreetAddress = address.StreetAddress,
                            City = address.City,
                            Zip = address.Zip
                        }
                    };

        return await query.ToListAsync();
    }

    public async Task<Client> GetById(int id)
    {
        var query = from client in _context.Clients
                    join profile in _context.Profiles on client.ClientId equals profile.ClientId
                    join address in _context.Addresses on client.ClientId equals address.ClientId
                    where client.ClientId == id
                    select new Client
                    {
                        ClientId = client.ClientId,
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        Email = client.Email,
                        Profile = new Profile
                        {
                            ClientId = client.ClientId,
                            Age = profile.Age,
                            Gender = profile.Gender,
                            MaritalStatus = profile.MaritalStatus,

                        },
                        Address = new Address
                        {
                            ClientId = client.ClientId,
                            Country = address.Country,
                            StreetAddress = address.StreetAddress,
                            City = address.City,
                            Zip = address.Zip
                        }
                    };

        return await query.FirstAsync();
    }
    public async Task<Client> AddNew(Client client)
    {
        _context.Add(client);
        await _context.SaveChangesAsync();

        return client;
    }

    public async Task<Client> Update(Client client)
    {
        var clientToEdit = await _context.Clients.FindAsync(client.ClientId);
        clientToEdit!.FirstName = client.FirstName;
        clientToEdit.LastName = client.LastName;
        clientToEdit.Email = client.Email;

        // Actualiza la entidad Address
        var address = await _context.Addresses.FindAsync(client.ClientId);
        address!.Country = client.Address?.Country;
        address.StreetAddress = client.Address?.StreetAddress;
        address.City = client.Address?.City;
        address.Zip = client.Address?.Zip;

        // Actualiza la entidad Profile
        var profile = await _context.Profiles.FindAsync(client.ClientId);
        profile!.Age = client.Profile?.Age;
        profile.Gender = client.Profile?.Gender;
        profile.MaritalStatus = client.Profile?.MaritalStatus;

        await _context.SaveChangesAsync();

        return client;
    }

    public async Task Delete(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        _context.Clients.Remove(client!);
        var profile = await _context.Profiles.FindAsync(id);
        _context.Profiles.Remove(profile!);
        var address = await _context.Addresses.FindAsync(id);
        _context.Addresses.Remove(address!);

        await _context.SaveChangesAsync();
    }
}