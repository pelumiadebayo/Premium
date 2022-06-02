using System.Net;
using IntranetApi.BusinessCore.Interfaces;
using IntranetApi.CoreObjects.DTOs;
using IntranetApi.CoreObjects.Models;
using IntranetApi.CoreObjects.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace IntranetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUser _userService;
    private readonly ICheckBookRequest _checkBookRequest;

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, IUser userService, ICheckBookRequest checkBookRequest)
    {
        _logger = logger;
        _userService = userService;
        _checkBookRequest = checkBookRequest;
    }
   
    [HttpPost("login-user")]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(GenericResponse))]
    public IActionResult CreateUser([FromBody] UserRequest request)
    => Ok(_userService.CreateUser(request));

    [HttpGet("get-check-book-request")]
    //[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(GenericResponse<IEnumerable<CheckBookUser>>))]
    public IActionResult GetCheckBookRequest(DateTime startdte, DateTime endDate)
    => Ok(_checkBookRequest.GetCheckBookRequestAsync(startdte, endDate));

    //[HttpGet("get-client-detail")]
    //public IActionResult GetClientDetails(string first, string second)
    //=> Ok(_checkBookRequest.GetCheckBookRequestAsync(first, second));


    //[HttpGet(Name = "GetWeatherForecast")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateTime.Now.AddDays(index),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}
}

