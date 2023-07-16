using Microsoft.AspNetCore.Mvc;
using server.Models;
using Services.Interfaces.IAddressService;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    private readonly ILogger<AddressController> _logger;

    public AddressController(IAddressService addressService, ILogger<AddressController> logger)
    {
        _logger = logger;
        _addressService = addressService;
    }

    [HttpGet]
    public async Task<IEnumerable<AddressDTO>> GetAll()
    {
        try{
            return await _addressService.GetAll();
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<AddressDTO> GetById(int id) 
    {
        try{
            return await _addressService.GetById(id);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpPost]
    public async Task<Address> AddNew([FromBody] Address address)
    {
        try{
            return await _addressService.AddNew(address);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpPut]
    public async Task<Address> Update([FromBody] Address address)
    {
        try{
            return await _addressService.Update(address);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try{
            await _addressService.Delete(id);
            return Ok(200);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }
}
