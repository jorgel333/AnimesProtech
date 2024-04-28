using FluentResults;
namespace AnimesProtech.Application.Errors;

public class ApplicationConflictError(string error) : Error(error)
{
}
