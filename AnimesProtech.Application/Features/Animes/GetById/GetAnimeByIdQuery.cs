using FluentResults;
using MediatR;

namespace AnimesProtech.Application.Features.Animes.GetById;

public record GetAnimeByIdQuery(int Id) : IRequest<Result<GetAnimeByIdQueryResponse>>;
