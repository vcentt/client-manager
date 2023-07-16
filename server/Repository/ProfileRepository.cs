using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IProfileRepository;
using server.Models;

namespace Repository.ProfileRepository;

public class ProfileRepository : IProfileRepository
{
    private readonly ClientContext _context;

    public ProfileRepository(ClientContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ProfileDTO>> GetAll()
    {
        var query = from profile in _context.Profiles
                    join client in _context.Clients on profile.ClientId equals client.ClientId
                    select new ProfileDTO {
                        Client = new Client
                        {
                            FirstName = client.FirstName,
                            LastName = client.LastName,
                            Email = client.Email
                            
                        },
                        Age = profile.Age,
                        Gender = profile.Gender,
                        MaritalStatus = profile.MaritalStatus
                    };

        return await query.ToListAsync();
    }

    public async Task<ProfileDTO> GetById(int id)
    {
        var query = from profile in _context.Profiles
                    join client in _context.Clients on profile.ClientId equals client.ClientId
                    where profile.ClientId == id
                    select new ProfileDTO {
                        Client = new Client
                        {
                            FirstName = client.FirstName,
                            LastName = client.LastName,
                            Email = client.Email
                            
                        },
                        Age = profile.Age,
                        Gender = profile.Gender,
                        MaritalStatus = profile.MaritalStatus
                    };

        return await query.FirstAsync();
    }

    public async Task<Profile> AddNew(Profile profile)
    {
        _context.Profiles.Add(profile);
        await _context.SaveChangesAsync();
        return profile;
    }

    public async Task<Profile> Delete(int id)
    {
        var query = from profile in _context.Profiles
                                where profile.ClientId == id
                                select profile;

        var profileToDelete = await query.FirstAsync();
        _context.Profiles.Remove(profileToDelete);

        await _context.SaveChangesAsync();
        return profileToDelete;
    }


    public async Task<Profile> Update(Profile profile)
    {
        _context.Profiles.Entry(profile).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return profile;
    }
}