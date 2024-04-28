using AnimesProtech.Application.Errors;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.Api.ApiUntils.ResponseDapter;

public static class SendResponseService
{
    public static IActionResult SendResponse<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return new OkObjectResult(result.ValueOrDefault);

        return HandleError(result.ToResult());
    }

    public static IActionResult SendResponse(Result result)
    {
        if (result.IsSuccess)
            return new NoContentResult();

        return HandleError(result);
    }

    public static IActionResult Created<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return new ObjectResult(result.Value)
            {
                StatusCode = 201,
            };

        return HandleError(result.ToResult());
    }

    public static IActionResult HandleError(Result result)
    {
        var error = result.Errors.FirstOrDefault();

        return error switch
        {
            ValidationError validationError => new BadRequestObjectResult(new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                Status = 400,
                Title = "Erro de validação",
                Detail = validationError.Message,
                Extensions = { { nameof(validationError.ErrorMessageDictionary), validationError.ErrorMessageDictionary } }
            }),

            ApplicationNotFoundError applicationNotFoundError => new NotFoundObjectResult(new ProblemDetails
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-404-not-found",
                Status = 404,
                Title = "O item requisitado não foi encontrado",
                Detail = applicationNotFoundError.Message
            }),

            ApplicationConflictError applicationConflictError => new ConflictObjectResult(new ProblemDetails
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-409-conflict",
                Status = 409,
                Title = "A solicitação não pôde ser concluída devido a um conflito.",
                Detail = applicationConflictError.Message
            }),

            _ => new ObjectResult(new ProblemDetails
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-500-internal-server-error",
                Status = 500,
                Title = "Erro desconhecido"
            })
            {
                StatusCode = 500
            },
        };
    }
}
