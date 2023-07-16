using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IAddressRepository;
using server.Models;

namespace Repository.AddressRepository;

public class AddressRepository : IAddressRepository
{
    private readonly ClientContext _context;

    public AddressRepository(ClientContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<AddressDTO>> GetAll()
    {
        var query = from address in _context.Addresses
                    join client in _context.Clients on address.ClientId equals client.ClientId
                    select new AddressDTO {
                        ClientId = address.ClientId,
                        Country = address.Country,
                        StreetAddress = address.StreetAddress,
                        City = address.City,
                        Zip = address.Zip,
                        Client = new Client
                        {
                            ClientId = client.ClientId,
                            FirstName = client.FirstName,
                            LastName = client.LastName,
                            Email = client.Email
                            
                        },
                    };

        return await query.ToListAsync();
    }

    public async Task<AddressDTO> GetById(int id)
    {
        var query = from address in _context.Addresses
                    join client in _context.Clients on address.ClientId equals client.ClientId
                    where address.ClientId == id
                    select new AddressDTO {
                        ClientId = address.ClientId,
                        Country = address.Country,
                        StreetAddress = address.StreetAddress,
                        City = address.City,
                        Zip = address.Zip,
                        Client = new Client
                        {
                            ClientId = client.ClientId,
                            FirstName = client.FirstName,
                            LastName = client.LastName,
                            Email = client.Email
                            
                        },
                    };

        return await query.FirstAsync();
    }

    public async Task<Address> AddNew(Address address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<Address> Update(Address address)
    {
        _context.Addresses.Entry(address).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return address;
    }
    public async Task<Address> Delete(int id)
    {
        var query = from address in _context.Addresses
                                where address.ClientId == id
                                select address;

        var addressToDelete = await query.FirstAsync();
        _context.Addresses.Remove(addressToDelete);

        await _context.SaveChangesAsync();
        return addressToDelete;
    }


}