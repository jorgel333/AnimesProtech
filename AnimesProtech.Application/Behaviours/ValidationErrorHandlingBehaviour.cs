﻿using AnimesProtech.Application.Errors;
using AnimesProtech.Application.Extensions;
using FluentResults;
using FluentValidation;
using MediatR;

namespace AnimesProtech.Application.Behaviours;

public class ValidationHandlingBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validator) : IPipelineBehavior<TRequest, TResponse>
    where TResponse : ResultBase, new()
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validator = validator;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var result = await Task.WhenAll(_validator.Select(v => v.ValidateAsync(context, cancellationToken)));

        var errorMessageDictionary = result.SelectMany(r => r.Errors)
            .GroupBy(p => p.PropertyName)
            .ToDictionary(eg => eg.Key, eg => eg.Select(e => e.ErrorMessage).ToArray());

        if (errorMessageDictionary.Count != 0)
            return Result.Fail(new ValidationError(errorMessageDictionary)).To<TResponse>();

        return await next();
    }
}
