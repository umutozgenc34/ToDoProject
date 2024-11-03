using Core.Entities.ReturnModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ToDoProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ReturnModel<T> result) =>
    result.Status switch
    {
    HttpStatusCode.NoContent => NoContent(),
    HttpStatusCode.Created => Created(result.UrlAsCreated, result),
    _ => new ObjectResult(result) { StatusCode = (int)result.Status }
    };
    

    [NonAction]
    public IActionResult CreateActionResult(ReturnModel result) =>
    result.Status switch
    {
        HttpStatusCode.NoContent => new ObjectResult(null) { StatusCode = (int)result.Status },
        _ => new ObjectResult(result) { StatusCode = (int)result.Status }
    };

}
