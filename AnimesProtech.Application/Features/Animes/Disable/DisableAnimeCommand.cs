using FluentResults;
using MediatR;

namespace AnimesProtech.Application.Features.Animes.Disable;

public record DisableAnimeCommand(int Id): IRequest<Result>;
