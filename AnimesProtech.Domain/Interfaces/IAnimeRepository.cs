using AnimesProtech.Domain.Entities;

namespace AnimesProtech.Domain.Interfaces;

public interface IAnimeRepository
{
    IEnumerable<Anime> GetAllFilter(string? keyword, int? directorId);
    void Update(Anime anime);
    void Create(Anime anime);
}
