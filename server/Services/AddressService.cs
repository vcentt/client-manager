
using Repository.Interfaces.IAddressRepository;
using server.Models;
using Services.Interfaces.IAddressService;

namespace Services.AddressService;

public class AddressService : IAddressService {
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository){
        _addressRepository = addressRepository;
    }

    public async Task<Address> AddNew(Address address)
    {
        return await _addressRepository.AddNew(address);
    }

    public async Task<Address> Delete(int id)
    {
        return await _addressRepository.Delete(id);
    }

    public async Task<IEnumerable<AddressDTO>> GetAll()
    {
        return await _addressRepository.GetAll();
    }

    public async Task<AddressDTO> GetById(int id)
    {
        return await _addressRepository.GetById(id);
    }

    public async Task<Address> Update(Address address)
    {
        return await _addressRepository.Update(address);
    }
}