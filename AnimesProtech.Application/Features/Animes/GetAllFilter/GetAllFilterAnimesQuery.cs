using AnimesProtech.Application.Dtos;
using FluentResults;
using MediatR;

namespace AnimesProtech.Application.Features.Animes.GetAllFilter;
public record GetAllFilterAnimesQuery(int Page, int PageSize, bool? IsDescending, string? Name, string? Keyword, int? DirectorId) : IRequest<Result<IEnumerable<GetAllFilterAnimesQueryResponse>>>;
