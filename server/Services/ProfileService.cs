
using Repository.Interfaces.IProfileRepository;
using server.Models;
using Services.Interfaces.IProfileService;

namespace Services.ProfileService;

public class ProfileService : IProfileService {
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository){
        _profileRepository = profileRepository;
    }

    public async Task<Profile> AddNew(Profile profile)
    {
        return await _profileRepository.AddNew(profile);
    }

    public async Task<Profile> Delete(int id)
    {
        return await _profileRepository.Delete(id);
    }

    public async Task<IEnumerable<ProfileDTO>> GetAll()
    {
        return await _profileRepository.GetAll();
    }

    public async Task<ProfileDTO> GetById(int id)
    {
        return await _profileRepository.GetById(id);
    }

    public async Task<Profile> Update(Profile profile)
    {
        return await _profileRepository.Update(profile);
    }
}