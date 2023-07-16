using server.Models;

namespace Repository.Interfaces.IProfileRepository;

public interface IProfileRepository {
    Task<IEnumerable<ProfileDTO>> GetAll();
    Task<ProfileDTO> GetById(int id);
    Task<Profile> AddNew(Profile profile);
    Task<Profile> Update(Profile profile);
    Task<Profile> Delete(int id);
}