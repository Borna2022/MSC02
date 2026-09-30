using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace MSC02.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TemperatureController : Controller
{
    [HttpGet]
    public int GetTemperature()
    {
        return 25 ;
    }

}