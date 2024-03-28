using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CallForPapers.Core.Controllers;

public class BaseController : ControllerBase
{
    protected IActionResult ConvertToActionResult<T>(Result<T> result)
    {
        if (result.IsFailed)
            throw new BadHttpRequestException(result.Errors.Last().Message);

        return Ok(result.Value);
    }
}