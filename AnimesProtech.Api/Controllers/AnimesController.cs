using AnimesProtech.Application.Features.Animes.GetAllFilter;
using AnimesProtech.Application.Features.Animes.Disable;
using AnimesProtech.Application.Features.Animes.GetById;
using AnimesProtech.Application.Features.Animes.Update;
using AnimesProtech.Api.ApiUntils.ResponseDapter;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace AnimesProtech.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    /// <summary>
    /// Busca uma lista de animes com opções de filtros.
    /// </summary>
    /// <param name="name">Nome do anime</param>
    /// <param name="keyword">Palavra chave</param>
    /// <param name="directorId">Id do diretor</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Success</response>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetAllFilter(string? name, string? keyword, int? directorId, CancellationToken cancellationToken)
    {
        var request = new GetAllFilterAnimesQuery(name, keyword, directorId);
        var response = await _sender.Send(request, cancellationToken);
        return SendResponseService.SendResponse(response);
    }

    /// <summary>
    /// Obtém um anime pelo seu Id.
    /// </summary>
    /// <param name="id">Id do anime</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var request = new GetAnimeByIdQuery(id);
        var response = await _sender.Send(request, cancellationToken);
        return SendResponseService.SendResponse(response);
    }

    /// <summary>
    /// Desativa um anime buscando pelo seu id.
    /// </summary>
    /// <param name="id">Id do anime</param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">NoContent</response>
    /// <response code="404">NotFound</response>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DisableAnime(int id, CancellationToken cancellationToken)
    {
        var request = new DisableAnimeCommand(id);
        var response = await _sender.Send(request, cancellationToken);
        return SendResponseService.SendResponse(response);
    }
    
    /// <summary>
    /// Atualiza os dados de um anime.
    /// </summary>
    /// <param name="id">Id do anime</param>
    /// <param name="cancellationToken"></param>
    /// <param name="animeData">Dados do anime  serem atualizados</param>
    /// <response code="204">NoContent</response>
    /// <response code="404">NotFound</response>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAnime(int id, UpdateAnimeData animeData, CancellationToken cancellationToken)
    {
        var request = new UpdateAnimeCommand(id, animeData);
        var response = await _sender.Send(request, cancellationToken);
        return SendResponseService.SendResponse(response);
    }
}
