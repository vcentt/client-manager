using server.Models;

namespace Repository.Interfaces.IAddressRepository;

public interface IAddressRepository {
    Task<IEnumerable<AddressDTO>> GetAll();
    Task<AddressDTO> GetById(int id);
    Task<Address> AddNew(Address address);
    Task<Address> Update(Address address);
    Task<Address> Delete(int id);
}