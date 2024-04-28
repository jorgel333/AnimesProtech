using FluentResults;

namespace AnimesProtech.Application.Errors;

public class ApplicationNotFoundError(string erro) : Error(erro)
{
}
