using FluentResults;
using MediatR;

namespace AnimesProtech.Application.Features.Animes.GetAllFilter;
public record GetAllFilterAnimesQuery(string? Name, string? Keyword, int? DirectorId) : IRequest<Result<IEnumerable<GetAllFilterAnimesQueryResponse>>>;
