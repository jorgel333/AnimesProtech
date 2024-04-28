using FluentResults;
using MediatR;

namespace AnimesProtech.Application.Features.Animes.Update;

public record UpdateAnimeCommand(int Id, UpdateAnimeData DataAnime) : IRequest<Result>;
