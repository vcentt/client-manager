using server.Models;

namespace Services.Interfaces.IProfileService;

public interface IProfileService {
    Task<IEnumerable<ProfileDTO>> GetAll();
    Task<ProfileDTO> GetById(int id);
    Task<Profile> AddNew(Profile profile);
    Task<Profile> Update(Profile profile);
    Task<Profile> Delete(int id);
}