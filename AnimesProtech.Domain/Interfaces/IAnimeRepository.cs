using AnimesProtech.Domain.Entities;

namespace AnimesProtech.Domain.Interfaces;

public interface IAnimeRepository
{
    Task<IEnumerable<Anime>> GetAllFilter(string? keywords, int? directorId, CancellationToken cancellationToken);
    void Update(Anime anime);
    void Create(Anime anime);
}
