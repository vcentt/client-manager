using server.Models;

namespace Services.Interfaces.IAddressService;

public interface IAddressService {
    Task<IEnumerable<AddressDTO>> GetAll();
    Task<AddressDTO> GetById(int id);
    Task<Address> AddNew(Address address);
    Task<Address> Update(Address address);
    Task<Address> Delete(int id);
}