using AnimesProtech.Application.Errors;
using AnimesProtech.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace AnimesProtech.Application.Features.Animes.GetById;

public class GetAnimeByIdQueryHandler(IAnimeRepository animeRepository) : IRequestHandler<GetAnimeByIdQuery, Result<GetAnimeByIdQueryResponse>>
{
    private readonly IAnimeRepository _animeRepository = animeRepository;
    public async Task<Result<GetAnimeByIdQueryResponse>> Handle(GetAnimeByIdQuery request, CancellationToken cancellationToken)
    {
        var anime = await _animeRepository.GetById(request.Id, cancellationToken);

        if (anime is null)
            return Result.Fail(new ApplicationNotFoundError("Anime não encontrado"));

        var response = new GetAnimeByIdQueryResponse(anime.Id, anime.Name, anime.Summary, anime.Director.Name);

        return Result.Ok(response);
    }
}
