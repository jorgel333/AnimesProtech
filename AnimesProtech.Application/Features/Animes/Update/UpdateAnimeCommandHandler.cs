using AnimesProtech.Domain.Interfaces.Repositories;
using AnimesProtech.Domain.Interfaces;
using FluentResults;
using MediatR;
using AnimesProtech.Application.Errors;

namespace AnimesProtech.Application.Features.Animes.Update;

public class UpdateAnimeCommandHandler(IAnimeRepository animeRepository, IUnityOfWork unityOfWork) : IRequestHandler<UpdateAnimeCommand, Result>
{
    private readonly IAnimeRepository _animeRepository = animeRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    public async Task<Result> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
    {
        var anime = await _animeRepository.GetById(request.Id, cancellationToken);

        if (anime == null)
            return Result.Fail(new ApplicationNotFoundError("Anime não encontrado"));

        anime.Update(request.DataAnime.Name, request.DataAnime.Summary, request.DataAnime.DirectorId);
        _animeRepository.Update(anime);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok();
    }
}
