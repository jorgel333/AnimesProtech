using FluentResults;

namespace AnimesProtech.Application.Errors;

public class ValidationError(Dictionary<string, string[]> errorMessageDictionary) : Error("Um ou mais erros de validação ocorreram!")
{
    public Dictionary<string, string[]> ErrorMessageDictionary { get; } = errorMessageDictionary;
}
