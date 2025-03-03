using Microsoft.AspNetCore.Mvc;
namespace HelloGreetingApplication.Controllers;
using ModelLayer.Model;
[ApiController]
[Route("[controller]")]
/// <summary>
/// Class providing API for HelloGreeting
/// </summary>
public class HelloGreetingController : ControllerBase
{
    /// <summary>
    /// Get Method to get the greeting message
    /// </summary>
    /// <returns>Hello, World!</returns>
    [HttpGet]
    public IActionResult Get()
    {
        ResponseModel<string> responseModel = new ResponseModel<string>();
        responseModel.Success = true;
        responseModel.Message = "API EndPoint Hit";
        responseModel.Data = "Hello, World!";
        return Ok(responseModel);
    }

    [HttpPost]
    public void Post() { }
    [HttpPut]
    public void Put() { }
    [HttpPatch]
    public void Patch() { }
    [HttpDelete]
    public void Delete() { }
}
