using Microsoft.AspNetCore.Mvc;
using MSC02.Services;

namespace MSC02.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TemperatureController : ControllerBase
{
    [HttpGet]
    public int GetTemperature()
    {
        return TemperatureStore.CurrentTemperature;
    }
}