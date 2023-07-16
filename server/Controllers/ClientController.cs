using Microsoft.AspNetCore.Mvc;
using server.Models;
using Services.Interfaces.IClientService;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    private readonly ILogger<ClientController> _logger;

    public ClientController(IClientService clientService, ILogger<ClientController> logger)
    {
        _logger = logger;
        _clientService = clientService;
    }

    [HttpGet("All-Clients")]
    public async Task<IEnumerable<SClient>> GetSingleAllClients()
    {
        try{
            return await _clientService.GetAllClients();
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpGet]
    public async Task<IEnumerable<Client>> GetAll()
    {
        try{
            return await _clientService.GetAll();
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<Client> GetById(int id) 
    {
        try{
            return await _clientService.GetById(id);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpPost]
    public async Task<Client> AddNew([FromBody] Client client)
    {
        try{
            return await _clientService.AddNew(client);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpPut]
    public async Task<Client> Update([FromBody] Client client)
    {
        try{
            return await _clientService.Update(client);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try{
            await _clientService.Delete(id);
            return Ok(200);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }
}
