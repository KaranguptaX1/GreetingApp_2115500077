using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using BusinessLayer.Interface;
using System.Linq.Expressions;
namespace HelloGreetingApplication.Controllers;

[ApiController]
[Route("[controller]")]
/// <summary>
/// Class providing API for HelloGreeting
/// </summary>
public class HelloGreetingController : ControllerBase
{
    private readonly ILogger<HelloGreetingController> _logger;
    private readonly IGreetingBL _greetingBl;
    public HelloGreetingController(ILogger<HelloGreetingController> logger, IGreetingBL greetingBl)
    {
        _logger = logger;
        _greetingBl = greetingBl;
    }

    /// <summary>
    /// Get Method to get the greeting message
    /// </summary>
    /// <returns>Hello, World!</returns>
    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("GET request received.");
        var responseModel = new ResponseModel<string>
        {
            Success = true,
            Message = "API EndPoint Hit",
            Data = "Hello, World!"
        };
        _logger.LogInformation("GET response: {@ResponseModel}", responseModel);
        return Ok(responseModel);
    }
    /// <summary>
    /// Adds new data.
    /// </summary>
    /// <param name="requestBody">The request body containing data.</param>
    /// <returns>Success message with created data.</returns>
    [HttpPost]
    public IActionResult Post([FromBody] RequestModel requestBody)
    {
        if (requestBody == null)
        {
            _logger.LogWarning("POST request received with invalid data.");
            return BadRequest("Invalid data provided.");
        }

        var responseModel = new ResponseModel<RequestModel>
        {
            Success = true,
            Message = "Data added successfully.",
            Data = requestBody
        };
        _logger.LogInformation("POST request received with data: {@RequestBody}", requestBody);
        return CreatedAtAction(nameof(Get), responseModel);
    }
    /// <summary>
    /// Updates the data at a particular ID.
    /// </summary>
    /// <param name="id">The ID of the data to update.</param>
    /// <param name="updatedData">The updated data.</param>
    /// <returns>Success or failure response.</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RequestModel updatedData)
    {
        if (updatedData == null)
        {
            _logger.LogWarning("PUT request received with invalid data for ID {Id}", id);
            return BadRequest("Invalid data provided.");
        }

        var response = new ResponseModel<string>
        {
            Success = true,
            Message = $"Data with ID {id} updated successfully.",
            Data = updatedData.ToString()
        };
        _logger.LogInformation("PUT request for ID {Id} with data: {@UpdatedData}", id, updatedData);
        return Ok(response);
    }
    /// <summary>
    /// Partially updates the data for a given ID.
    /// </summary>
    /// <param name="id">The ID of the data to update.</param>
    /// <param name="patchData">The partial update data.</param>
    /// <returns>Success or failure response.</returns>
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, [FromBody] RequestModel patchData)
    {
        if (patchData == null)
        {
            _logger.LogWarning("PATCH request received with invalid data for ID {Id}", id);
            return BadRequest("Invalid data provided.");
        }

        var response = new ResponseModel<string>
        {
            Success = true,
            Message = $"Data with ID {id} patched successfully.",
            Data = patchData.ToString()
        };
        _logger.LogInformation("PATCH request for ID {Id} with data: {@PatchData}", id, patchData);
        return Ok(response);
    }
    /// <summary>
    /// Deletes the data for a given ID.
    /// </summary>
    /// <param name="id">The ID of the data to delete.</param>
    /// <returns>Success or failure response.</returns>s
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("DELETE request received for ID {Id}", id);
        var response = new ResponseModel<string>
        {
            Success = true,
            Message = $"Data with ID {id} deleted successfully.",
            Data = null
        };
        return Ok(response);
    }
    /// <summary>
    /// Get a Simple Greeting
    /// </summary>
    /// <returns>Hello World</returns>
    [HttpGet("SimpleGreeting")]
    public IActionResult SimpleGreeting()
    {
        _logger.LogInformation("Executing Simple Greeting");
        string result = _greetingBl.SimpleGreeting();
        var response = new ResponseModel<string>
        {
            Success = true,
            Message = $"Got the SimpleGreeting {result}",
            Data = result
        };
        _logger.LogInformation("SimpleGreeting Executed Successfully");
        return Ok(response);
    }
    /// <summary>
    /// Get a personalized greeting message based on user input.
    /// </summary>
    /// <param name="firstName">User's first name (optional).</param>
    /// <param name="lastName">User's last name (optional).</param>
    /// <returns>Personalized greeting message.</returns>
    [HttpGet("GetGreeting")]
    public IActionResult GetGreeting([FromQuery] string? firstName, [FromQuery] string? lastName)
    {
        _logger.LogInformation("Executing Get Greeting");
        string result =_greetingBl.GetGreeting(firstName, lastName);
        var response = new ResponseModel<string>
        {
            Success = true,
            Message = $"Got the GetGreeting {result}",
            Data = result
        };
        _logger.LogInformation($"Greeting: {result}");
        return Ok(response);
    }
}