using AnimesProtech.Application.Errors;
using AnimesProtech.Domain.Interfaces;
using AnimesProtech.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace AnimesProtech.Application.Features.Animes.Disable;

public class DisableAnimeCommandHandler(IAnimeRepository animeRepository, IUnityOfWork unityOfWork) : IRequestHandler<DisableAnimeCommand, Result>
{
    private readonly IAnimeRepository _animeRepository = animeRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    public async Task<Result> Handle(DisableAnimeCommand request, CancellationToken cancellationToken)
    {
        var anime = await _animeRepository.GetById(request.Id, cancellationToken);

        if (anime is null)
            return Result.Fail(new ApplicationNotFoundError("Anime não encontrado"));

        anime.Disable();
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
