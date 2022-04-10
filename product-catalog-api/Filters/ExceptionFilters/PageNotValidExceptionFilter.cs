using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using product_catalog_data_model.Exceptions;

namespace product_catalog_api.Filters.ExceptionFilters;

/// <summary>
/// Filtr pro handlování dané exceptiony
/// </summary>
public class PageNotValidExceptionFilter : IActionFilter
{
    /// <inheritdoc />
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    /// <inheritdoc />
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is not PageNotValidException ex)
        {
            return;
        }

        context.Result = new BadRequestObjectResult(new ErrorResult
        {
            Type = nameof(PageNotValidException), StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message
        });

        context.ExceptionHandled = true;
    }
}
