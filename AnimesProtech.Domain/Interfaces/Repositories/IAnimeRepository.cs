using AnimesProtech.Domain.Entities;
using AnimesProtech.Domain;
namespace AnimesProtech.Domain.Interfaces.Repositories;

public interface IAnimeRepository
{
    Task<IEnumerable<Anime>> GetAllFilter(PaginasteQueryOptions paginasteQueryOptions, string? name, string? keywords, int? directorId, CancellationToken cancellationToken);
    Task<Anime?> GetById(int id, CancellationToken cancellationToken);
    void Update(Anime anime);
    void Create(Anime anime);
}
