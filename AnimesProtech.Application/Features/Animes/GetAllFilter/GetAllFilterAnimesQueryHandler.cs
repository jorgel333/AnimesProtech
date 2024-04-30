using AnimesProtech.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace AnimesProtech.Application.Features.Animes.GetAllFilter;

public class GetAllFilterAnimesQueryHandler(IAnimeRepository animeRepository) : IRequestHandler<GetAllFilterAnimesQuery, Result<IEnumerable<GetAllFilterAnimesQueryResponse>>>
{
    private readonly IAnimeRepository _animeRepository = animeRepository;
    public async Task<Result<IEnumerable<GetAllFilterAnimesQueryResponse>>> Handle(GetAllFilterAnimesQuery request, CancellationToken cancellationToken)
    {

        var animes = await _animeRepository.GetAllFilter(request.Name, request.Keyword, request.DirectorId, cancellationToken);

        var response = animes.Select(x => new GetAllFilterAnimesQueryResponse(x.Name, x.Summary, x.Director.Name));

        return Result.Ok(response ??= Enumerable.Empty<GetAllFilterAnimesQueryResponse>());
    }
}
