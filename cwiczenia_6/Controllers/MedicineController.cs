using cwiczenia_6.Models.DTO;
using cwiczenia_6.Services;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia_6.Controllers;

[Route("api")]
[ApiController]
public class MedicineController : ControllerBase
{
    private readonly IMedicineDbService _dbService;

    public MedicineController(IMedicineDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    [Route("doctor")]
    public async Task<IActionResult> GetDoctors()
    {
        return Ok(await _dbService.GetDoctors());
    }

    [HttpPost]
    [Route("doctor")]
    public async Task<IActionResult> AddDoctor(DoctorInfo doctorInfo)
    {
        await _dbService.AddDoctor(doctorInfo);
        return Ok();
    }

    [HttpPatch]
    [Route("doctor/{id}")]
    public async Task<IActionResult> EditDoctor(int id, DoctorInfoEdit doctorInfo)
    {
        await _dbService.EditDoctor(id, doctorInfo);
        
        return Ok();
    }

    [HttpDelete]
    [Route("doctor/{id}")]
    public async Task<IActionResult> GetDoctors(int id)
    {
        await _dbService.DeleteDoctor(id);
        return Ok();
    }
    
    [HttpGet]
    [Route("prescription/{id}")]
    public async Task<IActionResult> GetPrescription(int id)
    {
        return Ok(await _dbService.GetPrescription(id));
    }
}