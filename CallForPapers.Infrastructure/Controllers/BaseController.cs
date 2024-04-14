using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallForPapers.Infrastructure.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult ConvertToActionResult<T>(Result<T> result)
    {
        if (result.IsFailed)
            throw new BadHttpRequestException(result.Errors.Last().Message);

        return Ok(result.Value);
    }
    
    protected IActionResult ConvertToActionResult(Result result) 
    {
        if (result.IsFailed)
            throw new BadHttpRequestException(result.Errors.Last().Message);

        return Ok();
    }
}