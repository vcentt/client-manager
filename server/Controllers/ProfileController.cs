using Microsoft.AspNetCore.Mvc;
using server.Models;
using Services.Interfaces.IProfileService;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    private readonly ILogger<ProfileController> _logger;

    public ProfileController(IProfileService profileService, ILogger<ProfileController> logger)
    {
        _logger = logger;
        _profileService = profileService;
    }

    [HttpGet]
    public async Task<IEnumerable<ProfileDTO>> GetAll()
    {
        try{
            return await _profileService.GetAll();
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ProfileDTO> GetById(int id) 
    {
        try{
            return await _profileService.GetById(id);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpPost]
    public async Task<Profile> AddNew([FromBody] Profile profile)
    {
        try{
            return await _profileService.AddNew(profile);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpPut]
    public async Task<Profile> Update([FromBody] Profile profile)
    {
        try{
            return await _profileService.Update(profile);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try{
            await _profileService.Delete(id);
            return Ok(200);
        }catch(Exception e){
            throw new Exception(e.ToString());
        } 
    }
}
