using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using product_catalog_data_model.Exceptions;

namespace product_catalog_api.Filters.ExceptionFilters;

/// <summary>
/// Filtr pro handlování dané exceptiony
/// </summary>
public class ItemNotFoundExceptionFilter : IActionFilter
{
    /// <inheritdoc />
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    /// <inheritdoc />
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is not ItemNotFoundException ex)
        {
            return;
        }

        context.Result = new NotFoundObjectResult(new ErrorResult
        {
            Type = nameof(ItemNotFoundException), StatusCode = StatusCodes.Status404NotFound, Message = ex.Message
        });

        context.ExceptionHandled = true;
    }
}
